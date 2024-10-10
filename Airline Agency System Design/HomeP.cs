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
    public partial class HomeP : Form
    {
        public HomeP()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CancellationPTbl can = new CancellationPTbl();
            can.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TicketP tick = new TicketP();
            tick.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddPassengerP pass = new AddPassengerP();
            pass.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FlightPTbl flight = new FlightPTbl();
            flight.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HomeP_Load(object sender, EventArgs e)
        {

        }
    }
}
