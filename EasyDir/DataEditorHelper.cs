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
        private PathHelper _pathHelper = PathHelper.GetInstance;
        private SearchForm _searchForm = SearchForm.GetFormInstance;
        public readonly char[] _SearchSeparators = { ';', '*', '%'};
        private bool[] _searchMod = {false, false}; // 0 - register(*), 1- absolute match(%)

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
            List<Asset> _assets = new List<Asset>();

            for (int i=0; i<_fileSearcher.Assets.Count; i++)
            {
                if(!(System.IO.File.Exists( _fileSearcher.Assets[i].FullPath)))
                {
                    _assets.Add(_fileSearcher.Assets[i]);
                }
            }

            foreach(var asset in _assets)
            {
                _fileSearcher.Assets.Remove(asset);
                DeadCount++;
            }

            dataGridView.Refresh();
            _fileSearcher.UpdateCheckInfo();

            if (DeadCount > 0)
                MessageBox.Show(("Dead Assets Removed: " + DeadCount.ToString()),
                    "Dead Assets Cleaner",MessageBoxButtons.OK, MessageBoxIcon.Information);
            GC.Collect();
        }

        public void ClearData()
        {
            _fileSearcher.Assets.Clear();
            dataGridView.Refresh();
            _fileSearcher.UpdateCheckInfo();
        }

        public void RemoveSelData()
        {
            SelectRow();

            if (dataGridView.SelectedRows.Count > 0)
            {
                if (dataGridView.SelectedRows.Count > 4)
                {
                    if (MessageBox.Show("Delete " + dataGridView.SelectedRows.Count.ToString() + " Assets ?", "Assets Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        GC.Collect();
                        return;
                    }
                }

                if (dataGridView.SelectedRows.Count == dataGridView.Rows.Count)
                {
                    ClearData();
                    return;
                }
                
                dataGridView.SuspendDrawing();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    dataGridView.Rows.RemoveAt(row.Index);
                }
                dataGridView.ResumeDrawing();
                _fileSearcher.UpdateCheckInfo();
            }
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

        public void ShowFileinExplorer (string _path)
        {
            if (dataGridView.SelectedCells.Count < 1 && string.IsNullOrEmpty(_path))
                return;
            if(System.IO.File.Exists(_path))
            {
                _pathHelper.ShowFolder(_path);
            }
        }

        public List<string> GetSelectedFiles()
        {
            HashSet<string> _paths = new HashSet<string>();

            if (dataGridView.SelectedCells.Count < 1)
                return (_paths.ToList());
            for(var i=0; i<dataGridView.SelectedCells.Count;i++)
            {
                _paths.Add((string)dataGridView.Rows[dataGridView.SelectedCells[i].RowIndex].Cells[1].Value);
            }
            return (_paths.ToList());

        }

        public void SelAll()
        {
            if(_fileSearcher.Assets.Count>0)
            dataGridView.SelectAll();
        }

        public void ClearSel()
        {
            if (_fileSearcher.Assets.Count > 0)
                dataGridView.ClearSelection();
        }

        public void SelectRow()
        {
            if (dataGridView.Rows.Count < 1 || dataGridView.SelectedCells.Count <0)
                return;
          
            foreach(DataGridViewCell item in dataGridView.SelectedCells)
            {
               
              dataGridView.Rows[item.RowIndex].Selected = true;
                
            }
            
        }

        public void InvertSel()
        {
            SelectRow();
            HashSet<int> _rows = new HashSet<int>();
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                if (item.Selected == false)
                {
                    _rows.Add(item.Index);
                }
            }
            ClearSel();
            foreach (int index in _rows)
            {
                dataGridView.Rows[index].Selected = true;
            }
        }

        public void RemoveByCheck(bool _check)
        {
            List<Asset> _assets = new List<Asset>();

            for (int i =0; i< _fileSearcher.Assets.Count; i++)
            {
                if(_fileSearcher.Assets[i].Checked == _check)
                {
                    _assets.Add(_fileSearcher.Assets[i]);
                }
            }

            foreach(var asset in _assets)
            {
                _fileSearcher.Assets.Remove(asset);
            }

            dataGridView.Refresh();
            _fileSearcher.UpdateCheckInfo();

            GC.Collect();
        }

        public void SetSelCheck(bool _check, bool _invert)
        {
            if (dataGridView.SelectedCells.Count < 1)
                return;

            HashSet<int> _rows = new HashSet<int>();
            foreach(DataGridViewCell cell in dataGridView.SelectedCells)
            {
                _rows.Add(cell.RowIndex);
            }
            
            foreach (var row in _rows)
            {
                if(_invert)
                {
                    _fileSearcher.Assets[row].Checked = !_fileSearcher.Assets[row].Checked;
                }
                else
                {
                    _fileSearcher.Assets[row].Checked = _check;
                }
            }

            dataGridView.Refresh();
            _fileSearcher.UpdateCheckInfo();

            GC.Collect();
        }

        public void SelByCheck(bool _check)
        {
            if (dataGridView.Rows.Count < 1)
                return;

            ClearSel();
                
            for(int i=0; i<_fileSearcher.Assets.Count; i++)
            {
                if(_fileSearcher.Assets[i].Checked == _check)
                {
                    dataGridView.Rows[i].Selected = true;
                }
            }
        }

        public string GetSelInfo()
        {
            string result = "Selection : 0 | 0 B";
            if (dataGridView.SelectedCells.Count < 1 || dataGridView.Rows.Count<1)
                return result;

            double size = 0;
            HashSet<int> rows = new HashSet<int>();
            foreach (DataGridViewCell cell in dataGridView.SelectedCells)
            {
                if (rows.Add(cell.RowIndex))
                {
                    size += _pathHelper.GetFileSize(_fileSearcher.Assets[cell.RowIndex].FullPath);
                }
            }

            if( size >0 && rows.Count>0)
            result = string.Format("Selection : {0} | {1}", rows.Count, _pathHelper.GetFileSizeFormated(size));

            rows.Clear();

            return result;
        }

        public void FocusSelection()
        {


            if (dataGridView.SelectedCells.Count < 1 || dataGridView.Rows.Count < 1)
                return;

            SelectRow();

            int count = dataGridView.SelectedRows.Count;

            if (count < 1)
                return;

            if(count == dataGridView.Rows.Count)
            {
                dataGridView.FirstDisplayedScrollingRowIndex = 0;
                return;
            }
            
            int selRowsCount = dataGridView.SelectedRows.Count;

            foreach(DataGridViewRow row in dataGridView.Rows)
            {
               _fileSearcher.Assets[row.Index].RowSelected = row.Selected;
            }

            var list = _fileSearcher.Assets.ToList();
            list = list.OrderByDescending(x => x.RowSelected).ToList();

            _fileSearcher.Assets = new BindingList<Asset>(list);
            dataGridView.DataSource = _fileSearcher.Assets;
            for (int i = 0; i < selRowsCount; i++)
            {
                dataGridView.Rows[i].Selected = true;
            }

            dataGridView.FirstDisplayedScrollingRowIndex = 0;
            dataGridView.RefreshEdit();
            GC.Collect();

        }

        public void SelectByNames(List<string> _namePatters, NameMatchModes _matchMode)
        {
           

            if (dataGridView.Rows.Count < 1 || _matchMode == NameMatchModes.None || _namePatters.Count < 1)
                return;
            ClearSel();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (var pattern in _namePatters)
                {
                    if (_matchMode == NameMatchModes.MatchName)
                    {
                        if (_fileSearcher.Assets[row.Index].FileName.Contains(pattern))
                            row.Selected = true;
                    }
                    else
                    {
                        if (_matchMode == NameMatchModes.AbsoluteMatch)
                        {
                            if (_fileSearcher.Assets[row.Index].FileName == pattern)
                                row.Selected = true;
                        }
                    }
                }
            }

            FocusSelection();
        }

        public void CheckByNames(List<string> _namePatters, NameMatchModes _matchMode, bool _check)
        {
            SelectByNames(_namePatters, _matchMode);
            SetSelCheck(_check, false);
        }

        public void OpenSearchForm()
        {
            _searchForm = SearchForm.GetFormInstance;

            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == _searchForm.Name);

            if(formOpen == false)
            {
                _searchForm.Show();
            }

            if (_searchForm.WindowState == FormWindowState.Minimized)
            {
                _searchForm.WindowState = FormWindowState.Normal;
            }
            
        }

       public void FindItems(string _string)
        {
            if (_fileSearcher.Assets.Count < 1 || string.IsNullOrEmpty(_string))
            {
                ClearSel();
                return;
            }

            ClearSel();
            var _searchItems = SplitSearchString(_string);
            for (int i=0; i<_fileSearcher.Assets.Count;i++)
            {
              foreach(var item in _searchItems)
              {
                  _searchMod = new[] {false, false};
                  var curItem = item;

                    if (curItem.Contains(_SearchSeparators[1]))
                    {
                        curItem = curItem.Replace(_SearchSeparators[1].ToString(), "");
                        _searchMod[0] = true;
                    }

                    if (curItem.Contains(_SearchSeparators[2]))
                    {
                        curItem = curItem.Replace(_SearchSeparators[2].ToString(),"");
                        _searchMod[1] = true;
                    }

                    curItem = curItem.Trim();

                    if (string.IsNullOrEmpty(curItem) == false &&
                        (SelectSearchItem(curItem, _fileSearcher.Assets[i].FileName)))
                    { dataGridView.Rows[i].Selected = true;}
              }
            }
 
            FocusSelection();
        }

       private bool SelectSearchItem(string item, string source)
       {
           if (_searchMod[0] == false)
           {
               item = item.ToUpper();
               source = source.ToUpper();
           }

           if (_searchMod[1] == true)
           {
               return source == item;
           }
 
           return source.Contains(item);
       }

        private List<string> SplitSearchString (string _string)
        {
            List<string> _items = new List<string>();

            if (string.IsNullOrEmpty(_string))
                return _items;

            _items = _string.Split(_SearchSeparators[0]).ToList();
            _items = _items.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x = x.Trim()).Distinct().ToList();
            return _items;
        }

       

        public void SortData( int colIndex)
        {
            var list = _fileSearcher.Assets.ToList();

            if (list.Count < 2)
                return;

            switch(colIndex)
            {
                case 0 :
                    {
                       
                        var RevSortlist = list.OrderByDescending(x => x.Checked).ToList();
                        if (list[0].Checked == RevSortlist[0].Checked)
                        {
                            list = list.OrderBy(x => x.Checked).ToList();
                        }
                        else
                        {
                            list = RevSortlist;
                        }
                        
                        break;
                    }

                case 1:
                    {

                        var RevSortlist = list.OrderByDescending(x => x.FullPath).ToList();
                        if (list[0].FullPath == RevSortlist[0].FullPath)
                        {
                            list = list.OrderBy(x => x.FullPath).ToList();
                        }
                        else
                        {
                            list = RevSortlist;
                        }

                        break;
                    }
                case 2:
                    {

                        var RevSortlist = list.OrderByDescending(x => x.FileName).ToList();
                        if (list[0].FileName == RevSortlist[0].FileName)
                        {
                            list = list.OrderBy(x => x.FileName).ToList();
                        }
                        else
                        {
                            list = RevSortlist;
                        }

                        break;
                    }
                case 3:
                    {

                        var RevSortlist = list.OrderByDescending(x => x.FileExt).ToList();
                        if (list[0].FileExt == RevSortlist[0].FileExt)
                        {
                            list = list.OrderBy(x => x.FileExt).ToList();
                        }
                        else
                        {
                            list = RevSortlist;
                        }

                        break;
                    }

                case 4:
                    {
                        var RevSortlist = list.OrderByDescending(x => x.GetFileSize()).ToList();

                        if (list[0].FileExt == RevSortlist[0].FileExt)
                        {
                            list = list.OrderBy(x => x.GetFileSize()).ToList();
                        }
                        else
                        {
                            list = RevSortlist;
                        }
                        break;
                    }

                default:
                    {
                        GC.Collect();
                        return;
                    }
            }
            _fileSearcher.Assets = new BindingList<Asset>(list);
            dataGridView.DataSource = _fileSearcher.Assets;
            GC.Collect();
        }
}
}
