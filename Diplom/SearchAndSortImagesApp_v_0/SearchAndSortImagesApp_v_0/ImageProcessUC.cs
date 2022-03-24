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

namespace SearchAndSortImagesApp_v_0
{
    public partial class ImageProcessUC: UserControl
    {
        private int image_idx = 0;
        private string[] filesInFolder;
        // Bitmap bmp;

        private string pathToMainFolder = "";

        private string pathToTextFolder = "";
        private string pathToBuildingsFolder = "";
        private string pathToMonumentsFolder = "";
        private string pathToUnknownFolder = "";
        private string pathToFlagsFolder = "";
        private string pathToPeopleFolder = "";
        private string pathToLongDistanceFolder = "";
        private string pathToUknownTextFolder = "";
        private string pathToUnknownArchitectureFolder = "";

        private string imageName = "";

        //Dlya modulya raspredeleniya po papkam
        private List<string> Contry = new List<string>();
        private List<string> State = new List<string>();
        private List<string> Subrb = new List<string>();
        private List<string> Road = new List<string>();
        private List<string> ImageName = new List<string>();
        private List<string> Neighbourhood = new List<string>();

        //Dlya modulya poiska coordinate
        private List<string> latitudeList = new List<string>();
        private List<string> longitudeList = new List<string>();
        private List<string> imageNames = new List<string>();

        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public ImageProcessUC()
        {
            InitializeComponent();
            positionLabel.Visible = false;
            //loadImageProgressBar.Visible = false;
            createDirectoryProgressBar.Visible = false;
        }

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
                    filesInFolder = Directory.GetFiles(fbd.SelectedPath);


                    for (int i = 0; i <= filesInFolder.Length - 1; i++)
                    {
                        if (ImageExtensions.Contains(Path.GetExtension(filesInFolder[i]).ToUpperInvariant()))
                        {
                            checkFormat++;
                        }

                    }



                }
                fbd.Dispose();
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




