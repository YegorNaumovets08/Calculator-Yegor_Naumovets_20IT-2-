using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator_2_
{
    public partial class CalculatorForm : Form
    {
        public Calculate calculate;
        public string a;
        public string b;
        public char znak = ' ';
        public bool zexist = false;
        public bool rstexist = false;
        public CalculatorForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void screencalcul_TextChanged(object sender, EventArgs e)
        {
            EnableButton();
            DisEnableButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Numbr(button3.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Numbr(button6.Text);
        }

        private void SymbolSub_Click(object sender, EventArgs e)
        {
            SetZnak(SymbolSub.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Numbr(button1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Numbr(button2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Numbr(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Numbr(button5.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Numbr(button7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Numbr(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Numbr(button9.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Numbr(button0.Text);
        }

        private void SymbolSum_Click(object sender, EventArgs e)
        {
            SetZnak(SymbolSum.Text);
        }

        private void SymbolMul_Click(object sender, EventArgs e)
        {
            SetZnak(SymbolMul.Text);
        }

        private void SymbolDiv_Click(object sender, EventArgs e)
        {
            SetZnak(SymbolDiv.Text);
        }

        private void PosNegButton_Click(object sender, EventArgs e)
        {
            PosNegNmbr();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Equal();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void PosNegLabel_Click(object sender, EventArgs e)
        {

        }
        public void Numbr(string Nmbr)
        {
            if (zexist == false && screencalcul.Text != "0")
            {
                screencalcul.Text = screencalcul.Text + Nmbr;
                a = a + Nmbr;
            }
            else if (screencalcul.Text == "0" && zexist == false)
            {
                screencalcul.Text = null;
                screencalcul.Text = screencalcul.Text + Nmbr;
                a = a + Nmbr;
            }
            else if (screencalcul.Text == "0" && zexist != false)
            {
                screencalcul.Text = null;
                screencalcul.Text = screencalcul.Text + Nmbr;
                b = b + Nmbr;
            }
            else if (rstexist == true)
            {
                screencalcul.Text = null;
                screencalcul.Text = screencalcul.Text + Nmbr;
                b = b + Nmbr;
                rstexist = false;
            }
            else if (zexist == true && screencalcul.Text != "0" && screencalcul.Text == b)
            {
                screencalcul.Text = screencalcul.Text + Nmbr;
                b = b + Nmbr;
            }
            else if (zexist == true && screencalcul.Text != null)
            {
                screencalcul.Text = null;
                screencalcul.Text = screencalcul.Text + Nmbr;
                b = b + Nmbr;
            }
        }
        public void SetZnak(string z)
        {
            AllButtonsEnable();
            if (a!= null && zexist == false)
            {
                znak = char.Parse(z);
                zexist = true;
            }
            else if (a == null && zexist == false)
            {
                screencalcul.Text = null;
            }
            else
            {
                Equal();
                rstexist = true;
                znak = char.Parse(z);
                zexist = true;
            }
        }
        public void Equal()
        {
            if (a != null && a != "-" && b != null && znak != ' ')
            { 
                calculate = new Calculate(int.Parse(a), int.Parse(b), znak);
                if (calculate.Operation() > 999999999 || calculate.Operation() <= -999999999)
                {
                    screencalcul.Text = "EXCEEDED";
                    PosNegLabel.Text = null;
                    a = calculate.Operation().ToString();
                    AllButtonsDisenable();
                }
                else
                {
                    a = calculate.Operation().ToString();
                }
                if (a[0] == '-' && a.Length <= 9)
                {
                    PosNegLabel.Text = "-";
                    screencalcul.Text = a.Remove(0,1);
                }
                else if (b == "0" && znak == '/')
                {
                    screencalcul.Text = "NOT ÷ 0";
                    AllButtonsDisenable();
                }
                else if (a[0] != '-' && a.Length <= 9)
                {
                    PosNegLabel.Text = null;
                    screencalcul.Text = a;
                }
                rstexist = false;
                zexist = false;
                b = null;
            }
            else if (a != null && b == null)
            {
                if (a[0] == '-')
                {
                    PosNegLabel.Text = "-";
                    screencalcul.Text = a.Remove(0, 1);
                }
                else if (a[0] != '-')
                {
                    PosNegLabel.Text = null;
                    screencalcul.Text = a;
                }
            }
            else if (a == null && b == null)
            {
                ClearAll();
            }
            else if (a == "-" || a == null && zexist == true && b !=null)
            {
                a = "0";
                Equal();
            }
            else if (a!= null && b == "0" && znak == '/')
            {
                screencalcul.Text = "NOT ÷ 0";
                AllButtonsDisenable();
            }
        }
        public void PosNegNmbr()
        {
            if (PosNegLabel.Text != "-")
            {
                PosNegLabel.Text = "-";
                a = "-" + a;
            }
            else if (PosNegLabel.Text == "-")
            {
                PosNegLabel.Text = null;
                a = a.Remove(0, 1);
            }
        }
        public void ClearAll()
        {
            screencalcul.Text = null;
            PosNegLabel.Text = null;
            znak = ' ';
            zexist = false;
            a = null;
            b = null;
            rstexist = false;
            AllButtonsEnable();
        }
        public void DisEnableButton()
        {
            if (screencalcul.Text.Length >= 9)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button0.Enabled = false;
            }
        }
        public void EnableButton()
        {
            if (screencalcul.Text.Length < 9)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button0.Enabled = true;
            }
        }
        public void AllButtonsEnable()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button0.Enabled = true;
            SymbolSum.Enabled = true;
            SymbolSub.Enabled = true;
            SymbolMul.Enabled = true;
            SymbolDiv.Enabled = true;
            button17.Enabled = true;
            screencalcul.Enabled = true;
            PosNegButton.Enabled = true;
        }
        public void AllButtonsDisenable()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button0.Enabled = false;
            SymbolSum.Enabled = false;
            SymbolSub.Enabled = false;
            SymbolMul.Enabled = false;
            SymbolDiv.Enabled = false;
            button17.Enabled = false;
            screencalcul.Enabled = false;
            PosNegButton.Enabled = false;
        }

        private void ColourTopic_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Bisque)
            {
                this.BackColor = Color.DimGray;
                button1.BackColor = Color.Silver;
                button2.BackColor = Color.Silver;
                button3.BackColor = Color.Silver;
                button4.BackColor = Color.Silver;
                button5.BackColor = Color.Silver;
                button6.BackColor = Color.Silver;
                button7.BackColor = Color.Silver;
                button8.BackColor = Color.Silver;
                button9.BackColor = Color.Silver;
                button0.BackColor = Color.Silver;
                PosNegButton.BackColor = Color.SlateGray;
                button12.BackColor = Color.DarkSlateGray;
                SymbolSum.BackColor = Color.SlateGray;
                SymbolSub.BackColor = Color.SlateGray;
                SymbolMul.BackColor = Color.SlateGray;
                SymbolDiv.BackColor = Color.SlateGray;
                button17.BackColor = Color.SlateGray;
                screencalcul.BackColor = Color.LightGray;
                PosNegLabel.BackColor = Color.LightGray;
            }
            else
            {
                this.BackColor = Color.Bisque;
                button1.BackColor = Color.PaleGoldenrod;
                button2.BackColor = Color.PaleGoldenrod;
                button3.BackColor = Color.PaleGoldenrod;
                button4.BackColor = Color.PaleGoldenrod;
                button5.BackColor = Color.PaleGoldenrod;
                button6.BackColor = Color.PaleGoldenrod;
                button7.BackColor = Color.PaleGoldenrod;
                button8.BackColor = Color.PaleGoldenrod;
                button9.BackColor = Color.PaleGoldenrod;
                button0.BackColor = Color.PaleGoldenrod;
                PosNegButton.BackColor = Color.LightSalmon;
                button12.BackColor = Color.IndianRed;
                SymbolSum.BackColor = Color.LightSalmon;
                SymbolSub.BackColor = Color.LightSalmon;
                SymbolMul.BackColor = Color.LightSalmon;
                SymbolDiv.BackColor = Color.LightSalmon;
                button17.BackColor = Color.LightSalmon;
                screencalcul.BackColor = Color.MistyRose;
                PosNegLabel.BackColor = Color.MistyRose;
            }

        }
    }
}
