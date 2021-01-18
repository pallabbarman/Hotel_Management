﻿using System;
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
    public partial class AdminLogin : Form
    {
        CONNECT conn = new CONNECT();
        public AdminLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //back
        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
        //exit
        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //login section
        private void buttonAdminLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxAdminUsername.Text;
            string password = textBoxAdminPassword.Text;
           /* DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `admin` WHERE `Username`=@usn and `Password`=@pass", conn.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            // check if the user exists or not
            if (table.Rows.Count > 0)
            {
                this.Hide();
                HomePage page = new HomePage();
                page.Show();
            }*/
            if(username=="admin" && password=="admin")
            {
                this.Hide();
                HomePage page = new HomePage();
                page.Show();
            }
            else
            {
                // check if the username field is empty
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username To Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // check if the password field is empty
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Password To Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // check if the username or the password don't exist
                else
                {
                    MessageBox.Show("Wrong Username Or Password", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //go to register page
        /*private void AdminSignuppage_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminSignup admin = new AdminSignup();
            admin.Show();
        }*/
    }
}
