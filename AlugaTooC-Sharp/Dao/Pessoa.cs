using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Dao
{
    public class Pessoa
    {
        public void cadastraPessoa(String nome,String date, int fkIdEndereco, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("INSERT INTO public.pessoa(nome, nascimento, fkIdEndereco) VALUES ('"+nome+"', '"+date+"', '"+fkIdEndereco+"')", con);
            script.ExecuteNonQuery();
        }
        public int getUltimoRegistro(NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("select max(idPessoa) from pessoa", con);
            int result = 0;
            NpgsqlDataReader reader = script.ExecuteReader();
            while (reader.Read())
            {
                result = Convert.ToInt32(reader.GetInt32(0));
            }
            reader.Close();
            return result;
        }
    }
}