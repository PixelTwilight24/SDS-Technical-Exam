using SDS_Technical_Exam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SDS_Technical_Exam.ModelConfig
{
    public class RecyclableItemConfig: EntityTypeConfiguration<RecyclableItem>
    {
        public void Configure()
        {
            HasKey(x => x.Id);  // Primary Key

            HasRequired(p => p.RecyclableType)
            .WithMany(c => c.RecyclableItem)
            .HasForeignKey(p => p.RecyclableTypeId);

            Property(p => p.Weight)
                   .HasColumnType("decimal(18, 2)");
            Property(p => p.ComputedRate)
                   .HasColumnType("decimal(18, 2)");
            Property(p => p.ItemDescription)
                   .HasMaxLength(150);

        }
    }
}