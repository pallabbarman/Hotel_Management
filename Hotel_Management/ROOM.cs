using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hotel_Management
{
    class ROOM
    {
        CONNECT conn = new CONNECT();
        public DataTable roomTypelist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms_category`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
        public DataTable roomByType(int type)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms` WHERE `Type`=@typ and `Free`='Yes'", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@typ", MySqlDbType.Int32).Value = type;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
        public int getRoomType(int number)
        {
            MySqlCommand command = new MySqlCommand("SELECT  `Type` FROM `rooms` WHERE `Roomno`=@num", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return Convert.ToInt32(table.Rows[0][0].ToString());
        }
        public bool setRoomFree(int number, string YES_or_NO)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `rooms` SET `Free`=@yes_no WHERE`Roomno`=@num", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@yes_no", MySqlDbType.VarChar).Value = YES_or_NO;
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
        //create function add a new room
        public bool addRoom(int number, int type, string free)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `rooms`(`Roomno`, `Type`, `Free`) VALUES (@num,@tp,@fr)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;
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
        //create a function to get all rooms list
        public DataTable getRooms()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
        //create a funtion edit to selected room
        public bool editRoom(int number, int type, string free)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE `rooms` SET `Type`=@tp,`Free`=@fr WHERE `Roomno`=@num";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;
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
        public bool removeRoom(int number)
        {
            MySqlCommand command = new MySqlCommand();
            string removeQuery = "DELETE FROM `rooms` WHERE `Roomno`=@num";
            command.CommandText = removeQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
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
