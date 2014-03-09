using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PoorUnitTests.Slow
{
    public class HandleFactory
    {
        readonly Random Random = new Random();

        public string CreateNewHandle()
        {
            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                string handle;
                int timesUsed;
                do
                {
                    handle = GenerateHandle();
                    var selectCommand = new SqlCommand("SELECT COUNT(*) FROM Handles WHERE Handle = @Handle", connection);
                    selectCommand.Parameters.AddWithValue("@Handle", handle);
                    timesUsed = int.Parse(selectCommand.ExecuteScalar().ToString());
                } while (timesUsed > 0);
                var insertCommand = new SqlCommand("INSERT INTO Handles (Handle) VALUES (@Handle)", connection);
                insertCommand.Parameters.AddWithValue("@Handle", handle);
                insertCommand.ExecuteNonQuery();
                return handle;
            }
        }

        string GenerateHandle()
        {
            var handle = string.Empty;
            for (var i = 0; i < 10; i++)
            {
                handle += (char) Random.Next(65, 91);
            }
            return handle;
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