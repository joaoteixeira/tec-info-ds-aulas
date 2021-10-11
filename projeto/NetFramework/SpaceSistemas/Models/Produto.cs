using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSistemas.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Unidade { get; set; }

        public Double ValorCompra { get; set; }

        public Double ValorVenda { get; set; }

        private bool _selected = false;

        public bool IsSelected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
    }
}
