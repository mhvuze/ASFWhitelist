namespace ASFWhitelist
{
    partial class Form1
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
            this.listViewGames = new System.Windows.Forms.ListView();
            this.columnHeaderCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAppID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.buttonOpenASFconfig = new System.Windows.Forms.Button();
            this.buttonSaveList = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // listViewGames
            // 
            this.listViewGames.CheckBoxes = true;
            this.listViewGames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCheck,
            this.columnHeaderAppID,
            this.columnHeaderName});
            this.listViewGames.FullRowSelect = true;
            this.listViewGames.GridLines = true;
            this.listViewGames.Location = new System.Drawing.Point(12, 12);
            this.listViewGames.Name = "listViewGames";
            this.listViewGames.Size = new System.Drawing.Size(725, 419);
            this.listViewGames.TabIndex = 1;
            this.listViewGames.UseCompatibleStateImageBehavior = false;
            this.listViewGames.View = System.Windows.Forms.View.Details;
            this.listViewGames.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewGames_ColumnClick);
            // 
            // columnHeaderCheck
            // 
            this.columnHeaderCheck.Text = "✓";
            this.columnHeaderCheck.Width = 25;
            // 
            // columnHeaderAppID
            // 
            this.columnHeaderAppID.Text = "App ID";
            this.columnHeaderAppID.Width = 90;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Game name";
            this.columnHeaderName.Width = 588;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(747, 29);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(140, 20);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(744, 13);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(88, 13);
            this.labelSearch.TabIndex = 3;
            this.labelSearch.Text = "Search for game:";
            // 
            // buttonOpenASFconfig
            // 
            this.buttonOpenASFconfig.Location = new System.Drawing.Point(747, 56);
            this.buttonOpenASFconfig.Name = "buttonOpenASFconfig";
            this.buttonOpenASFconfig.Size = new System.Drawing.Size(140, 23);
            this.buttonOpenASFconfig.TabIndex = 4;
            this.buttonOpenASFconfig.Text = "Open ASF config";
            this.buttonOpenASFconfig.UseVisualStyleBackColor = true;
            this.buttonOpenASFconfig.Click += new System.EventHandler(this.buttonOpenASFconfig_Click);
            // 
            // buttonSaveList
            // 
            this.buttonSaveList.Enabled = false;
            this.buttonSaveList.Location = new System.Drawing.Point(747, 86);
            this.buttonSaveList.Name = "buttonSaveList";
            this.buttonSaveList.Size = new System.Drawing.Size(140, 23);
            this.buttonSaveList.TabIndex = 5;
            this.buttonSaveList.Text = "Save Blacklist";
            this.buttonSaveList.UseVisualStyleBackColor = true;
            this.buttonSaveList.Click += new System.EventHandler(this.buttonSaveList_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(747, 422);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(140, 13);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Ready.";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(747, 115);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(140, 23);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "Update Apps";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // openFileDialogConfig
            // 
            this.openFileDialogConfig.FileName = "ASF.json";
            this.openFileDialogConfig.Filter = "JSON files|*.json";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 444);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonSaveList);
            this.Controls.Add(this.buttonOpenASFconfig);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.listViewGames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ASFWhitelist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewGames;
        private System.Windows.Forms.ColumnHeader columnHeaderCheck;
        private System.Windows.Forms.ColumnHeader columnHeaderAppID;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button buttonOpenASFconfig;
        private System.Windows.Forms.Button buttonSaveList;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.OpenFileDialog openFileDialogConfig;
    }
}

