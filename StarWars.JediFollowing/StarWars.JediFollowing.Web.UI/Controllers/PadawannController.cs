using StarWars.JediFollowing.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace StarWars.JediFollowing.Web.UI.Controllers
{
    public class PadawannController : Controller        
    {
        public ActionResult Index()
        {
            using (Models.Entities context = new Entities())
            {
                var query = context.Padawann.OrderBy(item => item.Name).ToList();
                return View(query.ToList());
            }
        }

        public ActionResult Index2()
        {
            using (Models.Entities context = new Entities())
            {
                var query = context.Padawann
                                   .Include("Planet")
                                   .OrderBy(item => item.Name).ToList();
                return View(query.ToList());
            }
        }

        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Add(Models.Padawann model)
        {
            using (Models.Entities context = new Entities())
            {
                Planet planetData = context.Planet.FirstOrDefault(planet => planet.Label == model.PlanetName);

                if (planetData == null)
                    planetData = new Planet()
                    {
                        Label = model.PlanetName
                    };

                model.Planet = planetData;

                context.Padawann.Add(model);
                context.SaveChanges();
            }

            return this.View();
        }
    }
}