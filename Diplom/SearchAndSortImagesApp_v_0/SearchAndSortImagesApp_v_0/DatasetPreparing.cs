using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Azure.CognitiveServices.Search.VisualSearch;
using Microsoft.Azure.CognitiveServices.Search.VisualSearch.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using System.Net;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;
using OpenCvSharp.Util;
using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;

namespace SearchAndSortImagesApp_v_0
{
    public partial class DatasetPreparing : UserControl
    {
        private int image_idx = 0;
        private string[] filesInFolder;
        // Bitmap bmp;

        private string pathToMainFolder = "";
        private string pathToRootFolder = "";
        private string[] pathToRootFolderArray;

        private string pathToOrigImageSet = "";
        private string pathToOrigMetadata = "";
        private string pathToExtImageSet = "";
        private string pathToExtMetadata = "";

        private string imageName = "";

        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public static List<string> metadataList = new List<string>();
        public static List<string> metadataListExt = new List<string>();

        //Преднастройки для AWS S3
        private static string existingBucketName = "searchandsortimages";
        private static Amazon.RegionEndpoint bucketRegion = RegionEndpoint.EUCentral1;
        private static string accesKey = "AKIA5GSCYDIP2HQ7JNGO";
        private static string secretKey = "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";
        IAmazonS3 s3Client = new AmazonS3Client(accesKey, secretKey, bucketRegion);

        //Загрузка папки с картинками

        private void loadImageFolderButton_Click_1(object sender, EventArgs e)
        {
            int checkFormat = 0;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
            

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    pathToMainFolder = fbd.SelectedPath;
                    pathToOrigImageSet = pathToMainFolder;
                    pathToRootFolderArray = pathToMainFolder.Split('\\');
                    pathToRootFolder = string.Join("\\", pathToRootFolderArray.Reverse().Skip(1).Reverse());
                    string pathToLoadFolder = pathToRootFolder + "\\Extended photoset";
                    pathToExtImageSet = pathToLoadFolder;
                    pathToExtMetadata = pathToLoadFolder;

                    filesInFolder = Directory.GetFiles(fbd.SelectedPath);

                    for (int i = 0; i <= filesInFolder.Length - 1; i++)
                    {
                        if (ImageExtensions.Contains(Path.GetExtension(filesInFolder[i]).ToUpperInvariant()))
                        {
                            checkFormat++;
                        }

                    }
                    fbd.Dispose();


                }
            }

            if (checkFormat == filesInFolder.Length)
            {
                imageName = Path.GetFileName(filesInFolder[image_idx]);
                using (Image img = new Bitmap(filesInFolder[image_idx]))
                {
                    Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                    pictureLoadScreen.Image = rescaleImage;
                    img.Dispose();
                }

                string position = (image_idx+1) + "/" + filesInFolder.Length;
                positionLabel.Visible = true;
                positionLabel.Text = position;
                imagesPathTextBox.Text = pathToMainFolder;
            }
            else
            {
                MessageBox.Show("Не все файлы являются изображениями с разрешениями  .JPG, .JPE, .BMP, .GIF, .PNG");
            }

        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        private void nextImageButton_Click_1(object sender, EventArgs e)
        {
            image_idx++;
            if (filesInFolder.Length > 1 && image_idx >= 0 && image_idx < filesInFolder.Length)
            {
                imageName = Path.GetFileName(filesInFolder[image_idx]);
                using (Image img = new Bitmap(filesInFolder[image_idx]))
                {

                    Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                    pictureLoadScreen.Image = rescaleImage;
                    img.Dispose();
                }

                string position = image_idx + "/" + filesInFolder.Length;
                positionLabel.Text = position;

            }
            else
            {
                image_idx = 0;
                imageName = Path.GetFileName(filesInFolder[image_idx]);

                using (Image img = new Bitmap(filesInFolder[image_idx]))
                {
                    Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                    pictureLoadScreen.Image = rescaleImage;
                    img.Dispose();
                }
                string position = image_idx + "/" + filesInFolder.Length;
                positionLabel.Text = position;
            }

        }

        private void prevImageButton_Click(object sender, EventArgs e)
        {
            image_idx--;
            if (filesInFolder.Length > 1 && image_idx >= 0)
            {
                imageName = Path.GetFileName(filesInFolder[image_idx]);

                using (Image img = new Bitmap(filesInFolder[image_idx]))
                {
                    Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                    pictureLoadScreen.Image = rescaleImage;
                    img.Dispose();
                }

                string position = image_idx + "/" + filesInFolder.Length;
                positionLabel.Text = position;

            }
            else
            {
                image_idx = filesInFolder.Length - 1;
                imageName = Path.GetFileName(filesInFolder[image_idx]);

                using (Image img = new Bitmap(filesInFolder[image_idx]))
                {
                    Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                    pictureLoadScreen.Image = rescaleImage;
                    img.Dispose();
                }

                string position = image_idx + "/" + filesInFolder.Length;
                positionLabel.Text = position;

            }



        }
        public DatasetPreparing()
        {

            InitializeComponent();
            positionLabel.Visible = false;
            loadImageProgressBar.Visible = false;

        }

