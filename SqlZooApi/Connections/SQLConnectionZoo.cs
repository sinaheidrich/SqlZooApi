using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using ZooAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooAPI.Connections
{
    public class SQLConnectionZoo
    {
        // necessary for connection to database
        public string ConnectionString { get; set; }

        public SQLConnectionZoo(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // GET all zoo
        public IEnumerable<Zoo> GetZoo()
        {
            List<Zoo> list = new();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from zoo", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Zoo temp = new();
                        temp.Id = Convert.ToInt64(reader["Id"]);
                        temp.Ort = Convert.ToString(reader["Ort"]);
                        temp.Name = Convert.ToString(reader["Name"]);
                        list.Add(temp);
                    }
                }
            }
            return list;
        }

        // CREATE new zoo
        public int CreateZoo(ZooInput zoo)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO zoo (Ort, Name) VALUES ('" + zoo.Ort + "', '" + zoo.Name + "')", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // UPDATE exisiting zoo
        public int UpdateZoo(long id, ZooInput zoo)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE zoo SET Ort = '" + zoo.Ort + "', Name = '" + zoo.Name + "' WHERE ID = '" + id + "';", conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // DELETE zoo
        public int DeleteZoo(long id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM zoo WHERE ID = '" + id + "'", conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("UPDATE gast SET ZooID = '0' WHERE ZooID = '" + id + "';", conn);
                cmd.ExecuteNonQuery(); 
                cmd = new MySqlCommand("UPDATE gehege SET ZooID = '0' WHERE ZooID = '" + id + "';", conn);
                cmd.ExecuteNonQuery(); 
                cmd = new MySqlCommand("UPDATE mitarbeiter SET ZooID = '0' WHERE ZooID = '" + id + "';", conn);
                cmd.ExecuteNonQuery(); 
                cmd = new MySqlCommand("UPDATE nahrung SET ZooID = '0' WHERE ZooID = '" + id + "';", conn);
                cmd.ExecuteNonQuery(); 
                cmd = new MySqlCommand("UPDATE tier SET ZooID = '0' WHERE ZooID = '" + id + "';", conn);
                cmd.ExecuteNonQuery(); 
                return 1;
            }
        }
    }
}