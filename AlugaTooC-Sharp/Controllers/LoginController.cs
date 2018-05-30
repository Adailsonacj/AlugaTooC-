using AlugaTooC_Sharp.Dao;
using AlugaTooC_Sharp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugaTooC_Sharp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ViewResult validaSessao()
        {
            var vrSession = Session["usuario"];
            if (vrSession == null)
            {
                Response.Redirect(("~/Home/Login"));
                return null;
            }
            else
            {
                return View();
            }

        }
        
    }
}