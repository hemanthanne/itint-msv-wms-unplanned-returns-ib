using Lakeshore.SendUnplannedReturn.Application.SendUnplannedReturn;
using Lakeshore.SendUnplannedReturn.Domain.Models;
using Lakeshore.SendUnplannedReturn.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Lakeshore.SendUnplannedReturn.Infrastructure.SendUnplannedReturn
{

    public class Hrt_dtlQueryRepository : IHrt_dtlQueryRepository
    {
        private readonly UnplannedReturnDbContext _context;

        public Hrt_dtlQueryRepository(UnplannedReturnDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Hrt_dtl>> GetMappedDtl(string importFileName, int fromDc, int rtn, string maintenanceCode, string finalFlag, DateTime addedDateTime, CancellationToken cancellationToken)
        {
            DateTime addedDateTimeStart = addedDateTime.Date;
            DateTime addedDateTimeEnd = addedDateTime.Date.AddDays(1);

            var hrt_dtl = await _context.Hrt_dtl
                .Where(x => x.ImportFileName.Equals(importFileName) &&
                            x.FromDc.Equals(fromDc) &&
                            x.Rtn.Equals(rtn) &&
                            x.MaintenanceCode.Equals(maintenanceCode) &&
                            x.FinalFlag.Equals(finalFlag) &&
                            x.AddedDateTime >= addedDateTimeStart && x.AddedDateTime < addedDateTimeEnd)
                .ToListAsync(cancellationToken);

            return hrt_dtl;
        }
    }
}
