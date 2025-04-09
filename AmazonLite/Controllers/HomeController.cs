using Microsoft.AspNetCore.Mvc;
using AmazonLite.Models;
using AmazonLite.Helper;
using Microsoft.Extensions.Localization;
namespace AmazonLite.Controllers
   
{
    public class HomeController:Controller
    {
        List<ProdList> prodList;
        private readonly IMathLogic mathLogic;
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(IMathLogic mathLogicValue, IStringLocalizer<HomeController> localizer)
        {
            mathLogic = mathLogicValue;
            _localizer= localizer;
       prodList = new List<ProdList>
            {
   new ProdList{ProdId=1,ProdImage = "HP.jpg",ProdName="HP Laptop",ProdType="Laptop",ProdInfo = "HP offers a wide range of laptops designed to meet various needs, from everyday computing to high-performance tasks."},
    new ProdList{ProdId=2,ProdImage = "SonyTV.jpg",ProdName="Sony TV",ProdType="TV",ProdInfo = "Sony TVs are renowned for their stunning picture quality and immersive sound, offering features like 4K HDR, OLED displays, and advanced processors for a cinematic experience."},
    new ProdList{ProdId=3,ProdImage = "SamsungMobile.jpg",ProdName="Samsung Mobile",ProdType="Mobile",ProdInfo = "Samsung mobiles combine cutting-edge technology with sleek design, offering powerful performance, stunning displays, and advanced camera capabilities for a superior smartphone experience."},
    new ProdList{ProdId=4,ProdImage = "LloydAC.jpg",ProdName="Lloyd AC",ProdType="AC",ProdInfo = "Lloyd ACs offer high-performance cooling with advanced inverter technology, energy efficiency, and smart controls, ensuring comfort and convenience for any home or office."},
    new ProdList{ProdId=5,ProdImage = "HaierWM.jpg",ProdName="Haier Washing Machine",ProdType="Washing Machine",ProdInfo = "Haier washing machines offer advanced features like inverter motors, antibacterial technology, and customizable wash programs, ensuring efficient and hygienic laundry care."},
    new ProdList{ProdId=6,ProdImage = "Fridge.jpg",ProdName="LG Fridge",ProdType="Fridge",ProdInfo = "LG refrigerators offer advanced cooling technology, energy efficiency, and smart features, all wrapped in sleek and stylish designs to keep your food fresh and your kitchen modern."}
            };
        }

        public IActionResult FetchData()
        {
            ProdList prod= new ProdList { ProdId = 1, ProdImage = "HP.jpg", ProdName = "HP Laptop", ProdType = "Laptop", ProdInfo = "HP offers a wide range of laptops designed to meet various needs, from everyday computing to high-performance tasks." };
            return PartialView("_ItemPartial", prod);
        }

        public IActionResult Index()
        {
            mathLogic.Add(1, 2);
            mathLogic.Add(6, 3);
            ViewData["Welcome"] = _localizer["Welcome"];
            //List<string> os = new List<string> {"Suresh","Naren","Nithya" };
            //ViewData["Title"] = "Wipro";
            //ViewBag.UserNames = os;
            //TempData["Age"] = 23;




            //ProdList list = new ProdList();
            //list.ProdId = 1;
            //list.ProdName = "HP";
            //list.ProdType = "Laptop";
            //list.ProdInfo = "HP offers a wide range of laptops designed to meet various needs, from everyday computing to high-performance tasks.";
            //list.ProdImage = "HP.jpg";
            //ViewBag.BrandData=new BrandList { BrandID = 1, BrandName="Sony" };
                return View(prodList);
        }

        [Route("Home/jsquare")]
        [Route("Home/js")]
        [Route("Home/jss")]
        public IActionResult AboutUs()
        {
            Dashboard od = new Dashboard();
            ProdList plist = new ProdList { ProdId = 1, ProdImage = "HP.jpg", ProdName = "HP Laptop", ProdType = "Laptop", ProdInfo = "HP offers a wide range of laptops designed to meet various needs, from everyday computing to high-performance tasks." };
            BrandList blist= new BrandList { BrandID = 1, BrandName="HP" };
            od.brandList= blist;
            od.prodList = plist;
            //return View(od);
            return RedirectToAction("Login");
        }

        [HttpGet("Home/Prod/{name}")]
        public IActionResult ProdDetails([FromQuery]int Pid,[FromRoute]string name)
        {
            ProdList filterprod = prodList.Where(x => x.ProdId == Pid).FirstOrDefault();
            return View(filterprod);
        }

        public IActionResult Login()
        {
            //return View();
            //return Redirect("http://www.msdevbuild.com");
            //return Content("<h1>Welcome</h1>", "text/html");
            //return RedirectToRoute(new { Controller = "Product", action = "index" });

            //VIRTUAL FILE
            //return File("/GIT HUB.pdf", "application/pdf");

            //PHYSICAL FILE
            /*return PhysicalFile("C:\\Users\\PAVITHRA\\Downloads\\30thDec2024.pdf", "application/pdf");*/

            //TO STORE BINARY DATA
            Byte[] bytes = System.IO.File.ReadAllBytes("C:\\Users\\PAVITHRA\\Downloads\\30thDec2024.pdf");
            return new FileContentResult(bytes, "application/pdf");

        }
       
    }
}
