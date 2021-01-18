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
    public partial class Reports : Form
    {
        CONNECT conn = new CONNECT();
        public Reports()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPage user = new UserPage();
            user.Show();
        }

        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string report = textBoxReports.Text;
            MySqlCommand command = new MySqlCommand("INSERT INTO `reports`(`report`) VALUES (@rp)", conn.getConnection());
            command.Parameters.Add("@rp", MySqlDbType.VarChar).Value = textBoxReports.Text;
            conn.openConnection();
            if(report.Trim().Equals(""))
            {
                MessageBox.Show("Textbox is empty");
            }
            else if(command.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Thank you for your advice");
                Application.Exit();
            }
            conn.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxReports.Text = "";
        }
    }
}
