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
            this.ProgramList = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramList)).BeginInit();
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
            this.ProgramList.Location = new System.Drawing.Point(12, 12);
            this.ProgramList.Name = "ProgramList";
            this.ProgramList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProgramList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProgramList.ShowEditingIcon = false;
            this.ProgramList.Size = new System.Drawing.Size(460, 388);
            this.ProgramList.TabIndex = 0;
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.ProgramList);
            this.Name = "FormMain";
            this.Text = "Startup Delayer";
            ((System.ComponentModel.ISupportInitialize)(this.ProgramList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProgramList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPath;
    }
}

