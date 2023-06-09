using Lakeshore.SendUnplannedReturn.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Lakeshore.SendUnplannedReturn.Infrastructure.EntityModelConfiguration
{

    public class Hrt_dtlEntityConfiguration : IEntityTypeConfiguration<Hrt_dtl>
    {
        public void Configure(EntityTypeBuilder<Hrt_dtl> entity)
        {
            entity.HasKey(e => new { e.RecordId, e.ImportFileName, e.FromDc, e.MaintenanceCode, e.Rtn, e.OrderLine, e.FinalFlag });
            entity.ToTable("HRT_DTL");

            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.ImportFileName).HasColumnName("import_filename");
            entity.Property(e => e.FromDc).HasColumnName("from_dc");
            entity.Property(e => e.FileType).HasColumnName("file_type");
            entity.Property(e => e.MaintenanceCode).HasColumnName("maintenance_code");
            entity.Property(e => e.Rtn).HasColumnName("rtn");
            entity.Property(e => e.Rectype).HasColumnName("rectype");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.Units).HasColumnName("units");
            entity.Property(e => e.UnitNeGind).HasColumnName("unitnegind");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.InventoryClass).HasColumnName("inventory_class");
            entity.Property(e => e.Container).HasColumnName("container");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.LandedCost).HasColumnName("landed_cost");
            entity.Property(e => e.Filler).HasColumnName("filler");
            entity.Property(e => e.OrderLine).HasColumnName("order_line");
            entity.Property(e => e.Unsched).HasColumnName("unsched");
            entity.Property(e => e.FinalFlag).HasColumnName("final_flag");
            entity.Property(e => e.StageArea).HasColumnName("stage_area");
            entity.Property(e => e.HrtTime).HasColumnName("hrt_time");
            entity.Property(e => e.HrtDate).HasColumnName("hrt_date");
            entity.Property(e => e.AddedDateTime).HasColumnName("added_datetime");
            entity.Property(e => e.InventoryUpdateDateTime).HasColumnName("inventory_update_datetime");

        }
    }
}
