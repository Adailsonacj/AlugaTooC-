using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Models
{
    public class CidadeModel
    {
        public String Nome { get; private set; }
        public int Id { get; private set; }
        public CidadeModel(int Id, String Nome)
        {
            this.Nome = Nome;
            this.Id = Id;
        }
    }
}