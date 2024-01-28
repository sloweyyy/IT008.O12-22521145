using System;
using System.Windows.Forms;
using System.Drawing;

namespace Bai04
{
    public partial class Bai04 : Form
    {
        public Bai04()
        {
            InitializeComponent();
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button seatButton = (Button)sender;
            int seatNumber = (int)seatButton.Tag;

            if (seatButton.BackColor == Color.Yellow)
            {
                MessageBox.Show("Vé tại vị trí này đã được bán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!isSeatSelected[seatNumber - 1])
            {
                seatButton.BackColor = Color.Blue;
                isSeatSelected[seatNumber - 1] = true;
            }
            else
            {
                seatButton.BackColor = Color.White;
                isSeatSelected[seatNumber - 1] = false;
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            double seatPriceA = 5000;
            double seatPriceB = 6500;
            double seatPriceC = 8000;
            totalPrice = 0;

            for (int i = 0; i < isSeatSelected.Length; i++)
            {
                if (isSeatSelected[i])
                {
                    int seatNumber = i + 1;
                    double seatPrice = seatNumber <= 5 ? seatPriceA : (seatNumber <= 10 ? seatPriceB : seatPriceC);
                    totalPrice += seatPrice;
                    isSeatSelected[i] = false;
                    ((Button)seatingLayout.Controls[i]).BackColor = Color.Yellow;
                }
            }

            totalPriceLabel.Text = "Tổng tiền: " + totalPrice;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < isSeatSelected.Length; i++)
            {
                if (isSeatSelected[i])
                {
                    isSeatSelected[i] = false;
                    ((Button)seatingLayout.Controls[i]).BackColor = Color.White;
                }
            }

            totalPrice = 0;
            totalPriceLabel.Text = "Tổng tiền: 0";
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
