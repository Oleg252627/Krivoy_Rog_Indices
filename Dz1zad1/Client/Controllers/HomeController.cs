using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client.Models;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        
        private Singelton singelton = Singelton.Instens;
        // GET: Home
        [HandleError(ExceptionType = typeof(Exception), View = "DivadError")]
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Table_index()
        {
            try
            {
               string str = singelton.Client("index");
                singelton.Index_Name(str);
                return View(singelton.IndeList);
            }
            catch (Exception e)
            {
                return View("DivadError");
            }
           
        }
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            var index = singelton.IndeList.Find(z => z.Id == id);
            if (index == null)
            {
                return View("Index");
            }

            try
            {
                ViewBag.Name_index = index.Name_Index;
                string str=singelton.Client(index.Name_Index);
                singelton.Street_Name(str);
                return View(singelton.StreetList);
            }
            catch (Exception e)
            {
                return View("DivadError");
            }
        }
      
        [HttpGet]
        public ActionResult Serch_for_Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Serch_for_Index(Index ind)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    string str= singelton.Client(ind.Name_Index);
                    singelton.Street_Name(str);
                    return RedirectToAction("Deteils_Serch",ind);
                }
                catch (Exception e)
                {
                    return View("DivadError");
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Deteils_Serch(Index ind)
        {
            ViewBag.Name_index = ind.Name_Index;
            return View(singelton.StreetList);
        }

        public ActionResult DivadError()
        {
            return View();
        }
    }
}