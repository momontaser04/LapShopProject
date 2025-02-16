using Bl;
using LapShopPr.Bl;
using LapShopPr.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace LapShopPr
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            #region Custome service
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICategories, ClsCategories>();
            builder.Services.AddScoped<IItem, ClsItem>();
            builder.Services.AddScoped<IItemType, ClsItemType>();
            builder.Services.AddScoped<IOs, ClsOs>();
            builder.Services.AddScoped<IItemImages, ClsItemImages>();
            builder.Services.AddScoped<ISalesInvoice, ClsSalesInvoice>();
            builder.Services.AddScoped<ISalesInvoiceItems, ClsSalesInvoiceItems>();
            builder.Services.AddScoped<ISlider, ClsSlider>();
            builder.Services.AddScoped<ISettings, ClsSetting>();
            builder.Services.AddScoped<IPages, ClsPages>();

            #endregion

            #region Identity

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<LapShopContext>();

            #endregion

            #region Cookies
            builder.Services.ConfigureApplicationCookie(options =>
               {
                   options.AccessDeniedPath = "/User/AccessDenied";
                   options.Cookie.Name = "Cookie";
                   options.Cookie.HttpOnly = true;
                   options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                   options.LoginPath = "/User/Login";
                   options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                   options.SlidingExpiration = true;
               });
            #endregion
            #region Swagger
            //builder.Services.AddSwaggerGen(options =>
            // {
            //     options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            //     {
            //         Version = "v1",
            //         Title = "LapShop",
            //         Description = "APi for LapShop",

            //         Contact = new OpenApiContact
            //         {
            //             Email = "momntaser99@gmail.com",
            //             Name = "Mohamed Montaser Azmy",
            //             Url = new Uri("https://www.linkedin.com/in/mohamed-montaser-1ab942314/")
            //         },
            //     });
            // }); 
            #endregion


            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddDbContext<LapShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }




            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
   //         app.UseSwagger();
			//app.UseSwaggerUI(options =>
			//{
			//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
			//    options.RoutePrefix = string.Empty;
			//}); 
			app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");





                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employees}/{action=List}/{id?}");



            }
    );


            app.Run();
        }
    }
}