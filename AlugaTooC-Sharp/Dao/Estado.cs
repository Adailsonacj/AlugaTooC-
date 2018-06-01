using AlugaTooC_Sharp.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
        public List<EstadoModel> getEstados(NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("SELECT * FROM estados", con);
            List<EstadoModel> result = new List<EstadoModel>();
            NpgsqlDataReader reader = script.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new EstadoModel(reader.GetInt32(0), reader["nome"].ToString(), reader["uf"].ToString()));

            }
            reader.Close();
            return result;
        }
    }
}