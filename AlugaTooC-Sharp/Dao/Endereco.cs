using Npgsql;
using System;
using System.Data.SqlClient;

namespace AlugaTooC_Sharp.Dao
{
    public class Endereco
    {
        public void cadastraEndereco(String bairro, int numero, String logradouro, int fkIdCidade, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("INSERT INTO public.endereco(bairro, numero, logradouro, fkIdCidade) VALUES ('" + bairro + "', '" + numero + "', '" + logradouro + "', '" + fkIdCidade + "')", con);
            script.ExecuteNonQuery();
        }
        public int getUltimoRegistro(NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("select max(IdEndereco) from endereco", con);
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