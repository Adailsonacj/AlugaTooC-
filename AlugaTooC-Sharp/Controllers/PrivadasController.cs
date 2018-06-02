using AlugaTooC_Sharp.Dao;
using AlugaTooC_Sharp.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugaTooC_Sharp.Controllers
{
    public class PrivadasController : Controller
    {
        public static String caminhoImagem;
        public static String path = "";
        public static HttpPostedFileBase file;

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
                ViewBag.EmailSession = Session["usuario"];
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
                Conexao con = new Conexao();
                Produto pr = new Produto();
                var co = con.conecta();
                ViewBag.ListCategoria = pr.getCategorias(co);
                con.desconecta();
                return View();
            }
        }
        [HttpPost]
        public void EnvioImagem(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg" || Path.GetExtension(file.FileName).ToLower() == ".png" || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        PrivadasController.path = Path.Combine(Server.MapPath("~/Imagens"), file.FileName);
                        PrivadasController.file = file;
                        PrivadasController.caminhoImagem = "~/Imagens/" + file.FileName + "";
                        Response.Redirect("~/Privadas/CadastroProduto");
                    }
                }
            }
        }
        public void CadastroProdutoSucesso(int categoria, String nome, String descricao, int valor)
        {
            Conexao con = new Conexao();
            var co = con.conecta();
            Produto pr = new Produto();
            PrivadasController.file.SaveAs(PrivadasController.path);
            pr.CadastroProduto(nome, descricao, valor, Convert.ToInt32(Session["idPessoaF"].ToString()), categoria, PrivadasController.caminhoImagem, co);
            con.desconecta();
            Response.Redirect("~/Privadas/PaginaUsuario");
        }
        public ActionResult MeusProdutos()
        {
            Conexao con = new Conexao();
            Produto pr = new Produto();
            var getProdutos = pr.getProdutosId(Convert.ToInt32(Session["idPessoaF"].ToString()), con.conecta());
            con.desconecta();
            return View(getProdutos);
        }
        public void removeProduto(int id)
        {
            Conexao con = new Conexao();
            Produto pr = new Produto();
            pr.removeProduto(id, con.conecta());
            con.desconecta();
            Response.Redirect("~/Privadas/MeusProdutos");
        }
        public void AlteraEmail(String usuario, String senha)
        {
            Conexao con = new Conexao();
            Usuario us = new Usuario();
            us.alteraUsuario(Session["usuario"].ToString(), usuario, senha, con.conecta());
            Session["usuario"] = usuario;
            con.desconecta();
            Response.Redirect("~/Privadas/PaginaUsuario");
        }
        public void PaginaLogOut()
        {
            Session.Clear();
            Response.Redirect("~/Home/Index");
        }
    }
}