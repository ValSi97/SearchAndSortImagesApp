using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchAndSortImagesApp_v_0
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void PreparingDatasetButton_Click(object sender, EventArgs e)
        {
            SegmentingForm segmentingForm = new SegmentingForm();
            segmentingForm.ShowDialog();
        }

        private void segmentingModuleButton_Click(object sender, EventArgs e)
        {
            DatasetPrepareForm datasetPrepareForm = new DatasetPrepareForm();
            datasetPrepareForm.ShowDialog();
        }
    }
}
