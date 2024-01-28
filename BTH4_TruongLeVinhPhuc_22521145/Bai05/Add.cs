using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Bai05
{
    public partial class Add : Form
    {
        private TextBox _txtMaSV;
        private TextBox _txtTenSV;
        private ComboBox _txtKhoa;
        private TextBox _txtDiemTB;
        private Button add;
        private Button exit;
        private Label _lbMaSV;
        private Label _lbTenSV;
        private Label _lbKhoa;
        private Label _lbDiemTB;
        private Form1 _form1;

        public Add(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 220);
            Text = "Thêm Sinh Viên";

            _txtMaSV = CreateTextBox(50, 10);
            _txtTenSV = CreateTextBox(50, 50);

            _txtKhoa = new ComboBox();
            _txtKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            _txtKhoa.Items.AddRange(new string[]
            {
                "Khoa học Kĩ thuật Thông tin",
                "Khoa học máy tính",
                "Công nghệ Phần mềm",
                "Hệ thống thông tin",
                "Kỹ thuật máy tính",
                "Mạng máy tính và truyền thông"
            });
            _txtKhoa.Location = new Point(150, 90);
            _txtKhoa.Size = new Size(200, 30);

            _txtDiemTB = CreateTextBox(50, 130);

            add = CreateButton("Thêm Mới", 50, 170, 100);
            add.BackColor = Color.Green;
            add.FlatStyle = FlatStyle.Flat;
            add.Click += AddNew;

            exit = CreateButton("Thoát", 250, 170, 100);
            exit.BackColor = Color.OrangeRed;
            exit.FlatStyle = FlatStyle.Flat;
            exit.Click += Cancel;


            _lbMaSV = CreateLabel("Mã Số Sinh Viên", 50, 10);
            _lbTenSV = CreateLabel("Tên Sinh Viên", 50, 50);
            _lbKhoa = CreateLabel("Khoa", 50, 90);
            _lbDiemTB = CreateLabel("Điểm TB", 50, 130);

            Controls.Add(_txtMaSV);
            Controls.Add(_txtTenSV);
            Controls.Add(_txtKhoa);
            Controls.Add(_txtDiemTB);
            Controls.Add(add);
            Controls.Add(exit);
            Controls.Add(_lbMaSV);
            Controls.Add(_lbTenSV);
            Controls.Add(_lbKhoa);
            Controls.Add(_lbDiemTB);
        }

        private TextBox CreateTextBox(int left, int top)
        {
            var textBox = new TextBox();
            textBox.Location = new Point(150, top);
            textBox.Size = new Size(200, 30);
            return textBox;
        }

        private Button CreateButton(string text, int left, int top, int width)
        {
            var button = new Button();
            button.Text = text;
            button.Location = new Point(left, top);
            button.Size = new Size(width, 30);
            return button;
        }

        private Label CreateLabel(string text, int left, int top)
        {
            var label = new Label();
            label.Text = text;
            label.Location = new Point(left, top);
            label.Size = new Size(100, 30);
            return label;
        }

        private void AddNew(object sender, EventArgs e)
        {
            var student = new Student();

            student.MaSV = _txtMaSV.Text;
            student.TenSV = _txtTenSV.Text;
            student.Khoa = _txtKhoa.Text;
            student.DiemTB = _txtDiemTB.Text;

            if (student.MaSV == "" || student.TenSV == "" || student.Khoa == "" || student.DiemTB == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var s in _form1.students)
            {
                if (s.MaSV == student.MaSV)
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                var gpa = float.Parse(student.DiemTB);
                if (gpa < 0 || gpa > 10)
                {
                    MessageBox.Show("Điểm trung bình không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Điểm trung bình không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _form1.AddStudent(student);

            Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}