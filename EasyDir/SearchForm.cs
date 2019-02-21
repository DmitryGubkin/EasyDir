using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace EasyDir
{
    public partial class SearchForm : Form
    {
        private static SearchForm SearchFormInstance;
        private DataEditorHelper _dataEditorHelper;
        private int _maxLiveSearch = 12000; // live search limit
        private TypeAssistant assistant;


        private SearchForm()
        {
            InitializeComponent();

            assistant = new TypeAssistant();
            assistant.Idled += assistant_Idled;

            this.SetStyle(ControlStyles.ResizeRedraw, true);

        }


        public static SearchForm GetFormInstance
        {
            get
            {
                if (SearchFormInstance == null || SearchFormInstance.IsDisposed)
                {
                    SearchFormInstance = new SearchForm();
                }
                
                return SearchFormInstance;
            }
        }

        void assistant_Idled(object sender, EventArgs e)
        {
            assistant.WaitingMilliSeconds = 400;
            if (  FileSearcher.GetInstance.Assets.Count > _maxLiveSearch)
                assistant.WaitingMilliSeconds = assistant.WaitingMilliSeconds * (int)(1.2*FileSearcher.GetInstance.Assets.Count/ _maxLiveSearch);

            if (FileSearcher.GetInstance.Assets.Count > (4 * _maxLiveSearch) || tb_SearchField.Text.Trim().Length < 3)
            {
                _dataEditorHelper.ClearSel();
                return;
            }

            this.Invoke(
                new MethodInvoker(() =>
                {
                    _dataEditorHelper.FindItems(tb_SearchField.Text);
                }));
        }


        private void SearchForm_Load(object sender, EventArgs e)
        {
            
            _dataEditorHelper = DataEditorHelper.Getinstance();
            _dataEditorHelper.FindItems(tb_SearchField.Text);
        }

        private async void tb_SearchField_TextChanged(object sender, EventArgs e)
        {
            assistant.TextChanged();
        }
        

        private void tb_SearchField_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (_dataEditorHelper != null)
                    _dataEditorHelper.FindItems(tb_SearchField.Text);
                e.Handled = e.SuppressKeyPress = true;
            }

            if(e.KeyCode == Keys.Escape)
            {
                SearchFormInstance.Close();
                e.Handled = e.SuppressKeyPress = true;
            }
          
        }
    }
}
