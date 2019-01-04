using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EasyDir
{
   public class Asset
    {
        private string _fileName;
        private string _fileExt;
        private string _dirPath;
        private string _fullPath;
        private bool _checked;
        private string _fileSizeFormated;
        private double _fileSize;

        private PathHelper _pathHelper = PathHelper.GetInstance;

        public bool Checked { get => _checked; set => _checked = value; }
        public string FullPath { get => _fullPath; set => _fullPath = value; }
        public string FileName { get => _fileName; set => _fileName = value; }
        public string FileExt { get => _fileExt; set => _fileExt = value; }
        public string FileSizeFormated { get => _fileSizeFormated; set => _fileSizeFormated = value; }

        public string GetDirPath()
        {
            return _dirPath;
        }
       public double GetFileSize()
        {
            return _fileSize;
        }
       

        public bool isEmpty()
        {
            if (_fileName == "" || _fileExt == "" || _dirPath == "" || _fullPath == "")
            return true;
            return false;
        }
        public Asset()
        {
            _fileName = "";
            _fileExt = "";
            _dirPath = "";
            _fullPath = "";
            _fileSize = 0;
            _fileSizeFormated = "0.0 B";
            _checked = true;
        }

        public Asset (string fullPath)
        {
            SplitSource(fullPath);
            _checked = true;
        }
        
        private void SplitSource(string _path)
        {
            if (String.IsNullOrEmpty(_path) == false && File.Exists(_path))
            {
                _fileName = Path.GetFileNameWithoutExtension(_path);
                _fileExt = Path.GetExtension(_path);
                _dirPath = Path.GetDirectoryName(_path);
                _fullPath = _path;
                _fileSize = _pathHelper.GetFileSize(_path);
                _fileSizeFormated = _pathHelper.GetFileSizeFormated(_fileSize);
            }
        }
    }
}
