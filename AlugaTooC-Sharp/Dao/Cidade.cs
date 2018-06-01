using AlugaTooC_Sharp.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Dao
{
    public class Cidade
    {
        public List<CidadeModel> getCidades(int idEstado, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("SELECT * FROM cidades where fkIdEstado = '"+idEstado+"'", con);
            List<CidadeModel> result = new List<CidadeModel>();
            NpgsqlDataReader reader = script.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new CidadeModel(reader.GetInt32(0), reader["nome"].ToString()));

            }
            reader.Close();
            return result;
        }
    }
}