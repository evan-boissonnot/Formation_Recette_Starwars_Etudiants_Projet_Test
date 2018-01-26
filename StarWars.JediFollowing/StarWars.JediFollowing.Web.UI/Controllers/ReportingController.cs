using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarWars.JediFollowing.Web.UI.Controllers
{
    public class ReportingController : Controller
    {
        public ActionResult Index()
        {
            List<dynamic> items = new List<dynamic>();

            using (Models.Entities context = new Models.Entities())
            {
                var query = context.Lesson.GroupBy(item => item.Padawann.Name);

                foreach (var item in query)
                {
                    items.Add(new
                    {
                        PadawanName = item.Key
                    });
                }
            }

            return View();
        }
    }
}