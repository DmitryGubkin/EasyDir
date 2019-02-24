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
        private ToolTip _searchTip = new ToolTip();


        private SearchForm()
        {
            InitializeComponent();

            assistant = new TypeAssistant();
            assistant.Idled += assistant_Idled;

            this.SetStyle(ControlStyles.ResizeRedraw, true);

            _searchTip.ToolTipIcon = ToolTipIcon.Info;
            _searchTip.AutoPopDelay = Int16.MaxValue;
            _searchTip.InitialDelay = 1500;
            _searchTip.IsBalloon = true;
            _searchTip.ShowAlways = true;

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
            

            _searchTip.ToolTipTitle = "Use Character";
            _searchTip.SetToolTip(tb_SearchField,
                $"{_dataEditorHelper._SearchSeparators[0]} - as separator for multi searching" +
                $"\n{_dataEditorHelper._SearchSeparators[1]} - allow register sensitivity" +
                $"\n{_dataEditorHelper._SearchSeparators[2]} - absolute match");
        }

        private  void tb_SearchField_TextChanged(object sender, EventArgs e)
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

        private void tb_SearchField_MouseLeave(object sender, EventArgs e)
        {
            _searchTip.Active = false;
        }

        private void tb_SearchField_MouseEnter(object sender, EventArgs e)
        {
            _searchTip.Active = true;
        }
    }
}
