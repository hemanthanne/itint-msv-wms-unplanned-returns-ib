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
    public class Hrt_hdrQueryRepositoryTests : BaseTest
    {
        private IHrt_hdrQueryRepository _repository;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDatabase();

            _repository = new Hrt_hdrQueryRepository(DbContext);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            DbContext.Database.EnsureDeleted();
        }
        [Test]
        public async Task GetAll_ReturnsCorrectNumberOfRecords()
        {
            var records = await _repository.GetReadyForProcessing(CancellationToken.None);

            Assert.That(records.Count, Is.EqualTo(2));
        }
        [Test]
        public async Task GetAll_ReturnsCorrectFileName()
        {
            var records = await _repository.GetReadyForProcessing(CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.ImportFileName == "testimportfilename"));
        }
        [Test]
        public async Task GetAllAccounts_ReturnsCorrectMaintenanceCode()
        {
            var records = await _repository.GetReadyForProcessing(CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.MaintenanceCode == "testmaintaincecode2"));
        }
    }
}
