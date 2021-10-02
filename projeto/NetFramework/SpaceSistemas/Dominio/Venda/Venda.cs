using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceSistemas.Dominio.Venda
{
    public class Venda
    {
        public int Id { get; set; }

        public string Cliente { get; set; }

        public int QuantidadeProdutos { get; set; }

        public double ValorTotal { get; set; }

        public string Situacao { get; set; }

    }
}
