using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SDS_Technical_Exam.Models
{
    public class RecyclableItem
    {
        public int Id { get; set; }
        public int RecyclableTypeId { get; set; }
        public double Weight { get; set; }
        public double ComputedRate { get; set; }
        public string ItemDescription { get; set; }

        public RecyclableType RecyclableType { get; set; }
    }
}