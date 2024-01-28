namespace Bai03
{
    partial class Bai03
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
        private TextBox number1;
        private TextBox number2;
        private ComboBox operatorList;
        private Button executeButton;
        private TextBox result;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Bai03
            // 
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 350);
            Name = "Bai03";
            Text = "Bai03";
            ResumeLayout(false);
            PerformLayout();

            number1 = new TextBox();
            number1.Location = new Point(100, 50);
            number1.Name = "number1";
            number1.Size = new Size(100, 20);
            number1.TabIndex = 0;
            number1.Text = "0";
            Controls.Add(number1);

            number2 = new TextBox();
            number2.Location = new Point(100, 100);
            number2.Name = "number2";
            number2.Size = new Size(100, 20);
            number2.TabIndex = 1;
            number2.Text = "0";
            Controls.Add(number2);

            operatorList = new ComboBox();
            operatorList.FormattingEnabled = true;
            operatorList.Items.AddRange(new object[] { "+", "-", "*", "/" });
            operatorList.Location = new Point(100, 150);
            operatorList.Name = "operatorList";
            operatorList.Size = new Size(100, 28);
            operatorList.TabIndex = 2;
            operatorList.Text = "+";
            operatorList.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(operatorList);

            executeButton = new Button();
            executeButton.Location = new Point(100, 200);
            executeButton.Name = "executeButton";
            executeButton.Size = new Size(100, 30);
            executeButton.TabIndex = 3;
            executeButton.Text = "Calculate";
            executeButton.UseVisualStyleBackColor = true;
            executeButton.Click += executeButton_Click;
            Controls.Add(executeButton);

            result = new TextBox();
            result.Location = new Point(100, 250);
            result.Name = "result";
            result.Size = new Size(100, 20);
            result.TabIndex = 4;
            result.Text = "0";
            result.ReadOnly = true;
            Controls.Add(result);

            label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new Point(20, 53);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 5;
            label1.Text = "Number 1";
            Controls.Add(label1);

            label2 = new Label();
            label2.AutoSize = true;
            label2.Location = new Point(20, 103);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 6;
            label2.Text = "Number 2";
            Controls.Add(label2);

            label3 = new Label();
            label3.AutoSize = true;
            label3.Location = new Point(20, 153);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 7;
            label3.Text = "Operator";
            Controls.Add(label3);

            label4 = new Label();
            label4.AutoSize = true;
            label4.Location = new Point(20, 253);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 8;
            label4.Text = "Result";
            Controls.Add(label4);
        }

        #endregion
    }
}