using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugaTooC_Sharp.Dao
{
    public class Usuario
    {
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
        }
    }
}