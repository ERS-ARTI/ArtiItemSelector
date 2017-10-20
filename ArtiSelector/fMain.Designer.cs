namespace ArtiItemSelector {
    partial class FMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToProject = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tDebug = new System.Windows.Forms.TabPage();
            this.DebugItemDescription = new System.Windows.Forms.TextBox();
            this.DebugTree = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.tTrace = new System.Windows.Forms.TabPage();
            this.TraceItemDescription = new System.Windows.Forms.TextBox();
            this.TraceTree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.tPOI = new System.Windows.Forms.TabPage();
            this.tbPOI = new System.Windows.Forms.TextBox();
            this.tvPOI = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.tImplementer = new System.Windows.Forms.TabPage();
            this.tContent = new System.Windows.Forms.TabPage();
            this.FileView = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbProject = new System.Windows.Forms.Label();
            this.lbSelectedSourceFile = new System.Windows.Forms.Label();
            this.dlgOpenProject = new System.Windows.Forms.OpenFileDialog();
            this.listOfFiles = new System.Windows.Forms.ListBox();
            this.dlgSaveProject = new System.Windows.Forms.SaveFileDialog();
            this.InfoGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tDebug.SuspendLayout();
            this.tTrace.SuspendLayout();
            this.tPOI.SuspendLayout();
            this.tContent.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1145, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem5,
            this.menuSave,
            this.menuSaveAs,
            this.toolStripMenuItem4,
            this.toolStripSeparator1,
            this.addToProject,
            this.removeFromProject,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem2.Text = "&New Project";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.NewProjectClick);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem5.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem5.Text = "&Open Project";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.OpenProjectClick);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSave.Size = new System.Drawing.Size(192, 22);
            this.menuSave.Text = "&Save Project";
            this.menuSave.Click += new System.EventHandler(this.SaveProjectClick);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(192, 22);
            this.menuSaveAs.Text = "Save &As...";
            this.menuSaveAs.Click += new System.EventHandler(this.SaveAsClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem4.Text = "&Close Project";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.CloseProjectClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // addToProject
            // 
            this.addToProject.Name = "addToProject";
            this.addToProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addToProject.Size = new System.Drawing.Size(192, 22);
            this.addToProject.Text = "&Add to project";
            this.addToProject.Click += new System.EventHandler(this.AddSourcesClick);
            // 
            // removeFromProject
            // 
            this.removeFromProject.Name = "removeFromProject";
            this.removeFromProject.Size = new System.Drawing.Size(192, 22);
            this.removeFromProject.Text = "&Remove from project";
            this.removeFromProject.Click += new System.EventHandler(this.RemoveSourceClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(189, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitClick);
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "arti";
            this.dlgOpen.FileName = "*.arti";
            this.dlgOpen.Multiselect = true;
            this.dlgOpen.ReadOnlyChecked = true;
            this.dlgOpen.RestoreDirectory = true;
            this.dlgOpen.Title = "Select source files";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tDebug);
            this.tabControl.Controls.Add(this.tTrace);
            this.tabControl.Controls.Add(this.tPOI);
            this.tabControl.Controls.Add(this.tImplementer);
            this.tabControl.Controls.Add(this.tContent);
            this.tabControl.Location = new System.Drawing.Point(367, 41);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(778, 604);
            this.tabControl.TabIndex = 3;
            // 
            // tDebug
            // 
            this.tDebug.Controls.Add(this.DebugItemDescription);
            this.tDebug.Controls.Add(this.DebugTree);
            this.tDebug.Controls.Add(this.label2);
            this.tDebug.Location = new System.Drawing.Point(4, 22);
            this.tDebug.Name = "tDebug";
            this.tDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tDebug.Size = new System.Drawing.Size(770, 578);
            this.tDebug.TabIndex = 3;
            this.tDebug.Text = "States to monitor";
            this.tDebug.UseVisualStyleBackColor = true;
            // 
            // DebugItemDescription
            // 
            this.DebugItemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugItemDescription.BackColor = System.Drawing.SystemColors.Control;
            this.DebugItemDescription.Location = new System.Drawing.Point(251, 30);
            this.DebugItemDescription.Multiline = true;
            this.DebugItemDescription.Name = "DebugItemDescription";
            this.DebugItemDescription.ReadOnly = true;
            this.DebugItemDescription.Size = new System.Drawing.Size(513, 541);
            this.DebugItemDescription.TabIndex = 5;
            // 
            // DebugTree
            // 
            this.DebugTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DebugTree.Location = new System.Drawing.Point(19, 30);
            this.DebugTree.Name = "DebugTree";
            this.DebugTree.Size = new System.Drawing.Size(226, 541);
            this.DebugTree.TabIndex = 4;
            this.DebugTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.DebugCheckboxChanged);
            this.DebugTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DebugSelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select items to show in debugger";
            // 
            // tTrace
            // 
            this.tTrace.Controls.Add(this.TraceItemDescription);
            this.tTrace.Controls.Add(this.TraceTree);
            this.tTrace.Controls.Add(this.label1);
            this.tTrace.Location = new System.Drawing.Point(4, 22);
            this.tTrace.Name = "tTrace";
            this.tTrace.Padding = new System.Windows.Forms.Padding(3);
            this.tTrace.Size = new System.Drawing.Size(770, 578);
            this.tTrace.TabIndex = 2;
            this.tTrace.Text = "Events to trace";
            this.tTrace.UseVisualStyleBackColor = true;
            // 
            // TraceItemDescription
            // 
            this.TraceItemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TraceItemDescription.BackColor = System.Drawing.SystemColors.Control;
            this.TraceItemDescription.Location = new System.Drawing.Point(251, 30);
            this.TraceItemDescription.Multiline = true;
            this.TraceItemDescription.Name = "TraceItemDescription";
            this.TraceItemDescription.ReadOnly = true;
            this.TraceItemDescription.Size = new System.Drawing.Size(511, 541);
            this.TraceItemDescription.TabIndex = 3;
            // 
            // TraceTree
            // 
            this.TraceTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TraceTree.Location = new System.Drawing.Point(19, 30);
            this.TraceTree.Name = "TraceTree";
            this.TraceTree.Size = new System.Drawing.Size(226, 541);
            this.TraceTree.TabIndex = 2;
            this.TraceTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TraceCheckboxChanged);
            this.TraceTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TraceSelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select events to trace at run-time";
            // 
            // tPOI
            // 
            this.tPOI.Controls.Add(this.tbPOI);
            this.tPOI.Controls.Add(this.tvPOI);
            this.tPOI.Controls.Add(this.label3);
            this.tPOI.Location = new System.Drawing.Point(4, 22);
            this.tPOI.Name = "tPOI";
            this.tPOI.Size = new System.Drawing.Size(770, 578);
            this.tPOI.TabIndex = 5;
            this.tPOI.Text = "Points of Interest";
            this.tPOI.UseVisualStyleBackColor = true;
            // 
            // tbPOI
            // 
            this.tbPOI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPOI.BackColor = System.Drawing.SystemColors.Control;
            this.tbPOI.Location = new System.Drawing.Point(247, 27);
            this.tbPOI.Multiline = true;
            this.tbPOI.Name = "tbPOI";
            this.tbPOI.ReadOnly = true;
            this.tbPOI.Size = new System.Drawing.Size(511, 541);
            this.tbPOI.TabIndex = 6;
            // 
            // tvPOI
            // 
            this.tvPOI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvPOI.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvPOI.Location = new System.Drawing.Point(15, 27);
            this.tvPOI.Name = "tvPOI";
            this.tvPOI.Size = new System.Drawing.Size(226, 541);
            this.tvPOI.TabIndex = 5;
            this.tvPOI.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PoiSelectionChanged);
            this.tvPOI.DoubleClick += new System.EventHandler(this.PoiEditRequest);
            this.tvPOI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PoiKeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Assign names to points of interest";
            // 
            // tImplementer
            // 
            this.tImplementer.Location = new System.Drawing.Point(4, 22);
            this.tImplementer.Name = "tImplementer";
            this.tImplementer.Size = new System.Drawing.Size(770, 578);
            this.tImplementer.TabIndex = 4;
            this.tImplementer.Text = "Implementation parameters";
            this.tImplementer.UseVisualStyleBackColor = true;
            // 
            // tContent
            // 
            this.tContent.Controls.Add(this.FileView);
            this.tContent.Location = new System.Drawing.Point(4, 22);
            this.tContent.Name = "tContent";
            this.tContent.Padding = new System.Windows.Forms.Padding(3);
            this.tContent.Size = new System.Drawing.Size(770, 578);
            this.tContent.TabIndex = 1;
            this.tContent.Text = "ARTI";
            this.tContent.UseVisualStyleBackColor = true;
            // 
            // FileView
            // 
            this.FileView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileView.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileView.ForeColor = System.Drawing.Color.Lime;
            this.FileView.Location = new System.Drawing.Point(3, 3);
            this.FileView.Multiline = true;
            this.FileView.Name = "FileView";
            this.FileView.ReadOnly = true;
            this.FileView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FileView.Size = new System.Drawing.Size(764, 572);
            this.FileView.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbProject);
            this.panel1.Controls.Add(this.lbSelectedSourceFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 651);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 63);
            this.panel1.TabIndex = 5;
            // 
            // lbProject
            // 
            this.lbProject.AutoSize = true;
            this.lbProject.Location = new System.Drawing.Point(4, 22);
            this.lbProject.Name = "lbProject";
            this.lbProject.Size = new System.Drawing.Size(48, 13);
            this.lbProject.TabIndex = 1;
            this.lbProject.Text = "lbProject";
            // 
            // lbSelectedSourceFile
            // 
            this.lbSelectedSourceFile.AutoSize = true;
            this.lbSelectedSourceFile.Location = new System.Drawing.Point(4, 9);
            this.lbSelectedSourceFile.Name = "lbSelectedSourceFile";
            this.lbSelectedSourceFile.Size = new System.Drawing.Size(107, 13);
            this.lbSelectedSourceFile.TabIndex = 0;
            this.lbSelectedSourceFile.Text = "lbSelectedSourceFile";
            // 
            // dlgOpenProject
            // 
            this.dlgOpenProject.DefaultExt = "arti_project";
            this.dlgOpenProject.FileName = "project.arti_project";
            this.dlgOpenProject.Title = "Open project";
            // 
            // listOfFiles
            // 
            this.listOfFiles.FormattingEnabled = true;
            this.listOfFiles.Location = new System.Drawing.Point(7, 41);
            this.listOfFiles.Name = "listOfFiles";
            this.listOfFiles.Size = new System.Drawing.Size(354, 134);
            this.listOfFiles.TabIndex = 1;
            this.listOfFiles.SelectedIndexChanged += new System.EventHandler(this.SourceSelectionChanged);
            // 
            // dlgSaveProject
            // 
            this.dlgSaveProject.DefaultExt = "arti_project";
            this.dlgSaveProject.FileName = "project.arti_project";
            this.dlgSaveProject.OverwritePrompt = false;
            // 
            // InfoGrid
            // 
            this.InfoGrid.AllowUserToAddRows = false;
            this.InfoGrid.AllowUserToDeleteRows = false;
            this.InfoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.InfoGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.InfoGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.InfoGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InfoGrid.CausesValidation = false;
            this.InfoGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.InfoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoGrid.GridColor = System.Drawing.SystemColors.Info;
            this.InfoGrid.Location = new System.Drawing.Point(7, 181);
            this.InfoGrid.Name = "InfoGrid";
            this.InfoGrid.ReadOnly = true;
            this.InfoGrid.Size = new System.Drawing.Size(354, 460);
            this.InfoGrid.TabIndex = 2;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 714);
            this.Controls.Add(this.InfoGrid);
            this.Controls.Add(this.listOfFiles);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMain";
            this.Text = "ARTI Item Selector";
            this.Shown += new System.EventHandler(this.FMainShown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tDebug.ResumeLayout(false);
            this.tDebug.PerformLayout();
            this.tTrace.ResumeLayout(false);
            this.tTrace.PerformLayout();
            this.tPOI.ResumeLayout(false);
            this.tPOI.PerformLayout();
            this.tContent.ResumeLayout(false);
            this.tContent.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToProject;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tContent;
        private System.Windows.Forms.TextBox FileView;
        //private System.Windows.Forms.DataGridViewTextBoxColumn MetaName;
        //private System.Windows.Forms.DataGridViewTextBoxColumn MetaValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tTrace;
        private System.Windows.Forms.TabPage tDebug;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem removeFromProject;
        private System.Windows.Forms.OpenFileDialog dlgOpenProject;
        private System.Windows.Forms.ListBox listOfFiles;
        private System.Windows.Forms.Label lbSelectedSourceFile;
        private System.Windows.Forms.SaveFileDialog dlgSaveProject;
        private System.Windows.Forms.Label lbProject;
        private System.Windows.Forms.TreeView TraceTree;
        private System.Windows.Forms.TreeView DebugTree;
        private System.Windows.Forms.TextBox TraceItemDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DebugItemDescription;
        private System.Windows.Forms.TabPage tImplementer;
        private System.Windows.Forms.DataGridView InfoGrid;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.TabPage tPOI;
        private System.Windows.Forms.TextBox tbPOI;
        private System.Windows.Forms.TreeView tvPOI;
        private System.Windows.Forms.Label label3;
    }
}

