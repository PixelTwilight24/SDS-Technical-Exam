using SDS_Technical_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDS_Technical_Exam.ModelConfig;
using System.Data.Entity;

namespace Domain
{
    public class ApplicationDBContext: DbContext
    {

        public ApplicationDBContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<RecyclableItem> RecyclableItem { get; set; }
        public DbSet<RecyclableType> RecyclableType { get; set; }

    }
}
