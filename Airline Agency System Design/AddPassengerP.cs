using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_Agency_System_Design
{
    public partial class AddPassengerP : Form
    {
        public AddPassengerP()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\parisa\Documents\Airline Agency System Design.mdf"";Integrated Security=True;Connect Timeout=30");
        private void button4_Click(object sender, EventArgs e)
        {
            HomeP home = new HomeP();
            home.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Passid.Text = "";
            PassName.Text = "";
            PassportTb.Text = "";
            PassAd.Text = "";
            PhoneTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Passid.Text == "" || PassAd.Text == "" || PassName.Text == "" || PassportTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show(" Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into PassengerTbl values(" + Passid.Text + ",'" + PassName.Text + "','" + PassportTb.Text + "','" + PassAd.Text + "','" + NationalityCb.SelectedItem.ToString() + "','" + GenderCb.SelectedItem.ToString() + "','" + PhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Recorded Successfully");

                    Con.Close();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewPassengerP viewpass = new ViewPassengerP();
            viewpass.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddPassengerP_Load(object sender, EventArgs e)
        {

        }
    }
}
