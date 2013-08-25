namespace StartupDelayer
{
    partial class FormMain
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
            this.ProgramList = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgramContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonAddProgram = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramList)).BeginInit();
            this.ProgramContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgramList
            // 
            this.ProgramList.AllowUserToAddRows = false;
            this.ProgramList.AllowUserToDeleteRows = false;
            this.ProgramList.AllowUserToResizeRows = false;
            this.ProgramList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgramList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProgramList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.ProgramList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProgramList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColDelay,
            this.ColPath});
            this.ProgramList.ContextMenuStrip = this.ProgramContextMenu;
            this.ProgramList.Location = new System.Drawing.Point(12, 12);
            this.ProgramList.Name = "ProgramList";
            this.ProgramList.ReadOnly = true;
            this.ProgramList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProgramList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProgramList.ShowEditingIcon = false;
            this.ProgramList.Size = new System.Drawing.Size(460, 359);
            this.ProgramList.TabIndex = 0;
            this.ProgramList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProgramList_CellDoubleClick);
            this.ProgramList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ProgramList_CellMouseUp);
            // 
            // ColName
            // 
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColDelay
            // 
            this.ColDelay.HeaderText = "Delay (sec)";
            this.ColDelay.Name = "ColDelay";
            this.ColDelay.ReadOnly = true;
            // 
            // ColPath
            // 
            this.ColPath.HeaderText = "Path";
            this.ColPath.Name = "ColPath";
            this.ColPath.ReadOnly = true;
            // 
            // ProgramContextMenu
            // 
            this.ProgramContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemDelete});
            this.ProgramContextMenu.Name = "ProgramContextMenu";
            this.ProgramContextMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // ItemDelete
            // 
            this.ItemDelete.Name = "ItemDelete";
            this.ItemDelete.Size = new System.Drawing.Size(107, 22);
            this.ItemDelete.Text = "Delete";
            this.ItemDelete.Click += new System.EventHandler(this.ItemDelete_Click);
            // 
            // ButtonAddProgram
            // 
            this.ButtonAddProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddProgram.Location = new System.Drawing.Point(256, 377);
            this.ButtonAddProgram.Name = "ButtonAddProgram";
            this.ButtonAddProgram.Size = new System.Drawing.Size(216, 23);
            this.ButtonAddProgram.TabIndex = 1;
            this.ButtonAddProgram.Text = "Add Program";
            this.ButtonAddProgram.UseVisualStyleBackColor = true;
            this.ButtonAddProgram.Click += new System.EventHandler(this.ButtonAddProgram_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonSave.Location = new System.Drawing.Point(12, 377);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(216, 23);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonAddProgram);
            this.Controls.Add(this.ProgramList);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 451);
            this.Name = "FormMain";
            this.Text = "Startup Delayer";
            ((System.ComponentModel.ISupportInitialize)(this.ProgramList)).EndInit();
            this.ProgramContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProgramList;
        private System.Windows.Forms.Button ButtonAddProgram;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPath;
        private System.Windows.Forms.ContextMenuStrip ProgramContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ItemDelete;
    }
}

