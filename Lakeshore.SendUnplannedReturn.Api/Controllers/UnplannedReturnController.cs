using Lakeshore.SendUnplannedReturn.Application.SendUnplannedReturn.Command.UpdateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lakeshore.SendUnplannedReturn.Controllers
{
    [ApiController]
    [Route("itint-msv-wms-unplanned-returns-ib")]
    public class UnplannedReturnController : ControllerBase
    {       
        private readonly Serilog.ILogger _logger;

        private readonly IMediator _mediator;
       
        public UnplannedReturnController(  IMediator mediator, Serilog.ILogger logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("RunHrtPickup")]
        public async Task<ActionResult<bool>> RunHrtPickupAllUnplannedReturn(CancellationToken cancellationToken)
        {
            try
            {
                var RunHrtPickuped = await _mediator.Send(new RunHrtPickupUnplannedReturnCommand(), cancellationToken);
                
                return Ok(RunHrtPickuped);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }

           
        }

    }
}