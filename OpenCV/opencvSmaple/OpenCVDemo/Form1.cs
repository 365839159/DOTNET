using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCVDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //����ͼƬ
            Mat mat = new Mat(@"F:\Learm\Note\Lear\image\image-20210829211727769.png", ImreadModes.Unchanged);
            //��ʾ
            //Cv2.ImShow("png", mat);
            //������� 
            //Cv2.WaitKey(0);
           
            Bitmap bitmap = BitmapConverter.ToBitmap(mat);
            pictureBox1.Image= bitmap;
        }
    }
}