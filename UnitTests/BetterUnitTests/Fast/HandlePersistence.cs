using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BetterUnitTests.Fast
{
    public class HandlePersistence : IHandlePersistence
    {
        readonly Random Random = new Random();

        public bool HandleExists(string handle)
        {
            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                var selectCommand = new SqlCommand("SELECT COUNT(*) FROM Handles WHERE Handle = @Handle", connection);
                selectCommand.Parameters.AddWithValue("@Handle", handle);
                return int.Parse(selectCommand.ExecuteScalar().ToString()) != 0;
            }
        }

        public void SaveNewHandle(string handle)
        {
            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                var insertCommand = new SqlCommand("INSERT INTO Handles (Handle) VALUES (@Handle)", connection);
                insertCommand.Parameters.AddWithValue("@Handle", handle);
                insertCommand.ExecuteNonQuery();
            }
        }


        public IEnumerable<string> AllHandles()
        {
            var handles = new HashSet<string>();
            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                var command = new SqlCommand("SELECT * FROM Handles", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    var handle = reader.GetOrdinal("handle");
                    while (reader.Read())
                    {
                        handles.Add(reader.GetString(handle));
                    }
                }
            }
            return handles;
        }
    }
}