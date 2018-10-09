using System;
using System.Data.SqlClient;
using P011InitialSetup;

namespace P03MinionNames
{
    public class P03MinionNames
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            string villainName = "";

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villainCheckQuerry = $"SELECT * FROM Villains WHERE Id = {villainId}";

                using (SqlCommand command = new SqlCommand(villainCheckQuerry, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                            connection.Close();
                            return;
                        }
                        else
                        {
                            villainName = (string)reader[1];
                        }
                    }                   
                }

                string queryString =
                    $"SELECT v.Name, m.Name, m.Age FROM Villains AS v JOIN MinionsVillains AS mv ON mv.VillainId=v.Id JOIN Minions AS m ON m.Id=mv.MinionId WHERE v.Id = {villainId} ORDER BY m.Name";

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int minionCounter = 1;

                        if (reader.Read())
                        {
                            Console.WriteLine($"Villain: {reader[0]}");
                            Console.WriteLine($"{minionCounter}. {reader[1]} {reader[2]}");
                        }
                        else
                        {
                            Console.WriteLine($"Villain: {villainName}\r\n(no minions)");
                        }

                        while (reader.Read())
                        {
                            minionCounter++;
                            Console.WriteLine($"{minionCounter}. {reader[1]} {reader[2]}");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
