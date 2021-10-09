using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SpaceSistemas.Helpers
{
    static class DAOHelper
    {
        public static string GetString(MySqlDataReader reader, string column_name)
        {
            string text = string.Empty;

            if (!reader.IsDBNull(reader.GetOrdinal(column_name)))
                text = reader.GetString(column_name);

            return text;
        }

        public static double GetDouble(MySqlDataReader reader, string column_name)
        {
            double value = 0.0;

            if (!reader.IsDBNull(reader.GetOrdinal(column_name)))
                value = reader.GetDouble(column_name);

            return value;
        }

        public static DateTime? GetDateTime(MySqlDataReader reader, string column_name)
        {
            DateTime? value = null;

            if (!reader.IsDBNull(reader.GetOrdinal(column_name)))
                value = reader.GetDateTime(column_name);

            return value;
        }
    }
}
