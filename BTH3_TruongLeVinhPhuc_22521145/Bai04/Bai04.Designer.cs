namespace Bai04
{
    partial class Bai04
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private TableLayoutPanel seatingLayout;
        private Button selectButton;
        private Button cancelButton;
        private Button finishButton;
        private Label totalPriceLabel;
        private double totalPrice;
        private bool[] isSeatSelected;

        private void InitializeComponent()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Text = "Bai04";
            this.ResumeLayout(false);
            this.PerformLayout();

            Label screenLabel = new Label
            {
                Text = "Màn ảnh",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 20),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(0, 50),
            };

            Controls.Add(screenLabel);

            int numRows = 3;
            int numSeatsPerRow = 5;
            int seatingLayoutLeft = 100;
            int seatingLayoutTop = 100;
            int seatingLayoutWidth = 600;
            int seatingLayoutHeight = 250;

            seatingLayout = new TableLayoutPanel();
            seatingLayout.Location = new Point(seatingLayoutLeft, seatingLayoutTop);
            seatingLayout.Size = new Size(seatingLayoutWidth, seatingLayoutHeight);

            seatingLayout.RowCount = numRows;
            seatingLayout.ColumnCount = numSeatsPerRow;

            int seatButtonWidth = seatingLayoutWidth / numSeatsPerRow;
            int seatButtonHeight = seatingLayoutHeight / numRows;

            for (int i = 0; i < numSeatsPerRow; i++)
            {
                seatingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, seatButtonWidth));
            }

            for (int i = 0; i < numRows; i++)
            {
                seatingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, seatButtonHeight));
            }

            isSeatSelected = new bool[numRows * numSeatsPerRow];

            for (int row = 0; row < numRows; row++)
            {
                for (int seat = 0; seat < numSeatsPerRow; seat++)
                {
                    int seatNumber = row * numSeatsPerRow + seat + 1;
                    Button seatButton = new Button
                    {
                        Text = seatNumber.ToString(),
                        Tag = seatNumber,
                        Size = new Size(seatButtonWidth, seatButtonHeight),
                        Location = new Point(seatButtonWidth * seat, seatButtonHeight * row),
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    seatButton.Click += SeatButton_Click;
                    seatingLayout.Controls.Add(seatButton);
                }
            }

            Controls.Add(seatingLayout);
            totalPriceLabel = new Label
            {
                Text = "Tổng tiền: 0",
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(300, 350),
                Size = new Size(200, 50),

            };
            Controls.Add(totalPriceLabel);

            selectButton = new Button
            {
                Text = "CHỌN",
                Size = new Size(100, 50),
                Location = new Point(250, 400),
            };
            selectButton.Click += SelectButton_Click;

            cancelButton = new Button
            {
                Text = "HỦY BỎ",
                Size = new Size(100, 50),
                Location = new Point(350, 400),
            };
            cancelButton.Click += CancelButton_Click;

            finishButton = new Button
            {
                Text = "KẾT THÚC",
                Size = new Size(100, 50),
                Location = new Point(450, 400),
            };
            finishButton.Click += FinishButton_Click;

            Controls.Add(selectButton);
            Controls.Add(cancelButton);
            Controls.Add(finishButton);
        }
    }
}
