using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugaTooC_Sharp.Controllers
{
    public class PrivadasController : Controller
    {
        // GET: Privadas
        public ActionResult PaginaUsuario()
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
            /*
            LoginController login = new LoginController();
            return login.validaSessao();            
            */
        }
        public void btnPaginaUsuario(String btn)
        {
            if (btn.Equals("ALUGAR PRODUTO"))
            {
                Response.Redirect("~/Home/Index");
            }
        }
        public ActionResult CadastroProduto()
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
        public void AlteraEmail(String usuario, String senha)
        {
            if (usuario.Equals("adailson"))
            {
                Response.Redirect("~/Home/Index");
            }
        }
    }
}