using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooAPI.Dtos;

namespace ZooAPI.Connections
{
    public class SQLConnectionMitarbeiter
    {
        // necessary for connection to database
        public string ConnectionString { get; set; }

        public SQLConnectionMitarbeiter(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // GET all mitarbeiter
        public IEnumerable<Mitarbeiter> GetMitarbeiter()
        {
            List<Mitarbeiter> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from mitarbeiter", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Mitarbeiter temp = new();
                        temp.Id = Convert.ToInt64(reader["Id"]);
                        temp.Nachname = Convert.ToString(reader["Nachname"]);
                        temp.Vorname = Convert.ToString(reader["Vorname"]);
                        temp.Geburtsjahr = Convert.ToInt32(reader["Geburtsjahr"]);
                        temp.TierID = Convert.ToInt64(reader["TierID"]);
                        temp.ZooID = Convert.ToInt64(reader["ZooID"]);
                        list.Add(temp);
                    }
                }
            }
            return list;
        }

        // CREATE new mitarbeiter
        public int CreateMitarbeiter(MitarbeiterInput mitarbeiter)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO mitarbeiter (Nachname, Vorname, Geburtsjahr, TierID, ZooID) VALUES ('" + mitarbeiter.Nachname + "', '" + mitarbeiter.Vorname + "', '" + mitarbeiter.Geburtsjahr + "', '" + mitarbeiter.TierID + "', '" + mitarbeiter.ZooID + "')", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // UPDATE exisiting mitarbeiter
        public int UpdateMitarbeiter(long id, MitarbeiterInput mitarbeiter)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE mitarbeiter SET Nachname = '" + mitarbeiter.Nachname + "', Vorname = '" + mitarbeiter.Vorname + "', Geburtsjahr = '" + mitarbeiter.Geburtsjahr + "', TierID = '" + mitarbeiter.TierID + "', ZooID = '" + mitarbeiter.ZooID + "' WHERE ID = '" + id + "';", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // DELETE mitarbeiter
        public int DeleteMitarbeiter(long id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM mitarbeiter WHERE ID = '" + id + "'", conn);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
