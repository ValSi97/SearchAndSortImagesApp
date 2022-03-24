namespace SearchAndSortImagesApp_v_0
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PreparingDatasetButton = new System.Windows.Forms.Button();
            this.segmentingModuleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PreparingDatasetButton
            // 
            this.PreparingDatasetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreparingDatasetButton.Location = new System.Drawing.Point(67, 106);
            this.PreparingDatasetButton.Name = "PreparingDatasetButton";
            this.PreparingDatasetButton.Size = new System.Drawing.Size(546, 82);
            this.PreparingDatasetButton.TabIndex = 0;
            this.PreparingDatasetButton.Text = "Модуль подготовки больших массивов изображений";
            this.PreparingDatasetButton.UseVisualStyleBackColor = true;
            this.PreparingDatasetButton.Click += new System.EventHandler(this.PreparingDatasetButton_Click);
            // 
            // segmentingModuleButton
            // 
            this.segmentingModuleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.segmentingModuleButton.Location = new System.Drawing.Point(67, 231);
            this.segmentingModuleButton.Name = "segmentingModuleButton";
            this.segmentingModuleButton.Size = new System.Drawing.Size(546, 77);
            this.segmentingModuleButton.TabIndex = 1;
            this.segmentingModuleButton.Text = "Модуль сегментирования земной поверхности";
            this.segmentingModuleButton.UseVisualStyleBackColor = true;
            this.segmentingModuleButton.Click += new System.EventHandler(this.segmentingModuleButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 423);
            this.Controls.Add(this.segmentingModuleButton);
            this.Controls.Add(this.PreparingDatasetButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Главное окно";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PreparingDatasetButton;
        private System.Windows.Forms.Button segmentingModuleButton;
    }
}