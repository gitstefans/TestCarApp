﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SA.Controllers
{
    //[Authorize]
    public class ContactController : Controller
    {
        public IActionResult contactt()
        {
            return View();
        }
    }
}