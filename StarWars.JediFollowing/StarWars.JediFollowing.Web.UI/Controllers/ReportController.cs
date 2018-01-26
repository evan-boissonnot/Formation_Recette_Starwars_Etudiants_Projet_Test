using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarWars.JediFollowing.Web.UI.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}