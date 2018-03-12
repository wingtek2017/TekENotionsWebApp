using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TekENotionsWebApp.Models;

namespace TekENotionsWebApp.Controllers
{
    public class patternController : Controller
    {
        private TekENotionsEntities db = new TekENotionsEntities();

        // GET: pattern
        public ActionResult Pattern()
        {
            return View();
        }

       
    }
}
