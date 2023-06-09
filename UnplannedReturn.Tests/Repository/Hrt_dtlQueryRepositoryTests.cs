using Lakeshore.SendUnplannedReturn.Application.SendUnplannedReturn;
using Lakeshore.SendUnplannedReturn.Infrastructure.SendUnplannedReturn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnplannedReturn.Tests.Repository
{
    [TestFixture]
    public class Hrt_dtlQueryRepositoryTests : BaseTest
    {
        private IHrt_dtlQueryRepository _repository;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDatabase();

            _repository = new Hrt_dtlQueryRepository(DbContext);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            DbContext.Database.EnsureDeleted();
        }
        [Test]
        public async Task GetAll_ReturnsCorrectNumberOfRecords()
        {
            var records = await _repository.GetMappedDtl("testfilename", 23, 2, "testmaintaincecode", "testfinalflag", new DateTime(), CancellationToken.None);

            Assert.That(records.Count, Is.EqualTo(1));
        }
        [Test]
        public async Task GetAll_ReturnsCorrectFileName()
        {
            var records = await _repository.GetMappedDtl("testfilename", 23, 2, "testmaintaincecode", "testfinalflag", new DateTime(), CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.ImportFileName == "testfilename"));
        }
        [Test]
        public async Task GetAllAccounts_ReturnsCorrectMaintenanceCode()
        {
            var records = await _repository.GetMappedDtl("testfilename", 23, 2, "testmaintaincecode", "testfinalflag", new DateTime(), CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.MaintenanceCode == "testmaintaincecode"));
        }
    }
}
