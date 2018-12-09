using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;
namespace EasyDir
{
    class DialogHelper
    {
        public string GetFolder(string DefDir,string _Title)
        {
            CommonOpenFileDialog FolderDlg = new CommonOpenFileDialog();
            if (String.IsNullOrEmpty(DefDir) == false && System.IO.Directory.Exists(DefDir))
            {
                FolderDlg.InitialDirectory = DefDir;

            }

            if(String.IsNullOrEmpty(_Title) == false)
             {
                FolderDlg.Title = _Title;
             }
            
            FolderDlg.IsFolderPicker = true;
            if (FolderDlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return FolderDlg.FileName;
            }
            else
            {

                return null;
            }
        }


    }
}
