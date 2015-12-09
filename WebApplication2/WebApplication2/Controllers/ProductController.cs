using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /EmployeeInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        //Display Create,Save,Delete and All Products
        public ActionResult Data()
        {
            return View();
        }

        //Display Logs
        public ActionResult Log()
        {
            return View();
        }

    }
}