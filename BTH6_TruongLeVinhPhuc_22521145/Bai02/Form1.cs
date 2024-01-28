using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0;
        public Button btnCong, btnTru, btnNhan, btnChia, btnBang, btnXoa, btnXoaHet, btnCE, btnCham;
        public Button btnPhanSo, btnMC, btnMR, btnMS, btnSqrt, btnMCong, btnCongTru, btnPhanTram;
        public int buttonMargin = 5;

        public int buttonSize = 50;
        public bool isTypingNumber;
        public double ketQua;
        public MainMenu menu;
        public MenuItem menuItem;
        public string phepToan = "";
        public int textBoxHeight = 30;
        public TextBox txtKetQua;
        public int Memory = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            components = new Container();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 360);
            Text = "Calculator";

            btn0 = new Button();
            ConfigureButton(btn0, "0", 70, 280);
            btn1 = new Button();
            ConfigureButton(btn1, "1", 70, 220);
            btn2 = new Button();
            ConfigureButton(btn2, "2", 130, 220);
            btn3 = new Button();
            ConfigureButton(btn3, "3", 190, 220);
            btn4 = new Button();
            ConfigureButton(btn4, "4", 70, 160);
            btn5 = new Button();
            ConfigureButton(btn5, "5", 130, 160);
            btn6 = new Button();
            ConfigureButton(btn6, "6", 190, 160);
            btn7 = new Button();
            ConfigureButton(btn7, "7", 70, 100);
            btn8 = new Button();
            ConfigureButton(btn8, "8", 130, 100);
            btn9 = new Button();
            ConfigureButton(btn9, "9", 190, 100);

            btnCong = new Button();
            ConfigureButton(btnCong, "+", 250, 280);
            btnTru = new Button();
            ConfigureButton(btnTru, "-", 250, 220);
            btnNhan = new Button();
            ConfigureButton(btnNhan, "*", 250, 160);
            btnChia = new Button();
            ConfigureButton(btnChia, "/", 250, 100);
            btnBang = new Button();
            ConfigureButton(btnBang, "=", 310, 280);

            btnCongTru = new Button();
            ConfigureButton(btnCongTru, "+/-", 130, 280);
            btnCham = new Button();
            ConfigureButton(btnCham, ".", 190, 280);
            btnPhanSo = new Button();
            ConfigureButton(btnPhanSo, "1/x", 310, 220);
            btnPhanTram = new Button();
            ConfigureButton(btnPhanTram, "%", 310, 160);
            btnSqrt = new Button();
            ConfigureButton(btnSqrt, "sqrt", 310, 100);

            btnMC = new Button();
            ConfigureButton(btnMC, "MC", 10, 100);
            btnMR = new Button();
            ConfigureButton(btnMR, "MR", 10, 160);
            btnMS = new Button();
            ConfigureButton(btnMS, "MS", 10, 220);
            btnMCong = new Button();
            ConfigureButton(btnMCong, "M+", 10, 280);

            btnXoa = new Button();
            ConfigureButton(btnXoa, "<--", 10, 40, 2);
            btnCE = new Button();
            ConfigureButton(btnCE, "CE", 130, 40, 2);
            btnXoaHet = new Button();
            ConfigureButton(btnXoaHet, "C", 250, 40, 2);

            txtKetQua = new TextBox();
            txtKetQua.Location = new Point(10, 10);
            txtKetQua.Size = new Size(340, 30);
            txtKetQua.Text = "0";
            txtKetQua.TextAlign = HorizontalAlignment.Right;


            Controls.Add(txtKetQua);
            Controls.AddRange(new Control[]
            {
                btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0, btnCong, btnTru, btnNhan, btnChia, btnBang,
                btnXoa, btnXoaHet, btnCE, btnPhanSo, btnMC, btnMR, btnMS, btnSqrt, btnMCong, btnCongTru, btnPhanTram
            });
        }

        public void ConfigureButton(Button button, string text, int x, int y, int widthMultiplier = 1)
        {
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(buttonSize, buttonSize);
            button.Click += Button_Click;
            Controls.Add(button);
            button.Width = button.Width * widthMultiplier;
        }


        private void Button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var buttonText = button.Text;
            switch (buttonText)
            {
                case "1":
                    btn1_Click(sender, e);
                    break;
                case "2":
                    btn2_Click(sender, e);
                    break;
                case "3":
                    btn3_Click(sender, e);
                    break;
                case "4":
                    btn4_Click(sender, e);
                    break;
                case "5":
                    btn5_Click(sender, e);
                    break;
                case "6":
                    btn6_Click(sender, e);
                    break;
                case "7":
                    btn7_Click(sender, e);
                    break;
                case "8":
                    btn8_Click(sender, e);
                    break;
                case "9":
                    btn9_Click(sender, e);
                    break;
                case "0":
                    btn0_Click(sender, e);
                    break;
                case "+":
                    btnCong_Click(sender, e);
                    break;
                case "-":
                    btnTru_Click(sender, e);
                    break;
                case "*":
                    btnNhan_Click(sender, e);
                    break;
                case "/":
                    btnChia_Click(sender, e);
                    break;
                case "=":
                    btnBang_Click(sender, e);
                    break;
                case "←":
                    btnXoa_Click(sender, e);
                    break;
                case "C":
                    btnXoaHet_Click(sender, e);
                    break;
                case "CE":
                    btnCE_Click(sender, e);
                    break;
                case "1/x":
                    btnPhanSo_Click(sender, e);
                    break;
                case "MC":
                    btnMC_Click(sender, e);
                    break;
                case "MR":
                    btnMR_Click(sender, e);
                    break;
                case "MS":
                    btnMS_Click(sender, e);
                    break;
                case "Sqrt":
                    btnSqrt_Click(sender, e);
                    break;
                case "M+":
                    btnMCong_Click(sender, e);
                    break;
                case "+/-":
                    btnCongTru_Click(sender, e);
                    break;
                case "%":
                    btnPhanTram_Click(sender, e);
                    break;
            }
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            if (isTypingNumber)
            {
                txtKetQua.Text += "1";
            }
            else
            {
                txtKetQua.Text = "1";
                isTypingNumber = true;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (isTypingNumber)
            {
                txtKetQua.Text += "2";
            }
            else
            {
                txtKetQua.Text = "2";
                isTypingNumber = true;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (isTypingNumber)
            {
                txtKetQua.Text += "3";
            }
            else
            {
                txtKetQua.Text = "3";
                isTypingNumber = true;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (isTypingNumber)
            {
                txtKetQua.Text += "4";
            }
            else
            {
                txtKetQua.Text = "4";
                isTypingNumber = true;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (isTypingNumber)
            {
                txtKetQua.Text += "5";
            }
            else
            {
                txtKetQua.Text = "5";
                isTypingNumber = true;
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (isTypingNumber)
            {
                txtKetQua.Text += "6";
            }
            else
            {
                txtKetQua.Text = "6";
                isTypingNumber = true;
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (isTypingNumber)
            {
                txtKetQua.Text += "7";
            }
            else
            {
                txtKetQua.Text = "7";
                isTypingNumber = true;
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (isTypingNumber)
            {
                txtKetQua.Text += "8";
            }
            else
            {
                txtKetQua.Text = "8";
                isTypingNumber = true;
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (isTypingNumber)
            {
                txtKetQua.Text += "9";
            }
            else
            {
                txtKetQua.Text = "9";
                isTypingNumber = true;
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (isTypingNumber)
            {
                txtKetQua.Text += "0";
            }
            else
            {
                txtKetQua.Text = "0";
                isTypingNumber = true;
            }
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            PerformOperation();
            phepToan = "+";
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            PerformOperation();
            phepToan = "-";
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            PerformOperation();
            phepToan = "*";
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            PerformOperation();
            phepToan = "/";
        }

        private void PerformOperation()
        {
            var currentNumber = double.Parse(txtKetQua.Text);
            switch (phepToan)
            {
                case "+":
                    ketQua += currentNumber;
                    break;
                case "-":
                    ketQua -= currentNumber;
                    break;
                case "*":
                    ketQua *= currentNumber;
                    break;
                case "/":
                    if (currentNumber != 0)
                        ketQua /= currentNumber;
                    else
                        MessageBox.Show("Cannot divide by zero");
                    break;
                default:
                    ketQua = currentNumber;
                    break;
            }

            txtKetQua.Text = ketQua.ToString();
            isTypingNumber = false;
            phepToan = "";
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            PerformOperation();
            phepToan = "";
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            var length = txtKetQua.Text.Length;
            if (length > 0) txtKetQua.Text = txtKetQua.Text.Remove(length - 1, 1);

            if (length == 1) txtKetQua.Text = "0";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtKetQua.Text = "0";
            isTypingNumber = false;
        }


        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            txtKetQua.Text = "0";
        }

        private void btnPhanSo_Click(object sender, EventArgs e)
        {
            var ketQua = double.Parse(txtKetQua.Text);

            if (ketQua != 0)
                txtKetQua.Text = (1 / ketQua).ToString();
            else
                MessageBox.Show("Cannot divide by zero");
        }


        private void btnMC_Click(object sender, EventArgs e)
        {
            Memory = 0;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            txtKetQua.Text = Memory.ToString();
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            Memory = int.Parse(txtKetQua.Text);
        }

        private void btnMCong_Click(object sender, EventArgs e)
        {
            Memory += int.Parse(txtKetQua.Text);

        }
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            var ketQua = double.Parse(txtKetQua.Text);

            if (ketQua >= 0)
                txtKetQua.Text = Math.Sqrt(ketQua).ToString();
            else
                MessageBox.Show("Cannot calculate square root of a negative number");
        }


        private void btnCongTru_Click(object sender, EventArgs e)
        {
            var ketQua = double.Parse(txtKetQua.Text);
            txtKetQua.Text = (-ketQua).ToString();
        }

        private void btnPhanTram_Click(object sender, EventArgs e)
        {
            var ketQua = double.Parse(txtKetQua.Text);
            txtKetQua.Text = (ketQua / 100).ToString();
        }
    }
}