using Hastane.DataAccess.Abstract;
using Hastane.Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NRM1_HastaneOtomasyon.Models;
using System.Security.Claims;

namespace NRM1_HastaneOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminRepo _adminRepo;
        private readonly IEmployeeRepo _employeeRepo;
        public LoginController(IAdminRepo adminRepo, IEmployeeRepo employeeRepo)
        {
            _adminRepo = adminRepo;
            _employeeRepo = employeeRepo;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string emailAddress, string password)
        {
            //Admin,Manager,Personnel aslında tek bir tablodan yönetilir ve bu tablodan sorgu yapılır.Anlık çözüm üretmek için böyle bir davranış sergiledim.

            //BaseRepo'da yazabilirdim bu GetByEmail metotlarını yazmamamın nedeni ise BaseRepo'daki T kısıtlamasında emailAdress ve Password bilgilerinin bulunmamasından kaynaklanmaktadır!!

            var adminUser = await _adminRepo.GetByEmail(emailAddress, password);
            var claims = new List<Claim>();
            //Key --> Value!!!
            //Giriş yapan kişinin hangi bilgilerini tutacağını söylüyoruz.
            //Biz sadece Role alacağız.Sen burada gidip başka proplarda alabilirsin.

            if (adminUser != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            var userIdentity = new ClaimsIdentity(claims,"Login");

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (adminUser != null)
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin"});
            }


            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();

        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
