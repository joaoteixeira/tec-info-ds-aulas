using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceSistemas.Interfaces;
using SpaceSistemas.Database;
using SpaceSistemas.Helpers;
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
                query.CommandText = "SELECT * FROM funcionario LEFT JOIN sexo ON cod_sex = cod_sex_fk WHERE cod_func = @id";

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
                    funcionario.DataNascimento = DAOHelper.GetDateTime(reader, "datanasc_func");
                    funcionario.Email = reader.GetString("email_func");
                    funcionario.Celular = reader.GetString("celular_func");
                    funcionario.Funcao = reader.GetString("funcao_func");
                    funcionario.Salario = DAOHelper.GetDouble(reader, "salario_func");

                    if (!DAOHelper.IsNull(reader, "cod_sex_fk"))
                        funcionario.Sexo = new Sexo() { 
                            Id = reader.GetInt32("cod_sex"), 
                            Nome = reader.GetString("nome_sex") 
                        };
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

                /*
                 * PROCEDURE `inserir_funcionario`(IN nome varchar(200), IN cpf varchar(20), IN rg varchar(20),
                                                     IN datanasc date, IN email varchar(200), IN celular varchar(50), 
                                                    IN funcao varchar(50),
                                                     IN salario double)
                 */
                var query = conn.Query();
                //query.CommandText = "INSERT INTO funcionario (nome_func, cpf_func, rg_func, datanasc_func, email_func, celular_func, funcao_func, salario_func) " +
                //    "VALUES (@nome, @cpf, @rg, @datanasc, @email, @celular, @funcao, @salario)";

                query.CommandText = "CALL inserir_funcionario(@nome, @sexo, @cpf, @rg, @datanasc, @email, @celular, @funcao, @salario)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@sexo", t.Sexo.Id);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento?.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@funcao", t.Funcao);
                query.Parameters.AddWithValue("@salario", t.Salario);

                //var result = query.ExecuteNonQuery();

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if(reader.GetName(0).Equals("Alerta"))
                    {
                        throw new Exception(reader.GetString("Alerta"));
                    }
                }

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
                query.CommandText = "SELECT * FROM funcionario LEFT JOIN sexo ON cod_sex = cod_sex_fk";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario() {
                        Id = reader.GetInt32("cod_func"),
                        Nome = DAOHelper.GetString(reader, "nome_func"),
                        CPF = DAOHelper.GetString(reader, "cpf_func"),
                        RG = DAOHelper.GetString(reader, "rg_func"),
                        DataNascimento = DAOHelper.GetDateTime(reader, "datanasc_func"),
                        Email = DAOHelper.GetString(reader, "email_func"),
                        Celular = DAOHelper.GetString(reader, "celular_func"),
                        Funcao = DAOHelper.GetString(reader, "funcao_func"),
                        Salario = DAOHelper.GetDouble(reader, "salario_func"),
                        Sexo = DAOHelper.IsNull(reader, "cod_sex_fk") ? null : new Sexo() { Id = reader.GetInt32("cod_sex"), Nome = reader.GetString("nome_sex") }
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
                    "email_func = @email, celular_func = @celular, funcao_func = @funcao, salario_func = @salario, cod_sex_fk = @sexo " +
                    "WHERE cod_func = @id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@sexo", t.Sexo.Id);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento?.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
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
