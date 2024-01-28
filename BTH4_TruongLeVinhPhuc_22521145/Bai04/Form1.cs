using System.ComponentModel;

namespace Bai04
{
    public partial class Form1 : Form
    {
        private RichTextBox richTextBox;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuItem1;
        private ToolStripButton menuItem2;
        private ToolStrip toolStrip;
        private ToolStripButton newButton;
        private ToolStripButton saveButton;
        private ToolStripButton boldButton;
        private ToolStripButton italicButton;
        private ToolStripButton underlineButton;
        private ToolStripComboBox fontSizeComboBox;
        private ToolStripComboBox fontComboBox;


        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            components = new Container();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Text = "Soạn thảo văn bản";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            richTextBox = new RichTextBox();
            richTextBox.Location = new Point(20, 20);
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Text = "";
            Controls.Add(richTextBox);

            menuStrip = new MenuStrip();

            menuItem1 = new ToolStripMenuItem("Hệ thống");
            menuItem2 = new ToolStripButton("Định dạng");

            menuStrip.Items.Add(menuItem1);
            menuStrip.Items.Add(menuItem2);

            menuItem1.DropDownItems.Add("Tạo văn bản mới");
            menuItem1.DropDownItems.Add("Mở tập tin");
            menuItem1.DropDownItems.Add("Lưu tập tin");
            menuItem1.DropDownItems.Add("Thoát");
            menuItem1.DropDownItems[0].Image = Image.FromFile(@"..\..\..\Assets\new.png");
            menuItem1.DropDownItems[1].Image = Image.FromFile(@"..\..\..\Assets\open.png");
            menuItem1.DropDownItems[2].Image = Image.FromFile(@"..\..\..\Assets\save.png");
            menuItem1.DropDownItems[3].Image = Image.FromFile(@"..\..\..\Assets\exit.png");

            menuItem1.DropDownItemClicked += menuStrip_DropDownItemClicked;
            menuItem2.Click += formatMenu_Clicked;


            toolStrip = new ToolStrip();


            newButton = new ToolStripButton();
            newButton.Image = Image.FromFile(@"..\..\..\Assets\new.png");
            newButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newButton.Click += newButton_Click;
            toolStrip.Items.Add(newButton);

            saveButton = new ToolStripButton();
            saveButton.Image = Image.FromFile(@"..\..\..\Assets\save.png");
            saveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveButton.Click += saveButton_Click;
            toolStrip.Items.Add(saveButton);


            boldButton = new ToolStripButton();
            boldButton.Text = "B";
            boldButton.Font = new Font(boldButton.Font, FontStyle.Bold);
            boldButton.Font = new Font(boldButton.Font, FontStyle.Bold);
            boldButton.Click += boldButton_Click;
            toolStrip.Items.Add(boldButton);

            italicButton = new ToolStripButton();
            italicButton.Text = "I";
            italicButton.Font = new Font(italicButton.Font, FontStyle.Italic);
            italicButton.Font = new Font(italicButton.Font, FontStyle.Italic);
            italicButton.Click += italicButton_Click;
            toolStrip.Items.Add(italicButton);

            underlineButton = new ToolStripButton();
            underlineButton.Text = "U";
            underlineButton.Font = new Font(underlineButton.Font, FontStyle.Underline);
            underlineButton.Font = new Font(underlineButton.Font, FontStyle.Underline);
            underlineButton.Click += underlineButton_Click;
            toolStrip.Items.Add(underlineButton);

            fontSizeComboBox = new ToolStripComboBox();
            fontSizeComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            fontSizeComboBox.Items.AddRange(new object[]
            {
                "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72"
            });
            fontSizeComboBox.Name = "fontSizeComboBox";
            fontSizeComboBox.SelectedIndex = 6;
            fontSizeComboBox.Size = new Size(75, 25);
            fontSizeComboBox.TextChanged += fontSizeComboBox_TextChanged;
            toolStrip.Items.Add(fontSizeComboBox);

            fontComboBox = new ToolStripComboBox();
            fontComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            foreach (FontFamily font in FontFamily.Families)
            {
                fontComboBox.Items.Add(font.Name);
            }

            richTextBox.Font = new Font("Arial", 12);
            fontComboBox.SelectedItem = richTextBox.SelectionFont.Name;

            fontComboBox.Name = "fontComboBox";
            richTextBox.Font = new Font("Arial", 12);


            fontComboBox.Size = new Size(121, 25);
            fontComboBox.TextChanged += fontComboBox_TextChanged;
            toolStrip.Items.Add(fontComboBox);

            toolStrip.Location = new Point(0, 24);
            toolStrip.Size = new Size(800, 25);
            toolStrip.Stretch = true;

            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                newButton_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                saveButton_Click(sender, e);
            }
        }


        private void formatMenu_Clicked(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            fontDialog.ShowApply = true;
            fontDialog.Apply += fontDialog_Apply;
            fontDialog.ShowDialog();
        }

        private void fontDialog_Apply(object sender, EventArgs e)
        {
            FontDialog fontDialog = (FontDialog)sender;
            richTextBox.SelectionFont = fontDialog.Font;
            richTextBox.SelectionColor = fontDialog.Color;
        }


        private void menuStrip_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)e.ClickedItem;
            switch (menuItem.Text)
            {
                case "Tạo văn bản mới":
                    richTextBox.Clear();
                    break;
                case "Mở tập tin":
                    menuItem1.HideDropDown();
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    }

                    break;
                case "Lưu tập tin":
                    menuItem1.HideDropDown();
                    saveButton_Click(sender, e);
                    break;

                case "Thoát":
                    Application.Exit();
                    break;
            }
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }

        private void ToggleFontStyle(FontStyle style)
        {
            if (richTextBox.SelectionFont != null)
            {
                FontStyle newStyle;
                if (richTextBox.SelectionFont.Style.HasFlag(style))
                    newStyle = richTextBox.SelectionFont.Style & ~style;
                else
                    newStyle = richTextBox.SelectionFont.Style | style;

                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, newStyle);
            }
        }

        private void fontSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont != null)
            {
                richTextBox.SelectionFont =
                    new Font(richTextBox.SelectionFont.FontFamily, float.Parse(fontSizeComboBox.Text));
            }
        }

        private void fontComboBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont != null)
            {
                richTextBox.SelectionFont = new Font(fontComboBox.Text, richTextBox.SelectionFont.Size);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.OverwritePrompt = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                richTextBox.SaveFile(filePath, RichTextBoxStreamType.RichText);
            }

            MessageBox.Show("Lưu thành công!");
        }
    }
}