using Npgsql;
using System;

namespace AlugaTooC_Sharp.Dao
{
    public class Usuario
    {

        public String verificaUsuario(String usuario, String senha, NpgsqlConnection con)
        {
            NpgsqlCommand query = new NpgsqlCommand("select usuario from usuario where usuario = '" + usuario + "' AND senha = '" + senha + "'", con);

            NpgsqlDataReader reader = query.ExecuteReader();
            String result = null;
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
                result = reader.GetString(0);
            }
            reader.Close();
            return result;
        }
        public int getIdPessoaF(String usuario, String senha, NpgsqlConnection con)
        {
            NpgsqlCommand query = new NpgsqlCommand("select fkIdPessoaF from usuario where usuario = '" + usuario + "' and senha = '" + senha + "'  ", con);

            NpgsqlDataReader reader = query.ExecuteReader();
            int result = 0;
            while(reader.Read())
            {
                result = Convert.ToInt32(reader.GetInt32(0));
            }
            reader.Close();
            return result;
        }
        public void cadastraUsuario(String usuario, String senha, int fkIdPessoaF, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("INSERT INTO public.usuario(usuario, senha, fkIdPessoaF) VALUES ('" + usuario + "', '" + senha + "','" + fkIdPessoaF + "')", con);
            script.ExecuteNonQuery();
        }
        public void alteraUsuario(String usuarioAtual, String usuarioNovo, String senha, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("update public.usuario set usuario = '"+usuarioNovo+"' where usuario = '"+usuarioAtual+"' and senha = '"+senha+"'", con);
            script.ExecuteNonQuery();
        }
    }
}