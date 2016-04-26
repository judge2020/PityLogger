using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PityLogger
{
    public partial class Pity : Form
    {
        private bool hasSaved = false;
        private string filename;
        public Pity()
        {
            InitializeComponent();
            
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int enterednumber = Int32.Parse(textBox1.Text);
            if (enterednumber >= 5)
            {
                textBox1.Text = 4.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int currentnumber = Int32.Parse(textBox1.Text);
            // common + button

            if (currentnumber != 4)
            {
                int newnum = currentnumber + 1;
                textBox1.Text = newnum.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // common - button
            int currentnumber = Int32.Parse(textBox1.Text);

            if (currentnumber != 0)
            {
                int newnum = currentnumber - 1;
                textBox1.Text = newnum.ToString();
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int enterednumber = Int32.Parse(textBox2.Text);
            if (enterednumber >= 5)
            {
                textBox2.Text = 4.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int currentnumber = Int32.Parse(textBox2.Text);
            // rare + button

            if (currentnumber != 5)
            {
                int newnum = currentnumber + 1;
                textBox2.Text = newnum.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // rare - button
            int currentnumber = Int32.Parse(textBox2.Text);

            if (currentnumber != 0)
            {
                int newnum = currentnumber - 1;
                textBox2.Text = newnum.ToString();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int enterednumber = Int32.Parse(textBox3.Text);
            if (enterednumber >= 5)
            {
                textBox3.Text = 4.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int currentnumber = Int32.Parse(textBox3.Text);
            // epic + button

            if (currentnumber != 5)
            {
                int newnum = currentnumber + 1;
                textBox3.Text = newnum.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // epic - button
            int currentnumber = Int32.Parse(textBox3.Text);

            if (currentnumber != 0)
            {
                int newnum = currentnumber - 1;
                textBox3.Text = newnum.ToString();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int enterednumber = Int32.Parse(textBox4.Text);
            if (enterednumber >= 5)
            {
                textBox4.Text = 4.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int currentnumber = Int32.Parse(textBox4.Text);
            // legendary + button

            if (currentnumber != 5)
            {
                int newnum = currentnumber + 1;
                textBox4.Text = newnum.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // legendary - button
            int currentnumber = Int32.Parse(textBox4.Text);

            if (currentnumber != 0)
            {
                int newnum = currentnumber - 1;
                textBox4.Text = newnum.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label5.Text = "Saving...";
            int currentnumber1 = Int32.Parse(textBox1.Text);
            int currentnumber2 = Int32.Parse(textBox2.Text);
            int currentnumber3 = Int32.Parse(textBox3.Text);
            int currentnumber4 = Int32.Parse(textBox4.Text);
            int totalcards = currentnumber1 + currentnumber2 + currentnumber3 + currentnumber4;
            if (totalcards != 5)
            {
                label5.Text = "Please enter five cards.";
            }
            else
            {
                string whattosave = textBox1.Text + ", " + textBox2.Text + ", " + textBox3.Text + ", " + textBox4.Text;
                if (hasSaved == false)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        filename = saveFileDialog1.FileName;
                        hasSaved = true;
                        label5.Text = "Location selected. Please save again.";
                    }
                }
                else
                {
                    using (StreamWriter w = File.AppendText(filename))
                    {
                        Log(whattosave, w);
                        label5.Text = whattosave + " Saved!";
                        textBox1.Text = "4";
                        textBox2.Text = "1";
                        textBox3.Text = "0";
                        textBox4.Text = "0";

                    }

                    using (StreamReader r = File.OpenText(filename))
                    {
                        DumpLog(r);
                    }
                }
                
            }
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.WriteLine(logMessage);
            
        }
        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
