using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EasyDir
{
    class FileProcessor
    {
        private FileSearcher _fileSearcher = FileSearcher.GetInstance;
        private static FileProcessor _fileProcessor = new FileProcessor();
        private PathHelper _pathHelper = PathHelper.GetInstance;

        private FileProcessor() { }
        public static FileProcessor GetFileProcessor()
        {
            return _fileProcessor;
        }

        public void CopyFiles(string _OutPath, string _topRoot, bool overwrite,bool SubRoots)
        {
            if (string.IsNullOrEmpty(_OutPath) == true || Directory.Exists(_OutPath) == false)
                return;

            var assets = _fileSearcher.Assets.Where(x => x.Checked == true && File.Exists(x.FullPath)).Select(x => x).ToList();

            foreach (var asset in assets)
            {
                if (SubRoots == false)
                {
                    File.Copy(asset.FullPath, (_OutPath + Path.GetFileName(asset.FullPath)), overwrite);
                }
                else
                {
                    var _newPath = _pathHelper.GetFoldersFromFile(asset.GetDirPath(), _topRoot);
                    _newPath = _OutPath + _newPath;

                    if (!Directory.Exists(_newPath))
                    {
                        try
                        {
                           new DirectoryInfo(_newPath).Create();
                        }
                        catch (Exception e)
                        {
                           System.Windows.Forms.MessageBox.Show(e.ToString());
                        }

                    }
                    else
                    {
                        if (File.Exists(_newPath + @"\" + Path.GetFileName(asset.FullPath)) == true && overwrite == false)
                            continue;
                        File.Copy(asset.FullPath, (_newPath + @"\" + Path.GetFileName(asset.FullPath)), overwrite);
                    }
                   

                }
            }

            _pathHelper.ShowFolder(_OutPath);
        }
    }
}
