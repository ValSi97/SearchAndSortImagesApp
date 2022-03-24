namespace SearchAndSortImagesApp_v_0
{
    partial class SegmentingForm
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
            this.mapSegmenting1 = new SearchAndSortImagesApp_v_0.MapSegmenting();
            this.SuspendLayout();
            // 
            // mapSegmenting1
            // 
            this.mapSegmenting1.Location = new System.Drawing.Point(8, 9);
            this.mapSegmenting1.Name = "mapSegmenting1";
            this.mapSegmenting1.Size = new System.Drawing.Size(1419, 631);
            this.mapSegmenting1.TabIndex = 0;
            this.mapSegmenting1.Load += new System.EventHandler(this.mapSegmenting1_Load);
            // 
            // SegmentingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 652);
            this.Controls.Add(this.mapSegmenting1);
            this.Name = "SegmentingForm";
            this.Text = "SegmentingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MapSegmenting mapSegmenting1;
    }
}