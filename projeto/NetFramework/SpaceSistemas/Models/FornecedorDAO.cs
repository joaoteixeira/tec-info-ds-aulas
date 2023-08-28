using SpaceSistemas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SpaceSistemas.Database;
using SpaceSistemas.Helpers;

namespace SpaceSistemas.Models
{
    class FornecedorDAO : IDAO<Fornecedor>
    {
        private static Conexao conn;

        public FornecedorDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Fornecedor t)
        {
            throw new NotImplementedException();
        }

        public Fornecedor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Fornecedor fornecedor)
        {
            var query = conn.Query();
            query.CommandText = "INSERT INTO fornecedor VALUES (null, @razao_social, @nome_fantasia, @cnpj, @telefone, @representante, null)";

            query.Parameters.AddWithValue("@razao_social", fornecedor.RazaoSocial);
            query.Parameters.AddWithValue("@nome_fantasia", fornecedor.CNPJ);
            query.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
            query.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
            query.Parameters.AddWithValue("@representante", fornecedor.Representante);

            var result = query.ExecuteNonQuery();

            if (result == 0)
                throw new Exception("O registro não foi inserido. Verifique e tente novamente");
        }

        public List<Fornecedor> List()
        {
            try
            {
                List<Fornecedor> list = new List<Fornecedor>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Fornecedor()
                    {
                        Id = reader.GetInt32("cod_forn"),
                        RazaoSocial = DAOHelper.GetString(reader, "razaosocial_forn"),
                        NomeFantasia = DAOHelper.GetString(reader, "nomefantasia_forn"),
                        CNPJ = DAOHelper.GetString(reader, "cnpj_forn"),
                        Telefone = DAOHelper.GetString(reader, "telefone_forn"),
                        Representante = DAOHelper.GetString(reader, "representante_forn")
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

        public void Update(Fornecedor t)
        {
            throw new NotImplementedException();
        }
    }
}
