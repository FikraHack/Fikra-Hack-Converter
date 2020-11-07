using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fikra_Hack_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog Open = new OpenFileDialog();
        SaveFileDialog save = new SaveFileDialog();
        Algo Me = new Algo();

        private void button2_Click(object sender, EventArgs e)
        {
            if (Open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Open.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="")
            {
                if (textBox2.Text != "")
                {
                    System.IO.File.WriteAllBytes( Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\Fikra", Me.RC2Encrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text) );               
                }
                else
                {
                    MessageBox.Show("Please Add Key !");
                }
            }
        }

        public static string GeneratorStrings(int length11)
        {
            Random random = new Random();
            return new string((from s in Enumerable.Repeat<string>("ABCDEF5896TYUHNB125FGHKJPO558320CDSEZR478T5G87GHY5Y8U8QSACV4789BG855480G478AZERBC45C54FAZ89AZER8T54GH4H747H454B4V47F7G47GH7H4H7DFDSSZ45E47F47F45G58GH55G8G5G85HJ58J8IPOP85AQXCW", length11)
                               select s[random.Next(s.Length)]).ToArray<char>());
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "Click To Get Key" && textBox2.Text != "")
                {
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    button16.Enabled = true;
                    button17.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button16.Enabled = false;
                    button17.Enabled = false;
                }
                button6.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Fikra", Me.RC4Encrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                 
                }
                else
                {
                    MessageBox.Show("Please Add Key !");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Fikra", Me.DESEncrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                    
                }
                else
                {
                    MessageBox.Show("Please Add Key !");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Fikra", Me.Md5Encrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                   
                }
                else
                {
                    MessageBox.Show("Please Add Key !");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Fikra", Me.RSM_Result(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
             
                }
                else
                {
                    MessageBox.Show("Please Add Key !");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Fikra", Me.XOREncrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                }
                else
                {
                    MessageBox.Show("Please Add Key !");
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Fikra", Me.AES_Encrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                }
                else
                {
                    MessageBox.Show("Please Add Key !");
                }
            }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
              System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Fikra", Me.fikralgoEnc(System.IO.File.ReadAllBytes(textBox1.Text)));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                System.IO.MemoryStream MS = new System.IO.MemoryStream();
                Properties.Resources.Moon.Save(MS);
                byte[] Z = System.IO.File.ReadAllBytes(textBox1.Text);
                Z =Me.RC2Encrypt(Z, "fares");
                MS.Write(Z,0, Z.Length);
                System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Fikra.ico", MS.ToArray());
                MS.Close();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            WindowState =FormWindowState.Minimized;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                richTextBox1.Text = Properties.Resources.Vb_RC2Decrypt;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_RC2Decrypt;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.Vb_RC4Decrypt;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_RC4Decrypt;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.Vb_AESDecrypt;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_AESDecrypt;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.Vb_DESDecrypt;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_DESDecrypt;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.Vb_Md5Decrypt;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_Md5Decrypt;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.Vb_RSMDecrypt;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_RSMDecrypt;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.Vb_XORDecrypt;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_XORDecrypt;
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.VB_Fikra;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_fikra;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.Vb_icon;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_icon;
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button ==MouseButtons.Left)
            {
                textBox2.Text = GeneratorStrings(40);
                textBox2.SelectAll();
            }
        }


    }
}
