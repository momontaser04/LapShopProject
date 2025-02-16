using Bl;
using LapShopPr.Bl;
using LapShopPr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LapShopPr.Controllers
{
    public class OrderController : Controller
    {
        IItem ItemSrevice;
        UserManager<ApplicationUser> _userManager;
        ISalesInvoice salesInvoiceService;

        public OrderController(IItem oitem, UserManager<ApplicationUser> userManager,ISalesInvoice ssalesInvoiceService) 
        {
            ItemSrevice = oitem; // Correct assignment
            _userManager = userManager;
          salesInvoiceService = ssalesInvoiceService;
        }
        public IActionResult Cart()
        {
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies["Cart"] != null)
                sesstionCart = HttpContext.Request.Cookies["Cart"];
            var cart = JsonConvert.DeserializeObject<ShoppingCart>(sesstionCart);
            return View(cart);
        }

        public IActionResult MyOrders()
        {
           
            return View();
        }

   

        [Authorize]
        public async Task<IActionResult> OrderSuccess()
        {
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies["Cart"] != null)
                sesstionCart = HttpContext.Request.Cookies["Cart"];
            var cart = JsonConvert.DeserializeObject<ShoppingCart>(sesstionCart);
            await SaveOrder(cart);
            return View();

        }

        public IActionResult AddToCart(int ItemId)
        {
            ShoppingCart cart;
            if (HttpContext.Request.Cookies["Cart"] != null)
                cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies["Cart"]);
            else
                cart = new ShoppingCart();


            var item = ItemSrevice.GetById(ItemId);

            var lstItem = cart.LstItems.Where(a => a.ItemId == ItemId).FirstOrDefault();

            if (lstItem != null)
            {
                lstItem.Qty++;
                lstItem.Total = lstItem.Total * lstItem.Qty;
            }
            else

                cart.LstItems.Add(new ShoppingCartItem
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    Price = item.SalesPrice,
                    Qty = 1,
                    Total = item.SalesPrice

                });





            cart.Total = cart.LstItems.Sum(a => a.Total);

            HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));

            return RedirectToAction("Cart");
        }


        async Task SaveOrder(ShoppingCart oShopingCart)
        {
            try
            {
                List<TbSalesInvoiceItem> lstInvoiceItems = new List<TbSalesInvoiceItem>();
                foreach (ShoppingCartItem item in oShopingCart.LstItems)
                {
                    lstInvoiceItems.Add(new TbSalesInvoiceItem()
                    {
                        ItemId = item.ItemId,
                        Qty = item.Qty,
                        InvoicePrice = item.Price
                    });
                }

                var user = await _userManager.GetUserAsync(User);

                TbSalesInvoice oSalesInvoice = new TbSalesInvoice()
                {
                    InvoiceDate = DateTime.Now,
                    CustomerId = Guid.Parse(user.Id),
                    DelivryDate = DateTime.Now.AddDays(5),
                    CreatedBy = user.Id,
                    CreatedDate = DateTime.Now
                };

                salesInvoiceService.Save(oSalesInvoice, lstInvoiceItems, true);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
