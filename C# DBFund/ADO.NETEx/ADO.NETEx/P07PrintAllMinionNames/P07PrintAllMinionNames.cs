using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using P011InitialSetup;

namespace P07PrintAllMinionNames
{
    class P07PrintAllMinionNames
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                var minionNames = new List<string>();

                string queryString =
                    "SELECT Name FROM Minions";

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            minionNames.Add((string)reader[0]);
                        }
                    }
                }

                for (int i = 0; i < minionNames.Count/2 + minionNames.Count%2; i++)
                {
                    Console.WriteLine(minionNames[i]);
                    if (i == minionNames.Count - (i + 1))
                    {
                        break;
                    }
                    Console.WriteLine(minionNames[minionNames.Count - (i + 1)]);
                }

                connection.Close();
            }
        }
    }
}