                string position = image_idx + "/" + filesInFolder.Length;
                positionLabel.Visible = true;
                positionLabel.Text = position;
            }
            else
            {
                MessageBox.Show("Не все файлы являются изображениями с разрешениями  .JPG, .JPE, .BMP, .GIF, .PNG");
            }
            if (!pathToMainFolder.Equals(""))
            {
                CheckIfAlreadyDone(pathToMainFolder);
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

        private void nextImageButton_Click(object sender, EventArgs e)
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

                // if (File.Exists(pathToTextFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Text"))
                {
                    textFolderCheckBox.Checked = true;
                }
                else
                {
                    textFolderCheckBox.Checked = false;
                }
                //if (File.Exists(pathToBuildingsFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Buildings"))
                {
                    buildingsFolderCheckBox.Checked = true;
                }
                else
                {
                    buildingsFolderCheckBox.Checked = false;
                }
                //if (File.Exists(pathToMonumentsFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Monuments"))
                {
                    monumentsFolderCheckBox.Checked = true;
                }
                else
                {
                    monumentsFolderCheckBox.Checked = false;
                }
                // if (File.Exists(pathToUnknownFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Unknown"))
                {
                    unknownFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("Flags"))
                {
                    flagsFolderCheckBox.Checked = true;
                }
                else
                {
                    flagsFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("People"))
                {
                    peopleFolderCheckBox.Checked = true;
                }
                else
                {
                    peopleFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("LongDistance"))
                {
                    longDistanceFolderCheckBox.Checked = true;
                }
                else
                {
                    longDistanceFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("UnknownText"))
                {
                    unknownTextFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownTextFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("UnknownArchitecture"))
                {
                    unknownArchitectureFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownArchitectureFolderCheckBox.Checked = false;
                }
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

                // if (File.Exists(pathToTextFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Text"))
                {
                    textFolderCheckBox.Checked = true;
                }
                else
                {
                    textFolderCheckBox.Checked = false;
                }
                //if (File.Exists(pathToBuildingsFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Buildings"))
                {
                    buildingsFolderCheckBox.Checked = true;
                }
                else
                {
                    buildingsFolderCheckBox.Checked = false;
                }
                //if (File.Exists(pathToMonumentsFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Monuments"))
                {
                    monumentsFolderCheckBox.Checked = true;
                }
                else
                {
                    monumentsFolderCheckBox.Checked = false;
                }
                // if (File.Exists(pathToUnknownFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Unknown"))
                {
                    unknownFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("Flags"))
                {
                    flagsFolderCheckBox.Checked = true;
                }
                else
                {
                    flagsFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("People"))
                {
                    peopleFolderCheckBox.Checked = true;
                }
                else
                {
                    peopleFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("LongDistance"))
                {
                    longDistanceFolderCheckBox.Checked = true;
                }
                else
                {
                    longDistanceFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("UnknownText"))
                {
                    unknownTextFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownTextFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("UnknownArchitecture"))
                {
                    unknownArchitectureFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownArchitectureFolderCheckBox.Checked = false;
                }

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

                // if (File.Exists(pathToTextFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Text"))
                {
                    textFolderCheckBox.Checked = true;
                }
                else
                {
                    textFolderCheckBox.Checked = false;
                }
                //if (File.Exists(pathToBuildingsFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Buildings"))
                {
                    buildingsFolderCheckBox.Checked = true;
                }
                else
                {
                    buildingsFolderCheckBox.Checked = false;
                }
                //if (File.Exists(pathToMonumentsFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Monuments"))
                {
                    monumentsFolderCheckBox.Checked = true;
                }
                else
                {
                    monumentsFolderCheckBox.Checked = false;
                }
                // if (File.Exists(pathToUnknownFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Unknown"))
                {
                    unknownFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("Flags"))
                {
                    flagsFolderCheckBox.Checked = true;
                }
                else
                {
                    flagsFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("People"))
                {
                    peopleFolderCheckBox.Checked = true;
                }
                else
                {
                    peopleFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("LongDistance"))
                {
                    longDistanceFolderCheckBox.Checked = true;
                }
                else
                {
                    longDistanceFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("UnknownText"))
                {
                    unknownTextFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownTextFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("UnknownArchitecture"))
                {
                    unknownArchitectureFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownArchitectureFolderCheckBox.Checked = false;
                }
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

                // if (File.Exists(pathToTextFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Text"))
                {
                    textFolderCheckBox.Checked = true;
                }
                else
                {
                    textFolderCheckBox.Checked = false;
                }
                //if (File.Exists(pathToBuildingsFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Buildings"))
                {
                    buildingsFolderCheckBox.Checked = true;
                }
                else
                {
                    buildingsFolderCheckBox.Checked = false;
                }
                //if (File.Exists(pathToMonumentsFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Monuments"))
                {
                    monumentsFolderCheckBox.Checked = true;
                }
                else
                {
                    monumentsFolderCheckBox.Checked = false;
                }
                // if (File.Exists(pathToUnknownFolder + Path.GetFileName(filesInFolder[image_idx])))
                if (CheckIfAlreadyDone(imageName).Equals("Unknown"))
                {
                    unknownFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("Flags"))
                {
                    flagsFolderCheckBox.Checked = true;
                }
                else
                {
                    flagsFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("People"))
                {
                    peopleFolderCheckBox.Checked = true;
                }
                else
                {
                    peopleFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("LongDistance"))
                {
                    longDistanceFolderCheckBox.Checked = true;
                }
                else
                {
                    longDistanceFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("UnknownText"))
                {
                    unknownTextFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownTextFolderCheckBox.Checked = false;
                }

                if (CheckIfAlreadyDone(imageName).Equals("UnknownArchitecture"))
                {
                    unknownArchitectureFolderCheckBox.Checked = true;
                }
                else
                {
                    unknownArchitectureFolderCheckBox.Checked = false;
                }

            }



        }


        private void saveImageToFolderButton_Click_1(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(filesInFolder[image_idx]);

            if (textFolderCheckBox.Checked)
            {
                if (!Directory.Exists(pathToTextFolder))
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            pathToTextFolder = fbd.SelectedPath + "\\";
                            try
                            {
                                File.Copy(filesInFolder[image_idx], pathToTextFolder + fileName);
                                WriteToLog(pathToMainFolder, "Text");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(filesInFolder[image_idx], pathToTextFolder + fileName);
                        WriteToLog(pathToMainFolder, "Text");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            if (buildingsFolderCheckBox.Checked)
            {
                if (!Directory.Exists(pathToBuildingsFolder))
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            pathToBuildingsFolder = fbd.SelectedPath + "\\";
                            try
                            {
                                File.Copy(filesInFolder[image_idx], pathToBuildingsFolder + fileName);
                                WriteToLog(pathToMainFolder, "Buildings");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(filesInFolder[image_idx], pathToBuildingsFolder + fileName);
                        WriteToLog(pathToMainFolder, "Buildings");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            if (monumentsFolderCheckBox.Checked)
            {
                if (!Directory.Exists(pathToMonumentsFolder))
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            pathToMonumentsFolder = fbd.SelectedPath + "\\";
                            try
                            {
                                File.Copy(filesInFolder[image_idx], pathToMonumentsFolder + fileName);
                                WriteToLog(pathToMainFolder, "Monuments");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(filesInFolder[image_idx], pathToMonumentsFolder + fileName);
                        WriteToLog(pathToMainFolder, "Monuments");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (unknownFolderCheckBox.Checked)
            {
                if (!Directory.Exists(pathToUnknownFolder))
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            pathToUnknownFolder = fbd.SelectedPath + "\\";
                            try
                            {
                                File.Copy(filesInFolder[image_idx], pathToUnknownFolder + fileName);
                                WriteToLog(pathToMainFolder, "Unknown");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(filesInFolder[image_idx], pathToUnknownFolder + fileName);
                        WriteToLog(pathToMainFolder, "Unknown");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (flagsFolderCheckBox.Checked)
            {
                if (!Directory.Exists(pathToFlagsFolder))
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            pathToFlagsFolder = fbd.SelectedPath + "\\";
                            try
                            {
                                File.Copy(filesInFolder[image_idx], pathToFlagsFolder + fileName);
                                WriteToLog(pathToMainFolder, "Flags");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(filesInFolder[image_idx], pathToFlagsFolder + fileName);
                        WriteToLog(pathToMainFolder, "Flags");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (peopleFolderCheckBox.Checked)
            {
                if (!Directory.Exists(pathToPeopleFolder))
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            pathToPeopleFolder = fbd.SelectedPath + "\\";
                            try
                            {
                                File.Copy(filesInFolder[image_idx], pathToPeopleFolder + fileName);
                                WriteToLog(pathToMainFolder, "People");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(filesInFolder[image_idx], pathToPeopleFolder + fileName);
                        WriteToLog(pathToMainFolder, "People");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (longDistanceFolderCheckBox.Checked)
            {
                if (!Directory.Exists(pathToLongDistanceFolder))
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            pathToLongDistanceFolder = fbd.SelectedPath + "\\";
                            try
                            {
                                File.Copy(filesInFolder[image_idx], pathToLongDistanceFolder + fileName);
                                WriteToLog(pathToMainFolder, "LongDistance");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(filesInFolder[image_idx], pathToLongDistanceFolder + fileName);
                        WriteToLog(pathToMainFolder, "LongDistance");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (unknownTextFolderCheckBox.Checked)
            {
                if (!Directory.Exists(pathToUknownTextFolder))
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            pathToUknownTextFolder = fbd.SelectedPath + "\\";
                            try
                            {
                                File.Copy(filesInFolder[image_idx], pathToUknownTextFolder + fileName);
                                WriteToLog(pathToMainFolder, "UnknownText");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(filesInFolder[image_idx], pathToUknownTextFolder + fileName);
                        WriteToLog(pathToMainFolder, "UnknownText");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (unknownArchitectureFolderCheckBox.Checked)
            {
                if (!Directory.Exists(pathToUnknownArchitectureFolder))
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            pathToUnknownArchitectureFolder = fbd.SelectedPath + "\\";
                            try
                            {
                                File.Copy(filesInFolder[image_idx], pathToUnknownArchitectureFolder + fileName);
                                WriteToLog(pathToMainFolder, "UnknownArchitecture");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(filesInFolder[image_idx], pathToUnknownArchitectureFolder + fileName);
                        WriteToLog(pathToMainFolder, "UnknownArchitecture");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public void WriteToLog(string pathToMainFolder, string category)
        {
            string fileName = Path.GetDirectoryName(pathToMainFolder) + "\\AlreadyDone.txt";
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(fileName))
            {
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    if (textFolderCheckBox.Checked)
                    {
                        sw.WriteLine("Category:" + category + " ImageName:" + imageName);
                    }
                    if (buildingsFolderCheckBox.Checked)
                    {
                        sw.WriteLine("Category:" + category + " ImageName:" + imageName);
                    }
                    if (monumentsFolderCheckBox.Checked)
                    {
                        sw.WriteLine("Category:" + category + " ImageName:" + imageName);
                    }
                    if (unknownFolderCheckBox.Checked)
                    {
                        sw.WriteLine("Category:" + category + " ImageName:" + imageName);
                    }
                    if (flagsFolderCheckBox.Checked)
                    {
                        sw.WriteLine("Category:" + category + " ImageName:" + imageName);
                    }
                    if (peopleFolderCheckBox.Checked)
                    {
                        sw.WriteLine("Category:" + category + " ImageName:" + imageName);
                    }
                    if (longDistanceFolderCheckBox.Checked)
                    {
                        sw.WriteLine("Category:" + category + " ImageName:" + imageName);
                    }
                    if (unknownTextFolderCheckBox.Checked)
                    {
                        sw.WriteLine("Category:" + category + " ImageName:" + imageName);
                    }
                    if (unknownArchitectureFolderCheckBox.Checked)
                    {
                        sw.WriteLine("Category:" + category + " ImageName:" + imageName);
                    }
                }
            }
        }

        public string CheckIfAlreadyDone(string imageName)
        {
            string category = "";

            string fileName = Path.GetDirectoryName(pathToMainFolder) + "\\AlreadyDone.txt";
            // Check if file already exists. If yes, delete it.     
            if (!File.Exists(fileName))
            {
                // Create a new file     
                File.Create(fileName).Dispose();

            }
            else
            {

                // string[] lines = System.IO.File.ReadAllLines(fileName);
                List<string> lines = new List<string>();
                if (File.Exists(fileName))
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        while (sr.Peek() >= 0)
                        {
                            lines.Add(sr.ReadLine());
                        }

                        sr.Dispose();

                    }
                }

                if (lines.Count > 0)
                {
                    for (int i = 0; i < lines.Count; i++)
                    {
                        if (lines[i].Equals("Category:Text ImageName:" + imageName))
                        {
                            category = "Text";
                        }
                        if (lines[i].Equals("Category:Buildings ImageName:" + imageName))
                        {
                            category = "Buildings";
                        }
                        if (lines[i].Equals("Category:Monuments ImageName:" + imageName))
                        {
                            category = "Monuments";
                        }
                        if (lines[i].Equals("Category:Unknown ImageName:" + imageName))
                        {
                            category = "Unknown";
                        }
                        if (lines[i].Equals("Category:Flags ImageName:" + imageName))
                        {
                            category = "Flags";
                        }
                        if (lines[i].Equals("Category:People ImageName:" + imageName))
                        {
                            category = "People";
                        }
                        if (lines[i].Equals("Category:LongDistance ImageName:" + imageName))
                        {
                            category = "LongDistance";
                        }
                        if (lines[i].Equals("Category:UnknownText ImageName:" + imageName))
                        {
                            category = "UnknownText";
                        }
                        if (lines[i].Equals("Category:UnknownArchitecture ImageName:" + imageName))
                        {
                            category = "UnknownArchitecture";
                        }

                    }
                }

            }
            return category;

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
        //---------------------------------------------

        private void preparationImageButton_Click_1(object sender, EventArgs e)
        {
            if (!changeColorBalanceCheckBox.Checked && !changeContrastAndBrightnessCheckBox.Checked && !denoiseImageCheckBox.Checked)
            {
                const string caption = "Ошибка";
                MessageBox.Show("Не был выбран ни один тип коррекции", caption, MessageBoxButtons.OK);
            }
            //Изменение баланса цвета
            else if (changeColorBalanceCheckBox.Checked && !denoiseImageCheckBox.Checked && !changeContrastAndBrightnessCheckBox.Checked)
            {
                if (!pathToMainFolder.Equals("") && !imageName.Equals(""))
                {
                    var message = "Заменить изображение после коррекции цвета?";
                    var caption = "Заменить изображение";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        Bitmap cloneImage = null;
                        using (Bitmap newPreparateImage = ColorBalance(pathToMainFolder + "\\" + imageName))
                        {
                            cloneImage = new Bitmap(newPreparateImage);
                        }

                        using (cloneImage)
                        {

                            System.IO.File.Delete(pathToMainFolder + "\\" + imageName);

                            cloneImage.Save(pathToMainFolder + "\\" + imageName, ImageFormat.Jpeg);

                            using (Image img = new Bitmap(pathToMainFolder + "\\" + imageName))
                            {
                                Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                                pictureLoadScreen.Image = rescaleImage;
                                img.Dispose();
                            }

                            // cloneImage.Dispose();

                        }

                        changeColorBalanceCheckBox.Checked = false;
                    }
                }
                else
                {
                    var message = "Не выбрано изображение. Выберите изображение";
                    var caption = "Ошибка";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    changeColorBalanceCheckBox.Checked = false;

                }


            }
            //Изменения контраста и яркости
            else if (!changeColorBalanceCheckBox.Checked && !denoiseImageCheckBox.Checked && changeContrastAndBrightnessCheckBox.Checked)
            {
                if (!pathToMainFolder.Equals("") && !imageName.Equals(""))
                {


                    var message = "Заменить изображение после коррекции яроксти и контраста?";
                    var caption = "Заменить изображение";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        Bitmap clone = null;
                        Bitmap cloneImage = null;
                        using (Bitmap bitmap = new Bitmap(pathToMainFolder + "\\" + imageName))
                        {

                            using (clone = new Bitmap(AutoBrightnessAndContrast(bitmap)))

                            {
                                cloneImage = new Bitmap(clone);
                            }

                        }
                        using (cloneImage)
                        {
                            System.IO.File.Delete(pathToMainFolder + "\\" + imageName);

                            cloneImage.Save(pathToMainFolder + "\\" + imageName, ImageFormat.Jpeg);

                            using (Image img = new Bitmap(pathToMainFolder + "\\" + imageName))
                            {
                                Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                                pictureLoadScreen.Image = rescaleImage;
                                img.Dispose();
                            }

                            //pictureLoadScreen.Image = cloneImage;

                            //cloneImage.Dispose();
                        }

                        changeContrastAndBrightnessCheckBox.Checked = false;

                    }
                }
                else
                {
                    var message = "Не выбрано изображение. Выберите изображение";
                    var caption = "Ошибка";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    changeContrastAndBrightnessCheckBox.Checked = false;
                }

            }
            //Для удаления шума
            else if (!changeColorBalanceCheckBox.Checked && denoiseImageCheckBox.Checked && !changeContrastAndBrightnessCheckBox.Checked)
            {
                if (!pathToMainFolder.Equals("") && !imageName.Equals(""))
                {
                    var message = "Заменить изображение после удаления шума?";
                    var caption = "Заменить изображение";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);


                    if (result == DialogResult.OK)
                    {
                        Bitmap clone = null;
                        Bitmap cloneImage = null;
                        using (Bitmap bitmap = new Bitmap(pathToMainFolder + "\\" + imageName))
                        {

                            using (clone = new Bitmap(denoiserImage(bitmap)))

                            {
                                cloneImage = new Bitmap(clone);
                            }

                        }
                        using (cloneImage)
                        {
                            System.IO.File.Delete(pathToMainFolder + "\\" + imageName);

                            cloneImage.Save(pathToMainFolder + "\\" + imageName, ImageFormat.Jpeg);

                            using (Image img = new Bitmap(pathToMainFolder + "\\" + imageName))
                            {
                                Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                                pictureLoadScreen.Image = rescaleImage;
                                img.Dispose();
                            }

                            //pictureLoadScreen.Image = cloneImage;

                            //cloneImage.Dispose();
                        }

                        denoiseImageCheckBox.Checked = false;

                    }

                }

                else
                {
                    var message = "Не выбрано изображение. Выберите изображение";
                    var caption = "Ошибка";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    denoiseImageCheckBox.Checked = false;
                }
            }
            //Для изменения яркости и шума
            else if (!changeColorBalanceCheckBox.Checked && changeContrastAndBrightnessCheckBox.Checked && denoiseImageCheckBox.Checked)
            {
                if (!pathToMainFolder.Equals("") && !imageName.Equals(""))
                {
                    var message = "Заменить изображение после коррекции яркости и удаления шума?";
                    var caption = "Заменить изображение";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        Bitmap clone = null;
                        Bitmap cloneImage = null;
                        using (Bitmap bitmap = new Bitmap(pathToMainFolder + "\\" + imageName))
                        {

                            using (clone = new Bitmap(denoiserImage(AutoBrightnessAndContrast(bitmap))))

                            {
                                cloneImage = new Bitmap(clone);
                            }

                        }
                        using (cloneImage)
                        {
                            System.IO.File.Delete(pathToMainFolder + "\\" + imageName);

                            cloneImage.Save(pathToMainFolder + "\\" + imageName, ImageFormat.Jpeg);

                            using (Image img = new Bitmap(pathToMainFolder + "\\" + imageName))
                            {
                                Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                                pictureLoadScreen.Image = rescaleImage;
                                img.Dispose();
                            }

                            //pictureLoadScreen.Image = cloneImage;

                            //cloneImage.Dispose();
                        }
                        denoiseImageCheckBox.Checked = false;
                        changeContrastAndBrightnessCheckBox.Checked = false;

                    }

                }
                else
                {
                    var message = "Не выбрано изображение. Выберите изображение";
                    var caption = "Ошибка";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    denoiseImageCheckBox.Checked = false;
                    changeContrastAndBrightnessCheckBox.Checked = false;
                }
            }
            //для изменения баднса белого и удаления шума
            else if (changeColorBalanceCheckBox.Checked && !changeContrastAndBrightnessCheckBox.Checked && denoiseImageCheckBox.Checked)
            {
                if (!pathToMainFolder.Equals("") && !imageName.Equals(""))
                {
                    var message = "Заменить изображение после коррекции цвета и удаления шума?";
                    var caption = "Заменить изображение";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        Bitmap cloneImage = null;
                        using (Bitmap newPreparateImage = denoiserImage(ColorBalance(pathToMainFolder + "\\" + imageName)))
                        {
                            cloneImage = new Bitmap(newPreparateImage);
                        }

                        using (cloneImage)
                        {

                            System.IO.File.Delete(pathToMainFolder + "\\" + imageName);

                            cloneImage.Save(pathToMainFolder + "\\" + imageName, ImageFormat.Jpeg);

                            using (Image img = new Bitmap(pathToMainFolder + "\\" + imageName))
                            {
                                Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                                pictureLoadScreen.Image = rescaleImage;
                                img.Dispose();
                            }

                            // cloneImage.Dispose();

                        }
                        denoiseImageCheckBox.Checked = false;
                        changeColorBalanceCheckBox.Checked = false;
                    }

                }
                else
                {
                    var message = "Не выбрано изображение. Выберите изображение";
                    var caption = "Ошибка";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    denoiseImageCheckBox.Checked = false;
                    changeColorBalanceCheckBox.Checked = false;
                }
            }

            //Для изменения баланса цвета и яркости
            else if (changeColorBalanceCheckBox.Checked && changeContrastAndBrightnessCheckBox.Checked && !denoiseImageCheckBox.Checked)
            {
                if (!pathToMainFolder.Equals("") && !imageName.Equals(""))
                {

                    var message = "Заменить изображение после коррекции?";
                    var caption = "Заменить изображение";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        Bitmap cloneImage = null;
                        using (Bitmap newPreparateImage = AutoBrightnessAndContrast(ColorBalance(pathToMainFolder + "\\" + imageName)))
                        {
                            cloneImage = new Bitmap(newPreparateImage);
                        }

                        using (cloneImage)
                        {
                            System.IO.File.Delete(pathToMainFolder + "\\" + imageName);

                            cloneImage.Save(pathToMainFolder + "\\" + imageName, ImageFormat.Jpeg);

                            using (Image img = new Bitmap(pathToMainFolder + "\\" + imageName))
                            {
                                Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                                pictureLoadScreen.Image = rescaleImage;
                                img.Dispose();
                            }

                            //pictureLoadScreen.Image = cloneImage;

                            //cloneImage.Dispose();
                        }
                        changeColorBalanceCheckBox.Checked = false;
                        changeContrastAndBrightnessCheckBox.Checked = false;

                    }
                }
                else
                {
                    var message = "Не выбрано изображение. Выберите изображение";
                    var caption = "Ошибка";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    changeColorBalanceCheckBox.Checked = false;
                    changeContrastAndBrightnessCheckBox.Checked = false;
                }

            }
            //Для изменения всего
            else if (changeColorBalanceCheckBox.Checked && changeContrastAndBrightnessCheckBox.Checked && denoiseImageCheckBox.Checked)
            {
                if (!pathToMainFolder.Equals("") && !imageName.Equals(""))
                {
                    var message = "Заменить изображение после коррекции и удаления шума?";
                    var caption = "Заменить изображение";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        Bitmap cloneImage = null;
                        using (Bitmap newPreparateImage = denoiserImage(AutoBrightnessAndContrast(ColorBalance(pathToMainFolder + "\\" + imageName))))
                        {
                            cloneImage = new Bitmap(newPreparateImage);
                        }

                        using (cloneImage)
                        {
                            System.IO.File.Delete(pathToMainFolder + "\\" + imageName);

                            cloneImage.Save(pathToMainFolder + "\\" + imageName, ImageFormat.Jpeg);

                            using (Image img = new Bitmap(pathToMainFolder + "\\" + imageName))
                            {
                                Image rescaleImage = ScaleImage(img, pictureLoadScreen.ClientSize.Width, pictureLoadScreen.ClientSize.Height);
                                pictureLoadScreen.Image = rescaleImage;
                                img.Dispose();
                            }

                            //pictureLoadScreen.Image = cloneImage;

                            //cloneImage.Dispose();
                        }

                        changeColorBalanceCheckBox.Checked = false;
                        changeContrastAndBrightnessCheckBox.Checked = false;
                        denoiseImageCheckBox.Checked = false;

                    }
                }
                else
                {
                    var message = "Не выбрано изображение. Выберите изображение";
                    var caption = "Ошибка";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    changeColorBalanceCheckBox.Checked = false;
                    changeContrastAndBrightnessCheckBox.Checked = false;
                    denoiseImageCheckBox.Checked = false;
                }
            }

        }


        public Bitmap denoiserImage(Bitmap image)
        {
            Mat denoiseSource = BitmapConverter.ToMat(image);
            Mat denoiserDst = BitmapConverter.ToMat(image);
            Cv2.FastNlMeansDenoisingColored(denoiseSource, denoiserDst);
            Bitmap imageDst = BitmapConverter.ToBitmap(denoiserDst);
            return imageDst;

        }

        public Bitmap AutoBrightnessAndContrast(Bitmap colorBalanced)
        {

            Mat src = BitmapConverter.ToMat(colorBalanced);
            Mat dst = BitmapConverter.ToMat(colorBalanced);

            colorBalanced.Dispose();

            float clipHistPercent = 15;
            Debug.Assert(clipHistPercent >= 0);
            Debug.Assert((src.Type() == MatType.CV_8UC1) || (src.Type() == MatType.CV_8UC3) || (src.Type() == MatType.CV_8UC4));

            float alpha, beta;
            double minGray = 0.0, maxGray = 0.0;

            const int histogramSize = 256;//from 0 to 63
            int[] dimensions = { histogramSize }; // Histogram size for each dimension
            Rangef[] ranges = { new Rangef(0, histogramSize) }; // min/max

            Mat gray = new Mat();

            if (src.Type() == MatType.CV_8UC1) gray = src;
            else if (src.Type() == MatType.CV_8UC3) Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            else if (src.Type() == MatType.CV_8UC4) Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            if (clipHistPercent == 0)
            {
                Cv2.MinMaxLoc(gray, out minGray, out maxGray);
            }
            else
            {
                using (Mat histogram = new Mat())
                {
                    Cv2.CalcHist(
                  images: new[] { gray },
                  channels: new[] { 0 }, //The channel (dim) to be measured. In this case it is just the intensity (each array is single-channel) so we just write 0.
                  mask: null,
                  hist: histogram,
                  dims: 1, //The histogram dimensionality.
                  histSize: dimensions,
                  ranges: ranges);

                    List<float> accumulator = new List<float>(histogramSize);
                    accumulator.Insert(0, histogram.At<float>(0));

                    for (int i = 1; i < histogramSize; i++)
                    {
                        accumulator.Insert(i, (accumulator[i - 1] + histogram.At<float>(i)));

                    }

                    float max = accumulator[accumulator.Count - 1];

                    clipHistPercent *= (max / 100.0f); //make percent as absolute
                    clipHistPercent /= 2.0f; // left and right wings
                                             // locate left cut
                    minGray = 0;
                    while (accumulator[Convert.ToInt32(minGray)] < clipHistPercent)
                        minGray++;

                    // locate right cut
                    maxGray = histogramSize - 1;
                    while (accumulator[Convert.ToInt32(maxGray)] >= (max - clipHistPercent))
                        maxGray--;

                }
            }

            // current range
            float inputRange = Convert.ToSingle(maxGray) - Convert.ToSingle(minGray);

            alpha = (histogramSize - 1) / inputRange;   // alpha expands current range to histsize range
            beta = Convert.ToSingle(-minGray) * alpha;             // beta shifts current range so that minGray will go to 0

            // Apply brightness and contrast normalization
            // convertTo operates with saurate_cast
            src.ConvertTo(dst, -1, alpha, beta);

            // restore alpha channel from source 
            if (dst.Type() == MatType.CV_8UC4)
            {
                Mat[] src_sp = src.Split();
                Mat[] dst_sp = dst.Split();
                int[] from_to = { 3, 3 };
                Cv2.MixChannels(src_sp, dst_sp, from_to);

                Mat merged = new Mat();
                Cv2.Merge(dst_sp, merged);
                Bitmap updImage = merged.ToBitmap();
                return updImage;
            }
            else
            {
                Bitmap updImage = dst.ToBitmap();
                return updImage;
            }






        }

        public Bitmap ColorBalance(string imagePath)
        {
            //Это работает!!!!!!!!!!!!!!

            using (Bitmap balancedImage = new Bitmap(imagePath))
            {

                int width = balancedImage.Width;
                int height = balancedImage.Height;

                List<Color> color = new List<Color>();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        color.Add(balancedImage.GetPixel(x, y));

                    }
                }

                Color[] colors = color.ToArray();
                Color[] new_color = AutoLevel(colors);


                Bitmap pic = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        int arrayIndex = y * width + x;
                        Color c = new_color[arrayIndex];
                        pic.SetPixel(x, y, c);
                    }
                }

                balancedImage.Dispose();


                return pic;

            }

        }

        public static Color[] AutoLevel(Color[] input)
        {
            var histogram = new Histogram();
            foreach (var _ in input) histogram.AddColor(_);
            var levels = histogram.GetAutoLevels();
            var ret = new Color[input.Length];
            for (int _ = 0; _ < input.Length; _++)
            {
                ret[_] = levels.Apply(input[_].R, input[_].G, input[_].B).ToColor();
            }
            return ret;
        }

        public class Histogram
        {
            private long[,] _values = new long[3, 256];

            public void AddColor(Color color)
            {
                AddColor(color.R, color.G, color.B);
            }

            public void AddColor(RGB color)
            {
                AddColor(color.R, color.G, color.B);
            }

            public void AddColor(byte r, byte g, byte b)
            {
                _values[0, b]++;
                _values[1, g]++;
                _values[2, b]++;
            }

            public long this[int channel, int index]
            {
                get { return _values[channel, index]; }
            }

            public long GetMaxValue()
            {
                var ret = long.MinValue;
                foreach (var _ in _values) if (_ > ret) ret = _;
                return ret;
            }

            public RGB GetMeanColor()
            {
                var total = new long[3];
                var count = new long[3];
                var value = new byte[3];
                for (var _ = 0; _ < 3; _++)
                {
                    for (var __ = 0; __ < 256; __++)
                    {
                        total[_] += (_values[_, __] * __);
                        count[_] += _values[_, __];
                    }
                    value[_] = (byte)Math.Round((double)total[_] / count[_]);
                }
                return new RGB(value[2], value[1], value[0]);
            }

            public RGB GetPercentileColor(double percentile)
            {
                var ret = new RGB();
                for (var _ = 0; _ < 3; _++)
                {
                    var total = 0L;
                    for (var __ = 0; __ < 256; __++) total += _values[_, __];
                    var cutoff = (total * percentile);
                    var count = 0L;
                    for (var __ = 0; __ < 256; __++)
                    {
                        count += _values[_, __];
                        if (count > cutoff)
                        {
                            ret[_] = (byte)__;
                            break;
                        }
                    }
                }
                return ret;
            }

            public Levels GetAutoLevels()
            {
                var low = GetPercentileColor(0.005);
                var middle = GetMeanColor();
                var high = GetPercentileColor(0.995);
                return Levels.GetAdjusted(low, middle, high);
            }


            public class Levels
            {
                private RGB _inputLow = new RGB(0, 0, 0);
                private RGB _inputHigh = new RGB(255, 255, 255);
                private RGB _outputLow = new RGB(0, 0, 0);
                private RGB _outputHigh = new RGB(255, 255, 255);
                private double[] _gamma = { 1, 1, 1 };

                public RGB InputLow
                {
                    get { return _inputLow; }
                    set
                    {
                        for (var _ = 0; _ < 3; _++)
                        {
                            if (value[_] == 255) value[_] = 254;
                            if (_inputHigh[_] <= value[_]) _inputHigh[_] = (byte)(value[_] + 1);
                        }
                        _inputLow = value;
                    }
                }

                public RGB InputHigh
                {
                    get { return _inputHigh; }
                    set
                    {
                        for (var _ = 0; _ < 3; _++)
                        {
                            if (value[_] == 0) value[_] = 1;
                            if (_inputLow[_] >= value[_]) _inputLow[_] = (byte)(value[_] - 1);
                        }
                        _inputHigh = value;
                    }
                }

                public RGB OutputLow
                {
                    get { return _outputLow; }
                    set
                    {
                        for (var _ = 0; _ < 3; _++)
                        {
                            if (value[_] == 255) value[_] = 254;
                            if (_outputHigh[_] <= value[_]) _outputHigh[_] = (byte)(value[_] + 1);
                        }
                        _outputLow = value;
                    }
                }

                public RGB OutputHigh
                {
                    get { return _outputHigh; }
                    set
                    {
                        for (var _ = 0; _ < 3; _++)
                        {
                            if (value[_] == 0) value[_] = 1;
                            if (_outputLow[_] >= value[_]) _outputLow[_] = (byte)(value[_] - 1);
                        }
                        _outputHigh = value;
                    }
                }

                public double GetGamma(int channel)
                {
                    return _gamma[channel];
                }

                public void SetGamma(int channel, double value)
                {
                    _gamma[channel] = SetRange(value, 0.1, 10);
                }

                public RGB Apply(int r, int g, int b)
                {
                    var ret = new RGB();
                    var input = new double[] { b, g, r };
                    for (var _ = 0; _ < 3; _++)
                    {
                        var value_ = (input[_] - _inputLow[_]);
                        if (value_ < 0)
                        {
                            ret[_] = _outputLow[_];
                        }
                        else if ((_inputLow[_] + value_) >= _inputHigh[_])
                        {
                            ret[_] = _outputHigh[_];
                        }
                        else
                        {
                            ret[_] = (byte)SetRange((_outputLow[_] + ((_outputHigh[_] - _outputLow[_]) * Math.Pow((value_ / (_inputHigh[_] - _inputLow[_])), _gamma[_]))), 0, 255);
                        }
                    }
                    return ret;
                }

                internal static Levels GetAdjusted(RGB low, RGB middle, RGB high)
                {
                    var ret = new Levels();
                    for (var _ = 0; _ < 3; _++)
                    {
                        if ((low[_] < middle[_]) && (middle[_] < high[_]))
                        {
                            ret._gamma[_] = SetRange(Math.Log(0.5, ((double)(middle[_] - low[_]) / (high[_] - low[_]))), 0.1, 10);
                        }
                        else
                        {
                            ret._gamma[_] = 1;
                        }
                    }
                    ret._inputLow = low;
                    ret._inputHigh = high;
                    return ret;
                }
            }

            private static double SetRange(double value, double min, double max)
            {
                if (value < min) value = min;
                if (value > max) value = max;
                return value;
            }



            public struct RGB
            {
                public byte B;
                public byte G;
                public byte R;

                public RGB(byte r, byte g, byte b)
                {
                    B = b;
                    G = g;
                    R = r;
                }

                public byte this[int channel]
                {
                    get
                    {
                        switch (channel)
                        {
                            case 0: return B;
                            case 1: return G;
                            case 2: return R;
                            default: throw new ArgumentOutOfRangeException();
                        }
                    }
                    set
                    {
                        switch (channel)
                        {
                            case 0: B = value; break;
                            case 1: G = value; break;
                            case 2: R = value; break;
                            default: throw new ArgumentOutOfRangeException();
                        }
                    }
                }

                public Color ToColor()
                {
                    return Color.FromArgb(R, G, B);
                }
            }
        }

        private void createDirectoryButton_Click_1(object sender, EventArgs e)
        {
            string filePath = string.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Выберите файл для распределения фото";
                ofd.InitialDirectory = "C:\\";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                }
            }
            if (!filePath.Equals(""))
            {
                readCsvFile(filePath);
                createFileDirectory();
            }
        }

        private void readCsvFile(string filePath)
        {
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                int counter = 0;
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();


                    if (fields.Length >= 7)
                    {
                        Contry.Add(fields[0].Replace("Contry =", string.Empty).Trim());
                        State.Add(fields[1].Replace("State =", string.Empty).Trim());
                        Subrb.Add(fields[2].Replace("Subrb =", string.Empty).Trim());
                        Road.Add(fields[4].Replace("Road =", string.Empty).Trim());
                        ImageName.Add(fields[6].Replace("ImageName =", string.Empty).Trim());
                        Neighbourhood.Add(fields[5].Replace("Neighbourhood =", string.Empty).Trim());
                    }
                    counter++;


                }
            }

            var q = from x in Road
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Count = count };
            List<string> duplicateValue = new List<string>();
            List<string> duplicateIndex = new List<string>();
            if (q.Count() > 0)
            {
                foreach (var dupe in q)
                {
                    if (!dupe.Value.Equals(""))
                    {
                        duplicateValue.Add(dupe.Value);
                        duplicateIndex.Add(dupe.Count.ToString());
                    }

                }


            }

            string searchRoad = string.Empty;
            //List<string> valueInFile = new List<string>();
            //List<string> differentInFile = new List<string>();

            for (int i = 0; i < duplicateValue.Count; i++)
            {
                searchRoad = duplicateValue[i];

                int count_similiar = 0;

                for (int j = 0; j < Road.Count; j++)
                {
                    if (Road[j].Equals(searchRoad) && !Subrb[j].Equals(""))
                    {

                        count_similiar++;
                    }
                }
                if (count_similiar - Int32.Parse(duplicateIndex[i]) < 0)
                {

                    for (int k = 0; k < Road.Count; k++)
                    {
                        if (Road[k].Equals(searchRoad))
                        {
                            if (Subrb[k].Equals("") && !Neighbourhood[k].Equals(""))
                            {
                                Subrb[k] = Neighbourhood[k];
                                //valueInFile.Add(searchRoad + " " + k.ToString());
                            }
                        }
                    }
                }

                // differentInFile.Add(searchRoad + " " + count_similiar.ToString());

            }

        }

        private void createFileDirectory()
        {

            string pathToMainDirextoryFolder = "";
            var message = "Выберите папку, в которую будут размещены фото";
            var caption = "Выберите папку";
            var results = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);
            if (results == DialogResult.OK)
            {
                using (var fbd = new FolderBrowserDialog())
                {

                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        pathToMainDirextoryFolder = fbd.SelectedPath + "\\";

                    }

                }
                if (Contry.Count > 0 && State.Count > 0 && Subrb.Count > 0 && Road.Count > 0)
                {
                    if (!pathToMainDirextoryFolder.Equals(""))
                    {
                        for (int i = 0; i < Contry.Count; i++)
                        {
                            if (!Directory.Exists(pathToMainDirextoryFolder + Contry[i]))
                            {
                                Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[i]);

                            }

                        }
                    }

                    for (int j = 0; j < State.Count; j++)
                    {
                        if (Directory.Exists(pathToMainDirextoryFolder + Contry[j]))
                        {
                            if (!State[j].Equals(""))
                            {
                                if (!Directory.Exists(pathToMainDirextoryFolder + Contry[j] + "\\" + State[j]))
                                {
                                    Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[j] + "\\" + State[j]);

                                }
                            }
                            else
                            {
                                if (!Directory.Exists(pathToMainDirextoryFolder + Contry[j] + "\\" + "UnknownState"))
                                {
                                    Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[j] + "\\" + "UnknownState");
                                }
                            }
                        }
                    }

                    for (int k = 0; k < Subrb.Count; k++)
                    {
                        if (Directory.Exists(pathToMainDirextoryFolder + Contry[k]))
                        {
                            if (!State[k].Equals(""))
                            {
                                if (Directory.Exists(pathToMainDirextoryFolder + Contry[k] + "\\" + State[k]))
                                {
                                    if (!Subrb[k].Equals(""))
                                    {
                                        if (!Directory.Exists(pathToMainDirextoryFolder + Contry[k] + "\\" + State[k] + "\\" + (Subrb[k].Replace("/", "-"))))
                                        {
                                            Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[k] + "\\" + State[k] + "\\" + (Subrb[k].Replace("/", "-")));
                                        }
                                    }
                                    else
                                    {
                                        if (!Directory.Exists(pathToMainDirextoryFolder + Contry[k] + "\\" + State[k] + "\\" + "UnknownSubrb"))
                                        {
                                            Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[k] + "\\" + State[k] + "\\" + "UnknownSubrb");
                                        }
                                    }

                                }
                            }
                            else
                            {
                                if (Directory.Exists(pathToMainDirextoryFolder + Contry[k] + "\\" + "UnknownState"))
                                {
                                    if (!Subrb[k].Equals(""))
                                    {
                                        if (!Directory.Exists(pathToMainDirextoryFolder + Contry[k] + "\\" + "UnknownState" + "\\" + (Subrb[k].Replace("/", "-"))))
                                        {
                                            Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[k] + "\\" + "UnknownState" + "\\" + (Subrb[k].Replace("/", "-")));
                                        }
                                    }
                                    else
                                    {
                                        if (!Directory.Exists(pathToMainDirextoryFolder + Contry[k] + "\\" + "UnknownState" + "\\" + "UnknownSubrb"))
                                        {

                                            Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[k] + "\\" + "UnknownState" + "\\" + "UnknownSubrb");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    for (int m = 0; m < Road.Count; m++)
                    {
                        if (Directory.Exists(pathToMainDirextoryFolder + Contry[m]))
                        {
                            if (!State[m].Equals(""))
                            {
                                if (Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m]))
                                {
                                    if (!Subrb[m].Equals(""))
                                    {
                                        if (Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m] + "\\" + (Subrb[m].Replace("/", "-"))))
                                        {
                                            if (!Road[m].Equals(""))
                                            {
                                                if (!Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m] + "\\" + (Subrb[m].Replace("/", "-")) + "\\" + Road[m]))
                                                {
                                                    Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m] + "\\" + (Subrb[m].Replace("/", "-")) + "\\" + Road[m]);
                                                }
                                            }
                                            else
                                            {
                                                if (!Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m] + "\\" + (Subrb[m].Replace("/", "-")) + "\\" + "UnknownRoad"))
                                                {
                                                    Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m] + "\\" + (Subrb[m].Replace("/", "-")) + "\\" + "UnknownRoad");
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m] + "\\" + "UnknownSubrb"))
                                        {

                                            if (!Road[m].Equals(""))
                                            {
                                                if (!Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m] + "\\" + "UnknownSubrb" + "\\" + Road[m]))
                                                {
                                                    Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m] + "\\" + "UnknownSubrb" + "\\" + Road[m]);
                                                }
                                            }
                                            else
                                            {
                                                if (!Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m] + "\\" + "UnknownSubrb" + "\\" + "UnknownRoad"))
                                                {
                                                    Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[m] + "\\" + State[m] + "\\" + "UnknownSubrb" + "\\" + "UnknownRoad");
                                                }
                                            }

                                        }
                                    }

                                }
                            }
                            else
                            {
                                if (Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState"))
                                {
                                    if (!Subrb[m].Equals(""))
                                    {
                                        if (Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState" + "\\" + Subrb[m]))
                                        {
                                            if (!Road[m].Equals(""))
                                            {
                                                if (!Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState" + "\\" + Subrb[m] + "\\" + Road[m]))
                                                {
                                                    Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState" + "\\" + Subrb[m] + "\\" + Road[m]);
                                                }
                                            }
                                            else
                                            {
                                                if (!Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState" + "\\" + Subrb[m] + "\\" + "UnknownRoad"))
                                                {
                                                    Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState" + "\\" + Subrb[m] + "\\" + "UnknownRoad");
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState" + "\\" + "UnknownSubrb"))
                                        {
                                            if (!Road[m].Equals(""))
                                            {
                                                if (!Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState" + "\\" + "UnknownSubrb" + "\\" + Road[m]))
                                                {
                                                    Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState" + "\\" + "UnknownSubrb" + "\\" + Road[m]);
                                                }
                                            }
                                            else
                                            {
                                                if (!Directory.Exists(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState" + "\\" + "UnknownSubrb" + "\\" + "UnknownRoad"))
                                                {
                                                    Directory.CreateDirectory(pathToMainDirextoryFolder + Contry[m] + "\\" + "UnknownState" + "\\" + "UnknownSubrb" + "\\" + "UnknownRoad");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    createDirectoryProgressBar.Visible = true;
                    createDirectoryProgressBar.Minimum = 0;
                    createDirectoryProgressBar.Maximum = Contry.Count;
                    createDirectoryProgressBar.Step = 1;

                    List<string> exept = new List<string>();
                    for (int n = 0; n < Contry.Count; n++)
                    {


                        string newState = State[n];
                        string newSubrb = Subrb[n].Replace("/", "-");
                        string newRoad = Road[n];
                        if (State[n].Equals(""))
                        {
                            newState = "UnknownState";
                        }
                        if (Subrb[n].Equals(""))
                        {
                            newSubrb = "UnknownSubrb";
                        }
                        if (Road[n].Equals(""))
                        {
                            newRoad = "UnknownRoad";
                        }

                        // string oldPath = pathToMainFolder + ImageName[n];
                        string oldPath = string.Empty;
                        if (!pathToMainFolder.Equals(""))
                        {
                            oldPath = pathToMainFolder + "\\" + ImageName[n];
                        }
                        else
                        {
                            var messages = "Сначала выберите папку с фото";
                            var captions = "Выберите папку";
                            var resultes = MessageBox.Show(messages, captions, MessageBoxButtons.OKCancel);
                            if (resultes == DialogResult.OK)
                            {
                                using (var openFile = new FolderBrowserDialog())
                                {
                                    DialogResult result = openFile.ShowDialog();

                                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFile.SelectedPath))
                                    {
                                        pathToMainFolder = openFile.SelectedPath;
                                        oldPath = pathToMainFolder + "\\" + ImageName[n];
                                    }

                                    openFile.Dispose();
                                }

                            }

                        }
                        if (!pathToMainFolder.Equals(""))
                        {
                            string newPath = pathToMainDirextoryFolder + Contry[n] + "\\" + newState + "\\" + newSubrb + "\\" + newRoad + "\\" + ImageName[n];
                            try
                            {
                                File.Copy(oldPath, newPath);
                            }
                            catch (Exception ex)
                            {
                                exept.Add(n.ToString());
                            }
                        }
                        createDirectoryProgressBar.PerformStep();
                    }
                    createDirectoryProgressBar.Value = 0;
                    createDirectoryProgressBar.Visible = false;
                }
                else
                {
                    MessageBox.Show("Не удалось получить данные из файла");
                }
            }


        }

        private void findCoordinatesFormFileButton_Click(object sender, EventArgs e)
        {
            string pathToUploadFile = string.Empty;
            string folderToSave = string.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Выберите файл для распределения фото";
                ofd.InitialDirectory = "C:\\";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pathToUploadFile = ofd.FileName;
                }
            }
            if (!pathToUploadFile.Equals(""))
            {
                folderToSave = Path.GetDirectoryName(pathToUploadFile);
                if (File.Exists(pathToUploadFile))
                {
                    using (StreamReader reader = new StreamReader(pathToUploadFile))
                    {

                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(';');

                            imageNames.Add(values[0]);
                            latitudeList.Add(values[1]);
                            longitudeList.Add(values[2]);
                        }
                    }



                    List<string> res = GetAddressForCoordinates(latitudeList, longitudeList, imageNames);

                    writeToFile(res, folderToSave + "\\Train1_Labels_Finded.csv");
                }
            }
        }

        private void writeToFile(List<string> result, string pathToFolder)
        {
            if (!File.Exists(pathToFolder))
            {
                var myFile = File.Create(pathToFolder);
                myFile.Close();
            }
            else
            {
                File.Delete(pathToFolder);

                var myFile = File.Create(pathToFolder);
                myFile.Close();

                using (StreamWriter sw = File.AppendText(pathToFolder))
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        sw.WriteLine(result[i]);
                    }

                }
            }
        }

        private List<string> GetAddressForCoordinates(List<string> latitude, List<string> longitude, List<string> imageName)
        {
            byte[] resp;
            string country = "";
            string subrb = "";
            string attarction = "";
            string road = "";
            string neighbourhood = "";
            string state = "";

            List<string> result = new List<string>();
            var watch = System.Diagnostics.Stopwatch.StartNew();


            createDirectoryProgressBar.Visible = true;
            createDirectoryProgressBar.Minimum = 0;
            createDirectoryProgressBar.Maximum = latitude.Count - 1;
            createDirectoryProgressBar.Step = 1;

            for (int i = 1; i < latitude.Count; i++)
            {


                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2");
                    webClient.Headers.Add("Referer", "http://nominatim.openstreetmap.org");
                    webClient.Headers.Add("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
                    resp = webClient.DownloadData("http://nominatim.openstreetmap.org/reverse?format=json&lat=" + latitude[i] + "&lon=" + longitude[i]);
                    var json = System.Text.Encoding.UTF8.GetString(resp);



                    RootedObject imageParse = JsonConvert.DeserializeObject<RootedObject>(json);

                    country = imageParse.address.country;
                    state = imageParse.address.state;
                    subrb = imageParse.address.suburb;
                    attarction = imageParse.address.attraction;
                    road = imageParse.address.road.Replace(";", "-");
                    neighbourhood = imageParse.address.neighbourhood;


                    result.Add(string.Format("Contry = {0}; State = {1}; Subrb = {2}; Attraction = {3}; Road = {4}; Neighbourhood = {5}; ImageName = {6}", country, state, subrb, attarction, road, neighbourhood, imageName[i]));


                }
                catch (Exception ex)
                {
                    if (ex.Message.ToString().Equals("Ссылка на объект не указывает на экземпляр объекта."))
                    {
                        Console.WriteLine(ex.ToString());

                        System.Threading.Thread.Sleep(1200);
                        WebClient webClient = new WebClient();
                        webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2");
                        webClient.Headers.Add("Referer", "http://nominatim.openstreetmap.org");
                        webClient.Headers.Add("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
                        resp = webClient.DownloadData("http://nominatim.openstreetmap.org/reverse?format=json&lat=" + latitude[i] + "&lon=" + longitude[i]);
                        var json = System.Text.Encoding.UTF8.GetString(resp);

                        RootedObject imageParse = JsonConvert.DeserializeObject<RootedObject>(json);

                        country = imageParse.address.country;
                        state = imageParse.address.state;
                        subrb = imageParse.address.suburb;
                        attarction = imageParse.address.attraction;
                        road = imageParse.address.road;
                        neighbourhood = imageParse.address.neighbourhood;


                        result.Add(string.Format("Contry = {0}; State = {1}; Subrb = {2}; Attraction = {3}; Road = {4}; Neighbourhood = {5}; ImageName = {6}", country, state, subrb, attarction, road, neighbourhood, imageName[i]));

                        // Console.WriteLine("Index = {0}", i);
                    }
                    else
                    {
                        // Console.WriteLine(ex.ToString());
                    }
                }

                System.Threading.Thread.Sleep(1200);


                createDirectoryProgressBar.PerformStep();
            }
            createDirectoryProgressBar.Value = 0;
            createDirectoryProgressBar.Visible = false;
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return result;
        }

        public class Address
        {
            public string attraction { get; set; }
            public string road { get; set; }
            public string neighbourhood { get; set; }
            public string suburb { get; set; }
            public string state { get; set; }
            public string postcode { get; set; }
            public string country { get; set; }
            public string country_code { get; set; }
        }
        public class RootedObject
        {
            public long place_id { get; set; }
            public string licence { get; set; }
            public string osm_type { get; set; }
            public long osm_id { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
            public string display_name { get; set; }
            public Address address { get; set; }
            public List<string> boundingbox { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void peopleFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void flagsFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void unknownTextFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void unknownFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void longDistanceFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buildingsFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void unknownArchitectureFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void monumentsFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void changeContrastAndBrightnessCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void changeColorBalanceCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void denoiseImageCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void createDirectoryProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void positionLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureLoadScreen_Click(object sender, EventArgs e)
        {

        }

        private void loadImageFolderButton_Click(object sender, EventArgs e)
        {

        }

        private void textFolderCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextFolderCheckBox_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void pictureLoadScreen_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureLoadScreen_Click_2(object sender, EventArgs e)
        {

        }

        private void ImageProcessUC_Load(object sender, EventArgs e)
        {

        }

        private void positionLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void findCoordinatesFormFileButton_Click_1(object sender, EventArgs e)
        {

        }

        private void createDirectoryProgressBar_Click_1(object sender, EventArgs e)
        {

        }


        private void denoiseImageCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void changeColorBalanceCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void changeContrastAndBrightnessCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void unknownArchitectureFolderCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void longDistanceFolderCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void peopleFolderCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void flagsFolderCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void unknownTextFolderCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void unknownFolderCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

    }
}
