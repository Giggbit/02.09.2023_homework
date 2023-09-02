using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02._09._2023_Проводник
{
    public partial class Form1 : Form
    {

        public Form1() {
            InitializeComponent();

            DriveInfo[] drive = DriveInfo.GetDrives();
            foreach (DriveInfo d in drive) { 
                comboBox1.Items.Add(d.Name);
            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            string name = comboBox1.SelectedItem.ToString();
            listBox1.Items.Clear();
            string[] dirs = Directory.GetDirectories(name);
            foreach (string dir in dirs) {
                listBox1.Items.Add(dir);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            textBox1.Text = listBox1.SelectedItem.ToString();
            listBox2.Items.Clear();

            try {
                string[] dirs = Directory.GetFileSystemEntries(listBox1.SelectedItem.ToString());
                foreach (string dir in dirs) {
                    listBox2.Items.Add(dir);
                }
            }
            catch {
                MessageBox.Show("Error");
            }  
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
    }
}
