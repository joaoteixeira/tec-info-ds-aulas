using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SpaceSistemas.Database
{
    class Conexao
    {
        private static string host = "localhost";

        private static string port = "3308";

        private static string user = "root";

        private static string password = "root";

        private static string dbname = "dssistemas_db";

        private static MySqlConnection connection;

        private static MySqlCommand command;

        public Conexao()
        {
            try
            {
                connection = new MySqlConnection($"server={host};database={dbname};port={port};user={user};password={password}");
                connection.Open();

            } catch (Exception)
            {
                throw;
            }
        }

        public MySqlCommand Query()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;
            } 
            catch(Exception)
            {
                throw;
            }
        }

        public void Close()
        {
            connection.Close();
        }

    }
}
