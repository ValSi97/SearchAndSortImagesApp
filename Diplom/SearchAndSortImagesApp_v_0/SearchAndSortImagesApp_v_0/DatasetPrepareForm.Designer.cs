namespace SearchAndSortImagesApp_v_0
{
    partial class DatasetPrepareForm
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
            this.datasetPreparing1 = new SearchAndSortImagesApp_v_0.DatasetPreparing();
            this.SuspendLayout();
            // 
            // datasetPreparing1
            // 
            this.datasetPreparing1.Location = new System.Drawing.Point(0, 11);
            this.datasetPreparing1.Margin = new System.Windows.Forms.Padding(2);
            this.datasetPreparing1.Name = "datasetPreparing1";
            this.datasetPreparing1.Size = new System.Drawing.Size(1414, 629);
            this.datasetPreparing1.TabIndex = 0;
            this.datasetPreparing1.Load += new System.EventHandler(this.datasetPreparing1_Load);
            // 
            // DatasetPrepareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 641);
            this.Controls.Add(this.datasetPreparing1);
            this.Name = "DatasetPrepareForm";
            this.Text = "DatasetPrepareForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DatasetPreparing datasetPreparing1;
    }
}