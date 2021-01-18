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
    public partial class Rooms : Form
    {
        CONNECT conn = new CONNECT();
        ROOM room = new ROOM();
        public Rooms()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //add a new room
        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            string free = "";

            try
            {
                int number = Convert.ToInt32(textBoxNumber.Text);
                if (radioButtonYes.Checked)
                {
                    free = "Yes";
                }
                else if (radioButtonNO.Checked)
                {
                    free = "No";
                }
                if (room.addRoom(number, type, free))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("Room Added Successfully", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Room Not Added", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Room Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //update rooms
        private void buttonEditRoom_Click(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            String free = "";
            try
            {
                int number = Convert.ToInt32(textBoxNumber.Text);
                if (radioButtonYes.Checked)
                {
                    free = "Yes";
                }
                else if (radioButtonNO.Checked)
                {
                    free = "No";
                }
                if (room.editRoom(number, type, free))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("Room Data Updated", "Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Room Data NOT Updated", "Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Room Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //delete a room
        private void buttonRemoveRoom_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBoxNumber.Text);
                if (room.removeRoom(number))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("Room Data Deleted", "Remove Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Room Data NOT Deleted", "Remove Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Room Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //clear data
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = "";
            comboBoxRoomType.SelectedIndex = 0;
            radioButtonYes.Checked = true;
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = room.roomTypelist();
            comboBoxRoomType.DisplayMember = "Label";
            comboBoxRoomType.ValueMember = "Type";
            dataGridView1.DataSource = room.getRooms();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNumber.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBoxRoomType.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value;
            string free = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (free.Equals("Yes"))
            {
                radioButtonYes.Checked = true;
            }
            else if (free.Equals("No"))
            {
                radioButtonNO.Checked = false;
            }
        }
        //back button
        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage home = new HomePage();
            home.Show();
        }
        //exit button
        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
