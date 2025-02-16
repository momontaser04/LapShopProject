using LapShopPr.Bl;
using LapShopPr.Models;
using LapShopPr.Utlities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LapShopPr.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize (Roles ="Admin")]
    public class ItemsController : Controller
    {

        public ItemsController(ICategories category,IItem item,IItemType itemType,IOs os)
        {
            oclsitem = item;
            clsCategories = category;
            OClsItemType = itemType;
            OClsOs = os;

            
            
        }
        IItem oclsitem;
        ICategories clsCategories;

        IItemType OClsItemType;
        IOs OClsOs;
        public IActionResult List()
        {

            ViewBag.lstCategories = clsCategories.GetAll();
            var items = oclsitem.GetAllItemData(null);
            return View(items);
        }

        public IActionResult Search(int id)
        {
            ViewBag.lstCategories = clsCategories.GetAll();
            var items = oclsitem.GetAllItemData(id);
            return View("List", items);
        }

        public IActionResult Edit(int? itemId)
        {
            var item = new Models.TbItem();
            ViewBag.lstCategories = clsCategories.GetAll();
            ViewBag.lstItemTypes = OClsItemType.GetAll();
            ViewBag.lstOs = OClsOs.GetAll();
            if (itemId != null)
            {
                item = oclsitem.GetById(Convert.ToInt32(itemId));
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbItem item, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edit", item);

            item.ImageName = await Helper.UploadImage(Files, "Items");

            oclsitem.Save(item);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int itemId)
        {
            oclsitem.Delete(itemId);
            return RedirectToAction("List");
        }

     
    }
}




