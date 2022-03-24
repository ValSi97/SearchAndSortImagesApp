namespace SearchAndSortImagesApp_v_0
{
    partial class DatasetPreparing
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
            this.loadImageProgressBar = new System.Windows.Forms.ProgressBar();
            this.positionLabel = new System.Windows.Forms.Label();
            this.searchGoogleButton = new System.Windows.Forms.Button();
            this.loadImageFolderButton = new System.Windows.Forms.Button();
            this.pictureLoadScreen = new System.Windows.Forms.PictureBox();
            this.imagesPathLabel = new System.Windows.Forms.Label();
            this.metadataPathTextBox = new System.Windows.Forms.TextBox();
            this.imagesPathTextBox = new System.Windows.Forms.TextBox();
            this.metadataPathLabel = new System.Windows.Forms.Label();
            this.loadMetadataFileButton = new System.Windows.Forms.Button();
            this.uploadDataProgressBar = new System.Windows.Forms.ProgressBar();
            this.uploadDataButton = new System.Windows.Forms.Button();
            this.uploadDataTextBox = new System.Windows.Forms.TextBox();
            this.origPhotoSetCheckBox = new System.Windows.Forms.CheckBox();
            this.extPhotoSetCheckBox = new System.Windows.Forms.CheckBox();
            this.origMetadataCheckBox = new System.Windows.Forms.CheckBox();
            this.extMetadataCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoadScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // loadImageProgressBar
            // 
            this.loadImageProgressBar.Location = new System.Drawing.Point(456, 181);
            this.loadImageProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.loadImageProgressBar.Name = "loadImageProgressBar";
            this.loadImageProgressBar.Size = new System.Drawing.Size(405, 19);
            this.loadImageProgressBar.TabIndex = 18;
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(218, 293);
            this.positionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(35, 13);
            this.positionLabel.TabIndex = 17;
            this.positionLabel.Text = "label1";
            this.positionLabel.Click += new System.EventHandler(this.positionLabel_Click);
            // 
            // searchGoogleButton
            // 
            this.searchGoogleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchGoogleButton.Location = new System.Drawing.Point(456, 126);
            this.searchGoogleButton.Margin = new System.Windows.Forms.Padding(2);
            this.searchGoogleButton.Name = "searchGoogleButton";
            this.searchGoogleButton.Size = new System.Drawing.Size(405, 39);
            this.searchGoogleButton.TabIndex = 16;
            this.searchGoogleButton.Text = "Найти похожие фото";
            this.searchGoogleButton.UseVisualStyleBackColor = true;
            this.searchGoogleButton.Click += new System.EventHandler(this.searchGoogleButton_Click);
            // 
            // loadImageFolderButton
            // 
            this.loadImageFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadImageFolderButton.Location = new System.Drawing.Point(103, 323);
            this.loadImageFolderButton.Margin = new System.Windows.Forms.Padding(1);
            this.loadImageFolderButton.Name = "loadImageFolderButton";
            this.loadImageFolderButton.Size = new System.Drawing.Size(259, 39);
            this.loadImageFolderButton.TabIndex = 15;
            this.loadImageFolderButton.Text = "Загрузить папку с фото";
            this.loadImageFolderButton.UseVisualStyleBackColor = true;
            this.loadImageFolderButton.Click += new System.EventHandler(this.loadImageFolderButton_Click_1);
            // 
            // pictureLoadScreen
            // 
            this.pictureLoadScreen.BackColor = System.Drawing.SystemColors.Control;
            this.pictureLoadScreen.Location = new System.Drawing.Point(34, 8);
            this.pictureLoadScreen.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureLoadScreen.Name = "pictureLoadScreen";
            this.pictureLoadScreen.Size = new System.Drawing.Size(400, 283);
            this.pictureLoadScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLoadScreen.TabIndex = 12;
            this.pictureLoadScreen.TabStop = false;
            this.pictureLoadScreen.Click += new System.EventHandler(this.pictureLoadScreen_Click);
            // 
            // imagesPathLabel
            // 
            this.imagesPathLabel.AutoSize = true;
            this.imagesPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.imagesPathLabel.Location = new System.Drawing.Point(452, 4);
            this.imagesPathLabel.Name = "imagesPathLabel";
            this.imagesPathLabel.Size = new System.Drawing.Size(246, 20);
            this.imagesPathLabel.TabIndex = 21;
            this.imagesPathLabel.Text = "Путь к папке с фотографиями:";
            // 
            // metadataPathTextBox
            // 
            this.metadataPathTextBox.Location = new System.Drawing.Point(456, 87);
            this.metadataPathTextBox.Name = "metadataPathTextBox";
            this.metadataPathTextBox.ReadOnly = true;
            this.metadataPathTextBox.Size = new System.Drawing.Size(405, 20);
            this.metadataPathTextBox.TabIndex = 20;
            this.metadataPathTextBox.TextChanged += new System.EventHandler(this.metadataPathTextBox_TextChanged);
            // 
            // imagesPathTextBox
            // 
            this.imagesPathTextBox.Location = new System.Drawing.Point(456, 27);
            this.imagesPathTextBox.Name = "imagesPathTextBox";
            this.imagesPathTextBox.ReadOnly = true;
            this.imagesPathTextBox.Size = new System.Drawing.Size(405, 20);
            this.imagesPathTextBox.TabIndex = 19;
            // 
            // metadataPathLabel
            // 
            this.metadataPathLabel.AutoSize = true;
            this.metadataPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.metadataPathLabel.Location = new System.Drawing.Point(452, 64);
            this.metadataPathLabel.Name = "metadataPathLabel";
            this.metadataPathLabel.Size = new System.Drawing.Size(214, 20);
            this.metadataPathLabel.TabIndex = 22;
            this.metadataPathLabel.Text = "Путь к файлу метаданных:";
            this.metadataPathLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // loadMetadataFileButton
            // 
            this.loadMetadataFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadMetadataFileButton.Location = new System.Drawing.Point(103, 381);
            this.loadMetadataFileButton.Margin = new System.Windows.Forms.Padding(1);
            this.loadMetadataFileButton.Name = "loadMetadataFileButton";
            this.loadMetadataFileButton.Size = new System.Drawing.Size(259, 39);
            this.loadMetadataFileButton.TabIndex = 23;
            this.loadMetadataFileButton.Text = "Загрузить файл метаданных";
            this.loadMetadataFileButton.UseVisualStyleBackColor = true;
            this.loadMetadataFileButton.Click += new System.EventHandler(this.loadMetadataFileButton_Click);
            // 
            // uploadDataProgressBar
            // 
            this.uploadDataProgressBar.Location = new System.Drawing.Point(456, 313);
            this.uploadDataProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.uploadDataProgressBar.Name = "uploadDataProgressBar";
            this.uploadDataProgressBar.Size = new System.Drawing.Size(405, 19);
            this.uploadDataProgressBar.TabIndex = 25;
            this.uploadDataProgressBar.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // uploadDataButton
            // 
            this.uploadDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uploadDataButton.Location = new System.Drawing.Point(456, 252);
            this.uploadDataButton.Margin = new System.Windows.Forms.Padding(2);
            this.uploadDataButton.Name = "uploadDataButton";
            this.uploadDataButton.Size = new System.Drawing.Size(405, 39);
            this.uploadDataButton.TabIndex = 24;
            this.uploadDataButton.Text = "Выгрузить данные на удаленное хранилище";
            this.uploadDataButton.UseVisualStyleBackColor = true;
            this.uploadDataButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // uploadDataTextBox
            // 
            this.uploadDataTextBox.Location = new System.Drawing.Point(456, 355);
            this.uploadDataTextBox.Name = "uploadDataTextBox";
            this.uploadDataTextBox.ReadOnly = true;
            this.uploadDataTextBox.Size = new System.Drawing.Size(405, 20);
            this.uploadDataTextBox.TabIndex = 26;
            // 
            // origPhotoSetCheckBox
            // 
            this.origPhotoSetCheckBox.AutoSize = true;
            this.origPhotoSetCheckBox.Location = new System.Drawing.Point(456, 205);
            this.origPhotoSetCheckBox.Name = "origPhotoSetCheckBox";
            this.origPhotoSetCheckBox.Size = new System.Drawing.Size(175, 17);
            this.origPhotoSetCheckBox.TabIndex = 27;
            this.origPhotoSetCheckBox.Text = "Исходный набор фотографий";
            this.origPhotoSetCheckBox.UseVisualStyleBackColor = true;
            // 
            // extPhotoSetCheckBox
            // 
            this.extPhotoSetCheckBox.AutoSize = true;
            this.extPhotoSetCheckBox.Location = new System.Drawing.Point(456, 228);
            this.extPhotoSetCheckBox.Name = "extPhotoSetCheckBox";
            this.extPhotoSetCheckBox.Size = new System.Drawing.Size(195, 17);
            this.extPhotoSetCheckBox.TabIndex = 28;
            this.extPhotoSetCheckBox.Text = "Расширенный набор фотографий";
            this.extPhotoSetCheckBox.UseVisualStyleBackColor = true;
            // 
            // origMetadataCheckBox
            // 
            this.origMetadataCheckBox.AutoSize = true;
            this.origMetadataCheckBox.Location = new System.Drawing.Point(670, 205);
            this.origMetadataCheckBox.Name = "origMetadataCheckBox";
            this.origMetadataCheckBox.Size = new System.Drawing.Size(171, 17);
            this.origMetadataCheckBox.TabIndex = 29;
            this.origMetadataCheckBox.Text = "Исходный файл метаданных";
            this.origMetadataCheckBox.UseVisualStyleBackColor = true;
            // 
            // extMetadataCheckBox
            // 
            this.extMetadataCheckBox.AutoSize = true;
            this.extMetadataCheckBox.Location = new System.Drawing.Point(670, 228);
            this.extMetadataCheckBox.Name = "extMetadataCheckBox";
            this.extMetadataCheckBox.Size = new System.Drawing.Size(191, 17);
            this.extMetadataCheckBox.TabIndex = 30;
            this.extMetadataCheckBox.Text = "Расширенный файл метаданных";
            this.extMetadataCheckBox.UseVisualStyleBackColor = true;
            // 
            // DatasetPreparing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.extMetadataCheckBox);
            this.Controls.Add(this.origMetadataCheckBox);
            this.Controls.Add(this.extPhotoSetCheckBox);
            this.Controls.Add(this.origPhotoSetCheckBox);
            this.Controls.Add(this.uploadDataTextBox);
            this.Controls.Add(this.uploadDataProgressBar);
            this.Controls.Add(this.uploadDataButton);
            this.Controls.Add(this.loadMetadataFileButton);
            this.Controls.Add(this.metadataPathLabel);
            this.Controls.Add(this.imagesPathLabel);
            this.Controls.Add(this.metadataPathTextBox);
            this.Controls.Add(this.imagesPathTextBox);
            this.Controls.Add(this.loadImageProgressBar);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.searchGoogleButton);
            this.Controls.Add(this.loadImageFolderButton);
            this.Controls.Add(this.pictureLoadScreen);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DatasetPreparing";
            this.Size = new System.Drawing.Size(1184, 474);
            this.Load += new System.EventHandler(this.DatasetPreparing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoadScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar loadImageProgressBar;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Button searchGoogleButton;
        private System.Windows.Forms.Button loadImageFolderButton;
        private System.Windows.Forms.PictureBox pictureLoadScreen;
        private System.Windows.Forms.Label imagesPathLabel;
        private System.Windows.Forms.TextBox metadataPathTextBox;
        private System.Windows.Forms.TextBox imagesPathTextBox;
        private System.Windows.Forms.Label metadataPathLabel;
        private System.Windows.Forms.Button loadMetadataFileButton;
        private System.Windows.Forms.ProgressBar uploadDataProgressBar;
        private System.Windows.Forms.Button uploadDataButton;
        private System.Windows.Forms.TextBox uploadDataTextBox;
        private System.Windows.Forms.CheckBox origPhotoSetCheckBox;
        private System.Windows.Forms.CheckBox extPhotoSetCheckBox;
        private System.Windows.Forms.CheckBox origMetadataCheckBox;
        private System.Windows.Forms.CheckBox extMetadataCheckBox;
    }
}
