using Lakeshore.SendUnplannedReturn.Domain.Har.Events;
using Lakeshore.SendUnplannedReturn.Dto.SendUnplannedReturn;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Lakeshore.SendUnplannedReturn.Domain.Models
{

    public class Hrt_dtl : Entity
    {
        public long RecordId { get; set; }

        public string ImportFileName { get; set; }

        public int FromDc { get; set; }

        public string FileType { get; set; }

        public string MaintenanceCode { get; set; }

        public int Rtn { get; set; }

        public string? Rectype { get; set; }

        public string? Model { get; set; }

        public int Units { get; set; }
        public string UnitNeGind { get; set; }
        public string Reason { get; set; }
        public int InventoryClass { get; set; }
        public string Container { get; set; }
        public string Comment { get; set; }
        public decimal LandedCost { get; set; }
        public string Filler { get; set; }
        public int OrderLine { get; set; }
        public string Unsched { get; set; }
        public string FinalFlag { get; set; }
        public string StageArea { get; set; }
        public int HrtDate { get; set; }
        public int HrtTime { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime InventoryUpdateDateTime { get; set; }

        public Hrt_dtl()
        { }



        public Hrt_dtl(long recordId, string? importFileName, int fromDc, string? fileType, string? maintenanceCode, int rtn, string? rectype,
       string? model, int units, string? unitNeGind, string reason, int inventoryClass,
       string? container, string? comment, decimal landedCost, string filler, int orderLine, string unsched,
       string finalFlag, string stageArea, int hrtDate, int hrtTime, DateTime addedDateTime, DateTime inventoryUpdateDateTime)
        {
            RecordId = recordId;
            ImportFileName = importFileName;
            FromDc = fromDc;
            FileType = fileType;
            MaintenanceCode = maintenanceCode;
            Rtn = rtn;
            Rectype = rectype;
            Model = model;
            Units = units;
            UnitNeGind = unitNeGind;
            Reason = reason;
            InventoryClass = inventoryClass;
            Container = container;
            Comment = comment;
            LandedCost = landedCost;
            Filler = filler;
            OrderLine = orderLine;
            Unsched = unsched;
            FinalFlag = finalFlag;
            StageArea = stageArea;
            HrtDate = hrtDate;
            HrtTime = hrtTime;
            AddedDateTime = addedDateTime;
            InventoryUpdateDateTime = inventoryUpdateDateTime;
        }
    }

}
