using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using SA.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace SA.Controllers
{
    [Authorize]
    public class AddCarsController : Controller
    {
        private IConfiguration _configuration;
        private IHostingEnvironment _hostingEnvironment;

        public AddCarsController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Cars()
        {
            

            return View(new Car());
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                if (car.ImageUpload != null && car.ImageUpload.Length > 0)
                {
                    string basePath = _configuration["FileUploads"];
                    string originalName = car.ImageUpload.FileName;
                    string uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(originalName);
                    string path = Path.Combine(
                        _hostingEnvironment.WebRootPath,
                        basePath,
                        uniqueName);
                    using (FileStream fs = new FileStream(path, FileMode.CreateNew))
                    {
                        car.ImageUpload.CopyToAsync(fs);
                    }
                    car.OriginalImageName = originalName;
                    car.Image = uniqueName;
                }
                Auto.AddCar(car);
                TempData["Make"] = car.Make;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }
        
    }
}