using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooAPI.Dtos;

namespace ZooAPI.Connections
{
    public class SQLConnectionAbfragen
    {
        // necessary for connection to database
        public string ConnectionString { get; set; }

        public SQLConnectionAbfragen(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // GET alle Besucher eines bestimmten Tieres
        public IEnumerable<Gast> GetAlleBesucher(long id)
        {
            List<Gast> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM gast WHERE TierID = '" + id + "';", conn);
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

        // GET alle Tiere ohne Besucher
        public IEnumerable<Tier> GetAlleTiereOhneGast()
        {
            List<Tier> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tier t WHERE NOT EXISTS (SELECT * FROM gast g WHERE g.TierID = t.ID);", conn);
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

        // GET alle Tiere ohne Pfleger
        public IEnumerable<Tier> GetAlleTiereOhneMitarbeiter()
        {
            List<Tier> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tier t WHERE NOT EXISTS (SELECT * FROM mitarbeiter m WHERE m.TierID = t.ID);", conn);
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

        // GET Nahrung eines bestimmten Tieres
        public IEnumerable<Nahrung> GetNahrungTier(long id)
        {
            List<Nahrung> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM nahrung n WHERE n.TierID = '" + id + "';", conn);
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

        // GET vegetarische Tiere
        public IEnumerable<Tier> GetVegetarier()
        {
            List<Tier> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tier t WHERE t.Vegetarier = '1';", conn);
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

        // GET carnivore Tiere
        public IEnumerable<Tier> GetCarnivore()
        {
            List<Tier> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tier t WHERE t.Vegetarier = '0';", conn);
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

        // GET alle gepflegten Tiere eines Mitarbeiters 
        public IEnumerable<Tier> GetGepflegteTiereMitarbeiter(string mit) 
        {
            List<Tier> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT t.ID, t.ZooID, t.Tierart, t.Name, t.Vegetarier FROM mitarbeiter m, tier t WHERE m.Nachname = '" + mit + "' AND m.TierID = t.ID;", conn);
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

        // GET alle Zoos inklusive Tiere, Mitarbeiter, ...
        public IEnumerable<Gesamt> GetAlleZoosUndCo()
        {
            List<Gesamt> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT z.ID, z.Ort, z.Name, t.ID, t.Name, t.Tierart, n.ID, n.Name, m.ID, m.Nachname, m.Vorname, g.ID, g.Gehegeart, ga.ID, ga.Name " +
                    "FROM mitarbeiter m, tier t, zoo z, gast ga, gehege g, nahrung n WHERE z.ID = n.ZooID AND z.ID = m.ZooID AND z.ID = g.ZooID AND z.ID = ga.ZooID AND z.ID = t.ZooID", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Gesamt temp = new();
                        temp.ZooId = Convert.ToInt64(reader["ID"]);
                        temp.ZooOrt = Convert.ToString(reader["Ort"]);
                        temp.ZooName = Convert.ToString(reader["Name"]);
                        temp.TierId = Convert.ToInt64(reader["ID"]);
                        temp.TierName = Convert.ToString(reader["Name"]);
                        temp.Tierart = Convert.ToString(reader["Tierart"]);
                        temp.NahrungId = Convert.ToInt64(reader["ID"]);
                        temp.NahrungName = Convert.ToString(reader["Name"]);
                        temp.MitarbeiterId = Convert.ToInt64(reader["ID"]);
                        temp.MitarbeiterNachname = Convert.ToString(reader["Nachname"]);
                        temp.MitarbeiterVorname = Convert.ToString(reader["Vorname"]);
                        temp.GehegeId = Convert.ToInt64(reader["ID"]);
                        temp.Gehegeart = Convert.ToString(reader["Gehegeart"]);
                        temp.GastId = Convert.ToInt64(reader["ID"]);
                        temp.GastName = Convert.ToString(reader["Name"]);
                        list.Add(temp);
                    }
                }
            }
            return list;
        }
    }
}
