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
    public partial class UserSignup : Form
    {
        CONNECT conn = new CONNECT();
        public UserSignup()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //exit
        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //register an account
        private void buttonUserCreateaccount_Click(object sender, EventArgs e)
        {
            string fname = textBoxUserFname.Text;
            string lname = textBoxUserLname.Text;
            string email = textBoxEmail.Text;
            string username = textBoxUserUsername.Text;
            string password = textBoxUserPassword.Text;
            string cpassword = textBoxUserConfirmPassword.Text;
            MySqlCommand command = new MySqlCommand("INSERT INTO `user`(`Firstname`, `Lastname`,`Email`, `Username`, `Password`) VALUES (@fn,@ln,@em,@usn,@pass)", conn.getConnection());
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxUserFname.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxUserLname.Text;
            command.Parameters.Add("em", MySqlDbType.VarChar).Value = textBoxEmail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUserUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxUserPassword.Text;
            conn.openConnection();
            if (!checkTextBoxesValues())
            {
                if (textBoxUserPassword.Text.Equals(textBoxUserConfirmPassword.Text))
                {
                    if (checkUsername())
                    {
                        MessageBox.Show("This Username Already Exists, Select A Different One", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (command.ExecuteNonQuery() == 1)
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
            string fname = textBoxUserFname.Text;
            string lname = textBoxUserLname.Text;
            string email = textBoxEmail.Text;
            string username = textBoxUserUsername.Text;
            string password = textBoxUserPassword.Text;
            string cpassword = textBoxUserConfirmPassword.Text;
            if (fname.Trim().Equals("") || lname.Trim().Equals("") ||email.Trim().Equals("") || username.Trim().Equals("") || password.Trim().Equals(""))
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
            String username = textBoxUserUsername.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `Username`=@usn", conn.getConnection());
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
        //go to login page
        private void UserLoginpage_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserLogin user = new UserLogin();
            user.Show();
        }
    }
}
