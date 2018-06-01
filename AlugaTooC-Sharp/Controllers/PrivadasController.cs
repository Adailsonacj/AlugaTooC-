using AlugaTooC_Sharp.Dao;
using AlugaTooC_Sharp.Database;
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
        public ActionResult CadastroProdutoSucesso()
        {
            return View();
        }
        public ActionResult MeusProdutos()
        {
            return View();
        }
        public void AlteraEmail(String usuario, String senha)
        {
            Conexao con = new Conexao();
            Usuario us = new Usuario();
            us.alteraUsuario(Session["usuario"].ToString(), usuario, senha, con.conecta());
            Response.Redirect("~/Privadas/PaginaUsuario");
        }
        public void PaginaLogOut()
        {
            Session.Clear();
            Response.Redirect("~/Home/Index");
        }
    }
}