using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SpaceSistemas.Models
{
    class UsuarioDAO : AbstractDAO<Usuario>
    {
        public Usuario GetByUsuario(string usuarioNome, string senha)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM usuario LEFT JOIN funcionario ON cod_func = cod_func_fk " +
                    "WHERE usuario_usu = @usuario AND senha_usu = @senha";

                query.Parameters.AddWithValue("@usuario", usuarioNome);
                query.Parameters.AddWithValue("@senha", senha);

                MySqlDataReader reader = query.ExecuteReader();

                Usuario usuario = null;

                while (reader.Read())
                {
                    usuario = Usuario.GetInstance();
                    usuario.Id = reader.GetInt32("cod_usu");
                    usuario.UsuarioNome = reader.GetString("usuario_usu");
                    usuario.Funcionario = new Funcionario() { Id = reader.GetInt32("cod_func"), Nome = reader.GetString("nome_func") };
                }

                return usuario;
            } 
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
