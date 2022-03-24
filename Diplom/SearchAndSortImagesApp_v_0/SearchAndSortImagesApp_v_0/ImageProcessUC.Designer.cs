namespace SearchAndSortImagesApp_v_0
{
    partial class ImageProcessUC
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
            this.createDirectoryProgressBar = new System.Windows.Forms.ProgressBar();
            this.createDirectoryButton = new System.Windows.Forms.Button();
            this.denoiseImageCheckBox = new System.Windows.Forms.CheckBox();
            this.changeColorBalanceCheckBox = new System.Windows.Forms.CheckBox();
            this.changeContrastAndBrightnessCheckBox = new System.Windows.Forms.CheckBox();
            this.preparationImageButton = new System.Windows.Forms.Button();
            this.unknownArchitectureFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.longDistanceFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.peopleFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.flagsFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.unknownTextFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.unknownFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.monumentsFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.buildingsFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.textFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.loadImageFolderButton = new System.Windows.Forms.Button();
            this.nextImageButton = new System.Windows.Forms.Button();
            this.prevImageButton = new System.Windows.Forms.Button();
            this.positionLabel = new System.Windows.Forms.Label();
            this.pictureLoadScreen = new System.Windows.Forms.PictureBox();
            this.saveImageToFolderButton = new System.Windows.Forms.Button();
            this.findCoordinatesFormFileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoadScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // createDirectoryProgressBar
            // 
            this.createDirectoryProgressBar.Location = new System.Drawing.Point(1534, 329);
            this.createDirectoryProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.createDirectoryProgressBar.Name = "createDirectoryProgressBar";
            this.createDirectoryProgressBar.Size = new System.Drawing.Size(405, 30);
            this.createDirectoryProgressBar.TabIndex = 54;
            this.createDirectoryProgressBar.Click += new System.EventHandler(this.createDirectoryProgressBar_Click_1);
            // 
            // createDirectoryButton
            // 
            this.createDirectoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createDirectoryButton.Location = new System.Drawing.Point(1534, 252);
            this.createDirectoryButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.createDirectoryButton.Name = "createDirectoryButton";
            this.createDirectoryButton.Size = new System.Drawing.Size(405, 60);
            this.createDirectoryButton.TabIndex = 53;
            this.createDirectoryButton.Text = "Распределить фото";
            this.createDirectoryButton.UseVisualStyleBackColor = true;
            this.createDirectoryButton.Click += new System.EventHandler(this.createDirectoryButton_Click_1);
            // 
            // denoiseImageCheckBox
            // 
            this.denoiseImageCheckBox.AutoSize = true;
            this.denoiseImageCheckBox.Location = new System.Drawing.Point(1085, 341);
            this.denoiseImageCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.denoiseImageCheckBox.Name = "denoiseImageCheckBox";
            this.denoiseImageCheckBox.Size = new System.Drawing.Size(148, 24);
            this.denoiseImageCheckBox.TabIndex = 51;
            this.denoiseImageCheckBox.Text = "Удаление шума";
            this.denoiseImageCheckBox.UseVisualStyleBackColor = true;
            this.denoiseImageCheckBox.CheckedChanged += new System.EventHandler(this.denoiseImageCheckBox_CheckedChanged_1);
            // 
            // changeColorBalanceCheckBox
            // 
            this.changeColorBalanceCheckBox.AutoSize = true;
            this.changeColorBalanceCheckBox.Location = new System.Drawing.Point(1085, 302);
            this.changeColorBalanceCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.changeColorBalanceCheckBox.Name = "changeColorBalanceCheckBox";
            this.changeColorBalanceCheckBox.Size = new System.Drawing.Size(158, 24);
            this.changeColorBalanceCheckBox.TabIndex = 50;
            this.changeColorBalanceCheckBox.Text = "Коррекция цвета";
            this.changeColorBalanceCheckBox.UseVisualStyleBackColor = true;
            this.changeColorBalanceCheckBox.CheckedChanged += new System.EventHandler(this.changeColorBalanceCheckBox_CheckedChanged_1);
            // 
            // changeContrastAndBrightnessCheckBox
            // 
            this.changeContrastAndBrightnessCheckBox.AutoSize = true;
            this.changeContrastAndBrightnessCheckBox.Location = new System.Drawing.Point(1085, 264);
            this.changeContrastAndBrightnessCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.changeContrastAndBrightnessCheckBox.Name = "changeContrastAndBrightnessCheckBox";
            this.changeContrastAndBrightnessCheckBox.Size = new System.Drawing.Size(257, 24);
            this.changeContrastAndBrightnessCheckBox.TabIndex = 49;
            this.changeContrastAndBrightnessCheckBox.Text = "Коррекция контраста/яркости";
            this.changeContrastAndBrightnessCheckBox.UseVisualStyleBackColor = true;
            this.changeContrastAndBrightnessCheckBox.CheckedChanged += new System.EventHandler(this.changeContrastAndBrightnessCheckBox_CheckedChanged_1);
            // 
            // preparationImageButton
            // 
            this.preparationImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.preparationImageButton.Location = new System.Drawing.Point(1085, 179);
            this.preparationImageButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.preparationImageButton.Name = "preparationImageButton";
            this.preparationImageButton.Size = new System.Drawing.Size(393, 60);
            this.preparationImageButton.TabIndex = 48;
            this.preparationImageButton.Text = "Предобработать изображение";
            this.preparationImageButton.UseVisualStyleBackColor = true;
            this.preparationImageButton.Click += new System.EventHandler(this.preparationImageButton_Click_1);
            // 
            // unknownArchitectureFolderCheckBox
            // 
            this.unknownArchitectureFolderCheckBox.AutoSize = true;
            this.unknownArchitectureFolderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unknownArchitectureFolderCheckBox.Location = new System.Drawing.Point(1534, 3);
            this.unknownArchitectureFolderCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.unknownArchitectureFolderCheckBox.Name = "unknownArchitectureFolderCheckBox";
            this.unknownArchitectureFolderCheckBox.Size = new System.Drawing.Size(258, 24);
            this.unknownArchitectureFolderCheckBox.TabIndex = 46;
            this.unknownArchitectureFolderCheckBox.Text = "Неопределенная архитектура";
            this.unknownArchitectureFolderCheckBox.UseVisualStyleBackColor = true;
            this.unknownArchitectureFolderCheckBox.CheckedChanged += new System.EventHandler(this.unknownArchitectureFolderCheckBox_CheckedChanged_1);
            // 
            // longDistanceFolderCheckBox
            // 
            this.longDistanceFolderCheckBox.AutoSize = true;
            this.longDistanceFolderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.longDistanceFolderCheckBox.Location = new System.Drawing.Point(1085, 123);
            this.longDistanceFolderCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.longDistanceFolderCheckBox.Name = "longDistanceFolderCheckBox";
            this.longDistanceFolderCheckBox.Size = new System.Drawing.Size(253, 24);
            this.longDistanceFolderCheckBox.TabIndex = 45;
            this.longDistanceFolderCheckBox.Text = "Фото с большого расстояния";
            this.longDistanceFolderCheckBox.UseVisualStyleBackColor = true;
            this.longDistanceFolderCheckBox.CheckedChanged += new System.EventHandler(this.longDistanceFolderCheckBox_CheckedChanged_1);
            // 
            // peopleFolderCheckBox
            // 
            this.peopleFolderCheckBox.AutoSize = true;
            this.peopleFolderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.peopleFolderCheckBox.Location = new System.Drawing.Point(1085, 63);
            this.peopleFolderCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.peopleFolderCheckBox.Name = "peopleFolderCheckBox";
            this.peopleFolderCheckBox.Size = new System.Drawing.Size(72, 24);
            this.peopleFolderCheckBox.TabIndex = 44;
            this.peopleFolderCheckBox.Text = "Люди";
            this.peopleFolderCheckBox.UseVisualStyleBackColor = true;
            this.peopleFolderCheckBox.CheckedChanged += new System.EventHandler(this.peopleFolderCheckBox_CheckedChanged_1);
            // 
            // flagsFolderCheckBox
            // 
            this.flagsFolderCheckBox.AutoSize = true;
            this.flagsFolderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flagsFolderCheckBox.Location = new System.Drawing.Point(1085, 0);
            this.flagsFolderCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flagsFolderCheckBox.Name = "flagsFolderCheckBox";
            this.flagsFolderCheckBox.Size = new System.Drawing.Size(78, 24);
            this.flagsFolderCheckBox.TabIndex = 43;
            this.flagsFolderCheckBox.Text = "Флаги";
            this.flagsFolderCheckBox.UseVisualStyleBackColor = true;
            this.flagsFolderCheckBox.CheckedChanged += new System.EventHandler(this.flagsFolderCheckBox_CheckedChanged_1);
            // 
            // unknownTextFolderCheckBox
            // 
            this.unknownTextFolderCheckBox.AutoSize = true;
            this.unknownTextFolderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unknownTextFolderCheckBox.Location = new System.Drawing.Point(1534, 63);
            this.unknownTextFolderCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.unknownTextFolderCheckBox.Name = "unknownTextFolderCheckBox";
            this.unknownTextFolderCheckBox.Size = new System.Drawing.Size(230, 24);
            this.unknownTextFolderCheckBox.TabIndex = 42;
            this.unknownTextFolderCheckBox.Text = "Неопределенные надписи";
            this.unknownTextFolderCheckBox.UseVisualStyleBackColor = true;
            this.unknownTextFolderCheckBox.CheckedChanged += new System.EventHandler(this.unknownTextFolderCheckBox_CheckedChanged_1);
            // 
            // unknownFolderCheckBox
            // 
            this.unknownFolderCheckBox.AutoSize = true;
            this.unknownFolderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unknownFolderCheckBox.Location = new System.Drawing.Point(1534, 123);
            this.unknownFolderCheckBox.Name = "unknownFolderCheckBox";
            this.unknownFolderCheckBox.Size = new System.Drawing.Size(232, 24);
            this.unknownFolderCheckBox.TabIndex = 41;
            this.unknownFolderCheckBox.Text = "Неопределенные объекты";
            this.unknownFolderCheckBox.UseVisualStyleBackColor = true;
            this.unknownFolderCheckBox.CheckedChanged += new System.EventHandler(this.unknownFolderCheckBox_CheckedChanged_1);
            // 
            // monumentsFolderCheckBox
            // 
            this.monumentsFolderCheckBox.AutoSize = true;
            this.monumentsFolderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monumentsFolderCheckBox.Location = new System.Drawing.Point(693, 123);
            this.monumentsFolderCheckBox.Name = "monumentsFolderCheckBox";
            this.monumentsFolderCheckBox.Size = new System.Drawing.Size(197, 24);
            this.monumentsFolderCheckBox.TabIndex = 40;
            this.monumentsFolderCheckBox.Text = "Известные памятники";
            this.monumentsFolderCheckBox.UseVisualStyleBackColor = true;
            // 
            // buildingsFolderCheckBox
            // 
            this.buildingsFolderCheckBox.AutoSize = true;
            this.buildingsFolderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buildingsFolderCheckBox.Location = new System.Drawing.Point(693, 63);
            this.buildingsFolderCheckBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buildingsFolderCheckBox.Name = "buildingsFolderCheckBox";
            this.buildingsFolderCheckBox.Size = new System.Drawing.Size(86, 24);
            this.buildingsFolderCheckBox.TabIndex = 39;
            this.buildingsFolderCheckBox.Text = "Здания";
            this.buildingsFolderCheckBox.UseVisualStyleBackColor = true;
            // 
            // textFolderCheckBox
            // 
            this.textFolderCheckBox.AutoSize = true;
            this.textFolderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textFolderCheckBox.Location = new System.Drawing.Point(693, 3);
            this.textFolderCheckBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textFolderCheckBox.Name = "textFolderCheckBox";
            this.textFolderCheckBox.Size = new System.Drawing.Size(71, 24);
            this.textFolderCheckBox.TabIndex = 38;
            this.textFolderCheckBox.Text = "Текст";
            this.textFolderCheckBox.UseVisualStyleBackColor = true;
            this.textFolderCheckBox.CheckedChanged += new System.EventHandler(this.textFolderCheckBox_CheckedChanged);
            // 
            // loadImageFolderButton
            // 
            this.loadImageFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadImageFolderButton.Location = new System.Drawing.Point(183, 548);
            this.loadImageFolderButton.Name = "loadImageFolderButton";
            this.loadImageFolderButton.Size = new System.Drawing.Size(404, 60);
            this.loadImageFolderButton.TabIndex = 58;
            this.loadImageFolderButton.Text = "Загрузить папку с фото";
            this.loadImageFolderButton.UseVisualStyleBackColor = true;
            this.loadImageFolderButton.Click += new System.EventHandler(this.loadImageFolderButton_Click_1);
            // 
            // nextImageButton
            // 
            this.nextImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextImageButton.Location = new System.Drawing.Point(476, 470);
            this.nextImageButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.nextImageButton.Name = "nextImageButton";
            this.nextImageButton.Size = new System.Drawing.Size(279, 60);
            this.nextImageButton.TabIndex = 57;
            this.nextImageButton.Text = "Следующее фото";
            this.nextImageButton.UseVisualStyleBackColor = true;
            this.nextImageButton.Click += new System.EventHandler(this.nextImageButton_Click);
            // 
            // prevImageButton
            // 
            this.prevImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prevImageButton.Location = new System.Drawing.Point(17, 470);
            this.prevImageButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.prevImageButton.Name = "prevImageButton";
            this.prevImageButton.Size = new System.Drawing.Size(270, 60);
            this.prevImageButton.TabIndex = 56;
            this.prevImageButton.Text = "Предыдущее фото";
            this.prevImageButton.UseVisualStyleBackColor = true;
            this.prevImageButton.Click += new System.EventHandler(this.prevImageButton_Click);
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(333, 460);
            this.positionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(51, 20);
            this.positionLabel.TabIndex = 60;
            this.positionLabel.Text = "label1";
            this.positionLabel.Click += new System.EventHandler(this.positionLabel_Click_1);
            // 
            // pictureLoadScreen
            // 
            this.pictureLoadScreen.BackColor = System.Drawing.SystemColors.Control;
            this.pictureLoadScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureLoadScreen.Location = new System.Drawing.Point(68, 22);
            this.pictureLoadScreen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureLoadScreen.Name = "pictureLoadScreen";
            this.pictureLoadScreen.Size = new System.Drawing.Size(600, 438);
            this.pictureLoadScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLoadScreen.TabIndex = 59;
            this.pictureLoadScreen.TabStop = false;
            this.pictureLoadScreen.Click += new System.EventHandler(this.pictureLoadScreen_Click_2);
            // 
            // saveImageToFolderButton
            // 
            this.saveImageToFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveImageToFolderButton.Location = new System.Drawing.Point(690, 179);
            this.saveImageToFolderButton.Name = "saveImageToFolderButton";
            this.saveImageToFolderButton.Size = new System.Drawing.Size(200, 60);
            this.saveImageToFolderButton.TabIndex = 47;
            this.saveImageToFolderButton.Text = "Сохранить тэг";
            this.saveImageToFolderButton.UseVisualStyleBackColor = true;
            this.saveImageToFolderButton.Click += new System.EventHandler(this.saveImageToFolderButton_Click_1);
            // 
            // findCoordinatesFormFileButton
            // 
            this.findCoordinatesFormFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findCoordinatesFormFileButton.Location = new System.Drawing.Point(1534, 179);
            this.findCoordinatesFormFileButton.Name = "findCoordinatesFormFileButton";
            this.findCoordinatesFormFileButton.Size = new System.Drawing.Size(405, 60);
            this.findCoordinatesFormFileButton.TabIndex = 61;
            this.findCoordinatesFormFileButton.Text = "Найти страны по координатам";
            this.findCoordinatesFormFileButton.UseVisualStyleBackColor = true;
            this.findCoordinatesFormFileButton.Click += new System.EventHandler(this.findCoordinatesFormFileButton_Click);
            // 
            // ImageProcessUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.findCoordinatesFormFileButton);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.pictureLoadScreen);
            this.Controls.Add(this.loadImageFolderButton);
            this.Controls.Add(this.nextImageButton);
            this.Controls.Add(this.prevImageButton);
            this.Controls.Add(this.createDirectoryProgressBar);
            this.Controls.Add(this.createDirectoryButton);
            this.Controls.Add(this.denoiseImageCheckBox);
            this.Controls.Add(this.changeColorBalanceCheckBox);
            this.Controls.Add(this.changeContrastAndBrightnessCheckBox);
            this.Controls.Add(this.preparationImageButton);
            this.Controls.Add(this.saveImageToFolderButton);
            this.Controls.Add(this.unknownArchitectureFolderCheckBox);
            this.Controls.Add(this.longDistanceFolderCheckBox);
            this.Controls.Add(this.peopleFolderCheckBox);
            this.Controls.Add(this.flagsFolderCheckBox);
            this.Controls.Add(this.unknownTextFolderCheckBox);
            this.Controls.Add(this.unknownFolderCheckBox);
            this.Controls.Add(this.monumentsFolderCheckBox);
            this.Controls.Add(this.buildingsFolderCheckBox);
            this.Controls.Add(this.textFolderCheckBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ImageProcessUC";
            this.Size = new System.Drawing.Size(1982, 800);
            this.Load += new System.EventHandler(this.ImageProcessUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoadScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ProgressBar createDirectoryProgressBar;
        private System.Windows.Forms.Button createDirectoryButton;
        private System.Windows.Forms.CheckBox denoiseImageCheckBox;
        private System.Windows.Forms.CheckBox changeColorBalanceCheckBox;
        private System.Windows.Forms.CheckBox changeContrastAndBrightnessCheckBox;
        private System.Windows.Forms.Button preparationImageButton;
        private System.Windows.Forms.CheckBox unknownArchitectureFolderCheckBox;
        private System.Windows.Forms.CheckBox longDistanceFolderCheckBox;
        private System.Windows.Forms.CheckBox peopleFolderCheckBox;
        private System.Windows.Forms.CheckBox flagsFolderCheckBox;
        private System.Windows.Forms.CheckBox unknownTextFolderCheckBox;
        private System.Windows.Forms.CheckBox unknownFolderCheckBox;
        private System.Windows.Forms.CheckBox monumentsFolderCheckBox;
        private System.Windows.Forms.CheckBox buildingsFolderCheckBox;
        private System.Windows.Forms.CheckBox textFolderCheckBox;
        private System.Windows.Forms.Button loadImageFolderButton;
        private System.Windows.Forms.Button nextImageButton;
        private System.Windows.Forms.Button prevImageButton;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.PictureBox pictureLoadScreen;
        private System.Windows.Forms.Button saveImageToFolderButton;
        private System.Windows.Forms.Button findCoordinatesFormFileButton;
    }
}
