using Npgsql;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Data.Common;
=======
>>>>>>> bd7d6b665e68e632b6c6c9013bd3c8d6bc59581f
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugaTooC_Sharp.Dao
{
    public class Usuario
    {
<<<<<<< HEAD
        public NpgsqlDataReader NpgsqlCopyTextReader { get; private set; }

        public String verificaUsuario(String usuario, String senha, NpgsqlConnection con)
        {
            //String email;
            NpgsqlCommand query = new NpgsqlCommand("select usuario from usuario where usuario = '" + usuario + "' AND senha = '"+senha+"'", con);

            var reader = query.ExecuteReader();
            String result = null;
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
                result = reader.GetString(0);
            }
            return result;
=======
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
>>>>>>> bd7d6b665e68e632b6c6c9013bd3c8d6bc59581f
        }
    }
}