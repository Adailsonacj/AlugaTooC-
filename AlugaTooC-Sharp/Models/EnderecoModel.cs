using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaTooC_Sharp.Models
{
    public class EnderecoModel
    {
        public int cidade {  get; private set; }
        public int estado { get; private set; }
        public String bairro { get; private set; }
        public String logradouro { get; private set; }
        public int numero { get; private set; }
        public EnderecoModel (int estado, int cidade, String bairo, String logradouro, int numero)
        {
            this.estado = estado;
            this.cidade = cidade;
            this.bairro = bairro;
            this.logradouro = logradouro;
            this.numero = numero;
        }

    
    }
}