using Npgsql;

namespace AlugaTooC_Sharp.Database
{
    public class Conexao
    {
        string connection = "Server=localhost;Port=5433;Database=alugatoo;User Id=postgres;Password=root;";
        NpgsqlConnection con = new NpgsqlConnection();

        public NpgsqlConnection conecta()
        {
            con.ConnectionString = connection;
            //NpgsqlCommand script = new NpgsqlCommand("INSERT INTO public.estados(nome, uf)VALUES ('teste final', 'tf')", con);
            con.Open();
           // script.ExecuteNonQuery();
           /* if (con.State == ConnectionState.Open)
            {
            }
            */
            return con;
        }
        public void desconecta()
        {
            con.Close();
        }
    }
}