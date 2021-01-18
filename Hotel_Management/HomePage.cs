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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //exit
        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // go to client page
        private void buttonClients_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clients clients = new Clients();
            clients.Show();
        }
        //go to rooms page
        private void buttonRooms_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rooms rooms = new Rooms();
            rooms.Show();
        }
        //go to reservation page
        private void buttonReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservation reservation = new Reservation();
            reservation.Show();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin login = new AdminLogin();
            login.Show();
        }
    }
}
