using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management
{
    public partial class Book : Form
    {
        CONNECT conn = new CONNECT();
        ROOM room = new ROOM();
        RESERVATIONS reservation = new RESERVATIONS();
        public Book()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //back
        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPage user = new UserPage();
            user.Show();
        }
        //clear button
        private void buttonClearReserv_Click(object sender, EventArgs e)
        {
            textBoxClientID.Text = "";          
            comboBoxRmType.SelectedIndex = 0;
            textBoxPayment.Text = "";
            dateTimePickerIN.Value = DateTime.Now;
            dateTimePickerOUT.Value = DateTime.Now;
        }
        //book a room
        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            try
            {
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
                        MessageBox.Show("Booked Successfully", "Add Booking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Room not Booked", "Add Booking", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //exit button
        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Book_Load(object sender, EventArgs e)
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
    }
}
