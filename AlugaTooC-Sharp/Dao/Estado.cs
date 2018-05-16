using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Dao
{
    public class Estado
    {
        public void adicionaEstado(String nome, String uf, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("INSERT INTO public.estados(nome, uf)VALUES ("+nome+", "+uf+")", con);
            script.ExecuteNonQuery();
        }
    }
}