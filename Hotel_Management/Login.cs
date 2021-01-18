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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //exit
        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //go to admin section
        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin admin = new AdminLogin();
            admin.Show();
        }
        // go to user section
        private void buttonUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserLogin user = new UserLogin();
            user.Show();
        }
    }
}
