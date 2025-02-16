using Bl;
using LapShopPr.Migrations;
using LapShopPr.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LapShopPr.Controllers
{
    public class UserController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;

        public UserController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string ReturnUrl)
        {
            UserModel model = new UserModel()
            {
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }

        public IActionResult Register()
        {

            return View(new UserModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {




            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var loginResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                    var myUser = await _userManager.FindByEmailAsync(user.Email);
                    await _userManager.AddToRoleAsync(myUser, "Customer");
                    if (loginResult.Succeeded)
                        Redirect("/Order/OrderSuccess");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            } 

            return View(new UserModel());
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {




          
            ApplicationUser user = new ApplicationUser()
            {
              
                Email = model.Email,
                UserName = model.Email
            };
            try
            {
               
                    var signin = await _signInManager.PasswordSignInAsync(user.Email, model.Password, true, true);
            
                    if (signin.Succeeded)
                    {

                    if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect("~/");
                    }
                    else
                    {
                        return Redirect(model.ReturnUrl);
                    }
                   

                }
              
            }
            catch (Exception ex)
            {

            }

            return View(new UserModel());
        }


        public async Task< IActionResult> Logout()
        {
          await  _signInManager.SignOutAsync();
            return Redirect("~/");
        }



        public IActionResult AccessDenied()
        {
           
            return View();
        }
    }
}
