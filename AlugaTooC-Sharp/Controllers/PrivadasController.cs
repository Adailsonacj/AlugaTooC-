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
            return View();
        }
        public void btnPaginaUsuario(String btn)
        {
            if (btn.Equals("alugarProduto"))
            {
                Response.Redirect("~/Home/Index");
            }
        }
        public ActionResult CadastroProduto()
        {
            return View();
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