using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_tick;
            timer.Start();
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            check();
        }

        private void check()
        {
            bool uolReachable = uol();
            bool nasaReachable = nasa();

            if (uolReachable || nasaReachable)
            {
                button1.Text = "REDE ALCANÇÁVEL";
                button1.BackColor = Color.Green;

                button2.Text = "REDE ALCANÇÁVEL";
                button2.BackColor = Color.Green;

                button3.Text = "REDE ALCANÇÁVEL";
                button3.BackColor = Color.Green;
            }
            else
            {
                button1.Text = "REDE NÃO ALCANÇÁVEL";
                button1.BackColor = Color.Red;

                button2.Text = "REDE NÃO ALCANÇÁVEL";
                button2.BackColor = Color.Red;

                button3.Text = "REDE NÃO ALCANÇÁVEL";
                button3.BackColor = Color.Red;
            }
        }

        private bool uol()
        {
            try
            {
                string url = "www.uol.com";
                Ping ping = new Ping();
                PingReply reply = ping.Send(url);
                return reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                return false;
            }
        }

        private bool nasa()
        {
            try
            {
                string url = "www.nasa.com";
                Ping ping = new Ping();
                PingReply reply = ping.Send(url);
                return reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
