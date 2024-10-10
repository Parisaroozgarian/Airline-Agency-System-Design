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
    public partial class ViewFlightP : Form
    {
        public ViewFlightP()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\parisa\Documents\Airline Agency System Design.mdf"";Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from FlightTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FlightDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FlightPTbl Addf1 = new FlightPTbl();
            Addf1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FcodeTb.Text = "";
            Seatnum.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (FcodeTb.Text == "")
            {
                MessageBox.Show("Enter The Flight to Delete ");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from FlightTbl where Fcode = '" + FcodeTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight Delete Successfully");
                    Con.Close();
                    populate();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FcodeTb.Text == "")
            {
                MessageBox.Show("Enter The Flight to Delete ");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from FlightTbl where Fcode = '" + FcodeTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight Delete Successfully");
                    Con.Close();
                    populate();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void FlightDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FcodeTb.Text = FlightDGV.SelectedRows[0].Cells[0].Value.ToString();
            SrcCb.SelectedItem = FlightDGV.SelectedRows[0].Cells[1].Value.ToString();
            DstCb.SelectedItem = FlightDGV.SelectedRows[0].Cells[2].Value.ToString();
            Seatnum.Text = FlightDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void ViewFlightP_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
