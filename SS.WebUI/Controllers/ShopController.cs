using Microsoft.AspNetCore.Mvc;
using SS.Interfaces.Data;

namespace SS.WebUI.Controllers
{
    public class ShopController : Controller
    {
        protected IShopRepository _shopRepository;

        public ShopController(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public IActionResult Index()
        {
            return View(_shopRepository.All);
        }
    }
}