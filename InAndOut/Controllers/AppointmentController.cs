using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class AppointmentController : Controller
    {

        //http://localhost:45672/appoinrment/index
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            return Ok("you have entered id = {id}" + id);
        }
    }
}
