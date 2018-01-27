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
            List<Models.PadawanReportModel> items = new List<Models.PadawanReportModel>();

            using (Models.Entities context = new Models.Entities())
            {
                var query = context.Lesson.GroupBy(item => item.Padawann.Name);

                foreach (var item in query)
                {
                    items.Add(new Models.PadawanReportModel
                    {
                        PadawanName = item.Key,
                        Average = item.Average(lesson => lesson.Value)
                    });
                }
            }

            return View(items);
        }

        public ActionResult Index2()
        {
            List<Models.PadawanReportModel> items = null;

            using (Models.Entities context = new Models.Entities())
            {
                items = context.GetPadawanAverage()
                               .ToList()
                               .Select(item => new Models.PadawanReportModel() { PadawanName = item.Name,
                                                                                 Average = item.Average.GetValueOrDefault(0) })
                               .ToList();
            }

            return View(items);
        }
    }
}