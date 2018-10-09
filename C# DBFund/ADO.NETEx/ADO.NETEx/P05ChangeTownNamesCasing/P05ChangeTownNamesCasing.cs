using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using P011InitialSetup;

namespace P05ChangeTownNamesCasing
{
    public class P05ChangeTownNamesCasing
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            int countryId = 0;

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string countryCheckQuerry = $"SELECT * FROM Countries WHERE Name = '{countryName}'";

                using (SqlCommand command = new SqlCommand(countryCheckQuerry, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine("No town names were affected.");
                            connection.Close();
                            return;
                        }

                        countryId = (int) reader[0];
                    }
                }

                string townsQueryString =
                    $"SELECT * FROM Towns WHERE CountryCode = {countryId}";

                using (SqlCommand command = new SqlCommand(townsQueryString, connection))
                {
                    var townsList = new List<string>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            townsList.Add((string)reader[1]);
                        }
                    }

                    if (townsList.Count==0)
                    {
                        Console.WriteLine("No town names were affected.");
                    }
                    else
                    {
                        for (int i = 0; i < townsList.Count; i++)
                        {
                            string updateQuery =
                                $"UPDATE Towns SET Name = '{townsList[i].ToUpper()}' WHERE Name = '{townsList[i]}'";
                            townsList[i] = townsList[i].ToUpper();
                            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                            updateCommand.ExecuteNonQuery();
                        }

                        Console.WriteLine($"{townsList.Count} town names were affected.");
                        Console.WriteLine($"[{string.Join(", ", townsList)}]");
                    }
                }

                connection.Close();
            }
        }
    }
}
