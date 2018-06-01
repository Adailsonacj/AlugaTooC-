using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Models
{
    public class EstadoModel
    {
        public int Id { get; private set; }
        public String Nome { get; private set; }
        public String Uf { get; private set; }
        public EstadoModel(int Id, String Nome, String Uf)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Uf = Uf;
        }
    }
}