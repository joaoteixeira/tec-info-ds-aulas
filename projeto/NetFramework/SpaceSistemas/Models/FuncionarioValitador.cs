using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SpaceSistemas.Models
{
    class FuncionarioValitador : AbstractValidator<Funcionario>
    {
        public FuncionarioValitador()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo `Nome` é Obrigatório. Favor Preencher");
            RuleFor(x => x.CPF).NotEqual("___.___.___-__").WithMessage("O campo `CPF` é obrigatório. Favor Preencher");
            RuleFor(x => x.CPF).Must(CPFValidator).WithMessage("CPF inválido");
        }

        public bool CPFValidator(string cpf)
        {
            return true;
        }
    }
}
