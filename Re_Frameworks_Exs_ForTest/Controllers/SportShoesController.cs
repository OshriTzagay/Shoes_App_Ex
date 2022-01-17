using Re_Frameworks_Exs_ForTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Re_Frameworks_Exs_ForTest.Controllers
{
    public class SportShoesController : Controller
    {
        public static List<SportShoe> shoeList = new List<SportShoe>()
        {
            new SportShoe(1,"Nikey","Jordan",41,5000),
            new SportShoe(2,"Adidas","Stansmith",45,400),
            new SportShoe(3,"Puma","ClassicPumaz",38,500),
            new SportShoe(4,"Rebook","RerereBok",44,3500),
        };
        // GET: SportShoes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowShoeBrand()
        {
            ViewBag.ShoeBrand = shoeList[0].Brand;
            return View();
        }
        public ActionResult ShowShoeInfo(int id)
        {
            foreach (var shoe in shoeList)
            {
                if (shoe.Id == id)
                {
                    return View(shoe);
                }
            }
            return View("No Id Found.");
        }
        public ActionResult ShowAllShoes()
        {
            return View(shoeList);
        }
    }
}