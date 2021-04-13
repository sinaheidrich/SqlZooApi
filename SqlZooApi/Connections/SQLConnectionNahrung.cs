using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooAPI.Dtos;

namespace ZooAPI.Connections
{
    public class SQLConnectionNahrung
    {
        // necessary for connection to database
        public string ConnectionString { get; set; }

        public SQLConnectionNahrung(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // GET all nahrung
        public IEnumerable<Nahrung> GetNahrung()
        {
            List<Nahrung> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from nahrung", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Nahrung temp = new();
                        temp.Id = Convert.ToInt64(reader["Id"]);
                        temp.Name = Convert.ToString(reader["Name"]);
                        temp.Kilokalorien = Convert.ToInt32(reader["Kilokalorien"]);
                        temp.TierID = Convert.ToInt64(reader["TierID"]);
                        temp.ZooID = Convert.ToInt64(reader["ZooID"]);
                        list.Add(temp);
                    }
                }
            }
            return list;
        }

        // CREATE new nahrung
        public int CreateNahrung(NahrungInput nahrung)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO nahrung (Name, Kilokalorien, TierID, ZooID) VALUES ('" + nahrung.Name + "', '" + nahrung.Kilokalorien + "', '" + nahrung.TierID + "', '" + nahrung.ZooID + "')", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // UPDATE exisiting nahrung
        public int UpdateNahrung(long id, NahrungInput nahrung)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE nahrung SET Name = '" + nahrung.Name + "', Kilokalorien = '" + nahrung.Kilokalorien + "', TierID = '" + nahrung.TierID + "', ZooID = '" + nahrung.ZooID + "' WHERE ID = '" + id + "';", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // DELETE nahrung
        public int DeleteNahrung(long id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM nahrung WHERE ID = '" + id + "'", conn);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
