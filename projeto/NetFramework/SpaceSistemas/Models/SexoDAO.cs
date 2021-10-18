using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceSistemas.Interfaces;
using SpaceSistemas.Database;
using MySql.Data.MySqlClient;

namespace SpaceSistemas.Models
{
    class SexoDAO : IDAO<Sexo>
    {
        private static Conexao conn;

        public SexoDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Sexo t)
        {
            throw new NotImplementedException();
        }

        public Sexo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Sexo t)
        {
            throw new NotImplementedException();
        }

        public List<Sexo> List()
        {
            try
            {
                List<Sexo> list = new List<Sexo>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM sexo";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Sexo()
                    {
                        Id = reader.GetInt32("cod_sex"),
                        Nome = reader.GetString("nome_sex")
                    });
                }

                return list;
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

        public void Update(Sexo t)
        {
            throw new NotImplementedException();
        }
    }
}
