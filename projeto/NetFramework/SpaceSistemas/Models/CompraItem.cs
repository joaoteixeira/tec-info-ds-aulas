using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSistemas.Models
{
    class CompraItem
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public double Valor { get; set; }

        public double ValorTotal { get; set; }

        public Produto Produto { get; set; }
    }
}
