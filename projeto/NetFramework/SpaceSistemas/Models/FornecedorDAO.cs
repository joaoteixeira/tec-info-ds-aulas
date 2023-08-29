using SpaceSistemas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SpaceSistemas.Database;
using SpaceSistemas.Helpers;
using System.Runtime.InteropServices.WindowsRuntime;

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
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM fornecedor WHERE cod_forn = @codigo";

                query.Parameters.AddWithValue("@codigo", id);

                var resultado = query.ExecuteReader();

                var fornecedor = new Fornecedor();

                while (resultado.Read())
                {
                    fornecedor.Id = resultado.GetInt32("cod_forn");
                    fornecedor.RazaoSocial = resultado.GetString("razaosocial_forn");
                    fornecedor.NomeFantasia = resultado.GetString("nomefantasia_forn");
                    fornecedor.CNPJ = resultado.GetString("cnpj_forn");
                    fornecedor.Telefone = resultado.GetString("telefone_forn");
                    fornecedor.Representante = resultado.GetString("representante_forn");
                }

                return fornecedor;

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Fornecedor fornecedor)
        {
            var query = conn.Query();
            query.CommandText = "INSERT INTO fornecedor VALUES (null, @razao_social, @nome_fantasia, @cnpj, @telefone, @representante, null)";

            query.Parameters.AddWithValue("@razao_social", fornecedor.RazaoSocial);
            query.Parameters.AddWithValue("@nome_fantasia", fornecedor.NomeFantasia);
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

        public void Update(Fornecedor fornecedor)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE fornecedor SET razaosocial_forn = @razao_social, nomefantasia_forn = @nome_fantasia, " +
                    "cnpj_forn = @cnpj, telefone_forn = @telefone, representante_forn = @representante WHERE cod_forn = @codigo";

                query.Parameters.AddWithValue("@razao_social", fornecedor.RazaoSocial);
                query.Parameters.AddWithValue("@nome_fantasia", fornecedor.NomeFantasia);
                query.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
                query.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                query.Parameters.AddWithValue("@representante", fornecedor.Representante);

                query.Parameters.AddWithValue("@codigo", fornecedor.Id);

                var resultado = query.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Registro não atualizado.");
                }

            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
