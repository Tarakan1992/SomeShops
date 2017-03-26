using Microsoft.AspNetCore.Mvc;
using SS.Interfaces.Data;
using SS.Entities;
using SS.WebUI.Models;
using System.Linq;
using System;

namespace SS.WebUI.Controllers
{
    public class ProductController : DomainWithInfinityScrollController<Product, IProductRepository>
    {
        public ProductController(IProductRepository repository, IServiceProvider serviceProvider) 
            : base(repository, serviceProvider)
        {
        }

        protected override string ItemViewName => "_ProductDetailsPartial";

        [HttpGet("{shopId}")]
        public IActionResult Index(int shopId)
        {
            var model = new ListModel
            {
                Items = GetBlockItems(1, _repository.All.Where(p => p.ShopId == shopId)),
                ItemViewName = ItemViewName
            };

            return View(model);
        }
    }
}