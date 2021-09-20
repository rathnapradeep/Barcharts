using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Barcharts.Models;
using System.Net;
using Barcharts.Data;
using Microsoft.EntityFrameworkCore;

namespace Barcharts.Controllers
{
    public class ChartController : Controller
    {
        private readonly ILogger<ChartController> _logger;
        private readonly BarchartContext _context;

        public ChartController(BarchartContext context, ILogger<ChartController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult ClientOrder()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Method to retieve the clietn order data based on the search parameters
        [HttpPost]
        public async Task<IActionResult> GetData([FromBody] SearchModel searchData)
        {
            int totalOrders = 0;
            //If parameters are null, then set default values.
            var startMonth = searchData != null && searchData.StartDate.HasValue ? searchData.StartDate.Value.Month : 1;
            var endMonth = searchData != null && searchData.EndDate.HasValue ? searchData.EndDate.Value.Month : 6;

            var clientOrders = from c in _context.Client 
            join o in _context.Order
            on c.ClientId equals o.ClientId
            where o.DateOrdered.Month >= startMonth && o.DateOrdered.Month <= endMonth
            group c by c.Name into co
            select new ClientOrderModel { ClientName = co.Key, NumberOfOrders = co.Count() };

            List<ClientOrderModel> lClientOrders = await clientOrders.ToListAsync();
            ResultModel result = new ResultModel();
            result.ClientOrders = lClientOrders;
            //Calcualte the total orders
            foreach(ClientOrderModel order in result.ClientOrders)
            {
                totalOrders += order.NumberOfOrders;
            }
            
            result.TotalOrders = totalOrders;

            return Json(result);
        }
    }
}
