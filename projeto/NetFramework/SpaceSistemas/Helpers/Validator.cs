using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceSistemas.Models;
using FluentValidation;

namespace SpaceSistemas.Helpers
{
    static class Validator
    {
        /*
        public bool Validate(object validator, object obj)
        {
            var result = validator.Validate(obj);

            if (!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach (var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";
                }

                MessageBox.Show(errors, "Validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return result.IsValid;
        }
        */
    }
}
