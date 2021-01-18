using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hotel_Management
{
    public partial class Reservation : Form
    {
        CONNECT conn = new CONNECT();
        RESERVATIONS reservation = new RESERVATIONS();
        ROOM room = new ROOM();
        public Reservation()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Reservation_Load(object sender, EventArgs e)
        {
            //display room type
            comboBoxRmType.DataSource = room.roomTypelist();
            comboBoxRmType.DisplayMember = "Label";
            comboBoxRmType.ValueMember = "Type";
            //display room's no selected of room type
            int type = Convert.ToInt32(comboBoxRmType.SelectedValue.ToString());
            comboBoxRoomNumber.DataSource = room.roomByType(type);
            comboBoxRoomNumber.DisplayMember = "Roomno";
            comboBoxRoomNumber.ValueMember = "Roomno";
            dataGridView2.DataSource = reservation.getAllReserv();
            //MySqlCommand command = new MySqlCommand("selsect client.name,reservation.Datein,reservation.Dateout,reservation.Dayment,reservation.roomno" +
             //   " from client,reservation where client.Clientid=reservation.Clientid", conn.getConnection());
        }
        //add reservation
        private void buttonAddReserv_Click(object sender, EventArgs e)
        {
            try
            {
                /*Print print = new Print();
                print.Show();
                string add = "select client.Firstname,reservation.Datein,reservation.Dateout,reservation.Dayment,reservation.roomno" +
                " from client,reservation where client.Clientid=reservation.Clientid";
                MySqlCommand command = new MySqlCommand(add, conn.getConnection());
                CrystalReport1 crystal = new CrystalReport1();
                //DataSet ds = new DataSet();
                //crystal.SetDataSource();*/
                
                
                int clientid = Convert.ToInt32(textBoxClientID.Text);
                int roomno = Convert.ToInt32(comboBoxRoomNumber.SelectedValue);
                string payment = textBoxPayment.Text;
                DateTime datein = dateTimePickerIN.Value;
                DateTime dateout = dateTimePickerOUT.Value;
                // date in must be = or > today date
                // date out must be = or > date in
                if (DateTime.Compare(datein.Date, DateTime.Now.Date) < 0)
                {
                    MessageBox.Show("The Date In Must Be = or > To Today Date", "Invalid Date In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (DateTime.Compare(dateout.Date, datein.Date) < 0)
                {
                    MessageBox.Show("The Date Out Must Be = or > To Date In", "Invalid Date Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (reservation.addRerservation(roomno, clientid,payment, datein, dateout))
                    {
                        // set the room free column to NO
                        // you can add a message if the room is edited
                        room.setRoomFree(roomno, "No");
                        dataGridView2.DataSource = reservation.getAllReserv();
                        MessageBox.Show("New Reservation Added", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Reservation NOT Added", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Reservation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //edit reservation
        private void buttonEditReserv_Click(object sender, EventArgs e)
        {
            try
            {
                int reservid = Convert.ToInt32(textBoxReservId.Text);
                int clientid = Convert.ToInt32(textBoxClientID.Text);
                string payment = textBoxPayment.Text;
                int roomno = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                DateTime datein = dateTimePickerIN.Value;
                DateTime dateout = dateTimePickerOUT.Value;

                // date in must be = or > today date
                // date out must be = or > date in
                if (datein < DateTime.Now)
                {
                    MessageBox.Show("The Date In Must Be = or > To Today Date", "Invalid Date In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dateout < datein)
                {
                    MessageBox.Show("The Date Out Must Be = or > To Date In", "Invalid Date Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (reservation.editReservation(reservid, roomno, clientid,payment, datein, dateout))
                    {
                        // set the room free column to NO
                        // you can add a message if the room is edited
                        room.setRoomFree(roomno, "No");
                        dataGridView2.DataSource = reservation.getAllReserv();
                        MessageBox.Show("Reservation Data Updated", "Edit Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Reservation NOT Added", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Reservation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //delete reservation
        private void buttonRemoveReserv_Click(object sender, EventArgs e)
        {
            try
            {
                int reservid = Convert.ToInt32(textBoxReservId.Text);
                int roomno = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                if (reservation.removeReservation(reservid))
                {
                    dataGridView2.DataSource = reservation.getAllReserv();
                    // after deleting a reservation we need to set free column to 'Yes'
                    room.setRoomFree(roomno, "Yes");
                    MessageBox.Show("Reservation Deleted", "Delete Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Reservation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxReservId.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            int roomid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
            comboBoxRmType.SelectedValue = room.getRoomType(roomid);
            comboBoxRoomNumber.SelectedValue = roomid;
            textBoxClientID.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBoxPayment.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            dateTimePickerIN.Value = Convert.ToDateTime(dataGridView2.CurrentRow.Cells[4].Value);
            dateTimePickerOUT.Value = Convert.ToDateTime(dataGridView2.CurrentRow.Cells[5].Value);
        }
        //clear button
        private void buttonClearReserv_Click(object sender, EventArgs e)
        {
            textBoxClientID.Text = "";
            textBoxReservId.Text = "";
            textBoxPayment.Text = "";
            comboBoxRmType.SelectedIndex = 0;
            dateTimePickerIN.Value = DateTime.Now;
            dateTimePickerOUT.Value = DateTime.Now;
        }
        private void comboBoxRmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int type = Convert.ToInt32(comboBoxRmType.SelectedValue.ToString());
                comboBoxRoomNumber.DataSource = room.roomByType(type);
                comboBoxRoomNumber.DisplayMember = "Roomno";
                comboBoxRoomNumber.ValueMember = "Roomno";
            }
            catch (Exception)
            {

            }
        }
        //back button
        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage home = new HomePage();
            home.Show();
        }
        //exit
        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
