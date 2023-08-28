namespace FirstWinFormsApp
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            CounterLabel = new Label();
            IncreaseCountButton = new Button();
            imageList1 = new ImageList(components);
            HiddeButtoncheckBox = new CheckBox();
            SuspendLayout();
            // 
            // CounterLabel
            // 
            CounterLabel.AutoSize = true;
            CounterLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            CounterLabel.Location = new Point(130, 85);
            CounterLabel.Name = "CounterLabel";
            CounterLabel.Size = new Size(33, 37);
            CounterLabel.TabIndex = 0;
            CounterLabel.Text = "0";
            // 
            // IncreaseCountButton
            // 
            IncreaseCountButton.Location = new Point(180, 91);
            IncreaseCountButton.Name = "IncreaseCountButton";
            IncreaseCountButton.Size = new Size(172, 38);
            IncreaseCountButton.TabIndex = 1;
            IncreaseCountButton.Text = "Hit me !";
            IncreaseCountButton.UseVisualStyleBackColor = true;
            IncreaseCountButton.Click += IncreaseCountButton_Click;
            IncreaseCountButton.MouseHover += IncreaseCountButton_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // HiddeButtoncheckBox
            // 
            HiddeButtoncheckBox.AutoSize = true;
            HiddeButtoncheckBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            HiddeButtoncheckBox.Location = new Point(140, 152);
            HiddeButtoncheckBox.Name = "HiddeButtoncheckBox";
            HiddeButtoncheckBox.Size = new Size(123, 32);
            HiddeButtoncheckBox.TabIndex = 2;
            HiddeButtoncheckBox.Text = "Hide the button";
            HiddeButtoncheckBox.UseVisualStyleBackColor = true;
            HiddeButtoncheckBox.CheckedChanged += HiddeButtoncheckBox_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 198);
            Controls.Add(HiddeButtoncheckBox);
            Controls.Add(IncreaseCountButton);
            Controls.Add(CounterLabel);
            Name = "Form1";
            Text = "MyFirstApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CounterLabel;
        private Button IncreaseCountButton;
        private ImageList imageList1;
        private CheckBox HiddeButtoncheckBox;
    }
}