using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SS.Interfaces.Data;
using SS.Entities;

namespace SS.Data
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var shopRepository = serviceProvider.GetService<IShopRepository>();
            var productRepository = serviceProvider.GetService<IProductRepository>();

            if (!shopRepository.All.Any())
            {
                var startDate = new DateTime(1, 1, 1, 10, 0, 0);
                var endDate = new DateTime(1, 1, 1, 20, 0, 0);


                for (var i = 0; i < 200; i++)
                {
                    shopRepository.Insert(new Shop { Name = $"Shop {i + 1}", Address  = $"Some street {i + 1}", StartTime = startDate, EndTime = endDate });
                }

                foreach (var shop in shopRepository.All.ToList())
                {
                    for (int i = 0; i < 200; i++)
                    {
                        productRepository.Insert(
                            new Product
                            {
                                Name = $"Product {i + 1}",
                                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.",
                                ShopId = shop.Id
                            });
                    }
                }
            }
        }
    }
}
