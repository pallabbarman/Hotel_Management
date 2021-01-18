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
    public partial class UserPage : Form
    {
        public UserPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //booking section
        private void buttonBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            Book book = new Book();
            book.Show();
        }
        //rating section
        private void buttonRating_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rating rating = new Rating();
            rating.Show();
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports reports = new Reports();
            reports.Show();
        }

        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserLogin login = new UserLogin();
            login.Show();
        }

        private void buttonFood_Click(object sender, EventArgs e)
        {
            this.Hide();
            FoodMenu food = new FoodMenu();
            food.Show();
        }
    }
}
