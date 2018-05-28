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

        EnderecoModel endereco;

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
            if (us.verificaUsuario(usuario, senha, con.conecta()) != null)
            {
                return View();
            }
            return null;
        }
        public ActionResult formCadastroPessoa(int estado, int cidade, String bairro, String logradouro, int numero)
        {
            HomeController.estado = estado;
            HomeController.cidade = cidade;
            HomeController.bairro = bairro;
            HomeController.logradouro = logradouro;
            HomeController.numero = numero;
            return View();
        }
        public ActionResult CadastroSucesso(String nome, String nascimento)
        {
            Endereco en = new Endereco();
            Conexao con = new Conexao();
            Pessoa pe = new Pessoa();
            NpgsqlConnection co = con.conecta();
            //en.cadastraEndereco(HomeController.bairro, HomeController.numero, HomeController.logradouro, HomeController.cidade, co);
            var ultimoEndereco = en.getUltimoRegistro(co);

            pe.cadastraPessoa(nome, nascimento, ultimoEndereco, co);


            //PessoaFisica pf = new PessoaFisica();
            //pf.cadastraPessoaFisica(cpf, rg, pe.getUltimoRegistro(con.conecta()), con.conecta());
            con.desconecta();

            return View();
        }
    }
}