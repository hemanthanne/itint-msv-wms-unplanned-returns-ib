using Lakeshore.SendUnplannedReturn.Domain.Models;
using Lakeshore.SendUnplannedReturn.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace UnplannedReturn.Tests.Repository
{
    public abstract class BaseTest
    {
        protected readonly DbContextOptions<UnplannedReturnDbContext> DbContextOptions;
        protected UnplannedReturnDbContext DbContext;
        protected Mock<ILogger> LoggerMock;

        protected BaseTest()
        {
            DbContextOptions = new DbContextOptionsBuilder<UnplannedReturnDbContext>()
                .UseInMemoryDatabase(databaseName: "lakeshore_staging")
                .Options;

            DbContext = new UnplannedReturnDbContext(DbContextOptions);

            LoggerMock = new Mock<ILogger>();
        }
        protected void SetupFixture()
        {
            LoggerMock = new Mock<ILogger>();

            LoggerMock.Setup(m => m.LogInformation(It.IsAny<string>())).Verifiable();
            LoggerMock.Setup(m => m.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
        }
        protected void SeedDatabase()
        {
            DbContext.Database.EnsureCreated();

            SeedHrtdtl();
            SeedHrthdr();
          
            DbContext.SaveChanges();
        }
        private void SeedHrtdtl()
        {
            var hrt_Dtls = new List<Hrt_dtl>
            {
                new Hrt_dtl(1,"testfilename",23,"testfiletype","testmaintaincecode",2,"testrectype","model",2,"testnegind","testreason",1,"testcontainer","testcomment",2,"",23,"testunsched","testfinalflag","teststagearea",23,12,new DateTime(),new DateTime()),
                new Hrt_dtl(1,"testfilename2",23,"testfiletype2","testmaintaincecode2",2,"testrectype2","model2",2,"testnegind2","testreason2",1,"testcontainer2","testcomment2",2,"",23,"testunsched2","testfinalflag2","teststagearea2",23,12,new DateTime(),new DateTime()),
            };

            DbContext.Hrt_dtl.AddRange(hrt_Dtls);
        }

        private void SeedHrthdr()
        {
            var hrt_Hdrs = new List<Hrt_hdr>
            {
                new Hrt_hdr(2,"testimportfilename",3,"testfiletype","testmaintaincecode",12,"testrectype","testbillto","testbilltoname","testbilltoaddr1",
                "testbilltoaddr2","testbilltoaddr3","testbilltoadd4","testbilltocity","testbilltostate","testbilltozip9","testbilltocountry","testshipto",
                "testshiptpname","testshiptoaddr1","testshiptoaddr2","testshiptoaddr3","shiptoaddr4","testshiptocity","testshiptostate","testshiptozip9",
                "testshiptocountry","testrtntype","testbtnref","testfinalflag","teststagearea",23,3,new DateTime(),true,new DateTime()),
                new Hrt_hdr(3,"testimportfilename2",3,"testfiletype2","testmaintaincecode2",12,"testrectype2","testbillto2","testbilltoname2","testbilltoaddr12",
                "testbilltoaddr22","testbilltoaddr32","testbilltoadd42","testbilltocity2","testbilltostate2","testbilltozip92","testbilltocountry2","testshipto2",
                "testshiptpname2","testshiptoaddr12","testshiptoaddr22","testshiptoaddr32","shiptoaddr42","testshiptocity2","testshiptostate2","testshiptozip92",
                "testshiptocountry2","testrtntype2","testbtnref2","testfinalflag2","teststagearea2",23,3,new DateTime(),true,new DateTime()),
            };

            DbContext.Hrt_hdr.AddRange(hrt_Hdrs);
        }
    }
}
