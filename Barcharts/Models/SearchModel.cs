using System;
using System.ComponentModel.DataAnnotations;

namespace Barcharts.Models
{
    public class SearchModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
