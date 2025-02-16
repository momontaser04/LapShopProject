using Microsoft.AspNetCore.Mvc;

using LapShopPr.Models;
using LapShopPr.Bl;
using Microsoft.Identity.Client;
namespace LapShopPr.Controllers
{
    public class HomeController : Controller
    {
        IItem oclsitem;
        ISlider oslider;
        public HomeController(IItem item, ISlider slider)
        {
            oclsitem = item;
           oslider = slider;

        }

        public IActionResult Index()
        {
            VwHomePage vw=new VwHomePage();
            vw.LstAllItem = oclsitem.GetAllItemData(null).Take(20).ToList();
            vw.LstRecommendedItem = oclsitem.GetAllItemData(null).Skip(20).Take(10).ToList();
            vw.LstFreeDelivaryItem = oclsitem.GetAllItemData(null).Skip(60).Take(10).ToList();
            vw.LstNewItem = oclsitem.GetAllItemData(null).Skip(80).Take(10).ToList();
            vw.LstSlider = oslider.GetAll();







            return View(vw);

        }
    }
}
