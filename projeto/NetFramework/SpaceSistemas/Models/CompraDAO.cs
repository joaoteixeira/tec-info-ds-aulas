using SpaceSistemas.Database;
using SpaceSistemas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSistemas.Models
{
    class CompraDAO : IDAO<Compra>
    {
        private Conexao conn;

        public CompraDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Compra t)
        {
            throw new NotImplementedException();
        }

        public Compra GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Compra t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO compra (cod_func_fk, cod_forn_fk, data_comp, forma_pagamento_comp, valor_total_comp) " +
                    "VALUES (@funcionario, @fornecedor, @data, @forma_pagamento, @valor_total)";

                query.Parameters.AddWithValue("@funcionario", t.Funcionario.Id);
                query.Parameters.AddWithValue("@fornecedor", t.Fornecedor.Id);
                query.Parameters.AddWithValue("@data", t.Data.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@forma_pagamento", t.FormaPagamento);
                query.Parameters.AddWithValue("@valor_total", t.ValorTotal);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("A compra não foi realizada. Verifique e tente novamente.");

                long compraId = query.LastInsertedId;

                InsertItens(compraId, t.Itens);
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

        private void InsertItens(long compraId, List<CompraItem> itens)
        {

            foreach (CompraItem item in itens)
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO itens_compra (cod_comp_fk, cod_prod_fk, quantidade_itenc, valor_itenc, valor_total_itenc) " +
                    "VALUES (@compra, @produto, @quantidade, @valor, @valor_total)";

                query.Parameters.AddWithValue("@compra", compraId);
                query.Parameters.AddWithValue("@produto", item.Produto.Id);
                query.Parameters.AddWithValue("@quantidade", item.Quantidade);
                query.Parameters.AddWithValue("@valor", item.Valor);
                query.Parameters.AddWithValue("@valor_total", item.ValorTotal);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Os itens da compra não foi adicionada. Verifique e tente novamente.");
            }
        }

        public List<Compra> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Compra t)
        {
            throw new NotImplementedException();
        }
    }
}
