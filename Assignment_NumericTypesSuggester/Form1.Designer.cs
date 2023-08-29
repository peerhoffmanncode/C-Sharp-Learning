namespace Assignment_NumericTypesSuggester
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
            MinValueLabel = new Label();
            MaxValueLabel = new Label();
            SuggestedTypeLabel = new Label();
            IntegralOnlyCheckBox = new CheckBox();
            PerciseCheckBox = new CheckBox();
            MinValueTextBox = new TextBox();
            MaxValueTextBox = new TextBox();
            SuspendLayout();
            // 
            // MinValueLabel
            // 
            MinValueLabel.AutoSize = true;
            MinValueLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            MinValueLabel.Location = new Point(96, 51);
            MinValueLabel.Name = "MinValueLabel";
            MinValueLabel.Size = new Size(99, 25);
            MinValueLabel.TabIndex = 0;
            MinValueLabel.Text = "Min value:";
            // 
            // MaxValueLabel
            // 
            MaxValueLabel.AutoSize = true;
            MaxValueLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            MaxValueLabel.Location = new Point(93, 92);
            MaxValueLabel.Name = "MaxValueLabel";
            MaxValueLabel.Size = new Size(102, 25);
            MaxValueLabel.TabIndex = 1;
            MaxValueLabel.Text = "Max value:";
            // 
            // SuggestedTypeLabel
            // 
            SuggestedTypeLabel.AutoSize = true;
            SuggestedTypeLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            SuggestedTypeLabel.Location = new Point(34, 208);
            SuggestedTypeLabel.Name = "SuggestedTypeLabel";
            SuggestedTypeLabel.Size = new Size(310, 30);
            SuggestedTypeLabel.TabIndex = 2;
            SuggestedTypeLabel.Text = "Suggested type: signed Byte";
            SuggestedTypeLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // IntegralOnlyCheckBox
            // 
            IntegralOnlyCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IntegralOnlyCheckBox.AutoSize = true;
            IntegralOnlyCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            IntegralOnlyCheckBox.Checked = true;
            IntegralOnlyCheckBox.CheckState = CheckState.Checked;
            IntegralOnlyCheckBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            IntegralOnlyCheckBox.Location = new Point(67, 129);
            IntegralOnlyCheckBox.Name = "IntegralOnlyCheckBox";
            IntegralOnlyCheckBox.Size = new Size(149, 29);
            IntegralOnlyCheckBox.TabIndex = 3;
            IntegralOnlyCheckBox.Text = "Integral Only?";
            IntegralOnlyCheckBox.TextAlign = ContentAlignment.TopLeft;
            IntegralOnlyCheckBox.UseVisualStyleBackColor = true;
            IntegralOnlyCheckBox.CheckedChanged += IntegralOnlycheckBox_CheckedChanged;
            // 
            // PerciseCheckBox
            // 
            PerciseCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PerciseCheckBox.AutoSize = true;
            PerciseCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            PerciseCheckBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            PerciseCheckBox.Location = new Point(43, 164);
            PerciseCheckBox.Name = "PerciseCheckBox";
            PerciseCheckBox.Size = new Size(173, 29);
            PerciseCheckBox.TabIndex = 4;
            PerciseCheckBox.Text = "Must be percise?";
            PerciseCheckBox.TextAlign = ContentAlignment.TopLeft;
            PerciseCheckBox.UseVisualStyleBackColor = true;
            PerciseCheckBox.Visible = false;
            PerciseCheckBox.CheckedChanged += UpdateSuggestedType;
            // 
            // MinValueTextBox
            // 
            MinValueTextBox.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            MinValueTextBox.Location = new Point(201, 50);
            MinValueTextBox.Name = "MinValueTextBox";
            MinValueTextBox.Size = new Size(587, 31);
            MinValueTextBox.TabIndex = 5;
            MinValueTextBox.TextChanged += TextBox_TextChange;
            MinValueTextBox.KeyPress += TextBox_KeyPress;
            // 
            // MaxValueTextBox
            // 
            MaxValueTextBox.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            MaxValueTextBox.Location = new Point(201, 92);
            MaxValueTextBox.Name = "MaxValueTextBox";
            MaxValueTextBox.Size = new Size(587, 31);
            MaxValueTextBox.TabIndex = 6;
            MaxValueTextBox.TextChanged += TextBox_TextChange;
            MaxValueTextBox.KeyPress += TextBox_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(821, 288);
            Controls.Add(MaxValueTextBox);
            Controls.Add(MinValueTextBox);
            Controls.Add(PerciseCheckBox);
            Controls.Add(IntegralOnlyCheckBox);
            Controls.Add(SuggestedTypeLabel);
            Controls.Add(MaxValueLabel);
            Controls.Add(MinValueLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "C# numeric types suggester";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MinValueLabel;
        private Label MaxValueLabel;
        private Label SuggestedTypeLabel;
        private CheckBox IntegralOnlyCheckBox;
        private CheckBox PerciseCheckBox;
        private TextBox MinValueTextBox;
        private TextBox MaxValueTextBox;
    }
}