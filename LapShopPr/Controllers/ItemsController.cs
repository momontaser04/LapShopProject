using LapShopPr.Bl;
using LapShopPr.Models;
using Microsoft.AspNetCore.Mvc;

namespace LapShopPr.Controllers
{
    public class ItemsController : Controller
    {
        IItem oItem;
        IItemImages oImage;
        public ItemsController(IItem item, IItemImages images)
        {
oItem = item;
            oImage = images;
        }
        public IActionResult ItemDetails(int id)
        {
            var item = oItem.GetItemId(id);

            VwItemDetails vm = new VwItemDetails();
            vm.Item = item;
            vm.lstRecommendedItems = oItem.GetRecommendedItem(id).Take(20).ToList();
            vm.lstItemImages = oImage.GetByItemId(id);
            return View(vm);
        }
        public IActionResult ItemList()
        {


            return View();
        }
    }
}
