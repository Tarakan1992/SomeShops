using SS.Entities;
using SS.Interfaces.Data;
using System;

namespace SS.WebUI.Controllers
{
    public class ShopController : DomainWithInfinityScrollController<Shop, IShopRepository>
    {
        protected override string ItemViewName => "_ShopDetailsPartial";

        public ShopController(IShopRepository repository, IServiceProvider serviceProvider)
            : base(repository, serviceProvider)
        {
        }
    }
}