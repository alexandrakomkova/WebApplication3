using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            ViewBag.Url = Request.Url;
            ViewBag.Method = Request.HttpMethod.ToString();
            return View();
        }

        public ActionResult Internal()
        {
            ViewBag.Url = Request.Url;
            ViewBag.Method = Request.HttpMethod.ToString();
            return View();
        }
    }
}