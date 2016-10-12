using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class AnimalController : Controller
    {
        private ZooRepository repo = new ZooRepository();
        // GET: Animal
        public ActionResult Index()
        {

            ViewBag.Animals = repo.GetAnimals();
            
            //List<string> animals = new List<string> {"Zerba", "Potato", "Foot"};
            //ViewBag.Animals = animals;
           
            return View();
        }

        // GET: Animal/Details/5
        public ActionResult Details(string id)
        {
            Animal picked_animal = repo.FindAnimalByName(id);

            ViewBag.Animals = picked_animal;

            return View();
        }

    }
}
