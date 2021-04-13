using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooAPI.Dtos;

namespace ZooAPI.Connections
{
    public class SQLConnectionGast
    {
        // necessary for connection to database
        public string ConnectionString { get; set; }

        public SQLConnectionGast(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // GET all gast
        public IEnumerable<Gast> GetGast()
        {
            List<Gast> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from gast", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Gast temp = new();
                        temp.Id = Convert.ToInt64(reader["Id"]);
                        temp.Name = Convert.ToString(reader["Name"]);
                        temp.TierID = Convert.ToInt64(reader["TierID"]);
                        temp.ZooID = Convert.ToInt64(reader["ZooID"]);
                        list.Add(temp);
                    }
                }
            }
            return list;
        }

        // CREATE new gast
        public int CreateGast(GastInput gast)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO gast (Name, TierID, ZooID) VALUES ('" + gast.Name + "', '" + gast.TierID + "', '" + gast.ZooID + "')", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // UPDATE existing gast
        public int UpdateGast(long id, GastInput gast)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE gast SET Name = '" + gast.Name + "', TierID = '" + gast.TierID + "', ZooID = '" + gast.ZooID + "' WHERE ID = '" + id + "';", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // DELETE gast
        public int DeleteGast(long id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM gast WHERE ID = '" + id + "'", conn);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
