using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDir
{
    public partial class TaskProgressForm : Form
    {

        public bool CancelWork = false;
        private FileProcessor _fileProcessor;

        public TaskProgressForm()
        {
            InitializeComponent();
            pb_Staticstic.Maximum = 100;
            pb_Staticstic.Maximum = 0;
            pb_Staticstic.Value = 0;
            _fileProcessor = FileProcessor.GetFileProcessor();
        }
        

        private void TaskProgressForm_Load(object sender, EventArgs e)
        {
           
        }


        private void btn_Abort_Click(object sender, EventArgs e)
        {
            _fileProcessor.AbortCopy();
        }

        private void TaskProgressForm_Shown(object sender, EventArgs e)
        {
            _fileProcessor.CopyFilesAsync();
        }
    }
}
