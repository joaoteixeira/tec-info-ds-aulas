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
    class FuncionarioDAO : IDAO<Funcionario>
    {
        private static Conexao conn;

        public FuncionarioDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Funcionario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM funcionario WHERE cod_func = @id";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Registro não removido da base de dados. Verifique e tente novamente.");

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

        public Funcionario GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT* FROM funcionario WHERE cod_func = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var funcionario = new Funcionario();

                while (reader.Read())
                {
                    funcionario.Id = reader.GetInt32("cod_func");
                    funcionario.Nome = reader.GetString("nome_func");
                    funcionario.CPF = reader.GetString("cpf_func");
                    funcionario.RG = reader.GetString("rg_func");
                    funcionario.DataNascimento = reader.GetDateTime("datanasc_func");
                    funcionario.Email = reader.GetString("email_func");
                    funcionario.Celular = reader.GetString("celular_func");
                    funcionario.Funcao = reader.GetString("funcao_func");
                    funcionario.Salario = reader.GetDouble("salario_func");
                }

                return funcionario;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
        }

        public void Insert(Funcionario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO funcionario (nome_func, cpf_func, rg_func, datanasc_func, email_func, celular_func, funcao_func, salario_func) " +
                    "VALUES (@nome, @cpf, @rg, @datanasc, @email, @celular, @funcao, @salario)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@funcao", t.Funcao);
                query.Parameters.AddWithValue("@salario", t.Salario);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente.");

            } catch (Exception e)
            {
                throw e;
            } finally
            {
                conn.Close();
            }
        }

        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM funcionario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario() {
                        Id = reader.GetInt32("cod_func"),
                        Nome = reader.GetString("nome_func"),
                        CPF = reader.GetString("cpf_func"),
                        RG = reader.GetString("rg_func"),
                        DataNascimento = reader.GetDateTime("datanasc_func"),
                        Email = reader.GetString("email_func"),
                        Celular = reader.GetString("celular_func"),
                        Funcao = reader.GetString("funcao_func"),
                        Salario = reader.GetDouble("salario_func")
                    });
                }

                return list;
            }
            catch(Exception e)
            {
                throw e;
            } 
            finally
            {
                conn.Close();
            }
        }

        public void Update(Funcionario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE funcionario SET nome_func = @nome, cpf_func = @cpf, rg_func = @rg, datanasc_func = @datanasc, " +
                    "email_func = @email, celular_func = @celular, funcao_func = @funcao, salario_func = @salario " +
                    "WHERE cod_func = @id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@funcao", t.Funcao);
                query.Parameters.AddWithValue("@salario", t.Salario);

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização do registro não foi realizada.");

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
