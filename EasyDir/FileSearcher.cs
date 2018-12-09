using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace EasyDir
{
    class FileSearcher
    {
        private static FileSearcher _fileSearcher = new FileSearcher();
        public static FileSearcher GetInstance { get => _fileSearcher;}
        public List<Asset> Assets = new List<Asset>();
        private FileSearcher() { }

        public void Search(string _path, SearchTypes _searchType)
        {
            Assets.Clear();
            string[] FilePaths = null;
            if (String.IsNullOrEmpty(_path) == false
                 && Directory.Exists(_path) == true
                 && _searchType != SearchTypes.None)
            {
                if (_searchType == SearchTypes.CurrentFolder)
                {
                    FilePaths = Directory.GetFiles(_path, "*", SearchOption.TopDirectoryOnly);
                    if(FilePaths != null && FilePaths.Length >0)
                    {
                        foreach (var pathItem in FilePaths)
                        {
                            Assets.Add(new Asset(pathItem));
                        }
                        //Assets.ForEach(x => MessageBox.Show(x.FullPath + "\n" + x.DirPath + "\n" + x.FileName + "\n" + x.FileExt));
                    }
                    
                }

                else
                {
                    return;
                }
            }
        }


        
    }
}
