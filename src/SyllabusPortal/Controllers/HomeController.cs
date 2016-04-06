using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Data.SqlClient;
//using System.Configuration;
using System.Data;

namespace SyllabusPortal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*
        Models.rpudContext db = new Models.rpudContext();

        public IActionResult Index()
        {
            return View(db.rpuds);
        }
        */
        /*
        public IActionResult Index()
        {
            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["rpudsContext"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[rpud]", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                string a = "";

                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        a += " " + rdr.GetValue(i).ToString();
                    }
                    //rpud[0].id_rpud = Convert.ToInt32(rdr[0]);
                    //rpud.id_classifier = rdr[5].ToString();

                    ViewData["Message"] = a;
                }

                return View();
            }
        }
        */
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
