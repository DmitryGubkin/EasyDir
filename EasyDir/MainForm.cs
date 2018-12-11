using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;


namespace EasyDir
{
    public partial class MainForm : Form
    {
        DialogHelper _dialogHelper = new DialogHelper();
        PathHelper _pathHelper = PathHelper.GetInstance;
        FileSearcher _fileSearcher = FileSearcher.GetInstance;
        ComboBoxHelper _comboBoxHelper = new ComboBoxHelper();
        DataEditorHelper _dataEditorHelper;

        AssetNameHelper _assetNameHelper;
        ToolTip PathToolTip = new ToolTip();
        private string DefTTPath = "NO PATH";
        private string DefAssetName = "Asset_Name";
        private List<string> DragFilesBuffer = new List<string>();

        public MainForm()
        {
            InitializeComponent();

            _dataEditorHelper = new DataEditorHelper(ref DataEditor);
            _fileSearcher.SetDataGridView = DataEditor;

            PathToolTip.ToolTipIcon = ToolTipIcon.Info;
            PathToolTip.AutoPopDelay = Int16.MaxValue;
            PathToolTip.InitialDelay = 1500;
            PathToolTip.IsBalloon = true;
            PathToolTip.ShowAlways = true;

            AN_ContexMenu.Renderer = MainContexMenu.Renderer = new CustomContextMenuRender();
            AN_ContexMenu.ShowImageMargin = MainContexMenu.ShowImageMargin = false;
            tb_AssetName.Text = DefAssetName;

            tb_In.MouseLeave += new EventHandler(PathTT_Disable);
            tb_TopRoot.MouseLeave += new EventHandler(PathTT_Disable);
            tb_Out.MouseLeave += new EventHandler(PathTT_Disable);

            tb_AssetName.KeyDown += new KeyEventHandler(TBEnterPress);
            tb_In.KeyDown += new KeyEventHandler(TBEnterPress);
            tb_Out.KeyDown += new KeyEventHandler(TBEnterPress);
            tb_TopRoot.KeyDown += new KeyEventHandler(TBEnterPress);

            tb_In.DragEnter += new DragEventHandler(DataDragEnter);
            tb_In.DragDrop += new DragEventHandler(TextBoxDragAndDrop);

            tb_TopRoot.DragEnter += new DragEventHandler(DataDragEnter);
            tb_TopRoot.DragDrop += new DragEventHandler(TextBoxDragAndDrop);

            tb_Out.DragEnter += new DragEventHandler(DataDragEnter);
            tb_Out.DragDrop += new DragEventHandler(TextBoxDragAndDrop);

            cbl_Names.DragEnter += new DragEventHandler(DataDragEnter);
            cbl_Names.DragDrop += new DragEventHandler(CBLDragAndDrop);

            _assetNameHelper = AssetNameHelper.instance;
            _assetNameHelper.CheckedListBoxControl = cbl_Names;

            tb_AssetName.DataBindings.Add("Text", _assetNameHelper, "NodeName", true, DataSourceUpdateMode.OnPropertyChanged);


            //Asset Manager Init
            _comboBoxHelper.FillComboBox(cb_SearchMode, ComboBoxTypes.Seartch);
            _comboBoxHelper.FillComboBox(cb_NameMatchMode, ComboBoxTypes.NameMatch);

            // MessageBox.Show(cb_SearchMode.SelectedItem.ToString());

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_SelOut_Click(object sender, EventArgs e)
        {
            tb_Out.Text = _dialogHelper.GetFolder(tb_Out.Text, "Select Out Folder") ?? tb_Out.Text;
        }

        private void btn_SelIn_Click(object sender, EventArgs e)
        {

            tb_In.Text = _dialogHelper.GetFolder(tb_In.Text, "Select Source Folder") ?? tb_In.Text;

        }

        private void btn_SeTopRoot_Click(object sender, EventArgs e) // Progress Bar Testing
        {
            tb_TopRoot.Text = _dialogHelper.GetFolder(tb_TopRoot.Text, "Select Top Root") ?? tb_TopRoot.Text;

            //TaskProgressForm _progressDlg = new TaskProgressForm();
            //_progressDlg.ShowDialog();

            //_fileSearcher.Search(tb_In.Text, SearchTypes.CurrentFolder);


        }



        private void toolOpenSourceFolder_Click(object sender, EventArgs e)
        {
            _pathHelper.ShowFolder(tb_In.Text);
        }


        private void toolOpenOut_Click(object sender, EventArgs e)
        {
            _pathHelper.ShowFolder(tb_Out.Text);
        }

        private void toolPreviewPath_Click(object sender, EventArgs e)
        {

            _pathHelper.MakeFolders(tb_Out.Text, _pathHelper.GetFolders(tb_In.Text, tb_TopRoot.Text), false);
        }

        private void TTPathText(Control _control)
        {
            PathToolTip.Active = true;
            if (String.IsNullOrEmpty(_control.Text) == true)
            {
                PathToolTip.SetToolTip(_control, DefTTPath);
            }
            else
            {
                PathToolTip.SetToolTip(_control, _control.Text);
            }
        }

        private void PathTT_Disable(object sender, EventArgs e)
        {
            PathToolTip.Active = false;
        }

        private void tb_In_MouseEnter(object sender, EventArgs e)
        {
            TTPathText(tb_In);
        }

        private void tb_TopRoot_MouseEnter(object sender, EventArgs e)
        {
            TTPathText(tb_TopRoot);
        }

        private void tb_Out_MouseEnter(object sender, EventArgs e)
        {
            TTPathText(tb_Out);
        }


        private void tb_AssetName_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = DefAssetName;
            }
        }

