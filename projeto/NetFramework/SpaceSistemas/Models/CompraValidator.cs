using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SpaceSistemas.Models
{
    class CompraValidator : AbstractValidator<Compra>
    {
        public CompraValidator()
        {
            RuleFor(x => x.Data).NotEmpty();
            RuleFor(x => x.Funcionario).NotEmpty();
            RuleFor(x => x.Fornecedor).NotEmpty();
            RuleFor(x => x.Itens).NotEmpty().WithMessage("Adicionar no mínimo 1 (um) produto à compra!");
            RuleFor(x => x.FormaPagamento).NotEmpty();
        }
    }
}
