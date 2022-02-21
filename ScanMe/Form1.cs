using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
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
                richTextBox2.Clear();
            }
        }

        int BBB;

        private void button30_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                richTextBox1.Text = Convert.ToBase64String(System.IO.File.ReadAllBytes(textBox1.Text));
                textBox3.Text = richTextBox1.TextLength.ToString();
                richTextBox1.ForeColor = Color.DodgerBlue;

            }
            else if (richTextBox2.Text != "")
            {
                richTextBox1.Text = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(richTextBox2.Text));
                textBox3.Text = richTextBox1.TextLength.ToString();
                richTextBox1.ForeColor = Color.DodgerBlue;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RC2_Fikra", Me.RC2Encrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                    textBox3.Text = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RC2_Fikra").Length.ToString();
                    richTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RC2_Fikra";
                    richTextBox1.ForeColor = Color.DodgerBlue;
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
            comboBox1.SelectedIndex = 1;
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
                if (textBox2.Text != "Click To Get Key :)" && textBox2.Text != "")
                {
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    button16.Enabled = true;
                    button17.Enabled = true;
                    button22.Enabled = true;
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
                    button22.Enabled = false;
                }
                button6.Enabled = true;
                button20.Enabled = true;
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
                button20.Enabled = false;
                button22.Enabled = false;
            }

            if (richTextBox2.TextLength != 0 | textBox1.Text != "")
            {
                button24.Enabled = true;
                button30.Enabled = true;
            }
            else
            {
                button24.Enabled = false;
                button30.Enabled = false;
            }

            if (richTextBox1.TextLength > 0)
            {
                textBox3.Text = richTextBox1.TextLength.ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RC4_Fikra", Me.RC4Encrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                    textBox3.Text = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RC4_Fikra").Length.ToString();
                    richTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RC4_Fikra";
                    richTextBox1.ForeColor = Color.DodgerBlue;
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
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\DES_Fikra", Me.DESEncrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                    textBox3.Text = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\DES_Fikra").Length.ToString();
                    richTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\DES_Fikra";
                    richTextBox1.ForeColor = Color.DodgerBlue;
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
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MD5_Fikra", Me.Md5Encrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                    textBox3.Text = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MD5_Fikra").Length.ToString();
                    richTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MD5_Fikra";
                    richTextBox1.ForeColor = Color.DodgerBlue;
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
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RSM_Fikra", Me.RSM_Result(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                    textBox3.Text = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RSM_Fikra").Length.ToString();
                    richTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RSM_Fikra";
                    richTextBox1.ForeColor = Color.DodgerBlue;
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
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\XOR_Fikra", Me.XOREncrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                    textBox3.Text = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\XOR_Fikra").Length.ToString();
                    richTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\XOR_Fikra";
                    richTextBox1.ForeColor = Color.DodgerBlue;
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
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\AES_Fikra", Me.AES_Encrypt(System.IO.File.ReadAllBytes(textBox1.Text), textBox2.Text));
                    textBox3.Text = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\AES_Fikra").Length.ToString();
                    richTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\AES_Fikra";
                    richTextBox1.ForeColor = Color.DodgerBlue;
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
                System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RVS_Fikra", Me.fikralgoEnc(System.IO.File.ReadAllBytes(textBox1.Text)));
                textBox3.Text = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RVS_Fikra").Length.ToString();
                richTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RVS_Fikra";
                richTextBox1.ForeColor = Color.DodgerBlue;
            }

        }



        private void button22_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    Aes256 AAA = new Aes256(textBox2.Text);
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\A256_Fikra", AAA.Encrypt(System.IO.File.ReadAllBytes(textBox1.Text)));
                    textBox3.Text = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\A256_Fikra").Length.ToString();
                    richTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\A256_Fikra";
                    richTextBox1.ForeColor = Color.DodgerBlue;
                }
                else
                {
                    MessageBox.Show("Please Add Key !");
                }
            }

        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                BNR binary = new BNR();
                richTextBox1.Text = binary.HexToBinary(System.IO.File.ReadAllBytes(textBox1.Text));
                textBox3.Text = richTextBox1.TextLength.ToString();
                richTextBox1.ForeColor = Color.DodgerBlue;
            }
            else if (richTextBox2.Text != "")
            {
                BNR binary = new BNR();
                richTextBox1.Text = binary.HexToBinary(System.Text.Encoding.Default.GetBytes(richTextBox2.Text));
                textBox3.Text = richTextBox1.TextLength.ToString();
                richTextBox1.ForeColor = Color.DodgerBlue;
            }        
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                System.IO.MemoryStream MS = new System.IO.MemoryStream();
                Properties.Resources.Moon.Save(MS);
                byte[] Z = System.IO.File.ReadAllBytes(textBox1.Text);
                Z = Me.RC2Encrypt(Z, "fares");
                MS.Write(Z, 0, Z.Length);
                System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ICON_Fikra.ico", MS.ToArray());
                MS.Close();
                textBox3.Text = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ICON_Fikra.ico").Length.ToString();
                richTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ICON_Fikra.ico";
                richTextBox1.ForeColor = Color.DodgerBlue;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.VB_D_B64;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_D_B64;
            }

            richTextBox1.ForeColor = Color.Lime;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.Vb_RC2Decrypt;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_RC2Decrypt;
            }

            richTextBox1.ForeColor = Color.Lime;
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
            richTextBox1.ForeColor = Color.Lime;
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
            richTextBox1.ForeColor = Color.Lime;
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
            richTextBox1.ForeColor = Color.Lime;
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
            richTextBox1.ForeColor = Color.Lime;
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
            richTextBox1.ForeColor = Color.Lime;
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
            richTextBox1.ForeColor = Color.Lime;
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
            richTextBox1.ForeColor = Color.Lime;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.Vb_A256;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_A256;
            }
            richTextBox1.ForeColor = Color.Lime;
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
            richTextBox1.ForeColor = Color.Lime;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = Properties.Resources.VB_BNRDecrypt;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = Properties.Resources.C_BNRDecrypt;
            }
            richTextBox1.ForeColor = Color.Lime;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = GeneratorStrings(40);
                textBox2.SelectAll();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }


        private void copieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedRtf, TextDataFormat.Rtf);
            MessageBox.Show("Text Copied :)", "Fikra Hack");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                //1234567891011121314151617181920212122232242526272829303132334353637383940414243444546474849505152535455657585960616236364656676869707172737475767778798081828384858687888990919293949596979899
                if (richTextBox1.Text.Length > 0)
                {

                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        int num_value = (int)numericUpDown1.Value;
                        string text = richTextBox1.Text;
                        int text_size = text.Length;
                        int derive = text_size / num_value;
                        int text_position = 1;
                        int mod_value = text_size % num_value;
                        string contents = "";


                        for (int i = 0; i < num_value; i++)
                        {
                            contents = Strings.Mid(text, text_position, derive);
                            File.WriteAllText(folderBrowserDialog.SelectedPath + "\\Fikra" + i.ToString() + ".txt", contents);
                            text_position = text_position + derive;
                        }

                        if (mod_value > 0)
                        {
                            contents = Strings.Mid(text, text_position, mod_value);
                            File.WriteAllText(folderBrowserDialog.SelectedPath + "\\Fikra" + num_value.ToString() + ".txt", contents);
                            text_position = text_position + mod_value;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                richTextBox1.Text = richTextBox1.Text.Replace(textBox4.Text, textBox5.Text);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void richTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.SelectAll();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.SelectAll();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.SelectAll();
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
        }

        private void copieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox2.SelectedRtf, TextDataFormat.Rtf);
            MessageBox.Show("Text Copied :)", "Fikra Hack");
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }
    }
}
