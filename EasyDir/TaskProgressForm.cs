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
        AssetNameHelper a;

        public TaskProgressForm()
        {
            InitializeComponent();
            a = AssetNameHelper.instance;
        }
        

        private void TaskProgressForm_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(a.CheckedListBoxControl.Items.Count.ToString());
        }
    }
}
