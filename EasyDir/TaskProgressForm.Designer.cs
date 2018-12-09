namespace EasyDir
{
    partial class TaskProgressForm
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
            this.tl_MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pb_Staticstic = new System.Windows.Forms.ProgressBar();
            this.lb_CurrStage = new System.Windows.Forms.Label();
            this.btn_Abort = new System.Windows.Forms.Button();
            this.tl_MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tl_MainPanel
            // 
            this.tl_MainPanel.ColumnCount = 1;
            this.tl_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl_MainPanel.Controls.Add(this.pb_Staticstic, 0, 1);
            this.tl_MainPanel.Controls.Add(this.lb_CurrStage, 0, 0);
            this.tl_MainPanel.Controls.Add(this.btn_Abort, 0, 2);
            this.tl_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl_MainPanel.Location = new System.Drawing.Point(0, 0);
            this.tl_MainPanel.Name = "tl_MainPanel";
            this.tl_MainPanel.RowCount = 3;
            this.tl_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tl_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tl_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tl_MainPanel.Size = new System.Drawing.Size(234, 111);
            this.tl_MainPanel.TabIndex = 0;
            // 
            // pb_Staticstic
            // 
            this.pb_Staticstic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Staticstic.Location = new System.Drawing.Point(10, 37);
            this.pb_Staticstic.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pb_Staticstic.Name = "pb_Staticstic";
            this.pb_Staticstic.Size = new System.Drawing.Size(214, 23);
            this.pb_Staticstic.TabIndex = 0;
            // 
            // lb_CurrStage
            // 
            this.lb_CurrStage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_CurrStage.AutoSize = true;
            this.lb_CurrStage.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lb_CurrStage.ForeColor = System.Drawing.Color.Turquoise;
            this.lb_CurrStage.Location = new System.Drawing.Point(5, 10);
            this.lb_CurrStage.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lb_CurrStage.Name = "lb_CurrStage";
            this.lb_CurrStage.Size = new System.Drawing.Size(224, 17);
            this.lb_CurrStage.TabIndex = 1;
            this.lb_CurrStage.Text = "File Searching";
            this.lb_CurrStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Abort
            // 
            this.btn_Abort.AutoSize = true;
            this.btn_Abort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.btn_Abort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Abort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Abort.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_Abort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Abort.Location = new System.Drawing.Point(5, 70);
            this.btn_Abort.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.btn_Abort.Name = "btn_Abort";
            this.btn_Abort.Size = new System.Drawing.Size(224, 31);
            this.btn_Abort.TabIndex = 14;
            this.btn_Abort.Text = "Abort";
            this.btn_Abort.UseVisualStyleBackColor = false;
            // 
            // TaskProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(234, 111);
            this.Controls.Add(this.tl_MainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TaskProgressForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processing ...";
            this.Load += new System.EventHandler(this.TaskProgressForm_Load);
            this.tl_MainPanel.ResumeLayout(false);
            this.tl_MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tl_MainPanel;
        private System.Windows.Forms.ProgressBar pb_Staticstic;
        private System.Windows.Forms.Label lb_CurrStage;
        private System.Windows.Forms.Button btn_Abort;
    }
}