        private void pictureLoadScreen_Click(object sender, EventArgs e)
        {

        }

        private void DatasetPreparing_Load(object sender, EventArgs e)
        {

        }
        private void searchGoogleButton_Click(object sender, EventArgs e)
        {
            string pathToLoadFolder = "";
            string pathToUploadingImage = "";
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            byte[] resp;
            String subscriptionKey = "0019471b03144ab2a2f15194fa1bcb2c";
            var watch = System.Diagnostics.Stopwatch.StartNew();

            queryString["count"] = "150";
            queryString["offset"] = "35";
            queryString["imageType"] = "Photo";
            queryString["modules"] = "SimilarImages";

            //Загружаем папку куда будут сохрняться похожие изображения
            pathToLoadFolder = pathToRootFolder + "\\Extended photoset";
            pathToExtImageSet = pathToLoadFolder;
            pathToExtMetadata = pathToLoadFolder;
            //---------------------------------------------------------

            Directory.CreateDirectory(pathToLoadFolder);
            if (!File.Exists(pathToExtMetadata + "\\" + "ExtendedMetadata.csv"))
            {
                string st = metadataList[0];

                metadataListExt.Add(st);
            }
            else
            {
                metadataListExt = File.ReadAllLines(pathToExtMetadata + "\\" + "ExtendedMetadata.csv").ToList();
            }

            string position = (image_idx+1).ToString() + "/" + metadataList.Skip(1).Count();
            positionLabel.Text = position;

            foreach (string element in metadataList.Skip(1))
            {
                image_idx++;
                
                imageName = Path.GetFileName(pathToMainFolder + "\\" + metadataList[image_idx].Split(';')[0]);
                pathToUploadingImage = pathToOrigImageSet + "\\" + imageName;
                if (!File.Exists(pathToLoadFolder + "\\" + imageName))
                {
                    metadataListExt.Add(imageName + ";" + metadataList[image_idx].Split(';')[1] + ";" + metadataList[image_idx].Split(';')[2] + ";" + metadataList[image_idx].Split(';')[3]);

                    using (WebClient clientApi = new WebClient())
                    {
                        clientApi.Headers["Ocp-Apim-Subscription-Key"] = subscriptionKey;
                        clientApi.Headers["ContentType"] = "multipart/form-data";
                        const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/images/details?";
                        string imageFile = pathToUploadingImage;
                        resp = clientApi.UploadFile(uriBase + queryString, imageFile);
                        clientApi.Dispose();
                    }
                    var json = System.Text.Encoding.Default.GetString(resp);
                    Console.WriteLine(json);

                    RootObject imageParse = JsonConvert.DeserializeObject<RootObject>(json);
                    int amountOfImage = imageParse.visuallySimilarImages.value.Count;

                    loadImageProgressBar.Visible = true;
                    loadImageProgressBar.Minimum = 0;
                    loadImageProgressBar.Maximum = amountOfImage;
                    loadImageProgressBar.Step = 1;

                    for (int i = 0; i < amountOfImage - 1; i++)
                    {

                        string Url = imageParse.visuallySimilarImages.value[i].contentUrl;

                        string[] ImageNameArray = Url.Split('/');
                        string FileName = imageName;
                        int pFrom = 0;
                        int pTo = FileName.LastIndexOf(".");
                        FileName = FileName.Substring(pFrom, pTo) + "_" + (i + 1) + ".jpg";
                        string FilePath = pathToLoadFolder + "\\" + FileName;
                        try
                        {
                            MakeLoadRequest(Url, FilePath);
                            metadataListExt.Add(FileName + ";" + metadataList[image_idx].Split(';')[1] + ";" + metadataList[image_idx].Split(';')[2] + ";" + metadataList[image_idx].Split(';')[3]);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Equals("Базовое соединение закрыто: Не удалось установить доверительные отношения для защищенного канала SSL/TLS."))
                            {
                                continue;
                            }

                        }
                        loadImageProgressBar.PerformStep();
                    }
                    loadImageProgressBar.Value = 0;
                    File.Copy(pathToUploadingImage, pathToLoadFolder + "\\" + Path.GetFileName(pathToUploadingImage));
                    File.WriteAllLines(pathToExtMetadata + "\\" + "ExtendedMetadata.csv", metadataListExt);
                }
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                RefreshPictureBox(image_idx);
            }
            loadImageProgressBar.Visible = false;

        }

        public void MakeLoadRequest(string Url, string FilePath)
        {
            using (WebClient client = new WebClient())
            {

                client.DownloadFile(new Uri(Url), FilePath);
                client.Dispose();
            }
        }


        //JSON Parser
        public class RootObject
        {
            public string _type { get; set; }
            public Instrumentation instrumentation { get; set; }
            public string imageInsightsToken { get; set; }
            public VisuallySimilarImages visuallySimilarImages { get; set; }
        }

        public class Instrumentation
        {
            public string _type { get; set; }
        }
        public class VisuallySimilarImages
        {
            public List<Value> value { get; set; }
            public int currentOffset { get; set; }
            public int nextOffset { get; set; }
            public int totalEstimatedMatches { get; set; }
        }

        public class Value
        {
            public string webSearchUrl { get; set; }
            public string name { get; set; }
            public string thumbnailUrl { get; set; }
            public DateTime datePublished { get; set; }
            public bool isFamilyFriendly { get; set; }
            public string contentUrl { get; set; }
            public string hostPageUrl { get; set; }
            public string contentSize { get; set; }
            public string encodingFormat { get; set; }
            public string hostPageDisplayUrl { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public Thumbnail thumbnails { get; set; }
            public string imageInsightsToken { get; set; }
            public InsightsMetadata insightsMetadatas { get; set; }
            public string imageId { get; set; }
            public string accentColor { get; set; }
        }
        public class Thumbnail
        {
            public int width { get; set; }
            public int height { get; set; }
        }
        public class InsightsMetadata
        {
            public int pagesIncludingCount { get; set; }
            public int availableSizesCount { get; set; }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (origPhotoSetCheckBox.Checked == false && extPhotoSetCheckBox.Checked == false && origMetadataCheckBox.Checked == false && extMetadataCheckBox.Checked == false)
            {
                MessageBox.Show("Не выбран ни один из параметров загружаемых данных");
            }
            else
            {
                //создание папки на удаленном хранилище
                var folderkeyOrigDataSet = "Source dataset" + "/" + "Source photoset" + "/";
                var folderkeyExtDataSet = "Extended dataset" + "/" + "Extended photoset" + "/";
                var folderkeyOrigMetadataSet = "Source dataset" + "/";
                var folderkeyExtMetadataSet = "Extended dataset" + "/";

                uploadDataProgressBar.Visible = true;
                uploadDataProgressBar.Step = 1;
                uploadDataProgressBar.Value = 0;
                if (origPhotoSetCheckBox.Checked == true)
                {
                    CreateFolderRemoteStorage(folderkeyOrigDataSet, existingBucketName);
                    UploadFolderRemoteStorage(pathToOrigImageSet, existingBucketName, folderkeyOrigDataSet);
                }
                if (extPhotoSetCheckBox.Checked == true)
                {
                    CreateFolderRemoteStorage(folderkeyExtDataSet, existingBucketName);
                    UploadFolderRemoteStorage(pathToExtImageSet, existingBucketName, folderkeyExtDataSet);
                }
                if (origMetadataCheckBox.Checked == true)
                {
                    if (File.Exists(pathToOrigMetadata))
                    {
                        string linkURL = "https://searchandsortimages.s3.eu-central-1.amazonaws.com/Source+dataset/Source+photoset/";
                        metadataList = File.ReadAllLines(pathToOrigMetadata).ToList();
                        UploadFileRemoteStorage(folderkeyOrigMetadataSet, existingBucketName, pathToOrigMetadata, metadataList, linkURL);
                    }
                    else
                    {
                        MessageBox.Show("Исходный файл метаданных не найден в текущем контексте");
                    }
                }
                if (extMetadataCheckBox.Checked == true)
                {
                    if (File.Exists(pathToExtMetadata + "\\" + "ExtendedMetadata.csv"))
                    {
                        string linkURL = "https://searchandsortimages.s3.eu-central-1.amazonaws.com/Extended+dataset/Extended+photoset/";
                        metadataListExt = File.ReadAllLines(pathToExtMetadata + "\\" + "ExtendedMetadata.csv").ToList();
                        UploadFileRemoteStorage(folderkeyExtMetadataSet, existingBucketName, pathToExtMetadata + "\\" + "ExtendedMetadata.csv", metadataListExt, linkURL);
                    }
                    else
                    {
                        MessageBox.Show("Расширенный файл метаданных не найден в текущем контексте");
                    }
                }
                uploadDataProgressBar.Value = 0;
            }
            
        }

        public void CreateFolderRemoteStorage(string folderkey, string bucketName)
        {
            uploadDataTextBox.Text = "Создание папки " + folderkey;
            IAmazonS3 s3Client = new AmazonS3Client(accesKey, secretKey, bucketRegion);
            uploadDataProgressBar.Value = 0;
            uploadDataProgressBar.Minimum = 0;
            uploadDataProgressBar.Maximum = 1;
            PutObjectRequest requestCreateFolder = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = folderkey,
                ContentBody = string.Empty
            };
            PutObjectResponse response = s3Client.PutObject(requestCreateFolder);
            uploadDataProgressBar.PerformStep();
            
        }

        public void UploadFolderRemoteStorage(string directoryPath, string bucketName, string folderkey)
        {
            uploadDataTextBox.Text = "Загрузка папки " + directoryPath;
            uploadDataProgressBar.Value = 0;
            uploadDataProgressBar.Minimum = 0;
            uploadDataProgressBar.Maximum = 1;

            var directoryTransferUtility = new TransferUtility(s3Client);
            var requestUploadFolder = new TransferUtilityUploadDirectoryRequest
            {
                BucketName = bucketName,
                Directory = directoryPath,
                KeyPrefix = folderkey
            };

            directoryTransferUtility.UploadDirectory(requestUploadFolder);
            uploadDataProgressBar.PerformStep();
            
        }

        public void UploadFileRemoteStorage(string folderkey, string bucketName, string filePath, List<string> metadatalist, string linkURL)
        {
            
            uploadDataProgressBar.Value = 0;
            uploadDataProgressBar.Minimum = 0;
            uploadDataProgressBar.Maximum = 1;

            uploadDataTextBox.Text = "Обновление метаданных для файла " + filePath;

            List<string> metadataList1 = new List<string>();
            metadataList1.AddRange(metadatalist);
            metadataList1[0] += ";Photo URL";
            int index = 1;
            /*
            string linkURL = "https://searchandsortimages.s3.eu-central-1.amazonaws.com/classificated+extended+photoset/00KQ5GYHN00VLOIPWU82WM14NCWMVP.jpg";
            GetPreSignedUrlRequest urlRequest = new GetPreSignedUrlRequest
            {
                BucketName = existingBucketName,
                Key = folderkey,
                Expires = DateTime.Now.AddMinutes(5)
            };
            linkURL = s3Client.GetPreSignedURL(urlRequest);
            */
            uploadDataProgressBar.Value = 0;
            uploadDataProgressBar.Maximum = metadataList.Count();
            uploadDataProgressBar.PerformStep();
            
            foreach (string element in metadatalist.Skip(1))
            {

                string linkURLtoUpload = linkURL + metadataList1[index].Split(';')[0];
                metadataList1[index] += ";" + linkURLtoUpload;
                index++;
                uploadDataProgressBar.PerformStep();
            }
            metadatalist.Clear();
            metadatalist.AddRange(metadataList1);
            File.WriteAllLines(filePath, metadatalist);
            uploadDataProgressBar.Value = 0;
            uploadDataTextBox.Text = "Загрузка файла " + filePath;
            var fileTransferUtility = new TransferUtility(s3Client);

            var requestUploadFile = new TransferUtilityUploadRequest
            {
                BucketName = bucketName,
                FilePath = filePath,
                CannedACL = S3CannedACL.PublicReadWrite,
                Key = folderkey+ "Source metadata.csv"
            };

            fileTransferUtility.Upload(requestUploadFile);

            uploadDataProgressBar.PerformStep();

        }


        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void loadMetadataFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите файл метаданных";
            ofd.Filter = "CSV|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                metadataPathTextBox.Text = ofd.FileName;
                pathToOrigMetadata = ofd.FileName;
            }
            metadataList = File.ReadAllLines(ofd.FileName).ToList();
            //metadataList = ReadInCSV(ofd.FileName);

            RefreshPictureBox(image_idx);
        }
        //---------------------------------------------
        public static List<string> ReadInCSV(string absolutePath)
        {
            List<string> result = new List<string>();
            string value;
            using ( var fileReader = new StreamReader(absolutePath))
            {
                var csv = new CsvReader(fileReader, System.Globalization.CultureInfo.InvariantCulture);
                csv.Configuration.HasHeaderRecord = true;
                while (csv.Read())
                {
                    for (int i=0;csv.TryGetField<string>(i, out value); i++)
                    {
                        result.Add(value);
                    }
                }
            }
            return result;
        }
        public void RefreshPictureBox(int image_idx)
        {
            imageName = Path.GetFileName(pathToMainFolder + "\\" + metadataList[image_idx + 1].Split(';')[0]);
            using (Image img = new Bitmap(pathToMainFolder + "\\" + metadataList[image_idx + 1].Split(';')[0]))
            {
                Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                pictureLoadScreen.Image = rescaleImage;
                pictureLoadScreen.Refresh();
                img.Dispose();
                string position = (image_idx+1).ToString() + "/" + metadataList.Skip(1).Count();
                positionLabel.Text = position;
                positionLabel.Refresh();
            }
        }

        private void positionLabel_Click(object sender, EventArgs e)
        {

        }

        private void metadataPathTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
