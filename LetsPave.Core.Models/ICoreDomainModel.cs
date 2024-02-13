using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LetsPave.Core.Models
{
    public interface ICoreDomainModel<T> : ICoreModel<T>
    {
        DateTime Created { get; }
        DateTime? Updated { get; }
        string? UpdatedBy { get; }
        string? CreatedBy { get; }
        bool IsDeleted { get; }
        void SetDelete();
        void SetUpdate(string userName, DateTime? updatedDateTime = null);
        void SetCreate(string userName, DateTime? createdDateTime = null);
        ModelValidator Validate();
    }


   
    public class CoreDomainModel<T> : CoreModel<T>, ICoreDomainModel<T>
    {

        [JsonProperty]
        public virtual DateTime Created { get; protected set; }

        [JsonProperty]
        public virtual DateTime? Updated { get; protected set; }

        [JsonProperty, StringLength(100)]
        public virtual string? UpdatedBy { get; protected set; }

        [JsonProperty, StringLength(100)]
        public virtual string? CreatedBy { get; protected set; }

        [JsonProperty]
        public virtual bool IsDeleted { get; protected set; }

        public CoreDomainModel() : base()
        {
            Created = DateTime.UtcNow;
            IsDeleted = false;
            UpdatedBy = "Default User";
            CreatedBy = "Default User";
        }

        public void SetDelete()
        {
            IsDeleted = true;
        }
        public void SetUpdate(string userName, DateTime? updatedDateTime = null)
        {
            Updated = updatedDateTime == null ? DateTime.UtcNow : (DateTime)updatedDateTime;
            UpdatedBy = userName;
        }
        public void SetCreate(string userName, DateTime? createdDateTime = null)
        {
            Created = createdDateTime == null ? DateTime.UtcNow : (DateTime)createdDateTime;
            CreatedBy = userName;
        }

        public virtual ModelValidator Validate() // only model field level validation
        {
            var valid = ModelValidator.Validate(this);
            return valid;
        }
    }

    public class ModelValidator
    {
        public bool IsValid => !Errors.Any();
        public List<ValidationResult> Errors { get; set; }
        public void AddError(string error)
        {
            Errors.Add(new ValidationResult(error));
        }

        public ModelValidator ReturnError(string error)
        {
            Errors.Add(new ValidationResult(error));
            return this;
        }
        public ModelValidator()
        {
            Errors = new List<ValidationResult>();
        }
        public static ModelValidator Validate(object model)
        {
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, context, errors, validateAllProperties: true);

            return new ModelValidator
            {
                Errors = errors
            };
        }

        public string ErrorMessages => IsValid ? string.Empty : string.Join(". ", Errors.Select(e => e.ErrorMessage));
    }
}