        private void btn_AddName_Click(object sender, EventArgs e)
        {
            _assetNameHelper.AddNode(tb_AssetName.Text);

        }

        private void btn_RemoveName_Click(object sender, EventArgs e)
        {
            _assetNameHelper.RemoveNode();
        }

        private void toolStripTextBox1_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = DefAssetName;
            }
        }

        private void AN_ContexMenu_Opening(object sender, CancelEventArgs e)
        {
            if (cbl_Names.Items.Count > 0 && cbl_Names.SelectedItems.Count > 0)
            {
                this.AN_QuickNameEditor.Visible = true;
                this.AN_AddNode.Visible = false;
                this.AN_QuickNameEditor.Text = cbl_Names.SelectedItem.ToString();
               
            }
            else
            {
                this.AN_AddNode.Visible = true;
                this.AN_QuickNameEditor.Visible = false;
            }
        }

        private void cbl_Names_MouseDown(object sender, MouseEventArgs e)
        {
            //Clear Selection in List

            if (e.Button == MouseButtons.Left)
            {
                Point pt = new Point(e.X, e.Y);
                int index = cbl_Names.IndexFromPoint(pt);
                if (index <= -1)
                {
                    cbl_Names.SelectedItems.Clear();
                }
            }
        }

        private void AN_QuickNameEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                _assetNameHelper.RenameNode(AN_QuickNameEditor.Text);
                //AN_ContexMenu.Close();
            }
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = e.SuppressKeyPress = true;
                _assetNameHelper.RenameNode(AN_QuickNameEditor.Text);
                AN_ContexMenu.Close();
            }
        }

        private void AN_RemoveSel_Click(object sender, EventArgs e)
        {
            _assetNameHelper.RemoveNode();
        }

        private void AN_ClearAll_Click(object sender, EventArgs e)
        {
            _assetNameHelper.ClearAll();
        }

        private void AN_CheckAll_Click(object sender, EventArgs e)
        {
            _assetNameHelper.CheckUnCheckll(true);
        }

        private void AN_UnCheckAll_Click(object sender, EventArgs e)
        {
            _assetNameHelper.CheckUnCheckll(false);
        }

        private void AN_InvertAll_Click(object sender, EventArgs e)
        {
            _assetNameHelper.InvertAll();
        }

        private void AN_RemoveCheked_Click(object sender, EventArgs e)
        {
            _assetNameHelper.RemoveCheked();
        }

        private void cbl_Names_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_AssetName.Text = _assetNameHelper.NodeName;
            DefAssetName = tb_AssetName.Text;
        }

        private void TBEnterPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void btn_SearchAssets_Click(object sender, EventArgs e)
        {
            //  _assetNameHelper.GetNames().Count.ToString();
            _fileSearcher.Search(tb_In.Text, (SearchTypes)_comboBoxHelper.GetSearchMode(cb_SearchMode),
                (NameMatchModes)_comboBoxHelper.GetNameMatchMode(cb_NameMatchMode), _assetNameHelper.GetNames());

        }

        private void btn_MakeFolders_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_In.Text))
            {
                btn_SelIn_Click(sender, e);
            }

            //if (String.IsNullOrEmpty(tb_TopRoot.Text) && System.IO.Directory.Exists(tb_In.Text))
            //{
            //    btn_SeTopRoot_Click(sender, e);
            //}

            if (String.IsNullOrEmpty(tb_Out.Text))
            {
                btn_SelOut_Click(sender, e);
            }

            _pathHelper.MakeFolders(tb_Out.Text, _pathHelper.GetFolders(tb_In.Text, tb_TopRoot.Text), true);
        }

        private void AN_AddNode_Click(object sender, EventArgs e)
        {
            _assetNameHelper.AddNode(tb_AssetName.Text);
        }

        private void cbl_Names_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.D))
            {
                e.Handled = e.SuppressKeyPress = true;
                _assetNameHelper.AddNode(tb_AssetName.Text);

            }
            if (e.KeyData == (Keys.Control | Keys.X))
            {
                e.Handled = e.SuppressKeyPress = true;
                _assetNameHelper.RemoveNode();
            }
            if(e.KeyCode == Keys.Space)
            {
                e.Handled = e.SuppressKeyPress = true;             
                if(AN_ContexMenu.Visible == false)
                {
                    AN_ContexMenu.Show(Cursor.Position);
                }
            }
        }

        private void DataDragEnter (object sender, DragEventArgs e)
        {
            DragFilesBuffer.Clear();
            e.Effect = DragDropEffects.None;
            DragFilesBuffer = _pathHelper.GetDragedFiles(sender,e);
            if(DragFilesBuffer.Count>0)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TextBoxDragAndDrop (object sender, DragEventArgs e)
        {
            if (DragFilesBuffer.Count > 0)
                ((TextBox)sender).Text = DragFilesBuffer[0];

            DragFilesBuffer.Clear();
        }

        private void CBLDragAndDrop (object sender, DragEventArgs e)
        {
            if (DragFilesBuffer.Count > 0)
                _assetNameHelper.AddNodes(DragFilesBuffer);

            DragFilesBuffer.Clear();
        }

        private void AN_ContexMenu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Space )
            {
                _assetNameHelper.RenameNode(AN_QuickNameEditor.Text);
                ((ContextMenuStrip)sender).Close();
            }
            
        }

        private void AN_ContexMenu_Opened(object sender, EventArgs e)
        {
            AN_QuickNameEditor.Focus();
        }
    }
    }
