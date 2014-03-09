using System.Data.SqlClient;

namespace PoorUnitTests.CoupledToExternalComponent
{
    public class ProductRepository
    {
        public int Add(Product product)
        {
            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                var command = new SqlCommand("INSERT INTO Products (Name, Description, Color, QOH) Values (@Name, @Description, @Color, @QOH); SELECT @@Identity", connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Color", product.Color);
                command.Parameters.AddWithValue("@QOH", product.QuantityOnHand);
                connection.Open();
                var executeScalar = command.ExecuteScalar();
                return int.Parse(executeScalar.ToString());
            }
        }

        public Product Find(int productId)
        {
            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                var command = new SqlCommand("SELECT * FROM Products WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", productId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product
                                   {
                                       Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                       Name = reader.GetString(reader.GetOrdinal("Name")),
                                       Description = reader.GetString(reader.GetOrdinal("Description")),
                                       Color = reader.GetString(reader.GetOrdinal("Color")),
                                       QuantityOnHand = reader.GetInt32(reader.GetOrdinal("QOH")),
                                   };
                    }
                }
                return null;
            }
        }

        public void Delete(int productId)
        {
            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                var command = new SqlCommand("DELETE FROM Products WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", productId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}