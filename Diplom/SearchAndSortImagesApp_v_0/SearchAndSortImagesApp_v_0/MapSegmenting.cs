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
using Google.Common.Geometry;
using GMap.NET;
using GMap.NET.WindowsForms;


namespace SearchAndSortImagesApp_v_0
{
    public partial class MapSegmenting : UserControl
    {
        private string pathToMainFolder = "";
        private string pathToRootFolder = "";
        private string[] pathToRootFolderArray;

        private string pathToOrigMetadata = "";

        private int baseCount = 91000000;
        private int baseTmin = 50;
        private int baseTmax = 10000;
        private int Tmax;
        private int Tmin;
        public static List<string> metadataList = new List<string>();
        public static List<string> metadataList_1 = new List<string>();
        public static List<string> metadataList_2 = new List<string>();
        public static List<string> metadataList_2_1 = new List<string>();
        public static List<string> metadataListConst = new List<string>();
        public static List<string> metadataListFullConst = new List<string>();


        public MapSegmenting()
        {
            InitializeComponent();
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

            var divResult = baseCount / (metadataList.Skip(1).Count());
            if (baseTmin / baseCount == 0)
            {
                tMinTextBox.Text = ((baseTmin / baseCount) + 1).ToString();
                Tmin = (baseTmin / baseCount) + 1;
            }
            else
            {
                tMinTextBox.Text = (baseTmin / baseCount).ToString();
                Tmin = (baseTmin / baseCount);
            }

            if (baseTmax / baseCount == 0)
            {
                tMaxTextBox.Text = ((baseTmax / baseCount) + 2).ToString();
                Tmax = (baseTmax / baseCount) + 2;
            }
            else
            {
                tMaxTextBox.Text = (baseTmax / baseCount).ToString();
                Tmax = baseTmax / baseCount;
            }

        }

        private void MapSegmenting_Load(object sender, EventArgs e)
        {
            //Настройки для компонента GMap.
            gMapControl.Bearing = 0;

            //CanDragMap - Если параметр установлен в True,
            //пользователь может перетаскивать карту
            ///с помощью правой кнопки мыши.
            gMapControl.CanDragMap = true;

            //Указываем, что перетаскивание карты осуществляется
            //с использованием левой клавишей мыши.
            //По умолчанию - правая.
            gMapControl.DragButton = MouseButtons.Left;

            gMapControl.GrayScaleMode = true;

            //MarkersEnabled - Если параметр установлен в True,
            //любые маркеры, заданные вручную будет показаны.
            //Если нет, они не появятся.
            gMapControl.MarkersEnabled = true;

            //Указываем значение максимального приближения.
            gMapControl.MaxZoom = 18;

            //Указываем значение минимального приближения.
            gMapControl.MinZoom = 1;

            //Устанавливаем центр приближения/удаления
            //курсор мыши.
            gMapControl.MouseWheelZoomType =
            GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            //Отказываемся от негативного режима.
            gMapControl.NegativeMode = false;

            //Разрешаем полигоны.
            gMapControl.PolygonsEnabled = true;

            //Разрешаем маршруты
            gMapControl.RoutesEnabled = true;

            //Скрываем внешнюю сетку карты
            //с заголовками.
            gMapControl.ShowTileGridLines = false;

            //Указываем, что при загрузке карты будет использоваться
            //1ти кратное приближение.
            gMapControl.Zoom = 1;

            // данные карты будут храниться в кеше
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;

            //Указываем что будем использовать карты Google.
            gMapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;

        }

        private void gMapControl_Load(object sender, EventArgs e)
        {

        }

        private void gMapControl_Load_1(object sender, EventArgs e)
        {

        }

