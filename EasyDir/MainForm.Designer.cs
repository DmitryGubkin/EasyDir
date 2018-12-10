namespace EasyDir
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tb_Out = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SelOut = new System.Windows.Forms.Button();
            this.btn_SearchAssets = new System.Windows.Forms.Button();
            this.tp_in = new System.Windows.Forms.TableLayoutPanel();
            this.btn_SeTopRoot = new System.Windows.Forms.Button();
            this.tb_TopRoot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_In = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_SelIn = new System.Windows.Forms.Button();
            this.btn_MakeFolders = new System.Windows.Forms.Button();
            this.tb_AssetName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cb_SearchMode = new System.Windows.Forms.ComboBox();
            this.cb_NameMatchMode = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_RemoveName = new System.Windows.Forms.Button();
            this.btn_AddName = new System.Windows.Forms.Button();
            this.cbl_Names = new System.Windows.Forms.CheckedListBox();
            this.AN_ContexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AN_AddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.AN_QuickNameEditor = new System.Windows.Forms.ToolStripTextBox();
            this.AN_QNESeparator = new System.Windows.Forms.ToolStripSeparator();
            this.AN_CheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.AN_UnCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.AN_InvertAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.AN_RemoveSel = new System.Windows.Forms.ToolStripMenuItem();
            this.AN_RemoveCheked = new System.Windows.Forms.ToolStripMenuItem();
            this.AN_ClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.DataEditor = new System.Windows.Forms.DataGridView();
            this.MainContexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolOpenSourceFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOpenOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPreviewPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Col_Cheked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Col_FullPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Ext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tp_in.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.AN_ContexMenu.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataEditor)).BeginInit();
            this.MainContexMenu.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Out
            // 
            this.tb_Out.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Out.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.tb_Out.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_Out.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tb_Out.Location = new System.Drawing.Point(91, 54);
            this.tb_Out.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Out.Name = "tb_Out";
            this.tb_Out.Size = new System.Drawing.Size(484, 24);
            this.tb_Out.TabIndex = 1;
            this.tb_Out.MouseEnter += new System.EventHandler(this.tb_Out_MouseEnter);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Turquoise;
            this.label1.Location = new System.Drawing.Point(5, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Out :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_SelOut
            // 
            this.btn_SelOut.AutoSize = true;
            this.btn_SelOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.btn_SelOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SelOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SelOut.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_SelOut.ForeColor = System.Drawing.Color.Turquoise;
            this.btn_SelOut.Location = new System.Drawing.Point(580, 54);
            this.btn_SelOut.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btn_SelOut.Name = "btn_SelOut";
            this.btn_SelOut.Size = new System.Drawing.Size(111, 24);
            this.btn_SelOut.TabIndex = 2;
            this.btn_SelOut.Text = "Select ...";
            this.btn_SelOut.UseVisualStyleBackColor = false;
            this.btn_SelOut.Click += new System.EventHandler(this.btn_SelOut_Click);
            // 
            // btn_SearchAssets
            // 
            this.btn_SearchAssets.AutoSize = true;
            this.btn_SearchAssets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.tableLayoutPanel4.SetColumnSpan(this.btn_SearchAssets, 2);
            this.btn_SearchAssets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SearchAssets.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SearchAssets.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_SearchAssets.ForeColor = System.Drawing.Color.Turquoise;
            this.btn_SearchAssets.Location = new System.Drawing.Point(0, 67);
            this.btn_SearchAssets.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btn_SearchAssets.Name = "btn_SearchAssets";
            this.btn_SearchAssets.Size = new System.Drawing.Size(232, 29);
            this.btn_SearchAssets.TabIndex = 3;
            this.btn_SearchAssets.Text = "Search in Source";
            this.btn_SearchAssets.UseVisualStyleBackColor = false;
            this.btn_SearchAssets.Click += new System.EventHandler(this.btn_SearchAssets_Click);
            // 
            // tp_in
            // 
            this.tp_in.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tp_in.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tp_in.ColumnCount = 4;
            this.tp_in.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tp_in.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tp_in.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tp_in.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tp_in.Controls.Add(this.btn_SelOut, 2, 2);
            this.tp_in.Controls.Add(this.tb_Out, 1, 2);
            this.tp_in.Controls.Add(this.label1, 0, 2);
            this.tp_in.Controls.Add(this.btn_SeTopRoot, 2, 1);
            this.tp_in.Controls.Add(this.tb_TopRoot, 1, 1);
            this.tp_in.Controls.Add(this.label3, 0, 1);
            this.tp_in.Controls.Add(this.tb_In, 1, 0);
            this.tp_in.Controls.Add(this.label2, 0, 0);
            this.tp_in.Controls.Add(this.btn_SelIn, 2, 0);
            this.tp_in.Controls.Add(this.btn_MakeFolders, 3, 0);
            this.tp_in.Location = new System.Drawing.Point(9, 9);
            this.tp_in.Margin = new System.Windows.Forms.Padding(0);
            this.tp_in.Name = "tp_in";
            this.tp_in.RowCount = 3;
            this.tp_in.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tp_in.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tp_in.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tp_in.Size = new System.Drawing.Size(766, 80);
            this.tp_in.TabIndex = 0;
            // 
            // btn_SeTopRoot
            // 
            this.btn_SeTopRoot.AutoSize = true;
            this.btn_SeTopRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.btn_SeTopRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SeTopRoot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SeTopRoot.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_SeTopRoot.ForeColor = System.Drawing.Color.Turquoise;
            this.btn_SeTopRoot.Location = new System.Drawing.Point(580, 28);
            this.btn_SeTopRoot.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btn_SeTopRoot.Name = "btn_SeTopRoot";
            this.btn_SeTopRoot.Size = new System.Drawing.Size(111, 22);
            this.btn_SeTopRoot.TabIndex = 4;
            this.btn_SeTopRoot.Text = "Select ...";
            this.btn_SeTopRoot.UseVisualStyleBackColor = false;
            this.btn_SeTopRoot.Click += new System.EventHandler(this.btn_SeTopRoot_Click);
            // 
            // tb_TopRoot
            // 
            this.tb_TopRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_TopRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.tb_TopRoot.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_TopRoot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tb_TopRoot.Location = new System.Drawing.Point(91, 27);
            this.tb_TopRoot.Margin = new System.Windows.Forms.Padding(0);
            this.tb_TopRoot.Name = "tb_TopRoot";
            this.tb_TopRoot.Size = new System.Drawing.Size(484, 24);
            this.tb_TopRoot.TabIndex = 3;
            this.tb_TopRoot.MouseEnter += new System.EventHandler(this.tb_TopRoot_MouseEnter);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Turquoise;
            this.label3.Location = new System.Drawing.Point(5, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Top Root :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_In
            // 
            this.tb_In.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_In.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.tb_In.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_In.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tb_In.Location = new System.Drawing.Point(91, 1);
            this.tb_In.Margin = new System.Windows.Forms.Padding(0);
            this.tb_In.Name = "tb_In";
            this.tb_In.Size = new System.Drawing.Size(484, 24);
            this.tb_In.TabIndex = 1;
            this.tb_In.MouseEnter += new System.EventHandler(this.tb_In_MouseEnter);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Turquoise;
            this.label2.Location = new System.Drawing.Point(5, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Source :   ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_SelIn
            // 
            this.btn_SelIn.AutoSize = true;
            this.btn_SelIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.btn_SelIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SelIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SelIn.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_SelIn.ForeColor = System.Drawing.Color.Turquoise;
            this.btn_SelIn.Location = new System.Drawing.Point(580, 2);
            this.btn_SelIn.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btn_SelIn.Name = "btn_SelIn";
            this.btn_SelIn.Size = new System.Drawing.Size(111, 22);
            this.btn_SelIn.TabIndex = 2;
            this.btn_SelIn.Text = "Select ...";
            this.btn_SelIn.UseVisualStyleBackColor = false;
            this.btn_SelIn.Click += new System.EventHandler(this.btn_SelIn_Click);
            // 
            // btn_MakeFolders
            // 
            this.btn_MakeFolders.AutoSize = true;
            this.btn_MakeFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.btn_MakeFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_MakeFolders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_MakeFolders.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_MakeFolders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_MakeFolders.Location = new System.Drawing.Point(696, 2);
            this.btn_MakeFolders.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.btn_MakeFolders.Name = "btn_MakeFolders";
            this.tp_in.SetRowSpan(this.btn_MakeFolders, 3);
            this.btn_MakeFolders.Size = new System.Drawing.Size(67, 76);
            this.btn_MakeFolders.TabIndex = 2;
            this.btn_MakeFolders.Text = "Make Folders";
            this.btn_MakeFolders.UseVisualStyleBackColor = false;
            this.btn_MakeFolders.Click += new System.EventHandler(this.btn_MakeFolders_Click);
            // 
            // tb_AssetName
            // 
            this.tb_AssetName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.tableLayoutPanel4.SetColumnSpan(this.tb_AssetName, 2);
            this.tb_AssetName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_AssetName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_AssetName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tb_AssetName.Location = new System.Drawing.Point(0, 0);
            this.tb_AssetName.Margin = new System.Windows.Forms.Padding(0);
            this.tb_AssetName.Name = "tb_AssetName";
            this.tb_AssetName.Size = new System.Drawing.Size(232, 24);
            this.tb_AssetName.TabIndex = 12;
            this.tb_AssetName.Text = "Asset_Name";
            this.tb_AssetName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_AssetName.Validated += new System.EventHandler(this.tb_AssetName_Validated);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(760, 372);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cb_SearchMode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cb_NameMatchMode, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbl_Names, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(519, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(238, 366);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cb_SearchMode
            // 
            this.cb_SearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_SearchMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cb_SearchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SearchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_SearchMode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cb_SearchMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cb_SearchMode.FormattingEnabled = true;
            this.cb_SearchMode.Location = new System.Drawing.Point(5, 0);
            this.cb_SearchMode.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.cb_SearchMode.Name = "cb_SearchMode";
            this.cb_SearchMode.Size = new System.Drawing.Size(228, 24);
            this.cb_SearchMode.TabIndex = 1;
            // 
            // cb_NameMatchMode
            // 
            this.cb_NameMatchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_NameMatchMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cb_NameMatchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_NameMatchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_NameMatchMode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cb_NameMatchMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cb_NameMatchMode.FormattingEnabled = true;
            this.cb_NameMatchMode.Location = new System.Drawing.Point(5, 29);
            this.cb_NameMatchMode.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.cb_NameMatchMode.Name = "cb_NameMatchMode";
            this.cb_NameMatchMode.Size = new System.Drawing.Size(228, 24);
            this.cb_NameMatchMode.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btn_RemoveName, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.btn_SearchAssets, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tb_AssetName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_AddName, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 267);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.16667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.41667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(232, 96);
            this.tableLayoutPanel4.TabIndex = 12;
            // 
            // btn_RemoveName
            // 
            this.btn_RemoveName.AutoSize = true;
            this.btn_RemoveName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.btn_RemoveName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_RemoveName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RemoveName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_RemoveName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_RemoveName.Location = new System.Drawing.Point(121, 33);
            this.btn_RemoveName.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btn_RemoveName.Name = "btn_RemoveName";
            this.btn_RemoveName.Size = new System.Drawing.Size(111, 29);
            this.btn_RemoveName.TabIndex = 13;
            this.btn_RemoveName.Text = "Remove";
            this.btn_RemoveName.UseVisualStyleBackColor = false;
            this.btn_RemoveName.Click += new System.EventHandler(this.btn_RemoveName_Click);
            // 
            // btn_AddName
            // 
            this.btn_AddName.AutoSize = true;
            this.btn_AddName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.btn_AddName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_AddName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_AddName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_AddName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_AddName.Location = new System.Drawing.Point(0, 33);
            this.btn_AddName.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.btn_AddName.Name = "btn_AddName";
            this.btn_AddName.Size = new System.Drawing.Size(111, 29);
            this.btn_AddName.TabIndex = 14;
            this.btn_AddName.Text = "Add";
            this.btn_AddName.UseVisualStyleBackColor = false;
            this.btn_AddName.Click += new System.EventHandler(this.btn_AddName_Click);
            // 
            // cbl_Names
            // 
            this.cbl_Names.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cbl_Names.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbl_Names.ContextMenuStrip = this.AN_ContexMenu;
            this.cbl_Names.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbl_Names.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbl_Names.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cbl_Names.FormattingEnabled = true;
            this.cbl_Names.HorizontalScrollbar = true;
            this.cbl_Names.Items.AddRange(new object[] {
            "Asset_Name"});
            this.cbl_Names.Location = new System.Drawing.Point(5, 58);
            this.cbl_Names.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.cbl_Names.Name = "cbl_Names";
            this.cbl_Names.Size = new System.Drawing.Size(228, 206);
            this.cbl_Names.TabIndex = 11;
            this.cbl_Names.SelectedIndexChanged += new System.EventHandler(this.cbl_Names_SelectedIndexChanged);
            this.cbl_Names.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbl_Names_KeyDown);
            this.cbl_Names.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbl_Names_MouseDown);
            // 
            // AN_ContexMenu
            // 
            this.AN_ContexMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.AN_ContexMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AN_ContexMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AN_ContexMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.AN_ContexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AN_AddNode,
            this.AN_QuickNameEditor,
            this.AN_QNESeparator,
            this.AN_CheckAll,
            this.AN_UnCheckAll,
            this.AN_InvertAll,
            this.toolStripSeparator2,
            this.AN_RemoveSel,
            this.AN_RemoveCheked,
            this.AN_ClearAll});
            this.AN_ContexMenu.Name = "ImgContexMenu";
            this.AN_ContexMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.AN_ContexMenu.ShowImageMargin = false;
            this.AN_ContexMenu.Size = new System.Drawing.Size(200, 196);
            this.AN_ContexMenu.Opening += new System.ComponentModel.CancelEventHandler(this.AN_ContexMenu_Opening);
            // 
            // AN_AddNode
            // 
            this.AN_AddNode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AN_AddNode.Name = "AN_AddNode";
            this.AN_AddNode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.AN_AddNode.Size = new System.Drawing.Size(199, 22);
            this.AN_AddNode.Text = "Add Name Pattern";
            this.AN_AddNode.Click += new System.EventHandler(this.AN_AddNode_Click);
            // 
            // AN_QuickNameEditor
            // 
            this.AN_QuickNameEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.AN_QuickNameEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AN_QuickNameEditor.Font = new System.Drawing.Font("Tahoma", 10F);
            this.AN_QuickNameEditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.AN_QuickNameEditor.Name = "AN_QuickNameEditor";
            this.AN_QuickNameEditor.Size = new System.Drawing.Size(150, 24);
            this.AN_QuickNameEditor.Text = "Asset_Name";
            this.AN_QuickNameEditor.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AN_QuickNameEditor.ToolTipText = "Quick Name Pattern Edit\r\nEnter - Rename\r\nSpace - Rename and Close\r\n";
            this.AN_QuickNameEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AN_QuickNameEditor_KeyDown);
            this.AN_QuickNameEditor.Validated += new System.EventHandler(this.toolStripTextBox1_Validated);
            // 
            // AN_QNESeparator
            // 
            this.AN_QNESeparator.Name = "AN_QNESeparator";
            this.AN_QNESeparator.Size = new System.Drawing.Size(196, 6);
            // 
            // AN_CheckAll
            // 
            this.AN_CheckAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AN_CheckAll.ForeColor = System.Drawing.Color.Turquoise;
            this.AN_CheckAll.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.AN_CheckAll.Name = "AN_CheckAll";
            this.AN_CheckAll.ShowShortcutKeys = false;
            this.AN_CheckAll.Size = new System.Drawing.Size(199, 22);
            this.AN_CheckAll.Text = "Check All";
            this.AN_CheckAll.Click += new System.EventHandler(this.AN_CheckAll_Click);
            // 
            // AN_UnCheckAll
            // 
            this.AN_UnCheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AN_UnCheckAll.ForeColor = System.Drawing.Color.Turquoise;
            this.AN_UnCheckAll.Name = "AN_UnCheckAll";
            this.AN_UnCheckAll.ShowShortcutKeys = false;
            this.AN_UnCheckAll.Size = new System.Drawing.Size(199, 22);
            this.AN_UnCheckAll.Text = "UnCheck All";
            this.AN_UnCheckAll.Click += new System.EventHandler(this.AN_UnCheckAll_Click);
            // 
            // AN_InvertAll
            // 
            this.AN_InvertAll.ForeColor = System.Drawing.Color.Turquoise;
            this.AN_InvertAll.Name = "AN_InvertAll";
            this.AN_InvertAll.Size = new System.Drawing.Size(199, 22);
            this.AN_InvertAll.Text = "Invert All";
            this.AN_InvertAll.Click += new System.EventHandler(this.AN_InvertAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // AN_RemoveSel
            // 
            this.AN_RemoveSel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.AN_RemoveSel.Name = "AN_RemoveSel";
            this.AN_RemoveSel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.AN_RemoveSel.Size = new System.Drawing.Size(199, 22);
            this.AN_RemoveSel.Text = "Remove Selected";
            this.AN_RemoveSel.Click += new System.EventHandler(this.AN_RemoveSel_Click);
            // 
            // AN_RemoveCheked
            // 
            this.AN_RemoveCheked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.AN_RemoveCheked.Name = "AN_RemoveCheked";
            this.AN_RemoveCheked.Size = new System.Drawing.Size(199, 22);
            this.AN_RemoveCheked.Text = "Remove All Cheked";
            this.AN_RemoveCheked.Click += new System.EventHandler(this.AN_RemoveCheked_Click);
            // 
            // AN_ClearAll
            // 
            this.AN_ClearAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.AN_ClearAll.Name = "AN_ClearAll";
            this.AN_ClearAll.Size = new System.Drawing.Size(199, 22);
            this.AN_ClearAll.Text = "Clear List";
            this.AN_ClearAll.Click += new System.EventHandler(this.AN_ClearAll_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.DataEditor, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.666667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.46667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.80282F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(510, 366);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // DataEditor
            // 
            this.DataEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataEditor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.DataEditor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataEditor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataEditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataEditor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Cheked,
            this.Col_FullPath,
            this.Col_Name,
            this.Col_Ext});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataEditor.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataEditor.Location = new System.Drawing.Point(3, 12);
            this.DataEditor.Name = "DataEditor";
            this.DataEditor.Size = new System.Drawing.Size(504, 299);
            this.DataEditor.TabIndex = 1;
            // 
            // MainContexMenu
            // 
            this.MainContexMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.MainContexMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainContexMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainContexMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainContexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpenSourceFolder,
            this.toolOpenOut,
            this.toolStripSeparator1,
            this.toolPreviewPath});
            this.MainContexMenu.Name = "ImgContexMenu";
            this.MainContexMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainContexMenu.Size = new System.Drawing.Size(227, 76);
            // 
            // toolOpenSourceFolder
            // 
            this.toolOpenSourceFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolOpenSourceFolder.ForeColor = System.Drawing.Color.Turquoise;
            this.toolOpenSourceFolder.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolOpenSourceFolder.Name = "toolOpenSourceFolder";
            this.toolOpenSourceFolder.ShowShortcutKeys = false;
            this.toolOpenSourceFolder.Size = new System.Drawing.Size(226, 22);
            this.toolOpenSourceFolder.Text = "Show Source In Explorer ...";
            this.toolOpenSourceFolder.Click += new System.EventHandler(this.toolOpenSourceFolder_Click);
            // 
            // toolOpenOut
            // 
            this.toolOpenOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolOpenOut.ForeColor = System.Drawing.Color.Turquoise;
            this.toolOpenOut.Name = "toolOpenOut";
            this.toolOpenOut.ShowShortcutKeys = false;
            this.toolOpenOut.Size = new System.Drawing.Size(226, 22);
            this.toolOpenOut.Text = "Show Out In Explorer ...";
            this.toolOpenOut.Click += new System.EventHandler(this.toolOpenOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // toolPreviewPath
            // 
            this.toolPreviewPath.ForeColor = System.Drawing.Color.Turquoise;
            this.toolPreviewPath.Name = "toolPreviewPath";
            this.toolPreviewPath.Size = new System.Drawing.Size(226, 22);
            this.toolPreviewPath.Text = "Preview Final Path";
            this.toolPreviewPath.Click += new System.EventHandler(this.toolPreviewPath_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 101);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(766, 378);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // Col_Cheked
            // 
            this.Col_Cheked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Col_Cheked.HeaderText = "";
            this.Col_Cheked.MinimumWidth = 50;
            this.Col_Cheked.Name = "Col_Cheked";
            this.Col_Cheked.Width = 50;
            // 
            // Col_FullPath
            // 
            this.Col_FullPath.HeaderText = "Full Path";
            this.Col_FullPath.Name = "Col_FullPath";
            this.Col_FullPath.ReadOnly = true;
            // 
            // Col_Name
            // 
            this.Col_Name.HeaderText = "Name";
            this.Col_Name.Name = "Col_Name";
            // 
            // Col_Ext
            // 
            this.Col_Ext.HeaderText = ".*";
            this.Col_Ext.Name = "Col_Ext";
            this.Col_Ext.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(784, 491);
            this.ContextMenuStrip = this.MainContexMenu;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tp_in);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 530);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasyDir";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tp_in.ResumeLayout(false);
            this.tp_in.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.AN_ContexMenu.ResumeLayout(false);
            this.AN_ContexMenu.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataEditor)).EndInit();
            this.MainContexMenu.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tb_Out;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SelOut;
        private System.Windows.Forms.TableLayoutPanel tp_in;
        private System.Windows.Forms.Button btn_SelIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_In;
        private System.Windows.Forms.Button btn_SeTopRoot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_AssetName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckedListBox cbl_Names;
        private System.Windows.Forms.Button btn_AddName;
        private System.Windows.Forms.Button btn_RemoveName;
        private System.Windows.Forms.TextBox tb_TopRoot;
        private System.Windows.Forms.ContextMenuStrip MainContexMenu;
        private System.Windows.Forms.ToolStripMenuItem toolOpenSourceFolder;
        private System.Windows.Forms.ToolStripMenuItem toolOpenOut;
        private System.Windows.Forms.ToolStripMenuItem toolPreviewPath;
        private System.Windows.Forms.Button btn_SearchAssets;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip AN_ContexMenu;
        private System.Windows.Forms.ToolStripMenuItem AN_CheckAll;
        private System.Windows.Forms.ToolStripMenuItem AN_UnCheckAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem AN_RemoveCheked;
        private System.Windows.Forms.ToolStripMenuItem AN_ClearAll;
        private System.Windows.Forms.ToolStripTextBox AN_QuickNameEditor;
        private System.Windows.Forms.ToolStripSeparator AN_QNESeparator;
        private System.Windows.Forms.ToolStripMenuItem AN_InvertAll;
        private System.Windows.Forms.ToolStripMenuItem AN_RemoveSel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cb_SearchMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridView DataEditor;
        private System.Windows.Forms.ComboBox cb_NameMatchMode;
        private System.Windows.Forms.Button btn_MakeFolders;
        private System.Windows.Forms.ToolStripMenuItem AN_AddNode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Col_Cheked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_FullPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Ext;
    }
}

