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
            return View();
        }

        public ActionResult About()
        {
            Conexao con = new Conexao();

            Estado es = new Estado();
            es.adicionaEstado("Grosélia", "GA", con.conecta());


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
        public ActionResult formCidadesEstados()
        {
            /*Conexao con = new Conexao();
            Estado es = new Estado();
            
            ViewBag.Message = es.getEstados(con.conecta()).ToString();
            */
            return View();
        }
        public void EfetuaLogin(String usuario, String senha)
        {
            Conexao con = new Conexao();
            Usuario us = new Usuario();
            if (us.verificaUsuario(usuario, senha, con.conecta()) != null)
            {
                //this.Session.Add(usuario, );
                Response.Redirect("~/Home/Index");

            }
            Response.Redirect("~/Home/Login");
           
        }
        public ActionResult formCadastroPessoa(int estado, int cidade, String bairro, String logradouro, int numero)
        {
            if (estado == 0 && cidade == 0 && bairro == null && logradouro == null && numero == 0)
            {
                Response.Write("Os campos não podem estar vazios!");
                return null;
            }
            else
            {
                HomeController.estado = estado;
                HomeController.cidade = cidade;
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
                            }
                        }
                    }
                }
            }
            con.desconecta();

            return View();
        }
    }
}