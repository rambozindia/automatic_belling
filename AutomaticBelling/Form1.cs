using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace AutomaticBelling
{
    public partial class Form1 : Form
    {
        DateTime nowdate;
        WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
        string startdate;
        object listselect;
        string day, start,ps,na;
        
        public Form1()
        {
            InitializeComponent();
            ps = AutomaticBelling.Properties.Settings.Default.prayer.ToString();
            na = AutomaticBelling.Properties.Settings.Default.nationalanthem.ToString();
        }

        // ==================timer for prieview of current time and Day=================

        private void timer1_Tick(object sender, EventArgs e)
        {
            nowdate = DateTime.Now;
            nowt.Text = nowdate.ToString("hh:mm:ss tt");
            date.Text = nowdate.DayOfWeek.ToString();
        }

        //================== Sound Playing Function =====================================

        private void bellplaying()
        {
            try
            {
                wmp.URL = "Sound/bell.mp3";
                wmp.controls.play(); 
            }
            catch { }
        }

        //================ Button Effects ===============================================

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                pictureBox2.Image = AutomaticBelling.Properties.Resources.bellbtnpng2;
                bellplaying();
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = AutomaticBelling.Properties.Resources.bellbtnpng;
            wmp.controls.stop();
                
        }

        //===============================================================================

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Timer Start")
            {
                timer2.Start();
                AutomaticBelling.Properties.Settings.Default.timerstat = true;
                button1.Text = "Timer Stop";
                notifyIcon1.ShowBalloonTip(10, "Timer Start", "Automatic Belling system Enabled", ToolTipIcon.Info);
            }
            else if (button1.Text == "Timer Stop")
            {
                timer2.Stop();
                AutomaticBelling.Properties.Settings.Default.timerstat = false ;
                button1.Text = "Timer Start";
                notifyIcon1.ShowBalloonTip(10, "Timer Stop", "Automatic Belling system Disabled", ToolTipIcon.Info);
            }
            AutomaticBelling.Properties.Settings.Default.Save();
        }

        private void daytimeset()
        {
            nowdate = DateTime.Now;
            date.Text = nowdate.DayOfWeek.ToString();
            if (date.Text == "Friday")
            {
                listBox2.Items.Clear();
                for (int i = 0; i < AutomaticBelling.Properties.Settings.Default.friday.Count; i++)
                    listBox2.Items.Add(AutomaticBelling.Properties.Settings.Default.friday[i]);

                listBox1.Visible = false;
                listBox2.Visible = true;
                listselect = listBox2;
                ps = AutomaticBelling.Properties.Settings.Default.prayerf.ToString();
                na = AutomaticBelling.Properties.Settings.Default.nationalanthemf.ToString();
            }
            else
            {
                listBox1.Items.Clear();
                for (int i = 0; i < AutomaticBelling.Properties.Settings.Default.allday.Count; i++)
                    listBox1.Items.Add(AutomaticBelling.Properties.Settings.Default.allday[i]);

                listBox2.Visible = false;
                listBox1.Visible = true;
                listselect = listBox1;
                ps = AutomaticBelling.Properties.Settings.Default.prayer.ToString();
                na = AutomaticBelling.Properties.Settings.Default.nationalanthem.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (AutomaticBelling.Properties.Settings.Default.timerstat == true)
            {
                button1.Text = "Timer Stop";
                timer2.Enabled = true;
                timer2.Start();
            }
            else
            {
                button1.Text = "Timer Start";
                timer2.Stop();
                timer2.Enabled = false;
            }

            daytimeset();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (listselect == listBox1)
            {
                if (nowt.Text == ps)
                {
                    wmp.URL = "Sound/prayer.mp3";
                    wmp.controls.play();
                }
                else if (nowt.Text == na)
                {
                    wmp.URL = "Sound/Janagana.mp3";
                    wmp.controls.play();
                }

                for (int t = 0; t < listBox1.Items.Count; t++)
                {
                    if (listBox1.Items[t].ToString() == nowt.Text)
                    {
                        label1.Text = listBox1.Items[t].ToString();
                        bellplaying();
                    }
                }
               
            }
            else if (listselect == listBox2)
            {
                if (nowt.Text == ps)
                {
                    wmp.URL = "Sound/prayer.mp3";
                    wmp.controls.play();
                }
                else if (nowt.Text == na)
                {
                    wmp.URL = "Sound/Janagana.mp3";
                    wmp.controls.play();
                }

                for (int t = 0; t < listBox2.Items.Count; t++)
                {
                    if (listBox2.Items[t].ToString() == nowt.Text)
                    {
                        label1.Text = listBox2.Items[t].ToString();
                        bellplaying();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wmp.URL = "Sound/Janagana.mp3";
            wmp.controls.play(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wmp.URL = "Sound/prayer.mp3";
            wmp.controls.play(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

            ProcessStartInfo sInfo = new ProcessStartInfo("Automatic Belling");
            Process.Start(sInfo);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure want to exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlg == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void automaticBellingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settingsf sf = new Settingsf();
            sf.ShowDialog();
            if(timer2.Enabled)
            timer2.Stop();

            daytimeset();
            if (AutomaticBelling.Properties.Settings.Default.timerstat== true)
            { timer2.Start(); }

        }

        private void bellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }
    }
}
