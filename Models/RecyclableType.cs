using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SDS_Technical_Exam.Models
{
    public class RecyclableType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Rate { get; set; }
        public double MinKg { get; set; }
        public double MaxKg { get; set; }

        public ICollection<RecyclableItem> RecyclableItem { get; set; }
    }
}