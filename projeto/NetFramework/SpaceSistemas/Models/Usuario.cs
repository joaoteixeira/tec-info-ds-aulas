using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSistemas.Models
{
    class Usuario
    {
        public int Id { get; set; }

        public string UsuarioNome { get; set; }

        public string Senha { private get; set; }

        public Funcionario Funcionario { get; set; }

        private static Usuario _instance;
        
        private Usuario() { }

        public static Usuario GetInstance()
        {
            if (_instance == null)
                _instance = new Usuario();

            return _instance;
        }

        public static bool Login(string usuario, string senha)
        {
            var user = new UsuarioDAO().GetByUsuario(usuario, senha);

            if (user != null)
                return true;
            
            return false;
        }

        public static int GetFuncionarioId()
        {
            return _instance.Funcionario.Id;
        }
    }
}
