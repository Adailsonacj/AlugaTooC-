using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Dao
{
    public class PessoaFisica
    {
        public void cadastraPessoaFisica(Int64 cpf, Int64 rg, int fkIdPessoa, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("INSERT INTO public.pessoaFisica(cpf, rg, fkIdPessoa) VALUES ('" + cpf + "', '" + rg + "', '" + fkIdPessoa + "')", con);
            script.ExecuteNonQuery();
        }
        public int getUltimoRegistro(NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("select max(idpessoaf) from public.pessoafisica", con);
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