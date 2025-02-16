using LapShopPr.Bl;
using LapShopPr.Filters;
using Microsoft.AspNetCore.Mvc;
using LapShopPr.Models;
using Microsoft.AspNetCore.Authorization;
namespace LapShopPr.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    [Authorization]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
        
            return View();
        }
    }
}
