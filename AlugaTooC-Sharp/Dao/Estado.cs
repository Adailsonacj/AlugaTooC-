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
            NpgsqlCommand script = new NpgsqlCommand("INSERT INTO public.estados(nome, uf)VALUES ('" + nome + "', '" + uf + "' )", con);
            script.ExecuteNonQuery();
        }
        public List<String> getEstados(NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("SELECT * FROM estados", con);
            List<String> result = null;
            var reader = script.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader.GetString(0));

                //result = reader.GetString(0);
            }
            return result;
        }
    }
}