using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TRbooks.Models;

namespace TRbooks.Controllers
{
    public class RentalsController : Controller
    {
        [Authorize(Roles =RoleName.CanManageBooks)]
        public ActionResult New()
        {
            return View();
        }
    }
}