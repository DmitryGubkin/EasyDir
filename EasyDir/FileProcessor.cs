using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace EasyDir
{
    class FileProcessor
    {
        private FileSearcher _fileSearcher = FileSearcher.GetInstance;
        private static FileProcessor _fileProcessor = new FileProcessor();
        private PathHelper _pathHelper = PathHelper.GetInstance;
        
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;

        private string _outPath;
        private string _topRoot;
        private bool _overwrite;
        private bool _subRoots;
        private bool _foldersOnly;

        public string OutPath { get => _outPath; set => _outPath = value; }
        public string TopRoot { get => _topRoot; set => _topRoot = value; }
        public bool Overwrite { get => _overwrite; set => _overwrite = value; }
        public bool SubRoots { get => _subRoots; set => _subRoots = value; }
        public bool FoldersOnly { get => _foldersOnly; set => _foldersOnly = value; }

        private FileProcessor()
        {
        }

        public static FileProcessor GetFileProcessor()
        {
            return _fileProcessor;
        }

        public void CopyFiles()
        {
            if (string.IsNullOrEmpty(_outPath) == true || Directory.Exists(_outPath) == false || _fileSearcher.Assets.Count<1)
                return;

            var assets = _fileSearcher.Assets.Where(x => x.Checked == true && File.Exists(x.FullPath)).Select(x => x).ToList();

           // System.Windows.Forms.MessageBox.Show(assets.Count.ToString());
            foreach (var asset in assets)
            {
                if( token != null && token.IsCancellationRequested)
                {
                    MessageBox.Show("File Processor Aborted");
                    return;
                }
                
                if (_subRoots == false )
                {
                    var _newPath = _outPath + @"\" + Path.GetFileName(asset.FullPath);

                    if (Path.GetFullPath(_newPath) != asset.FullPath && FoldersOnly == false)
                    {
                        if (File.Exists(_newPath) == true && _overwrite == false)
                            continue;
                        try
                        {
                            File.Copy(asset.FullPath, _newPath, _overwrite);
                        }
                        catch
                        {
                            var dlgRes = MessageBox.Show("Error On File Copying\nContinue Processing ?", "File Processor",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlgRes == DialogResult.No)
                                return;
                        }
                       
                    }   
                }
                else
                {
                    var _newPath = _pathHelper.GetFoldersFromFile(asset.GetDirPath(), _topRoot);
                    _newPath = _outPath + _newPath;


                    if (!Directory.Exists(_newPath))
                    {
                        try
                        {
                           new DirectoryInfo(_newPath).Create();
                        }
                        catch 
                        {
                          var dlgRes =  MessageBox.Show("Error On Folder Creation\nContinue Processing ?", "File Processor",
                               MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                            if (dlgRes == DialogResult.No)
                                return;
                        }

                    }

                    if (Path.GetFullPath(_newPath + @"\" + Path.GetFileName(asset.FullPath)) != asset.FullPath &&
                        Directory.Exists(_newPath) == true && _foldersOnly == false) //source protect
                    {
                        if (File.Exists(_newPath + @"\" + Path.GetFileName(asset.FullPath)) == true && _overwrite == false)
                            continue;
                        try
                        {
                            File.Copy(asset.FullPath, (_newPath + @"\" + Path.GetFileName(asset.FullPath)), _overwrite);
                        }
                        catch
                        {
                            var dlgRes = MessageBox.Show("Error On File Copying\nContinue Processing ?", "File Processor",
                               MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                            if (dlgRes == DialogResult.No)
                                return;
                        }
                       
                    }        

                }
                
            }

            
            _pathHelper.ShowFolder(_outPath);
        }

        public async void CopyFilesAsync()
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            await Task.Run(() => CopyFiles());

        }

        public void AbortCopy()
        {
            if(cancelTokenSource != null && token != null)
            cancelTokenSource.Cancel();
        }
    }
}
