using Lakeshore.SendUnplannedReturn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.SendUnplannedReturn.Application.SendUnplannedReturn
{
    public interface IHrt_hdrQueryRepository
    {
        Task<List<Hrt_hdr>> GetReadyForProcessing(CancellationToken cancellationToken);
    }
}
