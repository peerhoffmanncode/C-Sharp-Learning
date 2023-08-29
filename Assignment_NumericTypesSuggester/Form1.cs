using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace Assignment_NumericTypesSuggester
{
    public partial class Form1 : Form
    {
        const string SuggestedTypeLabelDefault = "Suggested type: ";

        public Form1()
        {
            InitializeComponent();
        }

        private void IntegralOnlycheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PerciseCheckBox.Visible = !PerciseCheckBox.Visible;
            UpdateSuggestedTypeLable();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBoxInstance = (TextBox)sender;
            if (!IsValidKey(e.KeyChar, textBoxInstance))
            {
                e.Handled = true;
            }
        }

        private void TextBox_TextChange(object sender, EventArgs e)
        {
            UpdateSuggestedTypeLable();
        }

        private bool ValidateMaxValueTextBox()
        {
            BigInteger.TryParse(MinValueTextBox.Text, out BigInteger MinValueTextBoxAsBigInt);
            BigInteger.TryParse(MaxValueTextBox.Text, out BigInteger MaxValueTextBoxAsBigInt);

            if (MaxValueTextBoxAsBigInt < MinValueTextBoxAsBigInt)
            {
                MaxValueTextBox.BackColor = Color.Red;
                return false;
            }
            MaxValueTextBox.BackColor = Color.White;
            return true;
        }

        private void UpdateSuggestedType(object sender, EventArgs e)
        {
            UpdateSuggestedTypeLable();
        }

        private void UpdateSuggestedTypeLable()
        {
            BigInteger.TryParse(MinValueTextBox.Text, out BigInteger MinValueTextBoxAsBigInt);
            BigInteger.TryParse(MaxValueTextBox.Text, out BigInteger MaxValueTextBoxAsBigInt);
            string RangeAsString = (MaxValueTextBoxAsBigInt - MinValueTextBoxAsBigInt).ToString();


            if (ValidateMaxValueTextBox())
            {
                SuggestedTypeLabel.Text = SuggestedTypeLabelDefault + TypeSuggester.FindFittingType(MinValueTextBoxAsBigInt, MaxValueTextBoxAsBigInt, IntegralOnlyCheckBox.Checked, PerciseCheckBox.Checked);
                return;
            }
            SuggestedTypeLabel.Text = SuggestedTypeLabelDefault + "not enough data";
        }

        private static bool IsValidKey(char keyChar, TextBox instance)
        {
            return char.IsDigit(keyChar) || char.IsControl(keyChar) || (keyChar == '-' && instance.SelectionStart == 0);
        }
    }
}
