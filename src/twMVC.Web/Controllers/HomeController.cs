using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using twMVC.Interface;


namespace twMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public IRandomEmployeeNameService Ser { get; set; }

        public ActionResult Index()
        {
            var employee = Ser.GetEmployee();
            return View(employee);
        }

    }
}
