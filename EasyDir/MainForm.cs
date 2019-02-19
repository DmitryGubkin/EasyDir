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
        private static MainForm MainFormInstance;

        DialogHelper _dialogHelper = new DialogHelper();
        PathHelper _pathHelper = PathHelper.GetInstance;
        FileSearcher _fileSearcher = FileSearcher.GetInstance;
        ComboBoxHelper _comboBoxHelper = new ComboBoxHelper();
        DataEditorHelper _dataEditorHelper;
        FileProcessor _fileProcessor = FileProcessor.GetFileProcessor();
        public bool lockUI = false;

        AssetNameHelper _assetNameHelper;
        ToolTip PathToolTip = new ToolTip();

        private string DefTTPath = "NO PATH";
        private string DefAssetName = "Asset_Name";
        private bool FocusQNameEditor = false;
        private List<string> DragFilesBuffer = new List<string>();
        private BindingSource source = null;

        ToolStripLabel DE_Info = new ToolStripLabel("Selection : 0 | 0 B");
        


        public static MainForm GetFormInstance
        {
            get
            {
                if (MainFormInstance == null || MainFormInstance.IsDisposed)
                {
                    MainFormInstance = new MainForm();
                }
                return MainFormInstance;
            }
        }

        private MainForm()
        {
            InitializeComponent();
            _fileSearcher.DataViewer = DataEditor;
            _dataEditorHelper = DataEditorHelper.Getinstance();
            _dataEditorHelper.SetDataViewer();

            //Data Source Binding

            source = new BindingSource(_fileSearcher.Assets, null);
            DataEditor.DataSource = source;

            PathToolTip.ToolTipIcon = ToolTipIcon.Info;
            PathToolTip.AutoPopDelay = Int16.MaxValue;
            PathToolTip.InitialDelay = 1500;
            PathToolTip.IsBalloon = true;
            PathToolTip.ShowAlways = true;

            DE_ContexMenu.Renderer = AN_ContexMenu.Renderer = MainContexMenu.Renderer = new CustomContextMenuRender();
            DE_ContexMenu.ShowImageMargin = AN_ContexMenu.ShowImageMargin = MainContexMenu.ShowImageMargin = false;
            

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
            lb_CheckInfo.DataBindings.Add("Text", _fileSearcher, "AssetsInfo", true, DataSourceUpdateMode.OnPropertyChanged);

            tb_Out.DataBindings.Add("Text", _fileProcessor, "OutPath", true, DataSourceUpdateMode.OnPropertyChanged);
            tb_TopRoot.DataBindings.Add("Text", _fileProcessor, "TopRoot", true, DataSourceUpdateMode.OnPropertyChanged);
            cb_AllowOverWrite.DataBindings.Add("Checked", _fileProcessor, "Overwrite", true, DataSourceUpdateMode.OnPropertyChanged);
            cb_SubFolders.DataBindings.Add("Checked", _fileProcessor, "SubRoots", true, DataSourceUpdateMode.OnPropertyChanged);
            cb_FoldersOnly.DataBindings.Add("Checked", _fileProcessor, "FoldersOnly", true, DataSourceUpdateMode.OnPropertyChanged);

            cb_FoldersOnly.Enabled = cb_SubFolders.Checked;


            //Asset Manager Init
            _comboBoxHelper.FillComboBox(cmb_SearchMode, ComboBoxTypes.Search);
            _comboBoxHelper.FillComboBox(cmb_NameMatchMode, ComboBoxTypes.NameMatch);

            //data editor init
            DataEditor.AllowUserToAddRows = false;
            DataEditor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            DataEditor.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43);
            DataEditor.ColumnHeadersDefaultCellStyle.ForeColor = Color.Turquoise;
            DataEditor.EnableHeadersVisualStyles = false;
            DataEditor.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43);
            DataEditor.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 128);

            DataEditor.DefaultCellStyle.Font = new Font("Tahoma", 12, GraphicsUnit.Pixel);
            DataEditor.AllowUserToResizeRows = false;

            DE_Info.ForeColor = Color.FromArgb(241, 241, 241);
            DE_Info.Font = new Font("Tahoma", 12f, GraphicsUnit.Pixel);
            DE_ContexMenu.Items.Add(DE_Info);

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            DE_Style();

            DataEditor.CellContentClick += new DataGridViewCellEventHandler(DE_CellChanged);
            DataEditor.CellContentDoubleClick += new DataGridViewCellEventHandler(DE_CellChanged);
            DataEditor.CellContentDoubleClick += new DataGridViewCellEventHandler(DE_ShowFileInExplorer);
            DataEditor.CellValueChanged += new DataGridViewCellEventHandler(DE_CellValueChanged);
            DataEditor.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(SortDataByClick);
            DataEditor.ColumnHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(SortDataByClick);
            DataEditor.DragEnter += new DragEventHandler(DataDragEnter);
            DataEditor.DragDrop += new DragEventHandler(DE_DragAndDrop);

            

        }

        public void DE_Style()
        {
            DataEditor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataEditor.RowHeadersVisible = true;
            DataEditor.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DataEditor.RowHeadersWidth = 30;

            DataEditor.Columns[0].Width = 50;
            DataEditor.Columns[0].HeaderText = "Check";
            DataEditor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataEditor.Columns[1].ReadOnly = true;
            DataEditor.Columns[2].ReadOnly = true;
            DataEditor.Columns[3].ReadOnly = true;
            DataEditor.Columns[4].ReadOnly = true;

            DataEditor.Columns[1].HeaderText = "Full Path";
            DataEditor.Columns[2].HeaderText = "File Name";

            DataEditor.Columns[3].Width = 50;
            DataEditor.Columns[3].HeaderText = ".*";

            DataEditor.Columns[4].Width = 70;
            DataEditor.Columns[4].HeaderText = "Size";
            
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
            lb_CheckInfo.DataBindings.Clear();
            DataEditor.DataSource = null;
            DataEditor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DataEditor.RowHeadersVisible = false;

            _assetNameHelper.GetNames().Count.ToString();

            if (string.IsNullOrEmpty(tb_In.Text) == true)
            {
                btn_SelIn_Click(sender,e);
            }

            _fileSearcher.Search(tb_In.Text, (SearchTypes)_comboBoxHelper.GetSearchMode(cmb_SearchMode),
                (NameMatchModes)_comboBoxHelper.GetNameMatchMode(cmb_NameMatchMode), _assetNameHelper.GetNames());

            
            DataEditor.DataSource = source;
            lb_CheckInfo.DataBindings.Add("Text", _fileSearcher, "AssetsInfo", true, DataSourceUpdateMode.OnPropertyChanged);
            DE_Style();

        }

        private void btn_MakeFolders_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_In.Text))
            {
                btn_SelIn_Click(sender, e);
            }

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
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                e.Handled = e.SuppressKeyPress = true;
                _assetNameHelper.AddNode(tb_AssetName.Text);

            }
            if (e.KeyData == (Keys.Control | Keys.X) || e.KeyCode == Keys.Delete)
            {
                e.Handled = e.SuppressKeyPress = true;
                _assetNameHelper.RemoveNode();
            }
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = e.SuppressKeyPress = true;
                FocusQNameEditor = true;
                if (AN_ContexMenu.Visible == false)
                {
                    AN_ContexMenu.Show(Cursor.Position);
                }
            }
        }

        private void DataDragEnter(object sender, DragEventArgs e)
        {
            DragFilesBuffer.Clear();
            e.Effect = DragDropEffects.None;
            DragFilesBuffer = _pathHelper.GetDragedFiles(sender, e);
            if (DragFilesBuffer.Count > 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TextBoxDragAndDrop(object sender, DragEventArgs e)
        {
            if (DragFilesBuffer.Count > 0)
                ((TextBox)sender).Text = DragFilesBuffer[0];

            DragFilesBuffer.Clear();
        }

        private void CBLDragAndDrop(object sender, DragEventArgs e)
        {
            if (DragFilesBuffer.Count > 0)
                _assetNameHelper.AddNodes(DragFilesBuffer);

            DragFilesBuffer.Clear();
        }

        private void DE_DragAndDrop(object sender, DragEventArgs e)
        {
            if (DragFilesBuffer.Count > 0)
                _fileSearcher.AddAssets(DragFilesBuffer);
            DragFilesBuffer.Clear();
        }

        private void AN_ContexMenu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _assetNameHelper.RenameNode(AN_QuickNameEditor.Text);
                ((ContextMenuStrip)sender).Close();
            }

        }

        private void AN_ContexMenu_Opened(object sender, EventArgs e)
        {
            if (FocusQNameEditor)
                AN_QuickNameEditor.Focus();
        }

        private void AN_ContexMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            FocusQNameEditor = false;
        }

        private void DE_CellChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _dataEditorHelper.MultyCheck(e.RowIndex);
                DataEditor.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void DE_ShowFileInExplorer(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                // MessageBox.Show("");
                if (e.RowIndex != -1)
                    _dataEditorHelper.ShowFileinExplorer((string)DataEditor.Rows[e.RowIndex].Cells[1].Value);
            }
            else
            {
                if (e.RowIndex != -1)
                    _dataEditorHelper.SelectRow();
            }

        }

        private void DE_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _fileSearcher.UpdateCheckInfo();
            }

        }

        private void SortDataByClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _dataEditorHelper.SortData(e.ColumnIndex);

        }



        private void CheckBoxCheck(object sender, EventArgs e)
        {
            _dataEditorHelper.SetCheck(((CheckBox)sender).Checked);

        }

        private void btn_DE_CheckAll_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SetCheck(true);
        }

        private void btn_DE_UNCheckAll_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SetCheck(false);
        }

        private void btn_DE_InvCheck_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.InvCheck();
        }

        private void btn_DE_DeadClear_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.DeadClean();
        }

        private void btn_DE_CleaAll_Click(object sender, EventArgs e)
        {
             _dataEditorHelper.ClearData();
        }

        private void DataEditor_MouseDown(object sender, MouseEventArgs e)
        {
            //DataGridView dataGridView = (DataGridView)sender;
            DataEditor.DragEnter -= new DragEventHandler(DataDragEnter);
            DataEditor.DragDrop -= new DragEventHandler(DE_DragAndDrop);

            if (e.Button == MouseButtons.Middle)
            {
                DragFilesBuffer = _dataEditorHelper.GetSelectedFiles();
                if (DragFilesBuffer.Count > 0)
                {
                    this.DoDragDrop(new DataObject(DataFormats.FileDrop, DragFilesBuffer.ToArray()), DragDropEffects.Copy);

                }
            }

            DataEditor.DragEnter += new DragEventHandler(DataDragEnter);
            DataEditor.DragDrop += new DragEventHandler(DE_DragAndDrop);
            DragFilesBuffer.Clear();
        }

        private void DataEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyData == (Keys.Control | Keys.X))
            {
                _dataEditorHelper.RemoveSelData();
            }

            if (e.KeyData == (Keys.Control | Keys.A))
            {
                _dataEditorHelper.SelAll();
            }

            if (e.KeyData == (Keys.Control | Keys.D))
            {
                _dataEditorHelper.ClearSel();
            }

            if (e.KeyData == (Keys.Control | Keys.I))
            {
                _dataEditorHelper.InvertSel();
            }

            if (e.KeyData == (Keys.Alt | Keys.F))
            {
                _dataEditorHelper.FocusSelection();
            }
            if (e.KeyData == (Keys.Control | Keys.F))
            {
                _dataEditorHelper.OpenSearchForm();
            }


            if (e.KeyData == (Keys.Control | Keys.R))
            {
                _dataEditorHelper.SelectRow();
            }
            
        }

        private void btn_CopyFiles_Click(object sender, EventArgs e)
        {
            
            DataEditor.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (String.IsNullOrEmpty(tb_Out.Text))
            {
                btn_SelOut_Click(sender, e);
            }

            _fileProcessor.CopyFiles();
        }

        private void DE_ClearDead_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.DeadClean();
        }

        private void DE_ClearAll_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.ClearData();
        }

        private void DE_SelRemove_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.RemoveSelData();
        }

        private void DE_SelectAll_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SelAll();
        }

        private void DE_SelectNone_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.ClearSel();
        }

        private void DE_Sel_Invert_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.InvertSel();
        }

        private void DE_Remove_Checked_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.RemoveByCheck(true);
        }

        private void DE_Remove_UnChecked_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.RemoveByCheck(false);
        }

        private void DE_ShowInExp_Click(object sender, EventArgs e)
        {
            if (DataEditor.SelectedCells.Count < 1)
                return;

            if (DataEditor.SelectedCells[0].RowIndex != -1)
                _dataEditorHelper.ShowFileinExplorer((string)DataEditor.Rows[DataEditor.SelectedCells[0].RowIndex].Cells[1].Value);
        }

        private void DE_All_Check_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SetCheck(true);
        }

        private void DE_All_UnCheck_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SetCheck(false);
        }

        private void DE_All_InvCheck_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.InvCheck();
        }

        private void DE_Sel_Check_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SetSelCheck(true, false);
        }

        private void DE_Sel_UnCheck_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SetSelCheck(false, false);
        }

        private void DE_Sel_InvCheck_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SetSelCheck(true, true);
        }

        private void DE_All_Sel_UnChecked_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SelByCheck(false);
        }

        private void DE_All_Sel_Checked_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SelByCheck(true);
        }

        private void DE_ContexMenu_Opening(object sender, CancelEventArgs e)
        {
            DE_Info.Text = _dataEditorHelper.GetSelInfo();
        }

        private void DE_Sel_Focus_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.FocusSelection();
        }

        private void btn_SelByNames_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SelectByNames(_assetNameHelper.GetNames(), (NameMatchModes)_comboBoxHelper.GetNameMatchMode(cmb_NameMatchMode));
        }

        private void btn_CheckByNames_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.CheckByNames(_assetNameHelper.GetNames(), (NameMatchModes)_comboBoxHelper.GetNameMatchMode(cmb_NameMatchMode),true);
        }

        private void btn_UnCheckByNames_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.CheckByNames(_assetNameHelper.GetNames(), (NameMatchModes)_comboBoxHelper.GetNameMatchMode(cmb_NameMatchMode), false);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == (Keys.Control | Keys.F))
            {
                _dataEditorHelper.OpenSearchForm();
                e.Handled = e.SuppressKeyPress = true;
            }

            //if (e.KeyData ==Keys.Escape)
            //{
            //    _fileProcessor.AbortCopy();
            //       e.Handled = e.SuppressKeyPress = true;
            //}
        }

        private void DE_Search_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.OpenSearchForm();
        }

        private void cb_SubFolders_CheckedChanged(object sender, EventArgs e)
        {
            cb_FoldersOnly.Enabled = cb_SubFolders.Checked;
        }

        private void DE_Sel_EntireRow_Click(object sender, EventArgs e)
        {
            _dataEditorHelper.SelectRow();
        }
    }
    }
