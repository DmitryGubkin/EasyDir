using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDir
{
    class DataEditorHelper 
    {
        
        private FileSearcher _fileSearcher = FileSearcher.GetInstance;
        private static DataEditorHelper dataEditorHelper;
        private DataGridView dataGridView;

        private DataEditorHelper() { }

        public static DataEditorHelper Getinstance ()
        {
            if(dataEditorHelper == null)
            {
                dataEditorHelper = new DataEditorHelper();
               
            }
            return dataEditorHelper;
        }

       public void SetDataViewer()
        {
            dataGridView = _fileSearcher.DataViewer;

        }

        public void SetCheck (bool check)
        {

            foreach (DataGridViewRow item in dataGridView.Rows)
            {
               // MessageBox.Show(item.Cells[0].Value.ToString());
                item.Cells[0].Value = check;
                MessageBox.Show(item.Cells[0].Value.ToString());
                
            }
 
        }

}
}
