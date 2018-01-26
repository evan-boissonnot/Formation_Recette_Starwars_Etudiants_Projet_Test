using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarWars.JediFollowing.Web.UI.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult Add()
        {
            using (Models.Entities context = new Models.Entities())
            {
                this.SetPadawanList(context);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Add(Models.Lesson model)
        {
            using (Models.Entities context = new Models.Entities())
            {
                model.CreatedDate = DateTime.Now;
                model.LessonDate = DateTime.Now;

                context.Lesson.Add(model);
                context.SaveChanges();

                this.SetPadawanList(context);
            }

            return this.View();
        }

        private void SetPadawanList(Models.Entities context)
        {
            this.ViewBag.PadawanList = context.Padawann.OrderBy(item => item.Name).ToList();
        }
    }
}