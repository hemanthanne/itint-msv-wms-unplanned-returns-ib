using Lakeshore.SendUnplannedReturn.Domain;
using MediatR;
using Lakeshore.SendUnplannedReturn.Dto.SendUnplannedReturn;
using Microsoft.AspNetCore.Mvc.Formatters;
using Amazon.DynamoDBv2.Model;
using Lakeshore.SendUnplannedReturn.Domain.Models;

namespace Lakeshore.SendUnplannedReturn.Application.SendUnplannedReturn.Command.UpdateOrder
{

    public class RunHrtPickupUnplannedReturnCommandHandler : IRequestHandler<RunHrtPickupUnplannedReturnCommand, bool>
    {
        private readonly IHrt_dtlQueryRepository _hrtdtlqueryRepository;
        private readonly IHrt_hdrQueryRepository _hrthdrqueryRepository;
        private readonly ICommandUnitOfWork _unitWork;
        private readonly Serilog.ILogger _logger;

        public RunHrtPickupUnplannedReturnCommandHandler(
            IHrt_dtlQueryRepository hrtdtlqueryRepository,
            IHrt_hdrQueryRepository hrthdrqueryRepository,
            ICommandUnitOfWork unitWork,
            Serilog.ILogger logger)
        {

            _hrtdtlqueryRepository = hrtdtlqueryRepository;
            _hrthdrqueryRepository = hrthdrqueryRepository;
            _unitWork = unitWork ?? throw new ArgumentNullException(nameof(unitWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(RunHrtPickupUnplannedReturnCommand request, CancellationToken cancellationToken)
        {

            var hrthdr = await _hrthdrqueryRepository.GetReadyForProcessing(cancellationToken);

            try
            {
                foreach (var hrt_Hdr in hrthdr)
                {
                    var hrtdtl = await _hrtdtlqueryRepository.GetMappedDtl(hrt_Hdr.ImportFileName, hrt_Hdr.FromDc, hrt_Hdr.Rtn, hrt_Hdr.MaintenanceCode, hrt_Hdr.FinalFlag, hrt_Hdr.AddedDateTime, cancellationToken);
                    List<Item> items = new List<Item>();
                    foreach (var hrt_dtl in hrtdtl)
                    {
                        items.Add(new Item()
                        {
                            MaterialNumber = hrt_dtl.MaintenanceCode,
                            UnitsReturned = hrt_dtl.Units.ToString(),
                            NegativeIndicator = hrt_dtl.UnitNeGind,
                            ReasonCode = hrt_dtl.Reason,
                            Invclass = hrt_dtl.InventoryClass.ToString(),
                            Container = hrt_dtl.Container,
                            Comments = hrt_dtl.Comment,
                            FifoLayer = "",
                            Orderline = hrt_dtl.OrderLine.ToString(),
                            UnscheduledFlag = hrt_dtl.Unsched,
                            FinalFlag = hrt_dtl.FinalFlag,
                            WMSStagingArea = hrt_dtl.StageArea,
                            Text = new List<Text>()
                        {
                            new Text()
                            {
                                Language = "EN",
                                LongTextID = "ZRWC",
                                LongText = ""
                            }
                        }

                        });
                    }

                    var unplannedReturn = new UnplannedReturnDto();

                    unplannedReturn.UnplannedReturn = new UnplannedReturn
                    {
                        DeliveryDocument = hrt_Hdr.Rtn,
                        RecordType = hrt_Hdr.Rectype,
                        BillToNumber = hrt_Hdr.BillTo,
                        BillToName = hrt_Hdr.BillToName,
                        BillToAddress1 = hrt_Hdr.BillToAddr1,
                        BillToAddress2 = hrt_Hdr.BillToAddr2,
                        BillToAddress3 = hrt_Hdr.BillToAddr3,
                        BillToAddress4 = hrt_Hdr.BillToAddr4,
                        BillToCity = hrt_Hdr.BillToCity,
                        BillToState = hrt_Hdr.BillToState,
                        BillToZip9 = hrt_Hdr.BillToZip9,
                        BillToCountry = hrt_Hdr.BillToCountry,
                        ShipToNumber = hrt_Hdr.ShipTo,
                        ShipToName = hrt_Hdr.ShipToName,
                        ShiptoAddress1 = hrt_Hdr.ShipToAddr1,
                        ShipToAddress2 = hrt_Hdr.ShipToAddr2,
                        ShipToAddress3 = hrt_Hdr.ShipToAddr3,
                        ShipToAddress4 = hrt_Hdr.ShipToAddr4,
                        ShipToCity = hrt_Hdr.ShipToCity,
                        ShipToState = hrt_Hdr.ShipToState,
                        ShipToZip9 = hrt_Hdr.ShipToZip9,
                        ShipToCountry = hrt_Hdr.ShipToCountry,
                        Item = items
                    };

                    hrt_Hdr.StatusUpdate(unplannedReturn);

                }

                await _unitWork.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return false;
            }
        }

    }
}
