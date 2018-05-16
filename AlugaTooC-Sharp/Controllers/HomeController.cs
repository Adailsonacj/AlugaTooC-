using AlugaTooC_Sharp.Dao;
using AlugaTooC_Sharp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugaTooC_Sharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            Conexao con = new Conexao();

            Estado es = new Estado();
            es.adicionaEstado("Estado Novo", "EN", con.conecta());


            ViewBag.Message = "Só aqui no AlugaToo.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contato.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult formCadastroEndereco()
        {
            return View();
        }
        public ActionResult formCadastroPessoa()
        {
            return View();
        }
        public ActionResult formCadastroUsuario()
        {
            return View();
        }
        public ActionResult formCidadesEstados()
        {
            return View();
        }
    }
}