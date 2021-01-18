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
    public partial class Rating : Form
    {
        public Rating()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Rating_Load(object sender, EventArgs e)
        {
            rate1.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            rate1.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you sir." +
                " Please come again!");
            Application.Exit();
        }
        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPage user = new UserPage();
            user.Show();
        }
    }
}
