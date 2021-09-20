using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Barcharts.Data;
using System;
using System.Linq;

namespace Barcharts.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BarchartContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BarchartContext>>()))
            {
                // Look for any clients.
                if (!context.Client.Any())
                {
                    context.Client.AddRange(
                        new Client
                        {
                            Name = "Coca-Cola Inc.",
                            ContactName = "John Young", 
                            Active = true
                        },
                        new Client
                        {
                            Name = "Lindt Inc.",
                            ContactName = "Bradley Lee", 
                            Active = true
                        },
                        new Client
                        {
                            Name = "M&M Inc.",
                            ContactName = "Bret Johnson", 
                            Active = true
                        },
                        new Client
                        {
                            Name = "Kraft Inc.",
                            ContactName = "Dave Smith", 
                            Active = true
                        },
                        new Client
                        {
                            Name = "Mars Inc.",
                            ContactName = "Tracy McGregor", 
                            Active = true
                        },
                        new Client
                        {
                            Name = "Kelloggs Inc.",
                            ContactName = "Rahul Kumar", 
                            Active = true
                        }
                    );
                    context.SaveChanges();
                }

                // Look for any Orders.
                if (!context.Order.Any())
                {
                    context.Order.AddRange(
                        new Order
                        {
                            ClientId = 1,
                            DateOrdered = DateTime.Parse("2021-2-12")
                        },
                        new Order
                        {
                            ClientId = 1,
                            DateOrdered = DateTime.Parse("2021-3-18")
                        },
                        new Order
                        {
                            ClientId = 1,
                            DateOrdered = DateTime.Parse("2021-3-30")
                        },
                        new Order
                        {
                            ClientId = 1,
                            DateOrdered = DateTime.Parse("2021-5-1")
                        },
                        new Order
                        {
                            ClientId = 1,
                            DateOrdered = DateTime.Parse("2021-6-10")
                        },
                        new Order
                        {
                            ClientId = 2,
                            DateOrdered = DateTime.Parse("2021-1-20")
                        },
                        new Order
                        {
                            ClientId = 2,
                            DateOrdered = DateTime.Parse("2021-2-16")
                        },
                        new Order
                        {
                            ClientId = 2,
                            DateOrdered = DateTime.Parse("2021-4-19")
                        },
                        new Order
                        {
                            ClientId = 2,
                            DateOrdered = DateTime.Parse("2021-5-27")
                        },
                        new Order
                        {
                            ClientId = 3,
                            DateOrdered = DateTime.Parse("2021-2-9")
                        },
                        new Order
                        {
                            ClientId = 3,
                            DateOrdered = DateTime.Parse("2021-3-6")
                        },
                        new Order
                        {
                            ClientId = 3,
                            DateOrdered = DateTime.Parse("2021-4-7")
                        },
                        new Order
                        {
                            ClientId = 4,
                            DateOrdered = DateTime.Parse("2021-2-19")
                        },
                        new Order
                        {
                            ClientId = 4,
                            DateOrdered = DateTime.Parse("2021-3-2")
                        },
                        new Order
                        {
                            ClientId = 4,
                            DateOrdered = DateTime.Parse("2021-4-11")
                        },
                        new Order
                        {
                            ClientId = 5,
                            DateOrdered = DateTime.Parse("2021-2-4")
                        },
                        new Order
                        {
                            ClientId = 5,
                            DateOrdered = DateTime.Parse("2021-1-18")
                        },
                        new Order
                        {
                            ClientId = 6,
                            DateOrdered = DateTime.Parse("2021-2-12")
                        },
                        new Order
                        {
                            ClientId = 6,
                            DateOrdered = DateTime.Parse("2021-1-16")
                        },
                        new Order
                        {
                            ClientId = 6,
                            DateOrdered = DateTime.Parse("2021-2-1")
                        },
                        new Order
                        {
                            ClientId = 6,
                            DateOrdered = DateTime.Parse("2021-2-27")
                        },
                        new Order
                        {
                            ClientId = 6,
                            DateOrdered = DateTime.Parse("2021-3-12")
                        },
                        new Order
                        {
                            ClientId = 6,
                            DateOrdered = DateTime.Parse("2021-4-21")
                        },
                        new Order
                        {
                            ClientId = 6,
                            DateOrdered = DateTime.Parse("2021-5-3")
                        },
                        new Order
                        {
                            ClientId = 6,
                            DateOrdered = DateTime.Parse("2021-5-21")
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}