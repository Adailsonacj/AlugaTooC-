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
            con.Open();
            return con;
        }
        public void desconecta()
        {
            con.Close();
        }
    }
}