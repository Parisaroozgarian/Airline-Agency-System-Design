using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_Agency_System_Design
{
    public partial class LoginP : Form
    {
        public LoginP()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (UIdtB.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else if (UIdtB.Text == "Admin" && PassTb.Text == "Admin")
            {
                HomeP home = new HomeP();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password ");
            }
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UIdtB.Text = "";
            PassTb.Text = "";

        }

        private void UIdtB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}