using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class HabitatController : Controller
    {
        private ZooRepository repo = new ZooRepository();

        // GET: Habitat
        public ActionResult Index()
        {
            ViewBag.Habitats = repo.GetHabitats();

            return View();
        }

        // GET: Habitat/Details/5
        public ActionResult Details(int id)
        {
            Habitat picked_habitat = repo.FindHabitatById(id);
            ViewBag.Habitats = picked_habitat;
            return View();
        }

    }
}
