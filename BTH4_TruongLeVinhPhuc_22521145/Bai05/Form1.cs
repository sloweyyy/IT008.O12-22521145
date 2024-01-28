using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Bai05
{
    public partial class Form1 : Form
    {
        private MenuStrip _menuStrip;
        private ToolStrip _toolStrip;
        private ListView _listView;
        public List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            StartPosition = FormStartPosition.CenterScreen;
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);

            InitializeControls();
        }

        private void InitializeControls()
        {
            Text = "Quản lý sinh viên";

            var tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;

            _menuStrip = new MenuStrip();
            _menuStrip.Text = "Chức năng";
            _menuStrip.Dock = DockStyle.Top;

            var function = new ToolStripMenuItem("Chức năng");
            var add = new ToolStripMenuItem("Thêm mới", Image.FromFile("..\\..\\..\\Assets\\add.png"), AddNew,
                Keys.Control | Keys.N);
            var exit = new ToolStripMenuItem("Thoát", null, (s, e) => Close());
            function.DropDownItems.AddRange(new ToolStripItem[] { add, exit });
            _menuStrip.Items.Add(function);

            _toolStrip = new ToolStrip();
            _toolStrip.Dock = DockStyle.Bottom;
            var toolStripAddButton =
                new ToolStripButton("Thêm mới", Image.FromFile("..\\..\\..\\Assets\\add.png"), AddNew);
            var toolStripFindLabel = new ToolStripLabel("Tìm kiếm theo tên");
            var toolStripSearchBox = new ToolStripTextBox();
            toolStripSearchBox.Size = new Size(200, 25);
            toolStripSearchBox.TextChanged += Find;
            _toolStrip.Items.AddRange(new ToolStripItem[]
                { toolStripAddButton, toolStripFindLabel, toolStripSearchBox });

            _listView = new ListView();
            _listView.View = View.Details;

            ColumnHeader columnHeaderSTT = new ColumnHeader();
            columnHeaderSTT.Text = "STT";
            columnHeaderSTT.Width = 50;

            ColumnHeader columnHeaderMaSV = new ColumnHeader();
            columnHeaderMaSV.Text = "Mã SV";
            columnHeaderMaSV.Width = 200;

            ColumnHeader columnHeaderTenSV = new ColumnHeader();
            columnHeaderTenSV.Text = "Tên SV";
            columnHeaderTenSV.Width = 200;

            ColumnHeader columnHeaderKhoa = new ColumnHeader();
            columnHeaderKhoa.Text = "Khoa";
            columnHeaderKhoa.Width = 200;

            ColumnHeader columnHeaderDiemTB = new ColumnHeader();
            columnHeaderDiemTB.Text = "Điểm TB";
            columnHeaderDiemTB.Width = 200;

            _listView.Columns.AddRange(new ColumnHeader[]
                { columnHeaderSTT, columnHeaderMaSV, columnHeaderTenSV, columnHeaderKhoa, columnHeaderDiemTB });

            _listView.Dock = DockStyle.Fill;


            tableLayoutPanel.Controls.Add(_menuStrip, 0, 0);
            tableLayoutPanel.Controls.Add(_toolStrip, 0, 1);
            tableLayoutPanel.Controls.Add(_listView, 0, 2);

            Controls.Add(tableLayoutPanel);
        }

        private void AddNew(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Add))
                {
                    form.BringToFront();
                    return;
                }
            }

            var add = new Add(this);
            add.Show();
        }

        private void Find(object sender, EventArgs e)
        {
            _listView.Items.Clear();
            var find = ((ToolStripTextBox)sender).Text.ToLower();
            var index = 1;
            foreach (var student in students)
            {
                if (student.TenSV.ToLower().Contains(find))
                {
                    var item = new ListViewItem();
                    item.Text = index.ToString();
                    item.SubItems.Add(student.MaSV);
                    item.SubItems.Add(student.TenSV);
                    item.SubItems.Add(student.Khoa);
                    item.SubItems.Add(student.DiemTB);
                    _listView.Items.Add(item);
                    index++;
                }
            }
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
            var item = new ListViewItem();
            item.Text = (students.Count).ToString();
            item.SubItems.Add(student.MaSV);
            item.SubItems.Add(student.TenSV);
            item.SubItems.Add(student.Khoa);
            item.SubItems.Add(student.DiemTB);
            _listView.Items.Add(item);
        }
    }
}