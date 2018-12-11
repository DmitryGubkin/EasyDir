using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace EasyDir
{
    class PathHelper
    {
        private static PathHelper _instance = new PathHelper();
        public static PathHelper GetInstance { get => _instance; }

        private string[] _pathDivs = { @"\", @":\"};

        private PathHelper() { }


        public string GetFolders (string _path, string _topRoot)
        {
            if  (Directory.Exists(_path) || 
                String.IsNullOrEmpty(_path) == false)
            {

                if (_path.Contains(_pathDivs[1]))
                {

                    if (Directory.Exists(_path))
                    {
                        _path = _path.Substring(Path.GetPathRoot(_path).Length);
                    }
                    else
                    {
                        if (_path.Contains(_pathDivs[1]))
                        {
                            _path = _path.Substring(_path.IndexOf(_pathDivs[1]) + _pathDivs[1].Length);
                        }
                    }
                    // MessageBox.Show(_path);


                    if ((Directory.Exists(_topRoot) == true || String.IsNullOrEmpty(_topRoot) == false))

                    {
                        if (Directory.Exists(_topRoot))
                            _topRoot = _topRoot.Substring(Path.GetPathRoot(_topRoot).Length);

                        // MessageBox.Show(_topRoot);
                        if (_path.Length > _topRoot.Length)
                        {
                            if ((_path.Substring(0, (_topRoot.Length))) == _topRoot && _topRoot.Contains(_pathDivs[0]))
                            {
                                //MessageBox.Show("0");
                                //PathEnd(ref _topRoot);
                                _path = _path.Remove( 0, _topRoot.LastIndexOf(_pathDivs[0]));
                            }
                            else
                            {
                                //MessageBox.Show("1");
                                if (_path.Contains(_topRoot))
                                {
                                    _path = _path.Substring(_path.IndexOf(_topRoot));
                                }
                            }
                        }

                    }
                }

                
                PathStart(ref _path);
            }

           // MessageBox.Show(_path);

            return _path;
        }

        public void MakeFolders(string _base, string _path, bool _makeFoders)
        {
            if(Directory.Exists(_base) && 
                String.IsNullOrEmpty(_base) ==false &&
                String.IsNullOrEmpty(_path) == false )
            { 
                
                PathStart(ref _path);
                _path = _base + _path;

                
                if(!Directory.Exists(_path) && _makeFoders == true)
                {
                    try 
                    {
                        new DirectoryInfo(_path).Create();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                     
                }

                if (_makeFoders == true)
                {
                    ShowFolder(_path);
                }
                else //Preview Directory
                {
                   
                    if (String.IsNullOrEmpty(_path) == false)
                    {
                        DialogResult CopyPathDlg = MessageBox.Show(_path +
                            "\n ====================================== \nCopy path to buffer ?", "Directory Preview",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (CopyPathDlg == DialogResult.Yes)
                        {
                            Clipboard.SetText(_path);
                        }
                    }
   
                }
            } 
        }



        public void PathStart (ref string _path)
        {
            if (String.IsNullOrEmpty(_path) == false)
            {
                if (_path[0].ToString() != _pathDivs[0])
                {
                    _path = _pathDivs[0] + _path;
                }
            }
            
        }

        public void PathEnd (ref string _path)
        {
            if (String.IsNullOrEmpty(_path) == false && _path.Length>2)
            {
                if (_path[_path.Length - 1].ToString() == _pathDivs[0])
                {
                    _path = _path.Remove((_path.Length -2), 1);
                }
            }
        }

        public bool IsDik(string _path)
        {
            
            if (String.IsNullOrEmpty(_path) == false &&
                _path.Length > 2 &&
                Directory.Exists(_path) == true)
            {
                if (_path == Path.GetPathRoot(_path))
                    return true;
            }
            return false;
        }

        public void ShowFolder(string _path)
        {
            
            if(String.IsNullOrEmpty(_path) == false && Directory.Exists(_path) )
            {
              //  _path = Path.GetDirectoryName(_path);
                try
                {
                    Process.Start(_path);
                }
                catch
                {
                    MessageBox.Show("Folder Not Exist");
                }
                
            }
        }

        public List<string>  GetDragedFiles(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            List<string> files = new List<string>();

            if (paths == null && paths.Length<1)
                return files;

            foreach(var path in paths)
            {
                files.AddRange(PathToFiles(path,sender));
            }

            return (files.Distinct().ToList());
        }


        private List<string> PathToFiles(string _path, object sender)
        {
            List<string> res = new List<string>();
            if (File.Exists(_path))
            {
                if (sender.GetType() == typeof(TextBox))
                {
                    res.Add(Path.GetDirectoryName(_path));
                }
                else
                {
                    if (sender.GetType() == typeof(CheckedListBox))
                    {
                        res.Add(Path.GetFileNameWithoutExtension(_path));
                    }
                    else
                    {
                        res.Add(_path);
                    }

                }
            }
            else
            {
                if (Directory.Exists(_path))
                {
                    if (sender.GetType() == typeof(TextBox))
                    {
                        res.Add(_path);
                    }
                    else
                    {
                        var files = Directory.GetFiles(_path, "*", SearchOption.TopDirectoryOnly).ToList();

                        if (sender.GetType() == typeof(CheckedListBox))
                        {
                            res.AddRange((files.Select(x => Path.GetFileNameWithoutExtension(x)).ToList()));
                        }
                        else
                        {
                            res.AddRange(files);
                        }
                           
                    }

                }
            }

           
            return res;
                 
        }
    }
}
