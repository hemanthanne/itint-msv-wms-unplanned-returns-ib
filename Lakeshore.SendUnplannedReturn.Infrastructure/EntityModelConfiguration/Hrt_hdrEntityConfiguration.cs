using Lakeshore.SendUnplannedReturn.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.SendUnplannedReturn.Infrastructure.EntityModelConfiguration
{
    public class Hrt_hdrEntityConfiguration : IEntityTypeConfiguration<Hrt_hdr>
    {
        public void Configure(EntityTypeBuilder<Hrt_hdr> entity)
        {
            entity.HasKey(e => new { e.RecordId, e.ImportFileName, e.FromDc, e.MaintenanceCode, e.Rtn, e.FinalFlag });
            entity.ToTable("HRT_HDR");

            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.ImportFileName).HasColumnName("import_filename");
            entity.Property(e => e.FromDc).HasColumnName("from_dc");
            entity.Property(e => e.FileType).HasColumnName("file_type");
            entity.Property(e => e.MaintenanceCode).HasColumnName("maintenance_code");
            entity.Property(e => e.Rtn).HasColumnName("rtn");
            entity.Property(e => e.Rectype).HasColumnName("rectype");
            entity.Property(e => e.BillTo).HasColumnName("billto");
            entity.Property(e => e.BillToName).HasColumnName("billto_name");
            entity.Property(e => e.BillToAddr1).HasColumnName("billto_addr1");
            entity.Property(e => e.BillToAddr2).HasColumnName("billto_addr2");
            entity.Property(e => e.BillToAddr3).HasColumnName("billto_addr3");
            entity.Property(e => e.BillToAddr4).HasColumnName("billto_addr4");
            entity.Property(e => e.BillToCity).HasColumnName("billto_city");
            entity.Property(e => e.BillToState).HasColumnName("billto_state");
            entity.Property(e => e.BillToZip9).HasColumnName("billto_zip9");
            entity.Property(e => e.BillToCountry).HasColumnName("billto_country");
            entity.Property(e => e.ShipTo).HasColumnName("shipto");
            entity.Property(e => e.ShipToName).HasColumnName("shipto_name");
            entity.Property(e => e.ShipToAddr1).HasColumnName("shipto_addr1");
            entity.Property(e => e.ShipToAddr2).HasColumnName("shipto_addr2");
            entity.Property(e => e.ShipToAddr3).HasColumnName("shipto_addr3");
            entity.Property(e => e.ShipToAddr4).HasColumnName("shipto_addr4");
            entity.Property(e => e.ShipToCity).HasColumnName("shipto_city");
            entity.Property(e => e.ShipToState).HasColumnName("shipto_state");
            entity.Property(e => e.ShipToZip9).HasColumnName("shipto_zip9");
            entity.Property(e => e.ShipToCountry).HasColumnName("shipto_country");
            entity.Property(e => e.RtnType).HasColumnName("rtn_type");
            entity.Property(e => e.BntRef).HasColumnName("bnt_ref");
            entity.Property(e => e.FinalFlag).HasColumnName("final_flag");
            entity.Property(e => e.StageArea).HasColumnName("stage_area");
            entity.Property(e => e.HrtDate).HasColumnName("hrt_date");
            entity.Property(e => e.HrtTime).HasColumnName("hrt_time");
            entity.Property(e => e.AddedDateTime).HasColumnName("added_datetime");
            entity.Property(e => e.ReadyForProcessing).HasColumnName("ready_for_processing");
            entity.Property(e => e.ProcessedDateTime).HasColumnName("processed_datetime");

        }
    }
}
