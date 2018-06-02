using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Models
{
    public class ProdutoModel
    {
        public int Id { get; private set; }
        public String Nome { get; private set; }
        public String Descricao { get; private set; }
        public Decimal valor { get; private set; }
        public int idCategoria { get; private set; }
        public String caminhoImagem { get; private set; }

        public ProdutoModel(int Id, String Nome, String Descricao, Decimal valor, int idcategoria, String caminhoImagem)
        {
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.valor = valor;
            this.idCategoria = idCategoria;
            this.caminhoImagem = caminhoImagem;
            this.Id = Id;
        }
    }
}