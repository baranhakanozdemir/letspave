using LetsPave.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPave.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMontsToSeason()
        {
            var season=SaleService.GetSeason(6);
            Assert.IsNotNull(season);
            Assert.AreEqual("Summer", season);

            season = SaleService.GetSeason(16);
            Assert.AreEqual("Unknown", season);
        }

        [TestMethod]
        public void TestSeasonToMonths()
        {
            var monts = SaleService.GetMonths("Summer");
            Assert.IsNotNull(monts);
            Assert.AreEqual(3, monts.Count());
            Assert.AreEqual(21, monts.Sum());

            monts= SaleService.GetMonths("Hot");
            Assert.AreEqual(0, monts.Count());
        }
    }
}
