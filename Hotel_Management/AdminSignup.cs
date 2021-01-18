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
    public partial class AdminSignup : Form
    {
        CONNECT conn = new CONNECT();
        public AdminSignup()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //exit
        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //register for admin
        private void buttonAdminCreateaccount_Click(object sender, EventArgs e)
        {
            string fname = textBoxAdminFname.Text;
            string lname = textBoxAdminLname.Text;
            string username = textBoxAdminUsername.Text;
            string password = textBoxAdminPassword.Text;
            string cpassword = textBoxAdminConfirmPassword.Text;
            MySqlCommand command = new MySqlCommand("INSERT INTO `admin`(`Firstname`, `Lastname`, `Username`, `Password`) VALUES (@fn,@ln,@usn,@pass)", conn.getConnection());
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxAdminFname.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxAdminLname.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxAdminUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxAdminPassword.Text;
            conn.openConnection();
            if(!checkTextBoxesValues())
            {
                if(textBoxAdminPassword.Text.Equals(textBoxAdminConfirmPassword.Text))
                {
                    if(checkUsername())
                    {
                        MessageBox.Show("This Username Already Exists, Select A Different One", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if(command.ExecuteNonQuery()==1)
                        {
                            MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Confirmation Password", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter Your Informations First", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        // check if the textboxes contains the default values
        public Boolean checkTextBoxesValues()
        {
            String fname = textBoxAdminFname.Text;
            String lname = textBoxAdminLname.Text;
            String username = textBoxAdminUsername.Text;
            String password = textBoxAdminPassword.Text;
            if(fname.Trim().Equals("")||lname.Trim().Equals("")||username.Trim().Equals("")||password.Trim().Equals("") )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // check if the username already exists
        public Boolean checkUsername()
        {
            String username = textBoxAdminUsername.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `admin` WHERE `Username`=@usn", conn.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            // check if this username already exists in the database
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // go to login page
        private void AdminLoginpage_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin admin = new AdminLogin();
            admin.Show();
        }
    }
}
