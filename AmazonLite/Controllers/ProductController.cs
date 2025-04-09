using AmazonLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AmazonLite.Controllers
{
    public class ProductController : Controller
    {
        string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AmazonLight;Data Source=DESKTOP-10MGO6D\\SQLEXPRESS;Encrypt=False\r\n";

        public IActionResult Index()
        {
            ProdList plist = new ProdList { ProdId = 1, ProdImage = "HP.jpg", ProdName = "HP Laptop", ProdType = "Laptop", ProdInfo = "HP offers a wide range of laptops designed to meet various needs, from everyday computing to high-performance tasks." };

            return View(plist);
        }

        //[HttpPost]
        //public IActionResult SaveData(ProdList prodList)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (SqlConnection connection = new SqlConnection(sql))
        //        {

        //            string sqlquery = $"INSERT INTO PRODUCTS VALUES(@ProdImage,@ProdName,@ProdType,@ProdInfo)";
        //            using (SqlCommand command = new SqlCommand(sqlquery, connection))
        //            {
        //                // Add parameters from the model class
        //                command.Parameters.AddWithValue("@ProdImage", prodList.ProdImage);
        //                command.Parameters.AddWithValue("@ProdName", prodList.ProdName);
        //                command.Parameters.AddWithValue("@ProdType", prodList.ProdType);
        //                command.Parameters.AddWithValue("@ProdInfo", prodList.ProdInfo);

        //                connection.Open();

        //                command.ExecuteNonQuery();
                      
        //                    TempData["SuccessMessage"] = "The product has been successfully added!";
        //                    return RedirectToAction("index");
                        
        //            }

        //        }
        //    }
      


        //    return View(prodList);
        //}
        //[HttpPost]
        //public IActionResult DeleteData(ProdList prodList)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (SqlConnection connection = new SqlConnection(sql))
        //        {

        //            string sqlquery = $"DELETE FROM Products WHERE prodId=@prodId";
        //            using (SqlCommand command = new SqlCommand(sqlquery, connection))
        //            {
        //                // Add parameters from the model class
        //                command.Parameters.AddWithValue("@ProdId", prodList.ProdId);
                       

        //                connection.Open();

        //              command.ExecuteNonQuery();
                     

        //            }

        //        }
        //    }
        //    return View("index",prodList);
        //}





        [HttpPost]
        public IActionResult HandleForm(ProdList prodList, string action)
        {
            if (action == "SaveData") // Insert Product
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection connection = new SqlConnection(sql))
                    {

                        string sqlquery = $"INSERT INTO PRODUCTS VALUES(@ProdImage,@ProdName,@ProdType,@ProdInfo)";
                        using (SqlCommand command = new SqlCommand(sqlquery, connection))
                        {
                            // Add parameters from the model class
                            command.Parameters.AddWithValue("@ProdImage", prodList.ProdImage);
                            command.Parameters.AddWithValue("@ProdName", prodList.ProdName);
                            command.Parameters.AddWithValue("@ProdType", prodList.ProdType);
                            command.Parameters.AddWithValue("@ProdInfo", prodList.ProdInfo);

                            connection.Open();

                            command.ExecuteNonQuery();

                            // Logic to save the product to the database
                            TempData["SuccessMessage"] = "Product inserted successfully!";
                        }
                    }
                }
            }

            else if (action == "DeleteData") // Delete Product
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection connection = new SqlConnection(sql))
                    {

                        string sqlquery = $"DELETE FROM Products WHERE prodId=@prodId";
                        using (SqlCommand command = new SqlCommand(sqlquery, connection))
                        {
                            // Add parameters from the model class
                            command.Parameters.AddWithValue("@ProdId", prodList.ProdId);


                            connection.Open();

                            command.ExecuteNonQuery();
                            // Logic to delete the product from the database
                            TempData["SuccessMessage"] = "Product deleted successfully!";

                        }

                    }
                }
               
            }



            return RedirectToAction("Index",prodList);  // Reload the form
        }


        [HttpPost]
        public IActionResult ClearData(ProdList prodList)
        {
            return View("Index",new ProdList());
        }


        public IActionResult Login()
        {
            return View();
        }

    }
}
