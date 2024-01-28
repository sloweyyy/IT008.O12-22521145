namespace Bai03
{
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            float number1 = 0;
            float.TryParse(this.number1.Text, out number1);
            float number2 = 0;
            float.TryParse(this.number2.Text, out number2);
            var operator1 = this.operatorList.Text;
            float result = 0;
            switch (operator1)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    if (number2 == 0)
                    {
                        MessageBox.Show("Cannot divide by zero");
                        return;
                    }
                    result = (float)number1 / number2;
                    break;
            }
            this.result.Text = result.ToString();
        }


    }
}