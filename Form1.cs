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

namespace UrsulPacalitDeVulpe
{
    public partial class Form1 : Form
    {
        string[] files;
        int ind=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string workingdirectory =Environment.CurrentDirectory;
            string projectd= Directory.GetParent(workingdirectory).Parent.FullName;
            string path= Path.Combine(projectd, "Resurse");
            files = Directory.GetFiles(path);
            pictureBox.Image = Image.FromFile(files[0]);
            timer1.Start();
        }

        private  void timer1_Tick(object sender, EventArgs e)
        {
            if (ind < files.Length - 2)
            {
                ind++;
            }
            else { ind = 0; }
            
           progressBar1.Value = ind;
           pictureBox.Image = Image.FromFile(files[ind]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "manual")
            {
                timer1.Stop();
                buttonPrev.Enabled = true;
                buttonNext.Enabled = true;
                button3.Text = "auto";
            }else
            {
                timer1.Start();
                buttonPrev.Enabled = false;
                buttonNext.Enabled = false;
                button3.Text = "manual";
            }

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (ind < files.Length - 2)
            {
                ind++;
            }
           

            progressBar1.Value = ind;
            pictureBox.Image = Image.FromFile(files[ind]);
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (ind>0)
            {
                ind--;
            }
            

            progressBar1.Value = ind;
            pictureBox.Image = Image.FromFile(files[ind]);
        }
    }
}
