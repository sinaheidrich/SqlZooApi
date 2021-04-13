using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using ZooAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooAPI.Connections
{
    public class SQLConnectionTier
    {
        // necessary for connection to database
        public string ConnectionString { get; set; }

        public SQLConnectionTier(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // GET all tier
        public IEnumerable<Tier> GetTier()
        {
            List<Tier> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tier", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tier temp = new();
                        temp.Id = Convert.ToInt64(reader["Id"]);
                        temp.ZooID = Convert.ToInt32(reader["ZooId"]);
                        temp.Tierart = Convert.ToString(reader["Tierart"]);
                        temp.Name = Convert.ToString(reader["Name"]);
                        if (Convert.ToInt32(reader["Vegetarier"]) == 1) temp.Vegetarier = true;
                        else temp.Vegetarier = false;
                        list.Add(temp);
                    }
                }
            }
            return list;
        }

        // CREATE new tier
        public int CreateTier(TierInput tier)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                int help = 0;
                if (tier.Vegetarier == true) help = 1;
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tier (ZooID, Tierart, Name, Vegetarier) VALUES ('" + tier.ZooID + "', '" + tier.Tierart + "', '" + tier.Name + "', '" + help + "')", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // UPDATE exisiting tier
        public int UpdateTier(long id, TierInput tier)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                int help = 0;
                if (tier.Vegetarier == true) help = 1;
                MySqlCommand cmd = new MySqlCommand("UPDATE tier SET ZooID = '" + tier.ZooID + "', Tierart = '" + tier.Tierart + "', Name = '" + tier.Name + "', Vegetarier = '" + help + "' WHERE ID = '" + id + "';", conn);
                return cmd.ExecuteNonQuery(); 
            }
        }

        // DELETE tier
        public int DeleteTier(long id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM tier WHERE ID = '" + id + "'", conn);
                cmd.ExecuteNonQuery(); 
                cmd = new MySqlCommand("UPDATE gast SET TierID = '0' WHERE TierID = '" + id + "';", conn);
                cmd.ExecuteNonQuery(); 
                cmd = new MySqlCommand("UPDATE gehege SET TierID = '0' WHERE TierID = '" + id + "';", conn);
                cmd.ExecuteNonQuery(); 
                cmd = new MySqlCommand("UPDATE mitarbeiter SET TierID = '0' WHERE TierID = '" + id + "';", conn);
                cmd.ExecuteNonQuery(); 
                cmd = new MySqlCommand("UPDATE nahrung SET TierID = '0' WHERE TierID = '" + id + "';", conn);
                cmd.ExecuteNonQuery(); 
                return 1;
            }
        }
    }
}

