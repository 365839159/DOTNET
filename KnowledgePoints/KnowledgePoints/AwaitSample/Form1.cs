namespace AwaitSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            MessageBox.Show("sleep");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            MessageBox.Show("delay");
        }
    }
}