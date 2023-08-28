namespace FirstWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int _count = 0;

        private void IncreaseCountButton_Click(object sender, EventArgs e)
        {
            _count++;
            CounterLabel.Text = _count.ToString();
        }

        private void HiddeButtoncheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}