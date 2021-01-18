using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hotel_Management
{
    class CLIENT
    {
        CONNECT conn = new CONNECT();
        public bool insertClient(string fname, string lname, string phone, string country)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `clients`(`Firstname`, `Lastname`, `Phone`, `Country`) VALUES (@fn,@ln,@phn,@cnt)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;
            conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }
        public DataTable getClients()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            
            adapter.Fill(table);
            return table;
        }
        //create function to edit client data
        public bool editClient(int id, string fname, string lname, string phone, string country)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE `clients` SET `Firstname`=@fn,`Lastname`=@ln,`Phone`=@phn,`Country`=@cnt WHERE `Clientid`=@cid";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;
            conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }
        //create a function delete a room
        public bool removeClient(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string removeQuery = "DELETE FROM `clients` WHERE `Clientid`=@cid";
            command.CommandText = removeQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }
    }
}
