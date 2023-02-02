using Hastane.Business.Services.AdminService;
using Microsoft.AspNetCore.Mvc;

namespace NRM1_HastaneOtomasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    //Admin'in Kendisine ait işlemleri yapsam
    public class AdminController : Controller
    {

        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        public IActionResult Index()
        {
            return View();
        }

        //Admin Kendini Güncellemesi !!!
    }
}
