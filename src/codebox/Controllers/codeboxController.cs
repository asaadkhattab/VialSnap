using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace codebox.Controllers
{
    public class codeboxController : Controller
    {
        public ActionResult Template()
        {
            return View();
        }
    }
}