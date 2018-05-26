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
        public ActionResult EfetuaLogin(String usuario, String senha)
        {
            Conexao con = new Conexao();
            Usuario us = new Usuario();
            if(us.verificaUsuario(usuario, senha, con.conecta()) != null)
            {
                return View();
            }
            return null;
        }
        public ActionResult formCadastroPessoa(int estado, int cidade, String bairro, String logradouro, int numero)
        {
            Conexao con = new Conexao();
            Endereco en = new Endereco();
            en.cadastraEndereco(bairro, numero, logradouro, cidade, con.conecta());
            con.desconecta();
            return View();
        }
        public ActionResult CadastraPessoa(String nome, String nascimento)
        {
            Endereco en = new Endereco();
            Conexao con = new Conexao();
            Pessoa pe = new Pessoa();
            pe.cadastraPessoa(nome, nascimento, en.getUltimoRegistro(con.conecta()), con.conecta());
            //PessoaFisica pf = new PessoaFisica();
            //pf.cadastraPessoaFisica(cpf, rg, pe.getUltimoRegistro(con.conecta()), con.conecta());
            return View();
        }
    }
}