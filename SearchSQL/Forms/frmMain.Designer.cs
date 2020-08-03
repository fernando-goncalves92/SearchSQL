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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlObjectDetails = new System.Windows.Forms.Panel();
            this.toolStripFooter = new System.Windows.Forms.ToolStrip();
            this.lblObjectCreateDate = new System.Windows.Forms.ToolStripLabel();
            this.separatorFooter1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblObjectModifyDate = new System.Windows.Forms.ToolStripLabel();
            this.pictureBoxObjectDetails = new System.Windows.Forms.PictureBox();
            this.pnlFooterTotal = new System.Windows.Forms.Panel();
            this.lblFooterTotal = new System.Windows.Forms.Label();
            this.txtContentOrObjectToFind = new System.Windows.Forms.TextBox();
            this.treeViewObjects = new System.Windows.Forms.TreeView();
            this.tabControlContent = new System.Windows.Forms.TabControl();
            this.toolStripHeader = new System.Windows.Forms.ToolStrip();
            this.lblConfig = new System.Windows.Forms.ToolStripLabel();
            this.comboBoxConfig = new System.Windows.Forms.ToolStripComboBox();
            this.separatorHeader1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMakeDefaultConfig = new System.Windows.Forms.ToolStripButton();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblProgressBarMessage = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelPrincipal.SuspendLayout();
            this.pnlObjectDetails.SuspendLayout();
            this.toolStripFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectDetails)).BeginInit();
            this.pnlFooterTotal.SuspendLayout();
            this.toolStripHeader.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(90, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "mainMenu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 25);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(44, 25);
            this.toolStripMenuItem2.Text = "Help";
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
            this.tableLayoutPanelPrincipal.Size = new System.Drawing.Size(800, 421);
            this.tableLayoutPanelPrincipal.TabIndex = 0;
            // 
            // pnlObjectDetails
            // 
            this.pnlObjectDetails.BackColor = System.Drawing.Color.Khaki;
            this.pnlObjectDetails.Controls.Add(this.toolStripFooter);
            this.pnlObjectDetails.Controls.Add(this.pictureBoxObjectDetails);
            this.pnlObjectDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlObjectDetails.Location = new System.Drawing.Point(263, 404);
            this.pnlObjectDetails.Name = "pnlObjectDetails";
            this.pnlObjectDetails.Size = new System.Drawing.Size(534, 14);
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
            this.lblObjectModifyDate});
            this.toolStripFooter.Location = new System.Drawing.Point(20, 0);
            this.toolStripFooter.Name = "toolStripFooter";
            this.toolStripFooter.Size = new System.Drawing.Size(514, 14);
            this.toolStripFooter.TabIndex = 3;
            this.toolStripFooter.Text = "toolStrip2";
            // 
            // lblObjectCreateDate
            // 
            this.lblObjectCreateDate.Name = "lblObjectCreateDate";
            this.lblObjectCreateDate.Size = new System.Drawing.Size(177, 11);
            this.lblObjectCreateDate.Text = "Create Date: 06/06/1992 00:00:00";
            // 
            // separatorFooter1
            // 
            this.separatorFooter1.Name = "separatorFooter1";
            this.separatorFooter1.Size = new System.Drawing.Size(6, 14);
            // 
            // lblObjectModifyDate
            // 
            this.lblObjectModifyDate.Name = "lblObjectModifyDate";
            this.lblObjectModifyDate.Size = new System.Drawing.Size(181, 11);
            this.lblObjectModifyDate.Text = "Modify Date: 06/06/1992 00:00:00";
            // 
            // pictureBoxObjectDetails
            // 
            this.pictureBoxObjectDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxObjectDetails.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxObjectDetails.Image")));
            this.pictureBoxObjectDetails.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxObjectDetails.Name = "pictureBoxObjectDetails";
            this.pictureBoxObjectDetails.Size = new System.Drawing.Size(20, 14);
            this.pictureBoxObjectDetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxObjectDetails.TabIndex = 2;
            this.pictureBoxObjectDetails.TabStop = false;
            // 
            // pnlFooterTotal
            // 
            this.pnlFooterTotal.BackColor = System.Drawing.Color.Khaki;
            this.pnlFooterTotal.Controls.Add(this.lblFooterTotal);
            this.pnlFooterTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooterTotal.Location = new System.Drawing.Point(3, 404);
            this.pnlFooterTotal.Name = "pnlFooterTotal";
            this.pnlFooterTotal.Size = new System.Drawing.Size(254, 14);
            this.pnlFooterTotal.TabIndex = 0;
            // 
            // lblFooterTotal
            // 
            this.lblFooterTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblFooterTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooterTotal.Location = new System.Drawing.Point(0, 0);
            this.lblFooterTotal.Name = "lblFooterTotal";
            this.lblFooterTotal.Size = new System.Drawing.Size(254, 14);
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
            this.treeViewObjects.Size = new System.Drawing.Size(254, 365);
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
            this.tabControlContent.Size = new System.Drawing.Size(534, 395);
            this.tabControlContent.TabIndex = 3;
            this.tabControlContent.SelectedIndexChanged += new System.EventHandler(this.tabControlContent_SelectedIndexChanged);
            this.tabControlContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControlContent_MouseClick);
            // 
            // toolStripHeader
            // 
            this.toolStripHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.toolStripHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConfig,
            this.comboBoxConfig,
            this.separatorHeader1,
            this.btnMakeDefaultConfig,
            this.progressBar,
            this.lblProgressBarMessage});
            this.toolStripHeader.Location = new System.Drawing.Point(90, 0);
            this.toolStripHeader.Name = "toolStripHeader";
            this.toolStripHeader.Size = new System.Drawing.Size(710, 29);
            this.toolStripHeader.TabIndex = 1;
            this.toolStripHeader.Text = "toolStrip1";
            // 
            // lblConfig
            // 
            this.lblConfig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(46, 26);
            this.lblConfig.Text = "Config:";
            // 
            // comboBoxConfig
            // 
            this.comboBoxConfig.BackColor = System.Drawing.Color.LemonChiffon;
            this.comboBoxConfig.Name = "comboBoxConfig";
            this.comboBoxConfig.Size = new System.Drawing.Size(200, 29);
            // 
            // separatorHeader1
            // 
            this.separatorHeader1.Name = "separatorHeader1";
            this.separatorHeader1.Size = new System.Drawing.Size(6, 29);
            // 
            // btnMakeDefaultConfig
            // 
            this.btnMakeDefaultConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnMakeDefaultConfig.Image")));
            this.btnMakeDefaultConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMakeDefaultConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMakeDefaultConfig.Name = "btnMakeDefaultConfig";
            this.btnMakeDefaultConfig.Size = new System.Drawing.Size(213, 26);
            this.btnMakeDefaultConfig.Text = "Make this my default configuration";
            // 
            // progressBar
            // 
            this.progressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar.Name = "progressBar";
            this.progressBar.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.progressBar.Size = new System.Drawing.Size(155, 26);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // lblProgressBarMessage
            // 
            this.lblProgressBarMessage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblProgressBarMessage.Name = "lblProgressBarMessage";
            this.lblProgressBarMessage.Size = new System.Drawing.Size(40, 26);
            this.lblProgressBarMessage.Text = "Wait...";
            this.lblProgressBarMessage.Visible = false;
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.tableLayoutPanelHeader.ColumnCount = 2;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.toolStripHeader, 1, 0);
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
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanelPrincipal);
            this.Controls.Add(this.tableLayoutPanelHeader);
            this.Name = "frmMain";
            this.Text = "Search objects and contents in your SQL Server database easily";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPrincipal;
        private System.Windows.Forms.TreeView treeViewObjects;
        private System.Windows.Forms.TextBox txtContentOrObjectToFind;        
        private System.Windows.Forms.Panel pnlFooterTotal;
        private System.Windows.Forms.Label lblFooterTotal;
        private System.Windows.Forms.Panel pnlObjectDetails;
        private System.Windows.Forms.PictureBox pictureBoxObjectDetails;
        private System.Windows.Forms.ToolStrip toolStripHeader;
        private System.Windows.Forms.ToolStripLabel lblConfig;
        private System.Windows.Forms.ToolStripComboBox comboBoxConfig;
        private System.Windows.Forms.ToolStripSeparator separatorHeader1;
        private System.Windows.Forms.TabControl tabControlContent;
        private System.Windows.Forms.ToolStrip toolStripFooter;
        private System.Windows.Forms.ToolStripLabel lblObjectCreateDate;
        private System.Windows.Forms.ToolStripSeparator separatorFooter1;
        private System.Windows.Forms.ToolStripLabel lblObjectModifyDate;
        private System.Windows.Forms.ToolStripButton btnMakeDefaultConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripLabel lblProgressBarMessage;
    }
}