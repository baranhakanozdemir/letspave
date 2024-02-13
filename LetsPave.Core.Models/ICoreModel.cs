using System.ComponentModel.DataAnnotations.Schema;

namespace LetsPave.Core.Models
{
    public interface ICoreModel<T>
    {
        T Id { get; set; }
        void SetId(T id);
    }



    public class CoreModel<T> : ICoreModel<T>
    {
        public virtual T Id { get;  set; }

        public void SetId(T id)
        {
            Id = id;
        }
    }
}
