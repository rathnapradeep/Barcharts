using System;
using System.ComponentModel.DataAnnotations;

namespace Barcharts.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOrdered { get; set; }
        public int ClientId { get; set;}
        public Client Client { get; set; }
    }
}
