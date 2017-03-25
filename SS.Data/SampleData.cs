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
                shopRepository.Insert(new Shop { Name = "Denis" });
                shopRepository.Insert(new Shop { Name = "Kristina"});
                shopRepository.Insert(new Shop { Name = "Alexander"});
                shopRepository.Insert(new Shop { Name = "Sergey"});
                shopRepository.Insert(new Shop { Name = "Alexey"});
                shopRepository.Insert(new Shop { Name = "Vadim"});      
            }
            else if (!productRepository.All.Any())
            {
                foreach (var shop in shopRepository.All.ToList())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        productRepository.Insert(new Product { Name = $"Product{i}", Description = "Some description.", ShopId = shop.Id });
                    }
                }
            }
        }
    }
}
