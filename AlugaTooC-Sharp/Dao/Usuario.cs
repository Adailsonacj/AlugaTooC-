using Npgsql;
using System;

namespace AlugaTooC_Sharp.Dao
{
    public class Usuario
    {
        public NpgsqlDataReader NpgsqlCopyTextReader { get; private set; }

        public String verificaUsuario(String usuario, String senha, NpgsqlConnection con)
        {
            NpgsqlCommand query = new NpgsqlCommand("select usuario from usuario where usuario = '" + usuario + "' AND senha = '" + senha + "'", con);

            var reader = query.ExecuteReader();
            String result = null;
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
                result = reader.GetString(0);
            }
            return result;
        }
        public void cadastraUsuario(String usuario, String senha, int fkIdPessoaF, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("INSERT INTO public.usuario(usuario, senha, fkIdPessoaF) VALUES ('" + usuario + "', '" + senha + "','" + fkIdPessoaF + "')", con);
            script.ExecuteNonQuery();
        }
    }
}