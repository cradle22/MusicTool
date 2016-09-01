namespace MusicTool
{
  partial class MainForm
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.grp_left = new System.Windows.Forms.GroupBox();
      this.button2 = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.txt_minBitrate = new System.Windows.Forms.TextBox();
      this.btt_compare = new System.Windows.Forms.Button();
      this.btt_choseDirLeft = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txt_folderLeft = new System.Windows.Forms.TextBox();
      this.grp_right = new System.Windows.Forms.GroupBox();
      this.grp_playlist = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txt_delimiter = new System.Windows.Forms.TextBox();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txt_playlistOutput = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txt_pathSubst = new System.Windows.Forms.TextBox();
      this.txt_playlistFile = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.btt_openPlaylist = new System.Windows.Forms.Button();
      this.btt_choseDirRight = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.txt_folderRight = new System.Windows.Forms.TextBox();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.dgv_directories = new System.Windows.Forms.DataGridView();
      this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.artist1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.title1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.path1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.extension1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.lenght1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.bitrate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.equality = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.transcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.artist2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.title2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.path2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.extension2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.length2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.bitrate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.grp_left.SuspendLayout();
      this.grp_right.SuspendLayout();
      this.grp_playlist.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_directories)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.grp_left);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.grp_right);
      this.splitContainer1.Size = new System.Drawing.Size(1422, 336);
      this.splitContainer1.SplitterDistance = 716;
      this.splitContainer1.TabIndex = 0;
      // 
      // grp_left
      // 
      this.grp_left.Controls.Add(this.button4);
      this.grp_left.Controls.Add(this.button3);
      this.grp_left.Controls.Add(this.button2);
      this.grp_left.Controls.Add(this.label9);
      this.grp_left.Controls.Add(this.txt_minBitrate);
      this.grp_left.Controls.Add(this.btt_compare);
      this.grp_left.Controls.Add(this.btt_choseDirLeft);
      this.grp_left.Controls.Add(this.label1);
      this.grp_left.Controls.Add(this.txt_folderLeft);
      this.grp_left.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grp_left.Location = new System.Drawing.Point(0, 0);
      this.grp_left.Name = "grp_left";
      this.grp_left.Size = new System.Drawing.Size(716, 336);
      this.grp_left.TabIndex = 0;
      this.grp_left.TabStop = false;
      this.grp_left.Text = "Basis-Musikdaten";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(15, 105);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(141, 23);
      this.button2.TabIndex = 18;
      this.button2.Text = "Kopieren 0% rechts";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(13, 55);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(60, 13);
      this.label9.TabIndex = 17;
      this.label9.Text = "Min. Bitrate";
      // 
      // txt_minBitrate
      // 
      this.txt_minBitrate.Location = new System.Drawing.Point(79, 50);
      this.txt_minBitrate.Name = "txt_minBitrate";
      this.txt_minBitrate.Size = new System.Drawing.Size(100, 20);
      this.txt_minBitrate.TabIndex = 16;
      this.txt_minBitrate.Text = "155";
      // 
      // btt_compare
      // 
      this.btt_compare.Location = new System.Drawing.Point(16, 76);
      this.btt_compare.Name = "btt_compare";
      this.btt_compare.Size = new System.Drawing.Size(75, 23);
      this.btt_compare.TabIndex = 3;
      this.btt_compare.Text = "Vergleichen";
      this.btt_compare.UseVisualStyleBackColor = true;
      this.btt_compare.Click += new System.EventHandler(this.btt_compare_Click);
      // 
      // btt_choseDirLeft
      // 
      this.btt_choseDirLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btt_choseDirLeft.Location = new System.Drawing.Point(680, 24);
      this.btt_choseDirLeft.Name = "btt_choseDirLeft";
      this.btt_choseDirLeft.Size = new System.Drawing.Size(30, 20);
      this.btt_choseDirLeft.TabIndex = 2;
      this.btt_choseDirLeft.Text = "...";
      this.btt_choseDirLeft.UseVisualStyleBackColor = true;
      this.btt_choseDirLeft.Click += new System.EventHandler(this.btt_choseDirLeft_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Verzeichnis";
      // 
      // txt_folderLeft
      // 
      this.txt_folderLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_folderLeft.Location = new System.Drawing.Point(79, 24);
      this.txt_folderLeft.Name = "txt_folderLeft";
      this.txt_folderLeft.Size = new System.Drawing.Size(595, 20);
      this.txt_folderLeft.TabIndex = 0;
      this.txt_folderLeft.Text = "D:\\Media\\Audio\\Other\\Sixties & Seventies\\";
      // 
      // grp_right
      // 
      this.grp_right.Controls.Add(this.grp_playlist);
      this.grp_right.Controls.Add(this.btt_choseDirRight);
      this.grp_right.Controls.Add(this.label2);
      this.grp_right.Controls.Add(this.txt_folderRight);
      this.grp_right.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grp_right.Location = new System.Drawing.Point(0, 0);
      this.grp_right.Name = "grp_right";
      this.grp_right.Size = new System.Drawing.Size(702, 336);
      this.grp_right.TabIndex = 1;
      this.grp_right.TabStop = false;
      this.grp_right.Text = "Ziel-Musikdaten";
      // 
      // grp_playlist
      // 
      this.grp_playlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grp_playlist.Controls.Add(this.label5);
      this.grp_playlist.Controls.Add(this.txt_delimiter);
      this.grp_playlist.Controls.Add(this.comboBox1);
      this.grp_playlist.Controls.Add(this.label6);
      this.grp_playlist.Controls.Add(this.txt_playlistOutput);
      this.grp_playlist.Controls.Add(this.label4);
      this.grp_playlist.Controls.Add(this.txt_pathSubst);
      this.grp_playlist.Controls.Add(this.txt_playlistFile);
      this.grp_playlist.Controls.Add(this.button1);
      this.grp_playlist.Controls.Add(this.label3);
      this.grp_playlist.Controls.Add(this.btt_openPlaylist);
      this.grp_playlist.Location = new System.Drawing.Point(6, 50);
      this.grp_playlist.Name = "grp_playlist";
      this.grp_playlist.Size = new System.Drawing.Size(693, 346);
      this.grp_playlist.TabIndex = 8;
      this.grp_playlist.TabStop = false;
      this.grp_playlist.Text = "Playlist";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(437, 69);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(67, 13);
      this.label5.TabIndex = 16;
      this.label5.Text = "Pathdelimiter";
      // 
      // txt_delimiter
      // 
      this.txt_delimiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_delimiter.Location = new System.Drawing.Point(530, 66);
      this.txt_delimiter.Name = "txt_delimiter";
      this.txt_delimiter.Size = new System.Drawing.Size(154, 20);
      this.txt_delimiter.TabIndex = 15;
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[] {
            "APO Sansa Rockbox",
            "APO Lenovo Note 3"});
      this.comboBox1.Location = new System.Drawing.Point(99, 39);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(333, 21);
      this.comboBox1.TabIndex = 14;
      this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 179);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(39, 13);
      this.label6.TabIndex = 13;
      this.label6.Text = "Output";
      // 
      // txt_playlistOutput
      // 
      this.txt_playlistOutput.Location = new System.Drawing.Point(99, 176);
      this.txt_playlistOutput.Multiline = true;
      this.txt_playlistOutput.Name = "txt_playlistOutput";
      this.txt_playlistOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_playlistOutput.Size = new System.Drawing.Size(333, 93);
      this.txt_playlistOutput.TabIndex = 12;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 42);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(87, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Path-Substitution";
      // 
      // txt_pathSubst
      // 
      this.txt_pathSubst.Location = new System.Drawing.Point(99, 66);
      this.txt_pathSubst.Multiline = true;
      this.txt_pathSubst.Name = "txt_pathSubst";
      this.txt_pathSubst.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_pathSubst.Size = new System.Drawing.Size(333, 61);
      this.txt_pathSubst.TabIndex = 8;
      // 
      // txt_playlistFile
      // 
      this.txt_playlistFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_playlistFile.Location = new System.Drawing.Point(99, 13);
      this.txt_playlistFile.Name = "txt_playlistFile";
      this.txt_playlistFile.Size = new System.Drawing.Size(549, 20);
      this.txt_playlistFile.TabIndex = 4;
      this.txt_playlistFile.Text = "D:\\Media\\Audio\\Other\\Zusammenstellungen\\BesserApresSki.m3u8";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(9, 153);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 7;
      this.button1.Text = "Vergleichen";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 16);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(39, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Playlist";
      // 
      // btt_openPlaylist
      // 
      this.btt_openPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btt_openPlaylist.Location = new System.Drawing.Point(654, 13);
      this.btt_openPlaylist.Name = "btt_openPlaylist";
      this.btt_openPlaylist.Size = new System.Drawing.Size(30, 20);
      this.btt_openPlaylist.TabIndex = 6;
      this.btt_openPlaylist.Text = "...";
      this.btt_openPlaylist.UseVisualStyleBackColor = true;
      this.btt_openPlaylist.Click += new System.EventHandler(this.btt_openPlaylist_Click);
      // 
      // btt_choseDirRight
      // 
      this.btt_choseDirRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btt_choseDirRight.Location = new System.Drawing.Point(660, 24);
      this.btt_choseDirRight.Name = "btt_choseDirRight";
      this.btt_choseDirRight.Size = new System.Drawing.Size(30, 20);
      this.btt_choseDirRight.TabIndex = 5;
      this.btt_choseDirRight.Text = "...";
      this.btt_choseDirRight.UseVisualStyleBackColor = true;
      this.btt_choseDirRight.Click += new System.EventHandler(this.btt_choseDirRight_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 27);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(61, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Verzeichnis";
      // 
      // txt_folderRight
      // 
      this.txt_folderRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_folderRight.Location = new System.Drawing.Point(79, 24);
      this.txt_folderRight.Name = "txt_folderRight";
      this.txt_folderRight.Size = new System.Drawing.Size(575, 20);
      this.txt_folderRight.TabIndex = 3;
      this.txt_folderRight.Text = "D:\\Media\\Handy\\Sixties & Seventies\\";
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.dgv_directories);
      this.splitContainer2.Size = new System.Drawing.Size(1422, 708);
      this.splitContainer2.SplitterDistance = 336;
      this.splitContainer2.TabIndex = 1;
      // 
      // dgv_directories
      // 
      this.dgv_directories.AllowUserToAddRows = false;
      this.dgv_directories.AllowUserToDeleteRows = false;
      this.dgv_directories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_directories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.artist1,
            this.title1,
            this.path1,
            this.extension1,
            this.lenght1,
            this.bitrate1,
            this.equality,
            this.transcode,
            this.artist2,
            this.title2,
            this.path2,
            this.extension2,
            this.length2,
            this.bitrate2});
      this.dgv_directories.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgv_directories.Location = new System.Drawing.Point(0, 0);
      this.dgv_directories.Name = "dgv_directories";
      this.dgv_directories.ReadOnly = true;
      this.dgv_directories.Size = new System.Drawing.Size(1422, 368);
      this.dgv_directories.TabIndex = 0;
      // 
      // select
      // 
      this.select.HeaderText = "";
      this.select.Name = "select";
      this.select.ReadOnly = true;
      // 
      // artist1
      // 
      this.artist1.HeaderText = "Artist";
      this.artist1.Name = "artist1";
      this.artist1.ReadOnly = true;
      // 
      // title1
      // 
      this.title1.HeaderText = "Title";
      this.title1.Name = "title1";
      this.title1.ReadOnly = true;
      // 
      // path1
      // 
      this.path1.HeaderText = "Path";
      this.path1.Name = "path1";
      this.path1.ReadOnly = true;
      // 
      // extension1
      // 
      this.extension1.HeaderText = "Ext";
      this.extension1.Name = "extension1";
      this.extension1.ReadOnly = true;
      // 
      // lenght1
      // 
      this.lenght1.HeaderText = "Length";
      this.lenght1.Name = "lenght1";
      this.lenght1.ReadOnly = true;
      // 
      // bitrate1
      // 
      this.bitrate1.HeaderText = "Bitrate";
      this.bitrate1.Name = "bitrate1";
      this.bitrate1.ReadOnly = true;
      // 
      // equality
      // 
      this.equality.HeaderText = "==";
      this.equality.Name = "equality";
      this.equality.ReadOnly = true;
      // 
      // transcode
      // 
      this.transcode.HeaderText = "Codieren";
      this.transcode.Name = "transcode";
      this.transcode.ReadOnly = true;
      // 
      // artist2
      // 
      this.artist2.HeaderText = "Artist";
      this.artist2.Name = "artist2";
      this.artist2.ReadOnly = true;
      // 
      // title2
      // 
      this.title2.HeaderText = "Title";
      this.title2.Name = "title2";
      this.title2.ReadOnly = true;
      // 
      // path2
      // 
      this.path2.HeaderText = "Path";
      this.path2.Name = "path2";
      this.path2.ReadOnly = true;
      // 
      // extension2
      // 
      this.extension2.HeaderText = "Ext";
      this.extension2.Name = "extension2";
      this.extension2.ReadOnly = true;
      // 
      // length2
      // 
      this.length2.HeaderText = "Length";
      this.length2.Name = "length2";
      this.length2.ReadOnly = true;
      // 
      // bitrate2
      // 
      this.bitrate2.HeaderText = "Bitrate";
      this.bitrate2.Name = "bitrate2";
      this.bitrate2.ReadOnly = true;
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(15, 134);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(141, 23);
      this.button3.TabIndex = 19;
      this.button3.Text = "Kopieren 0% links";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(16, 163);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(140, 23);
      this.button4.TabIndex = 20;
      this.button4.Text = "Kopieren Encode rechts";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1422, 708);
      this.Controls.Add(this.splitContainer2);
      this.Name = "Form1";
      this.Text = "Form1";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.grp_left.ResumeLayout(false);
      this.grp_left.PerformLayout();
      this.grp_right.ResumeLayout(false);
      this.grp_right.PerformLayout();
      this.grp_playlist.ResumeLayout(false);
      this.grp_playlist.PerformLayout();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgv_directories)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.GroupBox grp_left;
    private System.Windows.Forms.Button btt_choseDirLeft;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txt_folderLeft;
    private System.Windows.Forms.GroupBox grp_right;
    private System.Windows.Forms.Button btt_choseDirRight;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txt_folderRight;
    private System.Windows.Forms.Button btt_compare;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button btt_openPlaylist;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txt_playlistFile;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.GroupBox grp_playlist;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txt_pathSubst;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txt_playlistOutput;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txt_minBitrate;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.DataGridView dgv_directories;
    private System.Windows.Forms.DataGridViewTextBoxColumn artist1;
    private System.Windows.Forms.DataGridViewCheckBoxColumn select;
    private System.Windows.Forms.DataGridViewTextBoxColumn title1;
    private System.Windows.Forms.DataGridViewTextBoxColumn path1;
    private System.Windows.Forms.DataGridViewTextBoxColumn extension1;
    private System.Windows.Forms.DataGridViewTextBoxColumn lenght1;
    private System.Windows.Forms.DataGridViewTextBoxColumn bitrate1;
    private System.Windows.Forms.DataGridViewTextBoxColumn equality;
    private System.Windows.Forms.DataGridViewTextBoxColumn transcode;
    private System.Windows.Forms.DataGridViewTextBoxColumn artist2;
    private System.Windows.Forms.DataGridViewTextBoxColumn title2;
    private System.Windows.Forms.DataGridViewTextBoxColumn path2;
    private System.Windows.Forms.DataGridViewTextBoxColumn extension2;
    private System.Windows.Forms.DataGridViewTextBoxColumn length2;
    private System.Windows.Forms.DataGridViewTextBoxColumn bitrate2;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txt_delimiter;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
  }
}

