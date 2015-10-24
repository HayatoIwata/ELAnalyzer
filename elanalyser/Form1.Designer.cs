namespace elanalyser
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OpenButton = new System.Windows.Forms.Button();
            this.OpenRegistDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.UserRythm = new System.Windows.Forms.TabPage();
            this.SaveAllSFF = new System.Windows.Forms.Button();
            this.SaveSelectedSFF = new System.Windows.Forms.Button();
            this.UserRythmList = new System.Windows.Forms.ListView();
            this.UserNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SFFStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SFFSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserRythmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RenameAndSaveSFF = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadSFF = new System.Windows.Forms.ToolStripMenuItem();
            this.InitializeSFF = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSFFFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveSFFDialog = new System.Windows.Forms.SaveFileDialog();
            this.MainTab.SuspendLayout();
            this.UserRythm.SuspendLayout();
            this.UserRythmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(371, 18);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(46, 25);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "開く";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // OpenRegistDialog
            // 
            this.OpenRegistDialog.Filter = "ELレジストファイル (*.B00)|*.B00";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(343, 19);
            this.textBox1.TabIndex = 2;
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.UserRythm);
            this.MainTab.Location = new System.Drawing.Point(17, 55);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(400, 381);
            this.MainTab.TabIndex = 3;
            // 
            // UserRythm
            // 
            this.UserRythm.Controls.Add(this.SaveAllSFF);
            this.UserRythm.Controls.Add(this.SaveSelectedSFF);
            this.UserRythm.Controls.Add(this.UserRythmList);
            this.UserRythm.Location = new System.Drawing.Point(4, 22);
            this.UserRythm.Name = "UserRythm";
            this.UserRythm.Padding = new System.Windows.Forms.Padding(3);
            this.UserRythm.Size = new System.Drawing.Size(392, 355);
            this.UserRythm.TabIndex = 0;
            this.UserRythm.Text = "ユーザーリズム";
            this.UserRythm.UseVisualStyleBackColor = true;
            // 
            // SaveAllSFF
            // 
            this.SaveAllSFF.Enabled = false;
            this.SaveAllSFF.Location = new System.Drawing.Point(204, 318);
            this.SaveAllSFF.Name = "SaveAllSFF";
            this.SaveAllSFF.Size = new System.Drawing.Size(174, 22);
            this.SaveAllSFF.TabIndex = 2;
            this.SaveAllSFF.Text = "空でないすべてのリズムを保存";
            this.SaveAllSFF.UseVisualStyleBackColor = true;
            this.SaveAllSFF.Click += new System.EventHandler(this.SaveAllSFF_Click);
            // 
            // SaveSelectedSFF
            // 
            this.SaveSelectedSFF.Enabled = false;
            this.SaveSelectedSFF.Location = new System.Drawing.Point(13, 318);
            this.SaveSelectedSFF.Name = "SaveSelectedSFF";
            this.SaveSelectedSFF.Size = new System.Drawing.Size(174, 23);
            this.SaveSelectedSFF.TabIndex = 1;
            this.SaveSelectedSFF.Text = "選択されたリズムを保存";
            this.SaveSelectedSFF.UseVisualStyleBackColor = true;
            this.SaveSelectedSFF.Click += new System.EventHandler(this.SaveSelectedSFF_Click);
            // 
            // UserRythmList
            // 
            this.UserRythmList.AutoArrange = false;
            this.UserRythmList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserNumber,
            this.SFFStatus,
            this.SFFSize});
            this.UserRythmList.ContextMenuStrip = this.UserRythmMenu;
            this.UserRythmList.FullRowSelect = true;
            this.UserRythmList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.UserRythmList.HideSelection = false;
            this.UserRythmList.LabelWrap = false;
            this.UserRythmList.Location = new System.Drawing.Point(13, 17);
            this.UserRythmList.Name = "UserRythmList";
            this.UserRythmList.ShowGroups = false;
            this.UserRythmList.Size = new System.Drawing.Size(365, 287);
            this.UserRythmList.TabIndex = 0;
            this.UserRythmList.UseCompatibleStateImageBehavior = false;
            this.UserRythmList.View = System.Windows.Forms.View.Details;
            // 
            // UserNumber
            // 
            this.UserNumber.Text = "ユーザーNo.";
            this.UserNumber.Width = 70;
            // 
            // SFFStatus
            // 
            this.SFFStatus.Text = "状態";
            this.SFFStatus.Width = 210;
            // 
            // SFFSize
            // 
            this.SFFSize.Text = "サイズ";
            this.SFFSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UserRythmMenu
            // 
            this.UserRythmMenu.AllowMerge = false;
            this.UserRythmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenameAndSaveSFF,
            this.ReadSFF,
            this.InitializeSFF});
            this.UserRythmMenu.Name = "UserRythmMenu";
            this.UserRythmMenu.ShowImageMargin = false;
            this.UserRythmMenu.Size = new System.Drawing.Size(138, 70);
            // 
            // RenameAndSaveSFF
            // 
            this.RenameAndSaveSFF.Enabled = false;
            this.RenameAndSaveSFF.Name = "RenameAndSaveSFF";
            this.RenameAndSaveSFF.Size = new System.Drawing.Size(137, 22);
            this.RenameAndSaveSFF.Text = "名前を付けて保存";
            this.RenameAndSaveSFF.Click += new System.EventHandler(this.RenameAndSaveSFF_Click);
            // 
            // ReadSFF
            // 
            this.ReadSFF.Enabled = false;
            this.ReadSFF.Name = "ReadSFF";
            this.ReadSFF.Size = new System.Drawing.Size(137, 22);
            this.ReadSFF.Text = "読み込み";
            // 
            // InitializeSFF
            // 
            this.InitializeSFF.Enabled = false;
            this.InitializeSFF.Name = "InitializeSFF";
            this.InitializeSFF.Size = new System.Drawing.Size(137, 22);
            this.InitializeSFF.Text = "削除";
            // 
            // SaveSFFFolderDialog
            // 
            this.SaveSFFFolderDialog.Description = "出力先フォルダーを選択してください。";
            // 
            // SaveSFFDialog
            // 
            this.SaveSFFDialog.DefaultExt = "*.sty";
            this.SaveSFFDialog.Filter = "スタイルファイル|*.sty|すべてのファイル|*.*";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 451);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.OpenButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EL Data Analyzer v1.01";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.MainTab.ResumeLayout(false);
            this.UserRythm.ResumeLayout(false);
            this.UserRythmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.OpenFileDialog OpenRegistDialog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage UserRythm;
        private System.Windows.Forms.ListView UserRythmList;
        private System.Windows.Forms.ColumnHeader UserNumber;
        private System.Windows.Forms.ColumnHeader SFFStatus;
        private System.Windows.Forms.ColumnHeader SFFSize;
        private System.Windows.Forms.Button SaveAllSFF;
        private System.Windows.Forms.Button SaveSelectedSFF;
        private System.Windows.Forms.FolderBrowserDialog SaveSFFFolderDialog;
        private System.Windows.Forms.SaveFileDialog SaveSFFDialog;
        private System.Windows.Forms.ContextMenuStrip UserRythmMenu;
        private System.Windows.Forms.ToolStripMenuItem RenameAndSaveSFF;
        private System.Windows.Forms.ToolStripMenuItem ReadSFF;
        private System.Windows.Forms.ToolStripMenuItem InitializeSFF;
    }
}

