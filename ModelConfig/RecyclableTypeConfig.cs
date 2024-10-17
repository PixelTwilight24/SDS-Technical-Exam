using SDS_Technical_Exam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SDS_Technical_Exam.ModelConfig
{
    public class RecyclableTypeConfig: EntityTypeConfiguration<RecyclableType>
    {
        public void Configure()
        {
            HasKey(x => x.Id);  // Primary Key


            Property(p => p.Type)
                .HasMaxLength(100)
                .IsRequired();
            HasIndex(x => x.Type)
                .IsUnique();

            Property(p => p.Rate)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            Property(p => p.MinKg)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            Property(p => p.MaxKg)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

        }
    }
}