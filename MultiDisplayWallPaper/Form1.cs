using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MultiDisplayWallPaper
{
    public partial class Form1 : Form
    {

        Bitmap pictWallPaper;
        //3640*1920
        Bitmap pictLeft;
        //2560*1440
        Bitmap pictRight;
        //1080*1920
        Image image1;
        Image image2;

        string[] wallpaperFullName1;
        string[] wallpaperFullName2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            //開視窗1
            FolderBrowserDialog pathWindow = new FolderBrowserDialog();
            pathWindow.ShowDialog();
            textPath1.Text = pathWindow.SelectedPath;
            //開視窗2
            pathWindow.ShowDialog();
            textPath2.Text = pathWindow.SelectedPath;
            pathWindow.Dispose();


            if (textPath1.Text == "" && textPath2.Text == "")
                return;

            wallpaperFullName1 = null;
            wallpaperFullName2 = null;
            wallpaperFullName1 = Directory.GetFiles(textPath1.Text);
            wallpaperFullName2 = Directory.GetFiles(textPath2.Text);

            if (wallpaperFullName1 == null)
                Console.WriteLine("NULL");
            else
            {
                Console.WriteLine("wallpaperFullName1 : " + wallpaperFullName1);
                Console.WriteLine("wallpaperFullName1'lens : " + wallpaperFullName1.Length);
            }
                

            //檢查
            Console.WriteLine("wallpaperFullName1");
            for (int i = 0; i < wallpaperFullName1.Length; i++)
            {
                Console.WriteLine(wallpaperFullName1[i]);
            }
            Console.WriteLine("wallpaperFullName2");
            for (int i = 0; i < wallpaperFullName2.Length; i++)
            {
                Console.WriteLine(wallpaperFullName2[i]);
            }
            Console.WriteLine("length : " + wallpaperFullName1.Length + " " + wallpaperFullName2.Length);
            

            string fileNameStr;
            string fileName;
            string[] fileNameSplit;

            listBoxDisplay1.Items.Clear();
            for (int i = 0; i < wallpaperFullName1.Length; i++)
            {
                fileNameStr = wallpaperFullName1[i];
                fileNameSplit = fileNameStr.Split('\\');
                fileName = fileNameSplit[fileNameSplit.Length - 1];
                listBoxDisplay1.Items.Add(fileName);
            }
            listBoxDisplay2.Items.Clear();
            for (int i = 0; i < wallpaperFullName2.Length; i++)
            {
                fileNameStr = wallpaperFullName2[i];
                fileNameSplit = fileNameStr.Split('\\');
                fileName = fileNameSplit[fileNameSplit.Length - 1];
                listBoxDisplay2.Items.Add(fileName);
            }

            SetpBar(wallpaperFullName1.Length * wallpaperFullName2.Length);
            /*
            int imageCount = 0;
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;

            for (int i = 0; i < wallpaperFullName1.Length; i++)
            {
                for (int j = 0; j < wallpaperFullName2.Length; j++)
                {
                    
                    pictWallPaper = new Bitmap(3640, 1920);
                    image1 = Image.FromFile(wallpaperFullName1[i]);
                    image2 = Image.FromFile(wallpaperFullName2[j]);
                    pictLeft = new Bitmap(image1, 2560, 1440);
                    pictRight = new Bitmap(image2, 1080, 1920);

                    //pict1
                    for (int h1 = 0; h1 < 1440; h1++)
                    {
                        for (int w1 = 0; w1 < 2560; w1++)
                        {
                            pictWallPaper.SetPixel(w1, 480 + h1, pictLeft.GetPixel(w1, h1));
                        }
                    }

                    //pict2
                    for (int h2 = 0; h2 < 1920; h2++)
                    {
                        for (int w2 = 0; w2 < 1080; w2++)
                        {
                            pictWallPaper.SetPixel(2560 + w2, h2, pictRight.GetPixel(w2, h2));
                        }
                    }

                    pictWallPaper.Save(savePath + "\\" + imageCount + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    pictWallPaper.Save(savePath + "\\" + imageCount + ".jpg", myImageCodecInfo, myEncoderParameters);
                    imageCount++;

                    pictWallPaper.Dispose();
                    image1.Dispose();
                    image2.Dispose();
                    pictLeft.Dispose();
                    pictRight.Dispose();
                }
            }
            */

        }

        private void btnMake_Click(object sender, EventArgs e)
        {
            //開視窗
            FolderBrowserDialog pathWindow = new FolderBrowserDialog();
            pathWindow.ShowDialog();
            string savePath = pathWindow.SelectedPath;
            pathWindow.Dispose();

            //確認路徑不為空
            if (savePath == "")
                return;
            Console.WriteLine(savePath);
            textSavePath.Text = savePath;

            //pBarClear
            pBar.Value = pBar.Minimum;
            //DONE! unvisible
            textDone.Visible = false;

            //檔案序列
            int imageCount = 0;
            //JPG設定
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;

            for (int i = 0; i < wallpaperFullName1.Length; i++)
            {
                for (int j = 0; j < wallpaperFullName2.Length; j++)
                {
                    pBar.PerformStep();
                    pictWallPaper = new Bitmap(3640, 1920);
                    image1 = Image.FromFile(wallpaperFullName1[i]);
                    image2 = Image.FromFile(wallpaperFullName2[j]);
                    pictLeft = new Bitmap(image1, 2560, 1440);
                    pictRight = new Bitmap(image2, 1080, 1920);

                    //pict1
                    for (int h1 = 0; h1 < 1440; h1++)
                    {
                        for (int w1 = 0; w1 < 2560; w1++)
                        {
                            pictWallPaper.SetPixel(w1, 480 + h1, pictLeft.GetPixel(w1, h1));
                        }
                    }

                    //pict2
                    for (int h2 = 0; h2 < 1920; h2++)
                    {
                        for (int w2 = 0; w2 < 1080; w2++)
                        {
                            pictWallPaper.SetPixel(2560 + w2, h2, pictRight.GetPixel(w2, h2));
                        }
                    }

                    //pictWallPaper.Save(savePath + "\\" + imageCount + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    pictWallPaper.Save(savePath + "\\" + imageCount + ".jpg", myImageCodecInfo, myEncoderParameters);
                    imageCount++;

                    //關閉
                    pictWallPaper.Dispose();
                    image1.Dispose();
                    image2.Dispose();
                    pictLeft.Dispose();
                    pictRight.Dispose();
                }
            }
            //show DONE!
            textDone.Visible = true;
        }

        private void listBoxDisplay1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictBoxDisplay1.Load(textPath1.Text + "\\" + listBoxDisplay1.SelectedItem.ToString());
        }

        private void listBoxDisplay2_SelectedIndexChanged(object sender, EventArgs e)
        { 
            pictBoxDisplay2.Load(textPath2.Text + "\\" + listBoxDisplay2.SelectedItem.ToString());
        }

        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        private void SetpBar(int barMax)
        {
            // 設定進度條最小值.
            pBar.Minimum = 0;
            // 設定進度條最大值.
            pBar.Maximum = barMax;
            // 設定進度條初始值
            pBar.Value = 0;
            // 設定每次增加的步長
            pBar.Step = 1;
        }
    }
}
