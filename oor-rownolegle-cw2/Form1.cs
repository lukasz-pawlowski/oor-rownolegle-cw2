using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oor_rownolegle_cw2
{
    public partial class Form1 : Form
    {
        //callback
        delegate void SetTextCallback(string text);

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (listBox1.Items.Count > 0)
            {
                String s;
                s = listBox1.Items[0].ToString();
                listBox1.Items.RemoveAt(0);

                Thread myNewThread = new Thread(
                    () => writeToBox( s )
                    );

                myNewThread.Start();
            }
        }

        private void writeToBox(string s)
        {
            for (int i = 0; i < numericUpDown1.Value; i++)
            {

              //  System.Threading.Thread.Sleep(5000);
                
                int f;
                for (int j = 0; j < 100000000; j++)
                    f = j * 234332 - j * 2342523;
                    

                // richTextBox1.AppendText(i + ": " + s);
                this.SetText(i + ": " + s + "\r\n");
            }

        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.AppendText(text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Thread myNewThread = new Thread(
                () => writeToBox(
                    textBox2.Text.ToString())
                );

            myNewThread.Priority = ThreadPriority.Highest;
            myNewThread.Start();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox1.Items.Add('a');
            listBox1.Items.Add('b');
            listBox1.Items.Add('c');
            listBox1.Items.Add('d');
            listBox1.Items.Add('e');
            listBox1.Items.Add('f');
            listBox1.Items.Add('g');
        }
    }
}
