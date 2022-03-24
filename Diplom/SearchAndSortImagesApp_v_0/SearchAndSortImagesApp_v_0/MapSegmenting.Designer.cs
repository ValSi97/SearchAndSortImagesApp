namespace SearchAndSortImagesApp_v_0
{
    partial class MapSegmenting
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadMetadataFileButton = new System.Windows.Forms.Button();
            this.metadataPathLabel = new System.Windows.Forms.Label();
            this.metadataPathTextBox = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.minSegmentingButton = new System.Windows.Forms.Button();
            this.adaptiveSegmentingButton = new System.Windows.Forms.Button();
            this.tMinlabel = new System.Windows.Forms.Label();
            this.tMinTextBox = new System.Windows.Forms.TextBox();
            this.tMaxLabel = new System.Windows.Forms.Label();
            this.tMaxTextBox = new System.Windows.Forms.TextBox();
            this.uploadDataButton = new System.Windows.Forms.Button();
            this.drawSegmentsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadMetadataFileButton
            // 
            this.loadMetadataFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadMetadataFileButton.Location = new System.Drawing.Point(996, 13);
            this.loadMetadataFileButton.Margin = new System.Windows.Forms.Padding(1);
            this.loadMetadataFileButton.Name = "loadMetadataFileButton";
            this.loadMetadataFileButton.Size = new System.Drawing.Size(259, 39);
            this.loadMetadataFileButton.TabIndex = 26;
            this.loadMetadataFileButton.Text = "Загрузить файл метаданных";
            this.loadMetadataFileButton.UseVisualStyleBackColor = true;
            this.loadMetadataFileButton.Click += new System.EventHandler(this.loadMetadataFileButton_Click);
            // 
            // metadataPathLabel
            // 
            this.metadataPathLabel.AutoSize = true;
            this.metadataPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.metadataPathLabel.Location = new System.Drawing.Point(992, 65);
            this.metadataPathLabel.Name = "metadataPathLabel";
            this.metadataPathLabel.Size = new System.Drawing.Size(214, 20);
            this.metadataPathLabel.TabIndex = 25;
            this.metadataPathLabel.Text = "Путь к файлу метаданных:";
            // 
            // metadataPathTextBox
            // 
            this.metadataPathTextBox.Location = new System.Drawing.Point(996, 101);
            this.metadataPathTextBox.Name = "metadataPathTextBox";
            this.metadataPathTextBox.ReadOnly = true;
            this.metadataPathTextBox.Size = new System.Drawing.Size(405, 20);
            this.metadataPathTextBox.TabIndex = 24;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(986, 631);
            this.splitter1.TabIndex = 27;
            this.splitter1.TabStop = false;
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(9, 3);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(970, 625);
            this.gMapControl.TabIndex = 28;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.Load += new System.EventHandler(this.gMapControl_Load_1);
            // 
            // minSegmentingButton
            // 
            this.minSegmentingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minSegmentingButton.Location = new System.Drawing.Point(996, 160);
            this.minSegmentingButton.Margin = new System.Windows.Forms.Padding(1);
            this.minSegmentingButton.Name = "minSegmentingButton";
            this.minSegmentingButton.Size = new System.Drawing.Size(405, 58);
            this.minSegmentingButton.TabIndex = 29;
            this.minSegmentingButton.Text = "Преобразовать координаты в сегменты мин. размера";
            this.minSegmentingButton.UseVisualStyleBackColor = true;
            this.minSegmentingButton.Click += new System.EventHandler(this.minSegmentingButton_Click);
            // 
            // adaptiveSegmentingButton
            // 
            this.adaptiveSegmentingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adaptiveSegmentingButton.Location = new System.Drawing.Point(996, 296);
            this.adaptiveSegmentingButton.Margin = new System.Windows.Forms.Padding(1);
            this.adaptiveSegmentingButton.Name = "adaptiveSegmentingButton";
            this.adaptiveSegmentingButton.Size = new System.Drawing.Size(405, 58);
            this.adaptiveSegmentingButton.TabIndex = 30;
            this.adaptiveSegmentingButton.Text = "Адаптивное определение сегментов для фотографий";
            this.adaptiveSegmentingButton.UseVisualStyleBackColor = true;
            this.adaptiveSegmentingButton.Click += new System.EventHandler(this.adaptiveSegmentingButton_Click);
            // 
            // tMinlabel
            // 
            this.tMinlabel.AutoSize = true;
            this.tMinlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tMinlabel.Location = new System.Drawing.Point(992, 239);
            this.tMinlabel.Name = "tMinlabel";
            this.tMinlabel.Size = new System.Drawing.Size(43, 20);
            this.tMinlabel.TabIndex = 32;
            this.tMinlabel.Text = "Tmin";
            // 
            // tMinTextBox
            // 
            this.tMinTextBox.Location = new System.Drawing.Point(996, 262);
            this.tMinTextBox.Name = "tMinTextBox";
            this.tMinTextBox.Size = new System.Drawing.Size(176, 20);
            this.tMinTextBox.TabIndex = 31;
            this.tMinTextBox.TextChanged += new System.EventHandler(this.tMinTextBox_TextChanged);
            // 
            // tMaxLabel
            // 
            this.tMaxLabel.AutoSize = true;
            this.tMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tMaxLabel.Location = new System.Drawing.Point(1208, 239);
            this.tMaxLabel.Name = "tMaxLabel";
            this.tMaxLabel.Size = new System.Drawing.Size(47, 20);
            this.tMaxLabel.TabIndex = 34;
            this.tMaxLabel.Text = "Tmax";
            // 
            // tMaxTextBox
            // 
            this.tMaxTextBox.Location = new System.Drawing.Point(1212, 262);
            this.tMaxTextBox.Name = "tMaxTextBox";
            this.tMaxTextBox.Size = new System.Drawing.Size(189, 20);
            this.tMaxTextBox.TabIndex = 33;
            this.tMaxTextBox.TextChanged += new System.EventHandler(this.tMaxTextBox_TextChanged);
            // 
            // uploadDataButton
            // 
            this.uploadDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uploadDataButton.Location = new System.Drawing.Point(996, 376);
            this.uploadDataButton.Margin = new System.Windows.Forms.Padding(2);
            this.uploadDataButton.Name = "uploadDataButton";
            this.uploadDataButton.Size = new System.Drawing.Size(405, 39);
            this.uploadDataButton.TabIndex = 35;
            this.uploadDataButton.Text = "Выгрузить метаданные на удаленное хранилище";
            this.uploadDataButton.UseVisualStyleBackColor = true;
            // 
            // drawSegmentsButton
            // 
            this.drawSegmentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drawSegmentsButton.Location = new System.Drawing.Point(996, 510);
            this.drawSegmentsButton.Margin = new System.Windows.Forms.Padding(2);
            this.drawSegmentsButton.Name = "drawSegmentsButton";
            this.drawSegmentsButton.Size = new System.Drawing.Size(405, 118);
            this.drawSegmentsButton.TabIndex = 36;
            this.drawSegmentsButton.Text = "Отобразить сегменты";
            this.drawSegmentsButton.UseVisualStyleBackColor = true;
            this.drawSegmentsButton.Click += new System.EventHandler(this.drawSegmentsButton_Click);
            // 
            // MapSegmenting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.drawSegmentsButton);
            this.Controls.Add(this.uploadDataButton);
            this.Controls.Add(this.tMaxLabel);
            this.Controls.Add(this.tMaxTextBox);
            this.Controls.Add(this.tMinlabel);
            this.Controls.Add(this.tMinTextBox);
            this.Controls.Add(this.adaptiveSegmentingButton);
            this.Controls.Add(this.minSegmentingButton);
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.loadMetadataFileButton);
            this.Controls.Add(this.metadataPathLabel);
            this.Controls.Add(this.metadataPathTextBox);
            this.Name = "MapSegmenting";
            this.Size = new System.Drawing.Size(1419, 631);
            this.Load += new System.EventHandler(this.MapSegmenting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loadMetadataFileButton;
        private System.Windows.Forms.Label metadataPathLabel;
        private System.Windows.Forms.TextBox metadataPathTextBox;
        private System.Windows.Forms.Splitter splitter1;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Button minSegmentingButton;
        private System.Windows.Forms.Button adaptiveSegmentingButton;
        private System.Windows.Forms.Label tMinlabel;
        private System.Windows.Forms.TextBox tMinTextBox;
        private System.Windows.Forms.Label tMaxLabel;
        private System.Windows.Forms.TextBox tMaxTextBox;
        private System.Windows.Forms.Button uploadDataButton;
        private System.Windows.Forms.Button drawSegmentsButton;
    }
}
