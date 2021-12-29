using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentersLife.ViewModels;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using System;

namespace RentersLife.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login([Bind("UserName, Password")] AccountViewModel profile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "renterslifeserver.database.windows.net";
                    builder.UserID = "plato5";
                    builder.Password = "Lewallen1971";
                    builder.InitialCatalog = "RentersLifeDb";

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        string sql = @"select * from Profile";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("{0}, {1}", reader["UserName"], reader["Email"]);
                                }
                            }
                        }

                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }



                return RedirectToAction("Index", "Account");
            }

            return View(profile);
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
