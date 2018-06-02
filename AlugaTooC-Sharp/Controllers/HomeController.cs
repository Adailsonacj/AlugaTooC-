using AlugaTooC_Sharp.Dao;
using AlugaTooC_Sharp.Database;
using AlugaTooC_Sharp.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugaTooC_Sharp.Controllers
{
    public class HomeController : Controller
    {
        public static int estado;
        public static int cidade;
        public static String bairro;
        public static String logradouro;
        public static int numero;
        public static int lerolero = 4000;

        public ActionResult Index()
        {
            Conexao con = new Conexao();
            Produto pr = new Produto();
            var listProdutos = pr.getProdutos(con.conecta());
            return View(listProdutos);
        }
        public ActionResult About()
        {
            Conexao con = new Conexao();

            Estado es = new Estado();


            //ViewBag.Message = "Só aqui no AlugaToo.";
            ViewBag.Message = es.getEstados(con.conecta())[14].Id;

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
        public ActionResult formEndereco(int cidade)
        {
            Conexao con = new Conexao();
            var co = con.conecta();
            HomeController.cidade = cidade;

            return View();
        }
        public ActionResult ListaCidade(int id)
        {
            Cidade ci = new Cidade();
            Conexao con = new Conexao();
            var co = con.conecta();
            return Json(ci.getCidades(27, co));
        }
        public ActionResult formEstado()
        {
            Conexao con = new Conexao();
            Estado es = new Estado();
            ViewBag.Model = es.getEstados(con.conecta());
            return View();
        }
        public ActionResult formCidades(int estado)
        {
            HomeController.estado = estado;
            Conexao con = new Conexao();
            Cidade ci = new Cidade();
            ViewBag.Model = ci.getCidades(estado, con.conecta());
            return View();
        }
        public void EfetuaLogin(String usuario, String senha)
        {
            Conexao con = new Conexao();
            Usuario us = new Usuario();
            var co = con.conecta();
            if (us.verificaUsuario(usuario, senha, co) != null)
            {
                Session["usuario"] = usuario;
                Session["senha"] = senha;
                Session["idPessoaF"] = us.getIdPessoaF(usuario, senha, co);

                //return View();
                Response.Redirect("~/Home/Index");

            }
            else
            {
                Session["usuario"] = null;
                Session["senha"] = null;
                //return null;
                Response.Redirect("~/Home/Login");
            }

        }
        public ActionResult formCadastroPessoa(String bairro, String logradouro, int numero)
        {
            if (bairro == null && logradouro == null && numero == 0)
            {
                Response.Write("Os campos não podem estar vazios!");
                return null;
            }
            else
            {
                HomeController.bairro = bairro;
                HomeController.logradouro = logradouro;
                HomeController.numero = numero;
                return View();
            }
        }
        public ActionResult CadastroSucesso(String nome, String nascimento, Int64 cpf, Int64 rg, String usuario, String senha, String senha1)
        {
            Conexao con = new Conexao();
            Endereco en = new Endereco();
            Pessoa pe = new Pessoa();
            PessoaFisica pf = new PessoaFisica();
            Usuario us = new Usuario();
            NpgsqlConnection co = con.conecta();
            if (HomeController.bairro != null && HomeController.numero != 0 && HomeController.logradouro != null && HomeController.cidade != 0)
            {
                if (nome != null && nascimento != null)
                {
                    if (cpf != 0 && rg != 0)
                    {
                        if (usuario != null && senha != null)
                        {
                            if (senha == senha1)
                            {
                                en.cadastraEndereco(HomeController.bairro, HomeController.numero, HomeController.logradouro, HomeController.cidade, co);
                                pe.cadastraPessoa(nome, nascimento, en.getUltimoRegistro(co), co);
                                pf.cadastraPessoaFisica(cpf, rg, pe.getUltimoRegistro(co), co);
                                us.cadastraUsuario(usuario, senha, pf.getUltimoRegistro(co), co);
                                ViewBag.Message = true;
                            }
                        }
                    }
                }
            }
            con.desconecta();

            return RedirectToAction("Index");
        }
    }
}