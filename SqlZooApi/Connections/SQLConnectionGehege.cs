using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooAPI.Dtos;

namespace ZooAPI.Connections
{
    public class SQLConnectionGehege
    {
        // necessary for connection to database
        public string ConnectionString { get; set; }

        public SQLConnectionGehege(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // GET all gehege
        public IEnumerable<Gehege> GetGehege()
        {
            List<Gehege> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from gehege", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Gehege temp = new();
                        temp.Id = Convert.ToInt64(reader["Id"]);
                        temp.Gehegeart = Convert.ToString(reader["Gehegeart"]);
                        temp.TierID = Convert.ToInt64(reader["TierID"]);
                        temp.ZooID = Convert.ToInt64(reader["ZooID"]); 
                        list.Add(temp);
                    }
                }
            }
            return list;
        }

        // CREATE new gehege
        public int CreateGehege(GehegeInput gehege)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO gehege (Gehegeart, TierID, ZooID) VALUES ('" + gehege.Gehegeart + "', '" + gehege.TierID + "', '" + gehege.ZooID + "')", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // UPDATE exisiting gehege
        public int UpdateGehege(long id, GehegeInput gehege)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE gehege SET Gehegeart = '" + gehege.Gehegeart + "', TierID = '" + gehege.TierID + "', ZooID = '" + gehege.ZooID + "' WHERE ID = '" + id + "';", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // DELETE gehege
        public int DeleteGehege(long id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM gehege WHERE ID = '" + id + "'", conn);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
