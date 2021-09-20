using System;
using System.Collections.Generic;

namespace Barcharts.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }    
        public List<Order> Orders { get; set; }
    }
}
