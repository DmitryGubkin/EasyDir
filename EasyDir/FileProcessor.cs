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

        public void CopyFiles(string _OutPath, string _topRoot, bool overwrite,bool SubRoots, bool FoldersOnly)
        {
            if (string.IsNullOrEmpty(_OutPath) == true || Directory.Exists(_OutPath) == false)
                return;

            var assets = _fileSearcher.Assets.Where(x => x.Checked == true && File.Exists(x.FullPath)).Select(x => x).ToList();
           // System.Windows.Forms.MessageBox.Show(assets.Count.ToString());
            foreach (var asset in assets)
            {
                if (SubRoots == false)
                {
                    var _newPath = _OutPath + @"\" + Path.GetFileName(asset.FullPath);

                    if (Path.GetFullPath(_newPath) != asset.FullPath)
                    {
                        if (File.Exists(_newPath) == true && overwrite == false)
                            continue;
                        try
                        {
                            File.Copy(asset.FullPath, _newPath, overwrite);
                        }
                        catch
                        {
                            var dlgRes = System.Windows.Forms.MessageBox.Show("Error On File Copying\nContinue Processing ?", "File Processor",
                              System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                            if (dlgRes == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                       
                    }   
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
                        catch 
                        {
                          var dlgRes =  System.Windows.Forms.MessageBox.Show("Error On Folder Creation\nContinue Processing ?", "File Processor",
                               System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
                            if (dlgRes == System.Windows.Forms.DialogResult.No)
                                return;
                        }

                    }

                    if (Path.GetFullPath(_newPath + @"\" + Path.GetFileName(asset.FullPath)) != asset.FullPath &&
                        Directory.Exists(_newPath) == true && FoldersOnly == false) //source protect
                    {
                        if (File.Exists(_newPath + @"\" + Path.GetFileName(asset.FullPath)) == true && overwrite == false)
                            continue;
                        try
                        {
                            File.Copy(asset.FullPath, (_newPath + @"\" + Path.GetFileName(asset.FullPath)), overwrite);
                        }
                        catch
                        {
                            var dlgRes = System.Windows.Forms.MessageBox.Show("Error On File Copying\nContinue Processing ?", "File Processor",
                               System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                            if (dlgRes == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                       
                    }        

                }
            }

            _pathHelper.ShowFolder(_OutPath);
        }
    }
}
