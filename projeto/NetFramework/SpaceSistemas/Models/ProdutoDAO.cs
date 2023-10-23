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
    class ProdutoDAO
    {
        private Conexao conn;

        public string resultado;

        public bool sucesso;

        public ProdutoDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Produto t)
        {
            throw new NotImplementedException();
        }

        public Produto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string Insert(Produto produto)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "CALL produto_inserir(@nome, @unidade, @valor)";

                query.Parameters.AddWithValue("@nome", produto.Nome);
                query.Parameters.AddWithValue("@unidade", produto.Unidade);
                query.Parameters.AddWithValue("@valor", produto.ValorVenda);

                var resultado = (string) query.ExecuteScalar();

                return resultado;

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produto> List()
        {
            try
            {
                List<Produto> list = new List<Produto>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produto()
                    {
                        Id = reader.GetInt32("cod_prod"),
                        Nome = reader.GetString("nome_prod"),
                        Unidade = reader.GetString("unidade_prod"),
                        ValorCompra = reader.GetDouble("valor_compra_prod")
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

        public void Update(Produto t)
        {
            throw new NotImplementedException();
        }
    }
}
