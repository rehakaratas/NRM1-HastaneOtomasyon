using Microsoft.AspNetCore.Mvc;

namespace NRM1_HastaneOtomasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonnelController : Controller
    {
        //Admin'in Personel üzerindeki işlemlerini yaptırsam 
        public IActionResult Index()
        {
            return View();
        }
    }
}
