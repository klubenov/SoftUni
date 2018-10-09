using System;
using System.Data.SqlClient;
using P011InitialSetup;

namespace P09IncreaseAgeStoredProcedure
{
    public class P09IncreaseAgeStoredProcedure
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string usp_GetOlderString = $"EXEC [dbo].usp_GetOlder {minionId}";

                SqlCommand procCommand = new SqlCommand(usp_GetOlderString, connection);
                procCommand.ExecuteNonQuery();

                string queryString =
                    $"SELECT Name, Age FROM Minions WHERE Id = {minionId}";

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]} years old");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
