using Hastane.Business.Models.DTOs;
using Hastane.Business.Services.AdminService;
using Hastane.DataAccess.Abstract;
using Hastane.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NRM1_HastaneOtomasyon.Models;

namespace NRM1_HastaneOtomasyon.Controllers
{

    [Authorize(Roles = "Admin")]
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

        //public IActionResult ShowAdminInfo()
        //{
        //    var bilgi = HttpContext.Session.GetString("adminSession");
        //    var adminInfo = JsonConvert.DeserializeObject<Admin>(bilgi);
        //    return View(adminInfo);
        //}

        public IActionResult AddManager()
        {
            return View(); //Burası yönetici ekleme sayfasını açacak olanm HttpGet!!
        }

        [HttpPost]
        public async Task<IActionResult> AddManager(AddManagerDTO addManagerDTO)
        {
            if (ModelState.IsValid)
            {
                await _adminService.AddManager(addManagerDTO);
                return RedirectToAction("ListOfManagers");
            }
            return View(addManagerDTO);
        }

        public async Task<IActionResult> ListOfManagers()
        {

            var managers = await _adminService.ListOfManager();
            return View(managers);
        }

        //[HttpGet]
        //public IActionResult UpdatedManager(Guid id)
        //{
        //    var updatedManager = (Manager)HomeController._myUser.Find(i => i.Id == id);
        //    return View(updatedManager);
        //}



        //[HttpPost]
        //public IActionResult UpdatedManager(Manager manager)
        //{
        //    HomeController._myUser.Remove(HomeController._myUser.Find(i => i.Id == manager.Id));
        //    HomeController._myUser.Add(manager);
        //    return RedirectToAction("ListOfManagers");
        //}


        //public IActionResult DeletedManager(Guid id)
        //{
        //    HomeController._myUser.Remove(HomeController._myUser.Find(i => i.Id == id));
        //    return RedirectToAction("ListOfManagers");
        //}

        //[HttpGet]
        //public IActionResult AddPersonnel()
        //{
        //    //Burası HttpGet olarak ifade edilir. Burada Mantık Kullanıcıya Sayfa görüntsünü getirmek için yazarız.
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddPersonnel(Personnel personnel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Veritabanı işlemleri gerçekleşecek
        //        HomeController._myUser.Add(personnel);
        //        return RedirectToAction("ListOfPersonnels");
        //    }

        //    return View(personnel); //Bunu yapmasanda hatalı veri girişi olursa sana tekrardan aynı sayfayı döner.Veriler sabit kalır ama biz işimizi garantiye aldık.

        //}

        ////IUser Tipinde Verileri Gönderdim.Gelen Verinin Tipinin Personnels olduğu kısmını View tarafında kontrol ettim.
        //public IActionResult ListOfPersonnels()
        //{
        //    return View(HomeController._myUser);
        //}

        ////Burada kullanıcının tipinin Personel olup olmadığını kontrol ettik Personel olanları bir listede topladık. Bu listeyi return view derken parametre olarak verdik.
        //public IActionResult ListOfPersonnels2()
        //{
        //    List<Personnel> myPersonnels = new List<Personnel>();
        //    foreach (var item in HomeController._myUser)
        //    {
        //        if (item is Personnel)
        //        {
        //            myPersonnels.Add((Personnel)item);

        //        }
        //    }

        //    return View(myPersonnels);
        //}

        ////Burada TempData - ViewBag - ViewData kullanacağız
        //public IActionResult ListOfPersonnels3()
        //{
        //    List<Personnel> myPersonnels = new List<Personnel>();
        //    foreach (var item in HomeController._myUser)
        //    {
        //        if (item is Personnel)
        //        {
        //            myPersonnels.Add((Personnel)item);

        //        }
        //    }

        //    ViewBag.ourPersonnels = myPersonnels;
        //    ViewData["ourPersonnels2"] = myPersonnels;


        //    //TempData veri ataması yaptığın zaman arka planda kendisi için bir çerez(cookie) oluşturur.Sen bu cookie sayesinde burada bulunan verileri başka bir View ekranında'da çağırabilirsin.!!!
        //    TempData["ourPersonnels3"] = myPersonnels;

        //    return View();
        //}

        //public IActionResult ShowUsAll()
        //{
        //    PersonelManagerVM personelManagerVM = new PersonelManagerVM();

        //    List<Personnel> myPersonnels = new List<Personnel>();
        //    List<Manager> myManagers = new List<Manager>();
        //    foreach (var item in HomeController._myUser)
        //    {
        //        if (item is Personnel)
        //        {
        //            myPersonnels.Add((Personnel)item);

        //        }
        //        if(item is Manager)
        //        {
        //            myManagers.Add((Manager)item);  
        //        }
        //    }

        //    personelManagerVM.PersonnelList = myPersonnels;
        //    personelManagerVM.ManagerList = myManagers;

        //    return View(personelManagerVM);
        //}

        //public IActionResult ShowUsAll2()
        //{

        //    List<Personnel> myPersonnels = new List<Personnel>();
        //    List<Manager> myManagers = new List<Manager>();
        //    foreach (var item in HomeController._myUser)
        //    {
        //        if (item is Personnel)
        //        {
        //            myPersonnels.Add((Personnel)item);

        //        }
        //        if (item is Manager)
        //        {
        //            myManagers.Add((Manager)item);
        //        }
        //    }

        //    ViewBag.ourManagers = myManagers;

        //    return View(myPersonnels);

        //    //@model --> myPersonnels
        //    //ViewBag.ourManageer --> myManagers 
        //}


    }
}
