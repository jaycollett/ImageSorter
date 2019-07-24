namespace ImageSorter
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.beginSortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnSort1 = new System.Windows.Forms.Button();
            this.btnSort2 = new System.Windows.Forms.Button();
            this.btnSort3 = new System.Windows.Forms.Button();
            this.btnSort4 = new System.Windows.Forms.Button();
            this.btnSort5 = new System.Windows.Forms.Button();
            this.btnSort6 = new System.Windows.Forms.Button();
            this.btnSort7 = new System.Windows.Forms.Button();
            this.btnSort8 = new System.Windows.Forms.Button();
            this.btnSort9 = new System.Windows.Forms.Button();
            this.btnSort10 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.beginSortingToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderSettingsToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "&Setting";
            // 
            // folderSettingsToolStripMenuItem
            // 
            this.folderSettingsToolStripMenuItem.Name = "folderSettingsToolStripMenuItem";
            this.folderSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.folderSettingsToolStripMenuItem.Text = "F&older Settings";
            this.folderSettingsToolStripMenuItem.Click += new System.EventHandler(this.FolderSettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(129, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(742, 411);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // beginSortingToolStripMenuItem
            // 
            this.beginSortingToolStripMenuItem.Name = "beginSortingToolStripMenuItem";
            this.beginSortingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beginSortingToolStripMenuItem.Text = "&Begin Sorting";
            this.beginSortingToolStripMenuItem.Click += new System.EventHandler(this.BeginSortingToolStripMenuItem_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(12, 37);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(111, 27);
            this.btnSkip.TabIndex = 2;
            this.btnSkip.Text = "Skip Image";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Visible = false;
            this.btnSkip.Click += new System.EventHandler(this.BtnSkip_Click);
            // 
            // btnSort1
            // 
            this.btnSort1.Location = new System.Drawing.Point(12, 70);
            this.btnSort1.Name = "btnSort1";
            this.btnSort1.Size = new System.Drawing.Size(111, 27);
            this.btnSort1.TabIndex = 3;
            this.btnSort1.Text = "btnSort1";
            this.btnSort1.UseVisualStyleBackColor = true;
            this.btnSort1.Visible = false;
            this.btnSort1.Click += new System.EventHandler(this.BtnSort1_Click);
            // 
            // btnSort2
            // 
            this.btnSort2.Location = new System.Drawing.Point(12, 103);
            this.btnSort2.Name = "btnSort2";
            this.btnSort2.Size = new System.Drawing.Size(111, 27);
            this.btnSort2.TabIndex = 4;
            this.btnSort2.Text = "btnSort2";
            this.btnSort2.UseVisualStyleBackColor = true;
            this.btnSort2.Visible = false;
            this.btnSort2.Click += new System.EventHandler(this.BtnSort2_Click);
            // 
            // btnSort3
            // 
            this.btnSort3.Location = new System.Drawing.Point(12, 136);
            this.btnSort3.Name = "btnSort3";
            this.btnSort3.Size = new System.Drawing.Size(111, 27);
            this.btnSort3.TabIndex = 5;
            this.btnSort3.Text = "btnSort3";
            this.btnSort3.UseVisualStyleBackColor = true;
            this.btnSort3.Visible = false;
            this.btnSort3.Click += new System.EventHandler(this.BtnSort3_Click);
            // 
            // btnSort4
            // 
            this.btnSort4.Location = new System.Drawing.Point(12, 169);
            this.btnSort4.Name = "btnSort4";
            this.btnSort4.Size = new System.Drawing.Size(111, 27);
            this.btnSort4.TabIndex = 6;
            this.btnSort4.Text = "btnSort4";
            this.btnSort4.UseVisualStyleBackColor = true;
            this.btnSort4.Visible = false;
            this.btnSort4.Click += new System.EventHandler(this.BtnSort4_Click);
            // 
            // btnSort5
            // 
            this.btnSort5.Location = new System.Drawing.Point(12, 202);
            this.btnSort5.Name = "btnSort5";
            this.btnSort5.Size = new System.Drawing.Size(111, 27);
            this.btnSort5.TabIndex = 7;
            this.btnSort5.Text = "btnSort5";
            this.btnSort5.UseVisualStyleBackColor = true;
            this.btnSort5.Visible = false;
            this.btnSort5.Click += new System.EventHandler(this.BtnSort5_Click);
            // 
            // btnSort6
            // 
            this.btnSort6.Location = new System.Drawing.Point(12, 235);
            this.btnSort6.Name = "btnSort6";
            this.btnSort6.Size = new System.Drawing.Size(111, 27);
            this.btnSort6.TabIndex = 8;
            this.btnSort6.Text = "btnSort6";
            this.btnSort6.UseVisualStyleBackColor = true;
            this.btnSort6.Visible = false;
            this.btnSort6.Click += new System.EventHandler(this.BtnSort6_Click);
            // 
            // btnSort7
            // 
            this.btnSort7.Location = new System.Drawing.Point(12, 268);
            this.btnSort7.Name = "btnSort7";
            this.btnSort7.Size = new System.Drawing.Size(111, 27);
            this.btnSort7.TabIndex = 9;
            this.btnSort7.Text = "btnSort7";
            this.btnSort7.UseVisualStyleBackColor = true;
            this.btnSort7.Visible = false;
            this.btnSort7.Click += new System.EventHandler(this.BtnSort7_Click);
            // 
            // btnSort8
            // 
            this.btnSort8.Location = new System.Drawing.Point(12, 301);
            this.btnSort8.Name = "btnSort8";
            this.btnSort8.Size = new System.Drawing.Size(111, 27);
            this.btnSort8.TabIndex = 10;
            this.btnSort8.Text = "btnSort8";
            this.btnSort8.UseVisualStyleBackColor = true;
            this.btnSort8.Visible = false;
            this.btnSort8.Click += new System.EventHandler(this.BtnSort8_Click);
            // 
            // btnSort9
            // 
            this.btnSort9.Location = new System.Drawing.Point(12, 334);
            this.btnSort9.Name = "btnSort9";
            this.btnSort9.Size = new System.Drawing.Size(111, 27);
            this.btnSort9.TabIndex = 11;
            this.btnSort9.Text = "btnSort9";
            this.btnSort9.UseVisualStyleBackColor = true;
            this.btnSort9.Visible = false;
            this.btnSort9.Click += new System.EventHandler(this.BtnSort9_Click);
            // 
            // btnSort10
            // 
            this.btnSort10.Location = new System.Drawing.Point(12, 367);
            this.btnSort10.Name = "btnSort10";
            this.btnSort10.Size = new System.Drawing.Size(111, 27);
            this.btnSort10.TabIndex = 12;
            this.btnSort10.Text = "btnSort10";
            this.btnSort10.UseVisualStyleBackColor = true;
            this.btnSort10.Visible = false;
            this.btnSort10.Click += new System.EventHandler(this.BtnSort10_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 450);
            this.Controls.Add(this.btnSort10);
            this.Controls.Add(this.btnSort9);
            this.Controls.Add(this.btnSort8);
            this.Controls.Add(this.btnSort7);
            this.Controls.Add(this.btnSort6);
            this.Controls.Add(this.btnSort5);
            this.Controls.Add(this.btnSort4);
            this.Controls.Add(this.btnSort3);
            this.Controls.Add(this.btnSort2);
            this.Controls.Add(this.btnSort1);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Image Sorter (v0.1a)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderSettingsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem beginSortingToolStripMenuItem;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnSort1;
        private System.Windows.Forms.Button btnSort2;
        private System.Windows.Forms.Button btnSort3;
        private System.Windows.Forms.Button btnSort4;
        private System.Windows.Forms.Button btnSort5;
        private System.Windows.Forms.Button btnSort6;
        private System.Windows.Forms.Button btnSort7;
        private System.Windows.Forms.Button btnSort8;
        private System.Windows.Forms.Button btnSort9;
        private System.Windows.Forms.Button btnSort10;
    }
}

