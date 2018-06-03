using AlugaTooC_Sharp.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Dao
{
    public class Produto
    {
        public List<CategoriaModel> getCategorias(NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("SELECT * FROM categoriaProduto", con);
            List<CategoriaModel> result = new List<CategoriaModel>();
            NpgsqlDataReader reader = script.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new CategoriaModel(reader.GetInt32(0), reader["nome"].ToString()));

            }
            reader.Close();
            return result;
        }
        public List<ProdutoModel> getProdutosId(int idPessoaF, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("SELECT * FROM produto where fkIdPessoaF = '"+idPessoaF+"'", con);
            List<ProdutoModel> result = new List<ProdutoModel>();
            NpgsqlDataReader reader = script.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new ProdutoModel(reader.GetInt32(0), reader["nome"].ToString(), reader["descricao"].ToString(), Convert.ToInt32(reader["valor"]), Convert.ToInt32(reader["fkIdCategoria"]), reader["caminhoImagem"].ToString()));

            }
            reader.Close();
            return result;
        }
        public List<ProdutoModel> getProdutos(NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("SELECT * FROM produto", con);
            List<ProdutoModel> result = new List<ProdutoModel>();
            NpgsqlDataReader reader = script.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new ProdutoModel(reader.GetInt32(0), reader["nome"].ToString(), reader["descricao"].ToString(), Convert.ToInt32(reader["valor"]), Convert.ToInt32(reader["fkIdCategoria"]), reader["caminhoImagem"].ToString()));

            }
            reader.Close();
            return result;
        }
        public void CadastroProduto(String nome, String descricao, decimal valor, int fkIdPessoaF, int fkIdCategoria, String caminhoImagem , NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("INSERT INTO public.produto(nome, descricao, valor, fkidpessoaf, fkidcategoria, \"caminhoImagem\") VALUES ('"+nome+"', '"+descricao+"', '"+valor+"','"+fkIdPessoaF+"','"+fkIdCategoria+"', '"+caminhoImagem+"')", con);
            script.ExecuteNonQuery();
        }
        public void removeProduto(int Id, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("delete from public.produto where idProduto = '"+Id+"'", con);
            script.ExecuteNonQuery();
        }
        public List<ProdutoModel> getProdutosCategoria(int categoria, NpgsqlConnection con)
        {
            NpgsqlCommand script = new NpgsqlCommand("SELECT * FROM produto where fkIdCategoria = '"+categoria+"'", con);
            List<ProdutoModel> result = new List<ProdutoModel>();
            NpgsqlDataReader reader = script.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new ProdutoModel(reader.GetInt32(0), reader["nome"].ToString(), reader["descricao"].ToString(), Convert.ToInt32(reader["valor"]), Convert.ToInt32(reader["fkIdCategoria"]), reader["caminhoImagem"].ToString()));

            }
            reader.Close();
            return result;
        }
    }
}