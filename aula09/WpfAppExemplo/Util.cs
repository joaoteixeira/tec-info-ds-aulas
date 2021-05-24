using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WpfAppExemplo
{
    class Util
    {
        public static bool IsEmail(string text)
        {
            bool blnValidEmail = false;
            Regex regEMail = new Regex(@"^[a-zA-Z][\w\.-]{1,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (text.Length > 0)
                blnValidEmail = regEMail.IsMatch(text);


            return blnValidEmail;
        }

        public static bool IsCPF(string text)
        {
            //TODO Código para verificar CPF

            return true;
        }


    }
}
