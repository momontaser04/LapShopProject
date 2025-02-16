using LapShopPr.Bl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LapShopPr.Controllers
{
    public class PagesController : Controller
    {
        IPages oclspage;
        public PagesController(IPages pages)
        {
            oclspage = pages;
            
        }
        // GET: PagesController
        public ActionResult Index(int PageId)
        {
            var page = oclspage.GetById(PageId);
            return View(page);
        }

      
    }
}
