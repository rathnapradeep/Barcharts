using System;
using System.Collections.Generic;

namespace Barcharts.Models
{
    public class ResultModel
    {
        public int TotalOrders { get; set; }
        public List<ClientOrderModel> ClientOrders {get;set;}
    }
}
