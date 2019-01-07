using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDir
{
    public partial class SearchForm : Form
    {
        private static SearchForm SearchFormInstance;
        private DataEditorHelper _dataEditorHelper;
        private int _maxLiveSearch = 4000; // live search limit
        private SearchForm()
        {
            InitializeComponent();
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

        private void SearchForm_Load(object sender, EventArgs e)
        {
            _dataEditorHelper = DataEditorHelper.Getinstance();
            _dataEditorHelper.FindItems(tb_SearchField.Text);
        }

        private void tb_SearchField_TextChanged(object sender, EventArgs e)
        {
            if (_dataEditorHelper != null && FileSearcher.GetInstance.Assets.Count< _maxLiveSearch) 
                _dataEditorHelper.FindItems(tb_SearchField.Text);
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
