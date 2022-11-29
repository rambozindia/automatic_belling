using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace AutomaticBelling
{
    public partial class Settingsf : Form
    {
        WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
        public Settingsf()
        {
            InitializeComponent();
        }

        private void Settingsf_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < AutomaticBelling.Properties.Settings.Default.allday.Count; i++)
                listBox1.Items.Add(AutomaticBelling.Properties.Settings.Default.allday[i]);
            listBox1.SelectedIndex=0;
            for (int i = 0; i < AutomaticBelling.Properties.Settings.Default.friday.Count; i++)
                listBox2.Items.Add(AutomaticBelling.Properties.Settings.Default.friday[i]);
            listBox2.SelectedIndex = 0;

            textBox8.Text = AutomaticBelling.Properties.Settings.Default.prayer;
            textBox7.Text = AutomaticBelling.Properties.Settings.Default.nationalanthem;
            textBox6.Text = AutomaticBelling.Properties.Settings.Default.prayerf;
            textBox5.Text = AutomaticBelling.Properties.Settings.Default.nationalanthemf;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = listBox1.SelectedItem.ToString();
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items[listBox1.SelectedIndex] = textBox1.Text.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectionMode != SelectionMode.None)
            {

                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            wmp.URL = "";
            this.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                textBox4.Text = listBox2.SelectedItem.ToString();
            }
            catch (Exception) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(textBox3.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectionMode != SelectionMode.None)
            {

                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text == "Play")
            {
                wmp.URL = "Sound/bell.mp3";
                wmp.controls.play();
                button12.Text = "Stop";
            }
            else if (button12.Text == "Stop")
            {
                wmp.controls.stop();
                button12.Text = "Play";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {       
            if (button13.Text == "Play")
            {
                wmp.URL = "Sound/prayer.mp3";
                wmp.controls.play();
                button13.Text = "Stop";
            }
            else if (button13.Text == "Stop")
            {
                wmp.controls.stop();
                button13.Text = "Play";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.Text == "Play")
            {
                wmp.URL = "Sound/Janagana.mp3";
                wmp.controls.play();
                button14.Text = "Stop";
            }
            else if (button14.Text == "Stop")
            {
                wmp.controls.stop();
                button14.Text = "Play";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            wmp.URL = "";
            openFileDialog1.InitialDirectory = System.Environment.SpecialFolder.Desktop.ToString();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string SourcePath = openFileDialog1.FileName;
                string DestinationPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Sound\\bell.mp3";
                File.Copy(SourcePath, DestinationPath, true);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            wmp.URL = "";
            openFileDialog1.InitialDirectory = System.Environment.SpecialFolder.Desktop.ToString();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string SourcePath = openFileDialog1.FileName;
                string DestinationPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Sound\\prayer.mp3";
                File.Copy(SourcePath, DestinationPath, true);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            wmp.URL = "";
            openFileDialog1.InitialDirectory = System.Environment.SpecialFolder.Desktop.ToString();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string SourcePath = openFileDialog1.FileName;
                string DestinationPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Sound\\Janagana.mp3";
                File.Copy(SourcePath, DestinationPath, true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AutomaticBelling.Properties.Settings.Default.allday.Clear();
            for (int i = 0; i < listBox1.Items.Count; i++)
                AutomaticBelling.Properties.Settings.Default.allday.Add(listBox1.Items[i].ToString());

            AutomaticBelling.Properties.Settings.Default.friday.Clear();
            for (int i = 0; i < listBox2.Items.Count; i++)
                AutomaticBelling.Properties.Settings.Default.friday.Add(listBox2.Items[i].ToString());

            AutomaticBelling.Properties.Settings.Default.prayer = textBox8.Text;
            AutomaticBelling.Properties.Settings.Default.nationalanthem = textBox7.Text;

            AutomaticBelling.Properties.Settings.Default.prayerf = textBox6.Text;
            AutomaticBelling.Properties.Settings.Default.nationalanthemf = textBox5.Text;

            AutomaticBelling.Properties.Settings.Default.Save();
            wmp.URL = "";
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items[listBox2.SelectedIndex] = textBox4.Text.ToString();
        }
    }
}
