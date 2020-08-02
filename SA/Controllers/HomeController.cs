using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SA.Models;

namespace SA.Controllers
{
    public class HomeController : Controller
    {
        public IStringLocalizer<Resource> localizer;

        public HomeController(IStringLocalizer<Resource> localizer) {
            this.localizer = localizer;
        }

        public IActionResult SetCulture(string culture, string sourceUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                }
                );

            return Redirect(sourceUrl);
        }

        public IActionResult Index()
        {
            //ViewBag.teststring = localizer["Make"];

            return View();
        }
        [HttpPost] //startuje se samo kada je zahtjev post
        //public IActionResult Index(Car car)
        //{
            
        //    /*
        //    Car car = new Car();
        //    car.Make = Make;
           
        //    */

        //    if (ModelState.IsValid) //akt validacione atribute nad poljima obj
        //    {
        //         Auto.AddCar(car);

        //         TempData["Make"] = car.Make;

        //         return RedirectToAction("Index"); 
        //    }
        //    else
        //    {
        //        return View();
        //        //vraca na isti pogled
        //    }
           

        //}
        
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int id)
        {
            using (TESTCARContext cr = new TESTCARContext())
            {
                cr.Car.Remove(cr.Car.FirstOrDefault(e => e.Id == id));
                cr.SaveChanges();

            }
            
            

            return RedirectToAction("Index");
            
        }

        //public IActionResult CarDetails(string ic)
        //{
        //    TESTCARContext db = new TESTCARContext();
        //    Car car = (Car)db.Car.Where(p => p.Make.ToLower().Equals(ic.ToLower()));

        //    if(car == null)
        //    {
        //        return NotFound();
        //    }

        //    return View("PageCar",car);
        //}
    }
}