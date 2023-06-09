using Lakeshore.SendUnplannedReturn.Application.SendUnplannedReturn;
using Lakeshore.SendUnplannedReturn.Domain.Models;
using Lakeshore.SendUnplannedReturn.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.SendUnplannedReturn.Infrastructure.SendUnplannedReturn
{
    public class Hrt_hdrQueryRepository : IHrt_hdrQueryRepository
    {
        private readonly UnplannedReturnDbContext _context;

        public Hrt_hdrQueryRepository(UnplannedReturnDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Hrt_hdr>> GetReadyForProcessing(CancellationToken cancellationToken)
        {
            var hrt_Hdr = await _context.Hrt_hdr.Where(x => x.ReadyForProcessing).ToListAsync(cancellationToken);
            return hrt_Hdr;
        }
    }
}
