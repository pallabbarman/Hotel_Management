using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace Hotel_Management
{
    class RESERVATIONS
    {
        CONNECT conn = new CONNECT();
        public DataTable getAllReserv()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `reservation`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
        //create function add a new reservation
        public bool addRerservation(int roomno, int clientid,string payment, DateTime datein, DateTime dateout)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `reservation`( `Roomno`, `Clientid`, `Payment`, `Datein`, `Dateout`) VALUES (@rnm,@cid,@py,@din,@dout)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = roomno;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientid;
            command.Parameters.Add("@py", MySqlDbType.VarChar).Value = payment;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = datein;
            command.Parameters.Add("@dout", MySqlDbType.Date).Value = dateout;
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
        //create a funtion edit to selected reservation
        public bool editReservation(int reservid, int roomno, int clientid,string payment, DateTime datein, DateTime dateout)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE `reservation` SET `Roomno`=@rnm,`Clientid`=@cid,`Payment`=@py,`Datein`=@din,`Dateout`=@dout WHERE `Reservid`=@rvid";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@rvid", MySqlDbType.Int32).Value = reservid;
            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = roomno;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientid;
            command.Parameters.Add("@py", MySqlDbType.VarChar).Value = payment;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = datein;
            command.Parameters.Add("@dout", MySqlDbType.Date).Value = dateout;
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
        //create a function delete a reservation
        public bool removeReservation(int reservid)
        {
            MySqlCommand command = new MySqlCommand();
            string removeQuery = "DELETE FROM `reservation` WHERE `Reservid`=@rvid";
            command.CommandText = removeQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@rvid", MySqlDbType.Int32).Value = reservid;
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