        private void minSegmentingButton_Click(object sender, EventArgs e)
        {
            MinSegmenting(metadataList);
        }
        public void MinSegmenting(List<String> metadataList)
        {
            List<string> metadataList1 = new List<string>();
            metadataList1.AddRange(metadataList);
            metadataList1[0] += ";MinCellID";
            int index = 1;
            foreach (string element in metadataList.Skip(1))
            {
                double latitude = double.Parse(metadataList[index].Split(';')[1], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
                double longitude = double.Parse(metadataList[index].Split(';')[2], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
                var latLngRadians = S2LatLng.FromDegrees(latitude, longitude);
                var cellId = S2CellId.FromLatLng(latLngRadians).Id;
                //var cellIdNew = new S2CellId(cellId);
                //var cell = new S2Cell(cellIdNew);

                metadataList1[index] += ";" + cellId.ToString();
                index++;
                //uploadDataProgressBar.PerformStep();
            }
            metadataList.Clear();
            metadataList.AddRange(metadataList1);
            File.WriteAllLines(pathToOrigMetadata, metadataList);
        }

        private void adaptiveSegmentingButton_Click(object sender, EventArgs e)
        {
            
        metadataList = AdaptiveSegmenting(metadataList);
        File.WriteAllLines(pathToOrigMetadata, metadataList);

        }

        public List<string> AdaptiveSegmenting(List<String> metadataList)
        {
            int index;
            List<string> metadataListRes = new List<string>();
            metadataListRes.AddRange(metadataList);
            metadataListRes[0] += ";AdaptedCellID";
            List<string> cells = new List<string>();
            
            index = 1;

            metadataList_1.Add("minCellId;Count;IterateCellId;ResultCellId");
            metadataList_2.Add("minCellId;Count;IterateCellId;ResultCellId");
            metadataList_2_1.Add("minCellId;Count;IterateCellId;ResultCellId");
            metadataListConst.Add("minCellId;Count;IterateCellId;ResultCellId");
            metadataListFullConst.Add("minCellId;Count;IterateCellId;ResultCellId");

            //Установка значений ListConst
            foreach (string element in metadataList.Skip(1))
            {
                metadataList_1.Add(metadataList[index].Split(';')[5]);
                metadataListConst.Add(metadataList[index].Split(';')[5]);
                metadataListFullConst.Add(metadataList[index].Split(';')[5]);
                //metadataList_2.Add(metadataList[index].Split(';')[5]);
                index++;
            }

            var result = metadataList_1.Skip(1).GroupBy(x => x).ToDictionary(y => y.Key, y => y.Count());
            var minValue = result.Values.Min();
            index = 1;

            string[] arr = new string[4];
            //var arr = metadataList_1[index].Split(';');

            string value;
            string key;

            //Группировка значений в List 1 и List 2 
            foreach (var x in result)
            {
                key = (x.Key).ToString();
                value = (x.Value).ToString();
                arr[1] = value;
                arr[0] = key;
                if (Int16.Parse(value) < Tmin)
                {
                    var cellId = new S2CellId(Convert.ToUInt64(arr[0])).Parent.Id;
                    arr[2] = cellId.ToString();
                }
                else
                    arr[2] = key;
                metadataList_2.Add(string.Join(";", arr));
                metadataList_2_1.Add(key.ToString());
                //metadataList_2[index] = string.Join(";", arr);

                index++;
            }

            while (minValue < Tmin)
            {
                //обновление List 1 на основе List 2
                index = 0;
                var itemIndex = 0;
                foreach (var s in metadataListConst)
                {
                    var ss = s.Split(';')[0];
                    if (metadataList_2_1.Contains(ss))
                    {
                        itemIndex = metadataList_2_1.IndexOf(ss);
                        metadataList_1[index] = metadataList_2[itemIndex];
                    }
                    index++;
                }

                //Обновление ListConst
                index = 1;

                metadataListConst.Clear();
                metadataListConst.Add("minCellId;Count;IterateCellId;ResultCellId");

                foreach (string element in metadataList_1.Skip(1))
                {

                    metadataListConst.Add(metadataList_1[index].Split(';')[2]);
                    //metadataList_2.Add(metadataList[index].Split(';')[5]);
                    index++;

                }


                metadataList_2.Clear();
                metadataList_2.Add("minCellId;Count;IterateCellId;ResultCellId");
                metadataList_2_1.Clear();
                metadataList_2_1.Add("minCellId;Count;IterateCellId;ResultCellId");

                result = metadataListConst.Skip(1).GroupBy(x => x).ToDictionary(y => y.Key, y => y.Count());
                minValue = result.Values.Min();


                //Группировка значений List2 и List 2_1
                index = 1;
                metadataList_2_1.Clear();
                metadataList_2_1.Add("minCellId;Count;IterateCellId;ResultCellId");
                foreach (var x in result)
                {
                    key = (x.Key).Split(';')[0].ToString();
                    value = (x.Value).ToString();
                    arr[1] = value;
                    arr[0] = key;
                    if (Int16.Parse(value) < Tmin)
                    {
                        var cellId = new S2CellId(Convert.ToUInt64(arr[0])).Parent.Id;
                        arr[2] = cellId.ToString();
                    }
                    else
                        arr[2] = key;
                    metadataList_2_1.Add(arr[0].ToString());
                    metadataList_2.Add(string.Join(";", arr)); ;
                    index++;
                }

            }
            //Заполнение ListRes
            index = 1;
            foreach (string element in metadataList_1.Skip(1))
            {

                metadataListRes[index] += ";" + metadataList_1[index].Split(';')[2];
                index++;

            }
            return metadataListRes;
        }

        private void tMinTextBox_TextChanged(object sender, EventArgs e)
        {
            if (tMinTextBox.Text != "")
            Tmin = Int16.Parse(tMinTextBox.Text);
        }

        private void tMaxTextBox_TextChanged(object sender, EventArgs e)
        {
            if (tMaxTextBox.Text != "")
                Tmax = Int16.Parse(tMaxTextBox.Text);
        }

        private void drawSegmentsButton_Click(object sender, EventArgs e)
        {
            DrawSegments(metadataList);
        }

        public void DrawSegments(List<string> metadataList)
        {
            // Подготавливаем массив сегментов
            var index = 1;
            List<ulong> cellIds = new List<ulong>();
            foreach (string element in metadataList.Skip(1))
            {
                var cellId = Convert.ToUInt64(element.Split(';')[6]);
                cellIds.Add(cellId);
                //var cell = new S2Cell(cellId);
                index++;
            }
            //работа с массивом сегментов
            var listPoints = new List<List<PointLatLng>>();
            foreach (ulong cellId in cellIds)
            {
                //создание ячейки из ИД ячейки
                var cellIdObj = new S2CellId((ulong)cellId);
                var cell = new S2Cell(cellIdObj);
                //определение точек границ ячейки
                var points = new List<PointLatLng>();
                
                for(var i=0; i<4; i++)
                {
                    var point = new S2LatLng(cell.GetVertex(i));
                    points.Add(new PointLatLng(point.LatDegrees, point.LngDegrees));
                    //Создание полигонов
                    listPoints.Add(points);
                    var polygon = new GMapPolygon(points, "mypolygon");
                    polygon.Fill = new SolidBrush(Color.FromArgb(3, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, float.Parse("0.1", System.Globalization.CultureInfo.InvariantCulture.NumberFormat));
                    var polygons = new GMapOverlay("polygons");
                    polygons.Polygons.Add(polygon);
                    //gMapOverlay = new GMapOverlay("overlay");
                    gMapControl.Overlays.Add(polygons);
                }

            }
            var j = 1;
        }
        
    }
}

