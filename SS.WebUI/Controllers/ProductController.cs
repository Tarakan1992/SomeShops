using Microsoft.AspNetCore.Mvc;
using SS.Interfaces.Data;
using SS.Entities;
using SS.WebUI.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace SS.WebUI.Controllers
{
    public class ProductController : DomainWithInfinityScrollController<Product, IProductRepository>
    {
        #region [Fields]

        protected override string ItemViewName => "_ProductDetailsPartial";

        #endregion

        #region [Constructors]

        public ProductController(IProductRepository repository, IServiceProvider serviceProvider) 
            : base(repository, serviceProvider)
        {
        }

        #endregion

        #region [Actions]

        [HttpGet("Shop/{shopId}/Products")]
        public IActionResult Index(int shopId)
        {
            var model = new InfinityScrollListModel
            {
                Items = GetBlockItems(1, _repository.All.Where(p => p.ShopId == shopId)),
                ItemViewName = ItemViewName,
                InfinityScrollModel = new InfinityScrollModel
                {
                    Url = Url.Action("InfinateScroll"),
                    Params = new List<string> { $"\"shopId\":{shopId}" }
                }
            };

            ViewBag.ShopId = shopId;

            return View(model);
        }

        public override IActionResult InfinateScroll(int blockNumber)
        {
            var shopIdValue = Request.Form["shopId"];

            var items = _repository.All;

            if (int.TryParse(shopIdValue, out int shopId))
            {
                items = items.Where(i => i.ShopId == shopId);
            }

            var model = new ListModel
            {
                Items = GetBlockItems(blockNumber, items),
                ItemViewName = ItemViewName
            };

            var jsonModel = new JsonModel()
            {
                NoMoreData = items.Count() < blockNumber * BlockSize,
                HTMLString = RenderPartialViewToString(ItemsListViewName, model)
            };

            return Json(jsonModel);
        }

        #endregion
    }
}