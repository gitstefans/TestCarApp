using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Models;

namespace SA.Controllers
{
    public class CarPageController : Controller
    {

        //public ActionResult CarPage(int id)
        //{
        //    using (TESTCARContext cr = new TESTCARContext())
        //    {
                
        //        cr.Car.Select(cr.Car.FirstOrDefault(e => e.Id == id));
        //        cr.SaveChanges();

        //    }
        //    return View();
        //}


        [HttpGet]
        public ActionResult carPage(int id)
        {
            
            //Car car = Auto.GetCar(id);
           //TempData["srdjan"] = car.Id;
            //TempData["stefan"] = car.Model;
            //ViewData["ja"] = car;            
            ViewData["specific_car"] = Auto.GetCar(id);
            
            


            return View("carPage");

        }


    }
}