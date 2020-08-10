namespace SearchSQL
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
            this.tableLayoutPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlObjectDetails = new System.Windows.Forms.Panel();
            this.toolStripFooter = new System.Windows.Forms.ToolStrip();
            this.lblObjectCreateDate = new System.Windows.Forms.ToolStripLabel();
            this.separatorFooter1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblObjectModifyDate = new System.Windows.Forms.ToolStripLabel();
            this.lblDatabase = new System.Windows.Forms.ToolStripLabel();
            this.separatorFooter2 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBoxObjectDetails = new System.Windows.Forms.PictureBox();
            this.pnlFooterTotal = new System.Windows.Forms.Panel();
            this.lblFooterTotal = new System.Windows.Forms.Label();
            this.txtContentOrObjectToFind = new System.Windows.Forms.TextBox();
            this.treeViewObjects = new System.Windows.Forms.TreeView();
            this.tabControlContent = new System.Windows.Forms.TabControl();
            this.toolStripHeader = new System.Windows.Forms.ToolStrip();
            this.lblSetting = new System.Windows.Forms.ToolStripLabel();
            this.comboBoxSetting = new System.Windows.Forms.ToolStripComboBox();
            this.separatorHeader1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMakeDefaultSetting = new System.Windows.Forms.ToolStripButton();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.separatorHeader2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelPrincipal.SuspendLayout();
            this.pnlObjectDetails.SuspendLayout();
            this.toolStripFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectDetails)).BeginInit();
            this.pnlFooterTotal.SuspendLayout();
            this.toolStripHeader.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelPrincipal
            // 
            this.tableLayoutPanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.tableLayoutPanelPrincipal.ColumnCount = 2;
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.5F));
            this.tableLayoutPanelPrincipal.Controls.Add(this.pnlObjectDetails, 1, 2);
            this.tableLayoutPanelPrincipal.Controls.Add(this.pnlFooterTotal, 0, 2);
            this.tableLayoutPanelPrincipal.Controls.Add(this.txtContentOrObjectToFind, 0, 0);
            this.tableLayoutPanelPrincipal.Controls.Add(this.treeViewObjects, 0, 1);
            this.tableLayoutPanelPrincipal.Controls.Add(this.tabControlContent, 1, 0);
            this.tableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPrincipal.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanelPrincipal.Name = "tableLayoutPanelPrincipal";
            this.tableLayoutPanelPrincipal.RowCount = 3;
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPrincipal.Size = new System.Drawing.Size(800, 441);
            this.tableLayoutPanelPrincipal.TabIndex = 0;
            // 
            // pnlObjectDetails
            // 
            this.pnlObjectDetails.BackColor = System.Drawing.Color.Khaki;
            this.pnlObjectDetails.Controls.Add(this.toolStripFooter);
            this.pnlObjectDetails.Controls.Add(this.pictureBoxObjectDetails);
            this.pnlObjectDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlObjectDetails.Location = new System.Drawing.Point(263, 423);
            this.pnlObjectDetails.Name = "pnlObjectDetails";
            this.pnlObjectDetails.Size = new System.Drawing.Size(534, 15);
            this.pnlObjectDetails.TabIndex = 0;
            // 
            // toolStripFooter
            // 
            this.toolStripFooter.BackColor = System.Drawing.Color.Khaki;
            this.toolStripFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripFooter.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblObjectCreateDate,
            this.separatorFooter1,
            this.lblObjectModifyDate,
            this.lblDatabase,
            this.separatorFooter2});
            this.toolStripFooter.Location = new System.Drawing.Point(20, 0);
            this.toolStripFooter.Name = "toolStripFooter";
            this.toolStripFooter.Size = new System.Drawing.Size(514, 15);
            this.toolStripFooter.TabIndex = 3;
            this.toolStripFooter.Text = "toolStrip2";
            // 
            // lblObjectCreateDate
            // 
            this.lblObjectCreateDate.Name = "lblObjectCreateDate";
            this.lblObjectCreateDate.Size = new System.Drawing.Size(177, 12);
            this.lblObjectCreateDate.Text = "Create Date: 06/06/1992 00:00:00";
            // 
            // separatorFooter1
            // 
            this.separatorFooter1.Name = "separatorFooter1";
            this.separatorFooter1.Size = new System.Drawing.Size(6, 15);
            // 
            // lblObjectModifyDate
            // 
            this.lblObjectModifyDate.Name = "lblObjectModifyDate";
            this.lblObjectModifyDate.Size = new System.Drawing.Size(181, 12);
            this.lblObjectModifyDate.Text = "Modify Date: 06/06/1992 00:00:00";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblDatabase.Size = new System.Drawing.Size(60, 12);
            this.lblDatabase.Text = "Database";
            // 
            // separatorFooter2
            // 
            this.separatorFooter2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.separatorFooter2.Name = "separatorFooter2";
            this.separatorFooter2.Size = new System.Drawing.Size(6, 15);
            // 
            // pictureBoxObjectDetails
            // 
            this.pictureBoxObjectDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxObjectDetails.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxObjectDetails.Image")));
            this.pictureBoxObjectDetails.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxObjectDetails.Name = "pictureBoxObjectDetails";
            this.pictureBoxObjectDetails.Size = new System.Drawing.Size(20, 15);
            this.pictureBoxObjectDetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxObjectDetails.TabIndex = 2;
            this.pictureBoxObjectDetails.TabStop = false;
            // 
            // pnlFooterTotal
            // 
            this.pnlFooterTotal.BackColor = System.Drawing.Color.Khaki;
            this.pnlFooterTotal.Controls.Add(this.lblFooterTotal);
            this.pnlFooterTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooterTotal.Location = new System.Drawing.Point(3, 423);
            this.pnlFooterTotal.Name = "pnlFooterTotal";
            this.pnlFooterTotal.Size = new System.Drawing.Size(254, 15);
            this.pnlFooterTotal.TabIndex = 0;
            // 
            // lblFooterTotal
            // 
            this.lblFooterTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblFooterTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooterTotal.Location = new System.Drawing.Point(0, 0);
            this.lblFooterTotal.Name = "lblFooterTotal";
            this.lblFooterTotal.Size = new System.Drawing.Size(254, 15);
            this.lblFooterTotal.TabIndex = 0;
            this.lblFooterTotal.Text = "Found objects: 0";
            this.lblFooterTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContentOrObjectToFind
            // 
            this.txtContentOrObjectToFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContentOrObjectToFind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.txtContentOrObjectToFind.ForeColor = System.Drawing.Color.Gray;
            this.txtContentOrObjectToFind.Location = new System.Drawing.Point(3, 3);
            this.txtContentOrObjectToFind.Name = "txtContentOrObjectToFind";
            this.txtContentOrObjectToFind.Size = new System.Drawing.Size(254, 23);
            this.txtContentOrObjectToFind.TabIndex = 1;
            this.txtContentOrObjectToFind.TabStop = false;
            this.txtContentOrObjectToFind.Text = "Type the content or object you\'re looking for...";
            this.txtContentOrObjectToFind.Enter += new System.EventHandler(this.txtContentFind_Enter);
            this.txtContentOrObjectToFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContentOrObjectToFind_KeyPress);
            this.txtContentOrObjectToFind.Leave += new System.EventHandler(this.txtContentFind_Leave);
            // 
            // treeViewObjects
            // 
            this.treeViewObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewObjects.Location = new System.Drawing.Point(3, 33);
            this.treeViewObjects.Name = "treeViewObjects";
            this.treeViewObjects.Size = new System.Drawing.Size(254, 384);
            this.treeViewObjects.TabIndex = 2;
            this.treeViewObjects.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewObjects_NodeMouseClick);
            this.treeViewObjects.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewOfObjects_NodeMouseDoubleClick);
            // 
            // tabControlContent
            // 
            this.tabControlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlContent.Location = new System.Drawing.Point(263, 3);
            this.tabControlContent.Name = "tabControlContent";
            this.tableLayoutPanelPrincipal.SetRowSpan(this.tabControlContent, 2);
            this.tabControlContent.SelectedIndex = 0;
            this.tabControlContent.Size = new System.Drawing.Size(534, 414);
            this.tabControlContent.TabIndex = 3;
            this.tabControlContent.SelectedIndexChanged += new System.EventHandler(this.tabControlContent_SelectedIndexChanged);
            this.tabControlContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControlContent_MouseClick);
            // 
            // toolStripHeader
            // 
            this.toolStripHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.tableLayoutPanelHeader.SetColumnSpan(this.toolStripHeader, 2);
            this.toolStripHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSetting,
            this.comboBoxSetting,
            this.separatorHeader1,
            this.btnMakeDefaultSetting,
            this.btnAbout,
            this.separatorHeader2,
            this.btnSettings});
            this.toolStripHeader.Location = new System.Drawing.Point(0, 0);
            this.toolStripHeader.Name = "toolStripHeader";
            this.toolStripHeader.Size = new System.Drawing.Size(800, 29);
            this.toolStripHeader.TabIndex = 1;
            this.toolStripHeader.Text = "toolStrip1";
            // 
            // lblSetting
            // 
            this.lblSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.Size = new System.Drawing.Size(83, 26);
            this.lblSetting.Text = "Active Setting:";
            // 
            // comboBoxSetting
            // 
            this.comboBoxSetting.BackColor = System.Drawing.Color.LemonChiffon;
            this.comboBoxSetting.Name = "comboBoxSetting";
            this.comboBoxSetting.Size = new System.Drawing.Size(200, 29);
            // 
            // separatorHeader1
            // 
            this.separatorHeader1.Name = "separatorHeader1";
            this.separatorHeader1.Size = new System.Drawing.Size(6, 29);
            // 
            // btnMakeDefaultSetting
            // 
            this.btnMakeDefaultSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnMakeDefaultSetting.Image")));
            this.btnMakeDefaultSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMakeDefaultSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMakeDefaultSetting.Name = "btnMakeDefaultSetting";
            this.btnMakeDefaultSetting.Size = new System.Drawing.Size(177, 26);
            this.btnMakeDefaultSetting.Text = "Make this my default setting";
            // 
            // btnAbout
            // 
            this.btnAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(60, 26);
            this.btnAbout.Text = "About";
            // 
            // separatorHeader2
            // 
            this.separatorHeader2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.separatorHeader2.Name = "separatorHeader2";
            this.separatorHeader2.Size = new System.Drawing.Size(6, 29);
            // 
            // btnSettings
            // 
            this.btnSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(69, 26);
            this.btnSettings.Text = "Settings";
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.tableLayoutPanelHeader.ColumnCount = 2;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.Controls.Add(this.toolStripHeader, 0, 0);
            this.tableLayoutPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowCount = 1;
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(800, 29);
            this.tableLayoutPanelHeader.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.tableLayoutPanelPrincipal);
            this.Controls.Add(this.tableLayoutPanelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "SearchSQL - Search objects and contents in your SQL Server database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanelPrincipal.ResumeLayout(false);
            this.tableLayoutPanelPrincipal.PerformLayout();
            this.pnlObjectDetails.ResumeLayout(false);
            this.pnlObjectDetails.PerformLayout();
            this.toolStripFooter.ResumeLayout(false);
            this.toolStripFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectDetails)).EndInit();
            this.pnlFooterTotal.ResumeLayout(false);
            this.toolStripHeader.ResumeLayout(false);
            this.toolStripHeader.PerformLayout();
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPrincipal;
        private System.Windows.Forms.TreeView treeViewObjects;
        private System.Windows.Forms.TextBox txtContentOrObjectToFind;        
        private System.Windows.Forms.Panel pnlFooterTotal;
        private System.Windows.Forms.Label lblFooterTotal;
        private System.Windows.Forms.Panel pnlObjectDetails;
        private System.Windows.Forms.PictureBox pictureBoxObjectDetails;
        private System.Windows.Forms.ToolStrip toolStripHeader;
        private System.Windows.Forms.ToolStripLabel lblSetting;
        private System.Windows.Forms.ToolStripComboBox comboBoxSetting;
        private System.Windows.Forms.ToolStripSeparator separatorHeader1;
        private System.Windows.Forms.TabControl tabControlContent;
        private System.Windows.Forms.ToolStrip toolStripFooter;
        private System.Windows.Forms.ToolStripLabel lblObjectCreateDate;
        private System.Windows.Forms.ToolStripSeparator separatorFooter1;
        private System.Windows.Forms.ToolStripLabel lblObjectModifyDate;
        private System.Windows.Forms.ToolStripButton btnMakeDefaultSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
        private System.Windows.Forms.ToolStripSeparator separatorFooter2;
        private System.Windows.Forms.ToolStripLabel lblDatabase;
        private System.Windows.Forms.ToolStripButton btnAbout;
        private System.Windows.Forms.ToolStripSeparator separatorHeader2;
        private System.Windows.Forms.ToolStripButton btnSettings;
    }
}