using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Dao
{
    public class PessoaFisica
    {
        public void cadastraPessoaFisica(int cpf, int rg, int fkIdPessoa, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("INSERT INTO public.pessoaFisica(cpf, rg, fkIdPessoa) VALUES ('" + cpf + "', '" + rg + "', '" + fkIdPessoa + "')", con);
            script.ExecuteNonQuery();
        }
    }
}