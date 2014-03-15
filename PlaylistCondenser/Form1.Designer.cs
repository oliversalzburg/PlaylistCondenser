namespace PlaylistCondenser {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing ) {
      if( disposing && ( components != null ) ) {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.listView1 = new System.Windows.Forms.ListView();
      this.indexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.titleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.locationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.sizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.playlistLoader = new System.ComponentModel.BackgroundWorker();
      this.TargetTextBox = new System.Windows.Forms.TextBox();
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.selectTargetDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.CondenseButton = new System.Windows.Forms.Button();
      this.playlistCondenser = new System.ComponentModel.BackgroundWorker();
      this.FileSizeLabel = new System.Windows.Forms.Label();
      this.FileCountLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // progressBar1
      // 
      this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar1.Location = new System.Drawing.Point(12, 653);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(351, 23);
      this.progressBar1.TabIndex = 0;
      // 
      // listView1
      // 
      this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexColumn,
            this.titleColumn,
            this.locationColumn,
            this.sizeColumn});
      this.listView1.FullRowSelect = true;
      this.listView1.Location = new System.Drawing.Point(12, 12);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(509, 611);
      this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.listView1.TabIndex = 2;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
      // 
      // indexColumn
      // 
      this.indexColumn.Text = "Index";
      // 
      // titleColumn
      // 
      this.titleColumn.Text = "Title";
      this.titleColumn.Width = 249;
      // 
      // locationColumn
      // 
      this.locationColumn.Text = "Location";
      this.locationColumn.Width = 193;
      // 
      // sizeColumn
      // 
      this.sizeColumn.Text = "Size";
      // 
      // playlistLoader
      // 
      this.playlistLoader.WorkerReportsProgress = true;
      this.playlistLoader.WorkerSupportsCancellation = true;
      // 
      // TargetTextBox
      // 
      this.TargetTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TargetTextBox.Location = new System.Drawing.Point(54, 629);
      this.TargetTextBox.Name = "TargetTextBox";
      this.TargetTextBox.Size = new System.Drawing.Size(309, 20);
      this.TargetTextBox.TabIndex = 4;
      // 
      // linkLabel1
      // 
      this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new System.Drawing.Point(12, 632);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(38, 13);
      this.linkLabel1.TabIndex = 5;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Target";
      this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      // 
      // CondenseButton
      // 
      this.CondenseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.CondenseButton.Location = new System.Drawing.Point(446, 653);
      this.CondenseButton.Name = "CondenseButton";
      this.CondenseButton.Size = new System.Drawing.Size(75, 23);
      this.CondenseButton.TabIndex = 6;
      this.CondenseButton.Text = "Condense";
      this.CondenseButton.UseVisualStyleBackColor = true;
      this.CondenseButton.Click += new System.EventHandler(this.CondenseButton_Click);
      // 
      // playlistCondenser
      // 
      this.playlistCondenser.WorkerReportsProgress = true;
      this.playlistCondenser.WorkerSupportsCancellation = true;
      // 
      // FileSizeLabel
      // 
      this.FileSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.FileSizeLabel.AutoSize = true;
      this.FileSizeLabel.Location = new System.Drawing.Point(369, 632);
      this.FileSizeLabel.Name = "FileSizeLabel";
      this.FileSizeLabel.Size = new System.Drawing.Size(39, 13);
      this.FileSizeLabel.TabIndex = 7;
      this.FileSizeLabel.Text = "Size: 0";
      // 
      // FileCountLabel
      // 
      this.FileCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.FileCountLabel.AutoSize = true;
      this.FileCountLabel.Location = new System.Drawing.Point(369, 653);
      this.FileCountLabel.Name = "FileCountLabel";
      this.FileCountLabel.Size = new System.Drawing.Size(40, 13);
      this.FileCountLabel.TabIndex = 8;
      this.FileCountLabel.Text = "Files: 0";
      // 
      // Form1
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(533, 688);
      this.Controls.Add(this.FileCountLabel);
      this.Controls.Add(this.FileSizeLabel);
      this.Controls.Add(this.CondenseButton);
      this.Controls.Add(this.linkLabel1);
      this.Controls.Add(this.TargetTextBox);
      this.Controls.Add(this.listView1);
      this.Controls.Add(this.progressBar1);
      this.DoubleBuffered = true;
      this.Name = "Form1";
      this.Text = "Form1";
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
      this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragOver);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ColumnHeader titleColumn;
    private System.Windows.Forms.ColumnHeader locationColumn;
    private System.Windows.Forms.ColumnHeader sizeColumn;
    private System.ComponentModel.BackgroundWorker playlistLoader;
    private System.Windows.Forms.TextBox TargetTextBox;
    private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.FolderBrowserDialog selectTargetDialog;
    private System.Windows.Forms.Button CondenseButton;
    private System.ComponentModel.BackgroundWorker playlistCondenser;
    private System.Windows.Forms.Label FileSizeLabel;
    private System.Windows.Forms.Label FileCountLabel;
    private System.Windows.Forms.ColumnHeader indexColumn;
  }
}

