using LapShopPr.Models;
using Microsoft.AspNetCore.Mvc;
using LapShopPr.Bl;
using LapShopPr.Utlities;
using Microsoft.AspNetCore.Authorization;

namespace LapShopPr.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {


        public CategoriesController(ICategories category)
        {
            clsCategories = category;
        }
        ICategories clsCategories;

        public IActionResult List()
        {
            return View(clsCategories.GetAll());
        }

        public IActionResult Edit(int? CategoryId)
        {
            var category = new TbCategory();
            if (CategoryId != null)
            {
                category = clsCategories.GetById(Convert.ToInt32(CategoryId));
            }
          
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbCategory category, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)

                return View("Edit", category);
            category.ImageName = await Helper.UploadImage(Files, "Categories");
            clsCategories.Save(category);

            return RedirectToAction("List");


        }


        public IActionResult Delete(int CategoryId)
        {
            clsCategories.Delete(CategoryId);
            return RedirectToAction("List");
        }
        async Task<string> UploadImage(List<IFormFile> Files)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/Categories", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                        return ImageName;
                    }
                }
            }
            return string.Empty;
        }

    }
}