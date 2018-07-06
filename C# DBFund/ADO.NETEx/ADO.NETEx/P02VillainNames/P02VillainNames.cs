using System;
using System.Data.SqlClient;
using P011InitialSetup;

namespace P02VillainNames
{
    public class P02VillainNames
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string queryString =
                    "SELECT v.Name, COUNT(mv.MinionId) FROM Villains AS v JOIN MinionsVillains AS mv ON mv.VillainId=v.Id GROUP BY v.Name HAVING COUNT(mv.MinionId) > 3 ORDER BY COUNT(mv.MinionId) DESC";

                using (SqlCommand command = new SqlCommand(queryString,connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} -> {reader[1]}");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
