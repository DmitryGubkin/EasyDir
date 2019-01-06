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
            //btn_Abort.Click += new EventHandler(_fileProcessor.OnCancelClicked);
            MessageBox.Show("Copy starting");
        }

        private void TaskProgressForm_Activated(object sender, EventArgs e)
        {
            
        }


    }
}
