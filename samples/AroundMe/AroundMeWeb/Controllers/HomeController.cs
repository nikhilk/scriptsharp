// HomeController.cs
//

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AroundMeWeb.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            var apiKeys = new {
                flickrApiKey = ConfigurationManager.AppSettings["flickrApiKey"],
                bingMapsKey = ConfigurationManager.AppSettings["bingMapsKey"],
                tileUrl = ConfigurationManager.AppSettings["tileUrl"]
            };
            return View(apiKeys);
        }
    }
}
