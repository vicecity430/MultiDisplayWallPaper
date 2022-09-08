using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MultiDisplayWallPaper
{
    public partial class Form1 : Form
    {
        //4000*2560
        Bitmap bitWallPaper;
        //2560*1440
        Bitmap bitMonitor1;
        //1440*2560
        Bitmap bitMonitor2;

        Image image1;
        Image image2;

        //string[] arrFilesMonitor1;
        string[] arrFilesMonitor1;
        //string[] arrFilesMonitor2;
        string[] arrFilesMonitor2;

        private BackgroundWorker backgroundGenerate;

        private System.Windows.Forms.ProgressBar ProgBar;

        public Form1()
        {
            InitializeComponent();
            //BackgroundWorker backgroundGenerate;
            backgroundGenerate = new BackgroundWorker();
            backgroundGenerate.WorkerReportsProgress = true;
            backgroundGenerate.WorkerSupportsCancellation = true;
            backgroundGenerate.DoWork += new DoWorkEventHandler(BackgroundGenerate_DoWork);
            backgroundGenerate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundGenerate_RunWorkerCompleted);
            backgroundGenerate.ProgressChanged += new ProgressChangedEventHandler(BackgroundGenerate_ProgressChanged);
            InitProgBar(100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPath1_Click(object sender, EventArgs e)
        {
            //開視窗1
            FolderBrowserDialog pathWindow = new FolderBrowserDialog();
            pathWindow.ShowDialog();
            string m_strIndex1 = pathWindow.SelectedPath;
            pathWindow.Dispose();

            //更新目錄TextBlock, 路徑為空則退出
            if (m_strIndex1 != "")
            {
                RefreshText(m_strIndex1, textPath1);
            }
            else
            {
                return;
            }

            arrFilesMonitor1 = null;
            arrFilesMonitor1 = Directory.GetFiles(m_strIndex1);

            if (arrFilesMonitor1 == null)
                Console.WriteLine("NULL");
            else
            {
                Console.WriteLine("FilesMonitor1 count : " + arrFilesMonitor1.Length);
            }

            //檢查
            Console.WriteLine("arrFilesMonitor1");
            for (int i = 0; i < arrFilesMonitor1.Length; i++)
            {
                Console.WriteLine(arrFilesMonitor1[i]);
            }

            string fileNameStr;
            string fileName;
            string[] fileNameSplit;

            listBoxDisplay1.Items.Clear();
            for (int i = 0; i < arrFilesMonitor1.Length; i++)
            {
                fileNameStr = arrFilesMonitor1[i];
                fileNameSplit = fileNameStr.Split('\\');
                fileName = fileNameSplit[fileNameSplit.Length - 1];
                listBoxDisplay1.Items.Add(fileName);
            }
        }
        private void btnPath2_Click(object sender, EventArgs e)
        {
            //開視窗2
            FolderBrowserDialog pathWindow = new FolderBrowserDialog();
            pathWindow.ShowDialog();
            string m_strIndex2 = pathWindow.SelectedPath;
            pathWindow.Dispose();

            //更新目錄TextBlock, 路徑為空則退出
            if (m_strIndex2 != "")
            {
                RefreshText(m_strIndex2, textPath2);
            }
            else
            {
                return;
            }

            arrFilesMonitor2 = null;
            arrFilesMonitor2 = Directory.GetFiles(m_strIndex2);

            if (arrFilesMonitor2 == null)
                Console.WriteLine("NULL");
            else
            {
                Console.WriteLine("FilesMonitor2 count : " + arrFilesMonitor2.Length);
            }

            Console.WriteLine("arrFilesMonitor2");
            for (int i = 0; i < arrFilesMonitor2.Length; i++)
            {
                Console.WriteLine(arrFilesMonitor2[i]);
            }

            string fileNameStr;
            string fileName;
            string[] fileNameSplit;

            listBoxDisplay2.Items.Clear();
            for (int i = 0; i < arrFilesMonitor2.Length; i++)
            {
                fileNameStr = arrFilesMonitor2[i];
                fileNameSplit = fileNameStr.Split('\\');
                fileName = fileNameSplit[fileNameSplit.Length - 1];
                listBoxDisplay2.Items.Add(fileName);
            }
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            //開視窗
            FolderBrowserDialog pathWindow = new FolderBrowserDialog();
            pathWindow.ShowDialog();
            string savePath = pathWindow.SelectedPath;
            pathWindow.Dispose();

            //確認路徑不為空
            if (savePath == "")
                return;
            Console.WriteLine("savePath : " + savePath);
            textSavePath.Text = savePath;
        }
        private void BackgroundGenerate_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            GenerateWallPaper(worker, e);
        }
        private void BackgroundGenerate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }

            btnStart.Enabled = true;
            btnCancel.Enabled = false;
            //show DONE!
            textDone.Visible = true;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            textDone.Visible = false;
            InitProgBar(arrFilesMonitor1.Length * arrFilesMonitor2.Length);
            btnStart.Enabled = false;
            btnCancel.Enabled = true;

            backgroundGenerate.RunWorkerAsync();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundGenerate.CancelAsync();
            btnStart.Enabled = true;
            btnCancel.Enabled = false;
        }
        private void GenerateWallPaper(BackgroundWorker worker, DoWorkEventArgs e)
        {
            //InitProgBar(arrFilesMonitor1.Length * arrFilesMonitor2.Length);
            //textDone.Visible = false;

            //檔案序列
            int imageCount = 0;
            //JPG設定
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;

            for (int i = 0; i < arrFilesMonitor1.Length; i++)
            {
                for (int j = 0; j < arrFilesMonitor2.Length; j++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        bitWallPaper = new Bitmap(4000, 2560); //4000 * 2560
                        image1 = Image.FromFile(arrFilesMonitor1[i]);
                        image2 = Image.FromFile(arrFilesMonitor2[j]);
                        bitMonitor1 = new Bitmap(image1, 2560, 1440);
                        bitMonitor2 = new Bitmap(image2, 1440, 2560);

                        //pict1
                        for (int h1 = 0; h1 < 1440; h1++)
                        {
                            for (int w1 = 0; w1 < 2560; w1++)
                            {
                                bitWallPaper.SetPixel(w1, 1120 + h1, bitMonitor1.GetPixel(w1, h1));
                            }
                        }

                        //pict2
                        for (int h2 = 0; h2 < 2560; h2++)
                        {
                            for (int w2 = 0; w2 < 1440; w2++)
                            {
                                bitWallPaper.SetPixel(2560 + w2, h2, bitMonitor2.GetPixel(w2, h2));
                            }
                        }

                        string savePath = textSavePath.Text;

                        //bitWallPaper.Save(savePath + "\\" + imageCount + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        bitWallPaper.Save(savePath + "\\" + imageCount + ".jpg", myImageCodecInfo, myEncoderParameters);
                        imageCount++;
                        //PorgBar.PerformStep();

                        // Report progress as a percentage of the total task.
                        int percentComplete = (int)((float)imageCount / (float)(arrFilesMonitor1.Length * arrFilesMonitor2.Length));
                        worker.ReportProgress(imageCount);

                        //關閉
                        bitWallPaper.Dispose();
                        image1.Dispose();
                        image2.Dispose();
                        bitMonitor1.Dispose();
                        bitMonitor2.Dispose();
                    }
                }
            }
            myEncoderParameter.Dispose();
            myEncoderParameters.Dispose();
        }

        private void BackgroundGenerate_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            ProgBar.PerformStep();
            //ProgBar.Value = e.ProgressPercentage;
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
        private void InitProgBar(int barMax)
        {
            // 設定進度條最小值.
            PorgBar.Minimum = 0;
            // 設定進度條最大值.
            PorgBar.Maximum = barMax;
            // 設定進度條初始值
            PorgBar.Value = 0;
            // 設定每次增加的步長
            PorgBar.Step = 1;
        }

        private void RefreshText(string index, Label label)
        {
            label.Text = index;
        }

        
    }
}
