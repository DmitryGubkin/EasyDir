using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace EasyDir
{
    class FileSearcher
    {
        private static FileSearcher _fileSearcher = new FileSearcher();
        public static FileSearcher GetInstance { get => _fileSearcher;}

        private DataGridView dataGridView;
        public DataGridView SetDataGridView { get => dataGridView; set => dataGridView = value; }

        public HashSet<Asset> Assets = new HashSet<Asset>(new AssetPathComparer());
        private FileSearcher() { }

        private bool modified = false;

        public void Search(string _path, SearchTypes _searchType, NameMatchModes _nameMatchMode, List<string> NamePatters)
        {

            string[] FilePaths = new string[0];
            List<string> _resPaths = new List<string>();

            if (String.IsNullOrEmpty(_path) == false
                 && Directory.Exists(_path) == true
                 && _searchType != SearchTypes.None)
            {
               

                if (_searchType != SearchTypes.None)
                {
                    SearchOption _sOption = SearchOption.TopDirectoryOnly;
                    if (_searchType == SearchTypes.AllSubFolders)
                        _sOption = SearchOption.AllDirectories;

                    try
                    {
                        NameMatchModes nameMatchOption = _nameMatchMode;

                        if (nameMatchOption == NameMatchModes.None)
                        {
                             FilePaths = Directory.GetFiles(_path, "*", _sOption);
                        }

                        else
                        {
                            if(NamePatters.Count>0)
                            {
                                FilePaths = Directory.GetFiles(_path, "*", _sOption);

                                foreach (var _namePattern in NamePatters)
                                {
                                    var Res = GetPathsMatched(_namePattern, FilePaths, nameMatchOption);

                                    if(Res != null && Res.Count>0)
                                    {
                                        _resPaths.AddRange(Res);

                                    }
                                }
                            }

                            FilePaths = _resPaths.ToArray(); 
                        }
                    }

                    catch
                    {
                        MessageBox.Show("To Many Fiels OR\nDisk Root Selected As Source","Search Error");
                        return;
                    }

                    if(FilePaths != null && FilePaths.Length >0)
                    {

                        if (Assets.Count > 0)
                        {
                            DialogResult clearDlg = MessageBox.Show("Yes - Clear\nNo - Add\nCancel - Abort Search", "Clear previous search results ?",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                            if (clearDlg == DialogResult.Cancel)
                                return;

                            if (clearDlg == DialogResult.Yes)
                            {
                                Assets.Clear();
                                dataGridView.Rows.Clear();
                                modified = false;
                            }
                        }

                        foreach (var pathItem in FilePaths)
                        {
                            Asset _asset = new Asset(pathItem);
                            if (Assets.Add(_asset))
                            {
                                AddRow(_asset);
                                modified = true;                               
                            }     
                        }

                        MessageBox.Show(Assets.Count.ToString(), "Search Error");

                        
                    }

                    GC.Collect();
                }

            }
        }

        public void FillData()
        {

            if (Assets.Count > 0 && modified == true)
            {
                if (dataGridView.Rows.Count>0 )
                dataGridView.Rows.Clear();

                foreach (var asset in Assets)
                {

                    dataGridView.Rows.Add(asset.Checked, asset.FullPath, asset.FileName, asset.FileExt);
                }
            }
        }

        private  void AddRow(Asset asset)
        {
            dataGridView.Rows.Add(asset.Checked, asset.FullPath, asset.FileName, asset.FileExt);
        }

        private List<string> GetPathsMatched(string NamePattern,string[] Paths, NameMatchModes _nameMatchMode)
        {
            if (_nameMatchMode == NameMatchModes.MatchName)
            {
                 return (Paths.Where(x => (Path.GetFileNameWithoutExtension(x)).Contains(NamePattern)).Select(x=>x).ToList());
               
            }
            if(_nameMatchMode == NameMatchModes.AbsoluteMatch)
            {
                return (Paths.Where(x => (Path.GetFileNameWithoutExtension(x)) == NamePattern).Select(x => x).ToList());
                
            }

            return null;
        }
    }
}
