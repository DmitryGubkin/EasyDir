using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace EasyDir
{
    class FileSearcher
    {
        private static FileSearcher _fileSearcher = new FileSearcher();
        public static FileSearcher GetInstance { get => _fileSearcher;}

        private DataGridView dataGridView;
        public DataGridView DataViewer { get => dataGridView; set => dataGridView = value; }

        public BindingList<Asset> Assets = new BindingList<Asset>();
        

        private FileSearcher()
        {
          
           
        }


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
                            }
                        }

                        
                        foreach (var pathItem in FilePaths)
                        {
                            Asset _asset = new Asset(pathItem);
                            if (Assets.Contains(_asset,new AssetPathComparer()) == false)
                            {
                                Assets.Add(_asset);                            
                            }     
                        }

                        MessageBox.Show(Assets.Count.ToString());
                        

                        
                    }

                    GC.Collect();
                }

            }
        }

        public void AddAsset(string _path)
        {
            if(String.IsNullOrEmpty(_path) == false)
            {
                if(File.Exists(_path))
                {
                    Asset _asset = new Asset(_path);
                    if (Assets.Contains(_asset, new AssetPathComparer()) == false)
                    {
                        Assets.Add(_asset);
                        
                    }
                }
            }
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
