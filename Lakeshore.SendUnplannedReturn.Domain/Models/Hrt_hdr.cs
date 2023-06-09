using Lakeshore.SendUnplannedReturn.Domain.Har.Events;
using Lakeshore.SendUnplannedReturn.Dto.SendUnplannedReturn;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lakeshore.SendUnplannedReturn.Domain.Models
{
    public class Hrt_hdr : Entity
    {
        public long RecordId { get; set; }

        public string? ImportFileName { get; set; }

        public int FromDc { get; set; }

        public string? FileType { get; set; }

        public string? MaintenanceCode { get; set; }

        public int Rtn { get; set; }

        public string? Rectype { get; set; }

        public string? BillTo { get; set; }


        public string? BillToName { get; set; }

        public string? BillToAddr1 { get; set; }

        public string? BillToAddr2 { get; set; }

        public string? BillToAddr3 { get; set; }

        public string? BillToAddr4 { get; set; }

        public string? BillToCity { get; set; }

        public string? BillToState { get; set; }

        public string? BillToZip9 { get; set; }

        public string? BillToCountry { get; set; }

        public string? ShipTo { get; set; }

        public string? ShipToName { get; set; }

        public string? ShipToAddr1 { get; set; }

        public string? ShipToAddr2 { get; set; }

        public string? ShipToAddr3 { get; set; }

        public string? ShipToAddr4 { get; set; }

        public string? ShipToCity { get; set; }

        public string? ShipToState { get; set; }

        public string? ShipToZip9 { get; set; }

        public string? ShipToCountry { get; set; }

        public string? RtnType { get; set; }

        public string? BntRef { get; set; }

        public string? FinalFlag { get; set; }

        public string? StageArea { get; set; }

        public int HrtDate { get; set; }
        public int HrtTime { get; set; }
        public DateTime AddedDateTime { get; set; }

        public bool ReadyForProcessing { get; set; }
        public DateTime ProcessedDateTime { get; set; }

        public void StatusUpdate(UnplannedReturnDto unplannedReturnDto)
        {
            if (unplannedReturnDto != null)
                this.AddDomainEvent(new UnplannedReturnUpdatedDomainEvent(unplannedReturnDto));
        }

        public Hrt_hdr()
        {

        }

        public Hrt_hdr(long recordId, string? importFileName, int fromDc, string? fileType, string? maintenanceCode, int rtn, string? rectype,
     string? billTo, string? billToName, string? billToAddr1, string? billToAddr2, string? billToAddr3,
     string? billToAddr4, string? billToCity, string? billToState, string? billToZip9, string? billToCountry, string? shipTo,
     string? shipToName, string? shipToAddr1, string? shipToAddr2, string? shipToAddr3, string? shipToAddr4, string? shipToCity,
     string? shipToState, string? shipToZip9, string? shipToCountry, string? rtnType, string? bntRef, string? finalFlag,string? stageArea
     ,int hrtdate,int hrttime,DateTime addedDateTime,bool readyForProcessing, DateTime processedDateTime)
        {
            RecordId = recordId;
            ImportFileName = importFileName;
            FromDc = fromDc;
            FileType = fileType;
            MaintenanceCode = maintenanceCode;
            Rtn = rtn;
            Rectype = rectype;
            BillTo = billTo;
            BillToName = billToName;
            BillToAddr1 = billToAddr1;
            BillToAddr2 = billToAddr2;
            BillToAddr3 = billToAddr3;
            BillToAddr4 = billToAddr4;
            BillToCity = billToCity;
            BillToState = billToState;
            BillToZip9 = billToZip9;
            BillToCountry = billToCountry;
            ShipTo = shipTo;
            ShipToName = shipToName;
            ShipToAddr1 = shipToAddr1;
            ShipToAddr2 = shipToAddr2;
            ShipToAddr3 = shipToAddr3;
            ShipToAddr4 = shipToAddr4;
            ShipToCity = shipToCity;
            ShipToState = shipToState;
            ShipToZip9 = shipToZip9;
            ShipToCountry = shipToCountry;
            RtnType = rtnType;
            BntRef = bntRef;
            FinalFlag = finalFlag;
            StageArea = stageArea;
            HrtDate = hrtdate;
            HrtTime = hrttime;
            AddedDateTime = addedDateTime;
            ReadyForProcessing = readyForProcessing;
            ProcessedDateTime = processedDateTime;
        }

    }
}
