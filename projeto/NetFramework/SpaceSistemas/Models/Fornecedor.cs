using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSistemas.Models
{
    class Fornecedor
    {
        public int Id { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public string Telefone { get; set; }

        public string Representante { get; set; }
    }
}
