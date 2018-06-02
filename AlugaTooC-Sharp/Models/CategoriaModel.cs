using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Models
{
    public class CategoriaModel
    {
        public String Nome { get; private set; }
        public int Id { get; private set; }
        public CategoriaModel(int Id, String Nome)
        {
            this.Nome = Nome;
            this.Id = Id;
        }
    }
}