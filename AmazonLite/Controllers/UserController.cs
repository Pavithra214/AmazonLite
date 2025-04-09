using AmazonLite.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonLite.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDBContext appDBContextObject;
        public UserController(AppDBContext appDBContext)
        {
            appDBContextObject = appDBContext;
        }
        public IActionResult Register()
        {
            return View(new ProdList());
        }

        public IActionResult SaveData(ProdList data)
        {
            appDBContextObject.ProdLists.Add(data);
            appDBContextObject.SaveChanges();
            return View("Register", data);
            //if(data.Email=="Pavi@gmail.com")
            //{
            //    ModelState.AddModelError(data.Email, "The Email name is already taken");

            //}
            //if(ModelState.IsValid)
            //{

            //}
            //return View("Register",data);
        }


        [Route("User/ReadData/{id}")]
        public IActionResult ReadData(int id)
        {
            var prod = appDBContextObject.ProdLists.ToList();
            var single=prod.Where(x=>x.ProdId==id).FirstOrDefault();
            return View("Register", single);
        }

        [Route("User/DeleteData/{ProdId}")]
        public IActionResult DeleteData(int ProdId)
        {
            var prod = appDBContextObject.ProdLists.ToList();
            var single = prod.Where(x => x.ProdId == ProdId).FirstOrDefault();
            if (single != null)
            {
                appDBContextObject.ProdLists.Remove(single);
                appDBContextObject.SaveChanges();
            }
            return View("Register", single);
        }

        //[HttpPost]
        [Route("User/UpdateData/{ProdId}")]
        public IActionResult UpdateData(ProdList data)
        {
            var existingProduct = appDBContextObject.ProdLists.FirstOrDefault(x => x.ProdId == data.ProdId);
            if (existingProduct != null)
            {
                existingProduct.ProdName = data.ProdName;
                existingProduct.ProdInfo = data.ProdInfo;
                existingProduct.ProdType = data.ProdType;
                appDBContextObject.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
