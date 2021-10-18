using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSistemas.Models
{
    class Compra
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string FormaPagamento { get; set; }

        public double ValorTotal { get; set; }

        public Funcionario Funcionario { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public List<CompraItem> Itens { get; set; } = new List<CompraItem>();
    }
}
