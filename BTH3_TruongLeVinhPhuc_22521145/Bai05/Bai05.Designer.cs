namespace Bai05
{
    partial class Bai05
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private Label titleLabel;
        private Label accountNumberLabel;
        private Label customerNameLabel;
        private Label addressLabel;
        private Label balanceLabel;
        private TextBox accountNumberTextBox;
        private TextBox customerNameTextBox;
        private TextBox addressTextBox;
        private TextBox balanceTextBox;
        private Button addOrUpdateButton;
        private Button deleteButton;
        private Button exitButton;
        private ListView accountListView;



        private void InitializeComponent()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Text = "Bai05";
            this.ResumeLayout(false);
            this.PerformLayout();
         
            titleLabel = new Label
            {
                Text = "Quản lý thông tin tài khoản",
                Location = new Point(10, 10),
                Font = new Font("Arial", 20, FontStyle.Bold),
                Size = new Size(800, 50), 
            };

            this.Controls.Add(titleLabel);

            accountNumberLabel = new Label
            {
                Text = "Số tài khoản:",
                Location = new Point(10, 100),
            };
            this.Controls.Add(accountNumberLabel);

            accountNumberTextBox = new TextBox
            {
                Location = new Point(300, 100),
                Width = 200,
            };
            this.Controls.Add(accountNumberTextBox);

            customerNameLabel = new Label
            {
                Text = "Tên khách hàng:",
                Location = new Point(10, 150),
            };
            this.Controls.Add(customerNameLabel);

            customerNameTextBox = new TextBox
            {
                Location = new Point(300, 150),
                Width = 200,
            };
            this.Controls.Add(customerNameTextBox);

            addressLabel = new Label
            {
                Text = "Địa chỉ khách hàng:",
                Location = new Point(10, 200),
            };
            this.Controls.Add(addressLabel);

            addressTextBox = new TextBox
            {
                Location = new Point(300, 200),
                Width = 200,
            };
            this.Controls.Add(addressTextBox);

            balanceLabel = new Label
            {
                Text = "Số tiền trong tài khoản:",
                Location = new Point(10, 250),
            };
            this.Controls.Add(balanceLabel);

            balanceTextBox = new TextBox
            {
                Location = new Point(300, 250),
                Width = 200,
            };
            this.Controls.Add(balanceTextBox);

            addOrUpdateButton = new Button
            {
                Text = "Thêm/Cập nhật",
                Location = new Point(10, 300),
                Width = 150,
                Height = 30,
            };
            addOrUpdateButton.Click += AddOrUpdateButton_Click;
            this.Controls.Add(addOrUpdateButton);

            deleteButton = new Button
            {
                Text = "Xoá",
                Location = new Point(200, 300),
                Width = 70,
                Height = 30,
            };
            deleteButton.Click += DeleteButton_Click;
            this.Controls.Add(deleteButton);

            exitButton = new Button
            {
                Text = "Thoát",
                Location = new Point(310, 300),
                Width = 70,
                Height = 30,
            };
            exitButton.Click += ExitButton_Click;
            this.Controls.Add(exitButton);

            accountListView = new ListView
            {
                Location = new Point(10, 350),
                Size = new Size(500, 200),
                View = View.Details,
            };
            
            accountListView.Columns.Add("STT", width: 50);

            accountListView.Columns.Add("Số tài khoản", 120);
            accountListView.Columns.Add("Tên khách hàng", 100);
            accountListView.Columns.Add("Địa chỉ", 100);
            accountListView.Columns.Add("Số tiền", 80);
            this.Controls.Add(accountListView);
            accountListView.SelectedIndexChanged += accountListView_SelectedIndexChanged;

        }

    }
}