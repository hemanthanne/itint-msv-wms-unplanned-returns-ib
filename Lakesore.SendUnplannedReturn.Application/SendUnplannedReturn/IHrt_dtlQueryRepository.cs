using Lakeshore.SendUnplannedReturn.Domain.Models;

namespace Lakeshore.SendUnplannedReturn.Application.SendUnplannedReturn
{

    public interface IHrt_dtlQueryRepository
    {
        Task<List<Hrt_dtl>> GetMappedDtl(string importFileName, int fromDc, int rtn, string maintenanceCode, string finalFlag, DateTime addedDateTime, CancellationToken cancellationToken);
    }
}
