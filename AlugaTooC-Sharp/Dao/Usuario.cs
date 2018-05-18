using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugaTooC_Sharp.Dao
{
    public class Usuario
    {
        public void adicionaEstado(String nome, String uf, NpgsqlConnection con)
        {
            NpgsqlCommand query = new NpgsqlCommand("INSERT INTO public.estados(nome, uf)VALUES ('" + nome + "', '" + uf + "' )", con);
            query.ExecuteNonQuery();
        }
        public String verificaUsuario(String usuario, NpgsqlConnection con)
        {
            //String email;
            NpgsqlCommand query = new NpgsqlCommand("select email from usuario where email = '" + usuario + "'");
            NpgsqlDataReader retorno = query.ExecuteReader();
            //retorno.Read();
            
            //email = retorno["email"].ToString();
            
            return retorno["email"].ToString();
        }
    }
}