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
    public partial class CancellationPTbl : Form
    {
        public CancellationPTbl()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\parisa\Documents\Airline Agency System Design.mdf"";Integrated Security=True;Connect Timeout=30");
        private void fillTicketId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TId from TicketTbl ", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TId", typeof(string));
            dt.Load(rdr);
            TidCb.ValueMember = "TId";
            TidCb.DataSource = dt;
            Con.Close();


        }

        private void fetchfcode()
        {
            Con.Open();
            string query = "select * from TicketTbl where TId=" + TidCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                FcodeTb.Text = dr["Fcode"].ToString();

            }
            Con.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomeP home = new HomeP();
            home.Show();
            this.Hide();
        }

        private void deleteTicket()
        {

            try
            {
                Con.Open();
                string query = "delete from TicketTbl where TId = " + TidCb.SelectedValue.ToString() + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete the Flight Successfully");
                Con.Close();
                populate();


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void populate()
        {
            Con.Open();
            string query = "select * from CancelTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CancelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            CanId.Text = "";
            FcodeTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CanId.Text == "" || FcodeTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into CancelTbl values(" + CanId.Text + ",'" + TidCb.SelectedValue.ToString() + "','" + FcodeTb.Text + "','" + CancDate.Value.Date + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cancel the Ticket Successfully");

                    Con.Close();
                    populate();
                    deleteTicket();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void CancellationPTbl_Load(object sender, EventArgs e)
        {
            fillTicketId();
            populate();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CancelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
