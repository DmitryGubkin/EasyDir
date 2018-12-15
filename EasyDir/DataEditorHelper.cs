using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;


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
            foreach (var item in _fileSearcher.Assets)
            {
                item.Checked = check;
            }
             dataGridView.Refresh();
            _fileSearcher.UpdateCheckInfo();
        }

        public void InvCheck()
        {
            foreach (var item in _fileSearcher.Assets)
            {
                item.Checked = !(item.Checked);
            }
            dataGridView.Refresh();
            _fileSearcher.UpdateCheckInfo();
        }

        public void DeadClean()
        {
            int DeadCount = 0;
            foreach (var item in _fileSearcher.Assets)
            {
                if(!(System.IO.File.Exists( item.FullPath)))
                {
                    _fileSearcher.Assets.Remove(item);
                    DeadCount++;
                }
            }

            dataGridView.Refresh();
            _fileSearcher.UpdateCheckInfo();

            if (DeadCount > 0)
                MessageBox.Show(("Dead Assets Removed: " + DeadCount.ToString()),
                    "Dead Assets Cleaner",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ClearData()
        {
            _fileSearcher.Assets.Clear();
            dataGridView.Refresh();
            _fileSearcher.UpdateCheckInfo();
        }

        public void MultyCheck(int Row)
        {
           if(dataGridView.SelectedCells.Count>0)
            {
                List<int> RowsIndex = new List<int>();
               for (int i =0; i<dataGridView.SelectedCells.Count;i++)
                {
                    if ((RowsIndex.Contains(dataGridView.SelectedCells[i].RowIndex)) == false)
                    {
                        RowsIndex.Add(dataGridView.SelectedCells[i].RowIndex);
                    }
                }

             
                if (RowsIndex.Count < 2)
                    return;

                bool val = (bool)dataGridView.Rows[Row].Cells[0].Value;
               foreach (var rowIndex in RowsIndex)
                {
                    dataGridView.Rows[rowIndex].Cells[0].Value = !val;
                }
            }

        }
}
}
