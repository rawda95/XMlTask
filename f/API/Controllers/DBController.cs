using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IXmlFileServices xmlFileServices;
        public DBController(IWebHostEnvironment _env, IXmlFileServices xmlFileServices)
        {
            this._env = _env;
            this.xmlFileServices = xmlFileServices;
        }


        [HttpGet]
        [Route("GetAppsDBName")]
        public IActionResult GetAppsDBName()
        {
            XMLFile xml01 = new XMLFile(_env.ContentRootPath + "/XMlFiles/01/App.config.xml");
            XMLFile xml02 = new XMLFile(_env.ContentRootPath + "/XMlFiles/02/App.config.xml");

            var DBNameOf01 = this.xmlFileServices.ReadKey(xml01, "DB");
            var DBNameOf02 = this.xmlFileServices.ReadKey(xml02, "DB");

            return Json(new { App01 = DBNameOf01, App02 = DBNameOf02 });




        }
    }
}