﻿using System;
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
            if(dataGridView.SelectedCells.Count<1)
            {
                return;
            }

            HashSet<string> selData = new HashSet<string>();
            List<Asset> assetsToRemove = new List<Asset>();

            for (int i = 0; i < dataGridView.SelectedCells.Count; i++)
            {
                selData.Add((string)dataGridView.Rows[dataGridView.SelectedCells[i].RowIndex].Cells[1].Value);
            }

            if (selData.Count>0)
            {
                if(selData.Count>4)
                {
                    if(MessageBox.Show("Delete " + selData.Count.ToString() +" Assets ?","Assets Delete",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        GC.Collect();
                        return;
                    }
                }
               
                foreach(var fullPath in selData)
                {
                    var asset = _fileSearcher.Assets.Where(x => x.FullPath == fullPath).Select(x => x).ToList();
                    if(asset.Count>0)
                    {
                        assetsToRemove.AddRange(asset);
                    } 
                }
            }

            foreach (var asset in assetsToRemove)
            {
                _fileSearcher.Assets.Remove(asset);
            }
            GC.Collect();
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

            int index = 0;
            var rows = dataGridView.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                var asset = _fileSearcher.Assets[row.Index];
                _fileSearcher.Assets[row.Index] = _fileSearcher.Assets[index];
                _fileSearcher.Assets[index] = asset;
                index++;
            }

            ClearSel();

            for (int i =0; i<count; i++)
            {
                dataGridView.Rows[i].Selected = true;
            }

            dataGridView.FirstDisplayedScrollingRowIndex = 0;
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
