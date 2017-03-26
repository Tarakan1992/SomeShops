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
                    var shop = new Shop { Name = $"Shop {i + 1}", Address = $"Some street {i + 1}", StartTime = startDate, EndTime = endDate };
                    shopRepository.Insert(shop);
                }

                shopRepository.SaveChanges();

                foreach (var shop in shopRepository.All.ToList())
                {
                    for (var j = 0; j < 200; j++)
                    {
                        var product = new Product
                        {
                            Name = $"Product {j + 1}",
                            Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.",
                            ShopId = shop.Id
                        };

                        productRepository.Insert(product);
                    }
                }

                productRepository.SaveChanges();
            }
        }
    }
}
