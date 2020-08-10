namespace SearchSQL
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.tableLayoutPanelFooter = new System.Windows.Forms.TableLayoutPanel();
            this.listViewSettings = new System.Windows.Forms.ListView();
            this.columnHeaderAlias = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderStringConnection = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDbms = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDefault = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblStringConnection = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblDbms = new System.Windows.Forms.Label();
            this.comboBoxDbms = new System.Windows.Forms.ComboBox();
            this.checkBoxDefaultSetting = new System.Windows.Forms.CheckBox();
            this.btnDeleteSetting = new System.Windows.Forms.Button();
            this.btnUpdateSetting = new System.Windows.Forms.Button();
            this.btnAddSetting = new System.Windows.Forms.Button();
            this.btnTesteConnectionString = new System.Windows.Forms.Button();
            this.btnStringConnectionFormat = new System.Windows.Forms.Button();
            this.tableLayoutPanelFooter.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelFooter
            // 
            this.tableLayoutPanelFooter.ColumnCount = 2;
            this.tableLayoutPanelFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFooter.Controls.Add(this.listViewSettings, 0, 1);
            this.tableLayoutPanelFooter.Controls.Add(this.tableLayoutPanelHeader, 0, 0);
            this.tableLayoutPanelFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFooter.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelFooter.Name = "tableLayoutPanelFooter";
            this.tableLayoutPanelFooter.RowCount = 2;
            this.tableLayoutPanelFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.58747F));
            this.tableLayoutPanelFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.41253F));
            this.tableLayoutPanelFooter.Size = new System.Drawing.Size(777, 362);
            this.tableLayoutPanelFooter.TabIndex = 0;
            // 
            // listViewSettings
            // 
            this.listViewSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAlias,
            this.columnHeaderStringConnection,
            this.columnHeaderDbms,
            this.columnHeaderDefault});
            this.tableLayoutPanelFooter.SetColumnSpan(this.listViewSettings, 2);
            this.listViewSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSettings.FullRowSelect = true;
            this.listViewSettings.GridLines = true;
            this.listViewSettings.HideSelection = false;
            this.listViewSettings.Location = new System.Drawing.Point(3, 95);
            this.listViewSettings.MultiSelect = false;
            this.listViewSettings.Name = "listViewSettings";
            this.listViewSettings.Size = new System.Drawing.Size(771, 264);
            this.listViewSettings.TabIndex = 1;
            this.listViewSettings.UseCompatibleStateImageBehavior = false;
            this.listViewSettings.View = System.Windows.Forms.View.Details;
            this.listViewSettings.SelectedIndexChanged += new System.EventHandler(this.listViewSettings_SelectedIndexChanged);
            // 
            // columnHeaderAlias
            // 
            this.columnHeaderAlias.Name = "columnHeaderAlias";
            this.columnHeaderAlias.Text = "Alias";
            this.columnHeaderAlias.Width = 200;
            // 
            // columnHeaderStringConnection
            // 
            this.columnHeaderStringConnection.Name = "columnHeaderStringConnection";
            this.columnHeaderStringConnection.Text = "Connection String";
            this.columnHeaderStringConnection.Width = 350;
            // 
            // columnHeaderDbms
            // 
            this.columnHeaderDbms.Name = "columnHeaderDbms";
            this.columnHeaderDbms.Text = "Dbms";
            this.columnHeaderDbms.Width = 100;
            // 
            // columnHeaderDefault
            // 
            this.columnHeaderDefault.Name = "columnHeaderDefault";
            this.columnHeaderDefault.Text = "Default Setting";
            this.columnHeaderDefault.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderDefault.Width = 100;
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.ColumnCount = 4;
            this.tableLayoutPanelFooter.SetColumnSpan(this.tableLayoutPanelHeader, 2);
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanelHeader.Controls.Add(this.lblAlias, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.lblStringConnection, 0, 1);
            this.tableLayoutPanelHeader.Controls.Add(this.txtAlias, 1, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.txtConnectionString, 1, 1);
            this.tableLayoutPanelHeader.Controls.Add(this.lblDbms, 0, 2);
            this.tableLayoutPanelHeader.Controls.Add(this.comboBoxDbms, 1, 2);
            this.tableLayoutPanelHeader.Controls.Add(this.checkBoxDefaultSetting, 2, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.btnDeleteSetting, 3, 2);
            this.tableLayoutPanelHeader.Controls.Add(this.btnUpdateSetting, 3, 1);
            this.tableLayoutPanelHeader.Controls.Add(this.btnAddSetting, 3, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.btnTesteConnectionString, 2, 1);
            this.tableLayoutPanelHeader.Controls.Add(this.btnStringConnectionFormat, 2, 2);
            this.tableLayoutPanelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowCount = 3;
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(771, 86);
            this.tableLayoutPanelHeader.TabIndex = 0;
            // 
            // lblAlias
            // 
            this.lblAlias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlias.ForeColor = System.Drawing.Color.White;
            this.lblAlias.Location = new System.Drawing.Point(3, 0);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(145, 28);
            this.lblAlias.TabIndex = 0;
            this.lblAlias.Text = "Alias:";
            this.lblAlias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStringConnection
            // 
            this.lblStringConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStringConnection.ForeColor = System.Drawing.Color.White;
            this.lblStringConnection.Location = new System.Drawing.Point(3, 28);
            this.lblStringConnection.Name = "lblStringConnection";
            this.lblStringConnection.Size = new System.Drawing.Size(145, 28);
            this.lblStringConnection.TabIndex = 1;
            this.lblStringConnection.Text = "String Connection:";
            this.lblStringConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAlias
            // 
            this.txtAlias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAlias.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAlias.Location = new System.Drawing.Point(154, 3);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(447, 22);
            this.txtAlias.TabIndex = 1;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnectionString.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConnectionString.Location = new System.Drawing.Point(154, 31);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(447, 22);
            this.txtConnectionString.TabIndex = 2;
            // 
            // lblDbms
            // 
            this.lblDbms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDbms.ForeColor = System.Drawing.Color.White;
            this.lblDbms.Location = new System.Drawing.Point(3, 56);
            this.lblDbms.Name = "lblDbms";
            this.lblDbms.Size = new System.Drawing.Size(145, 30);
            this.lblDbms.TabIndex = 4;
            this.lblDbms.Text = "Dbms:";
            this.lblDbms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxDbms
            // 
            this.comboBoxDbms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxDbms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDbms.FormattingEnabled = true;
            this.comboBoxDbms.Location = new System.Drawing.Point(154, 59);
            this.comboBoxDbms.Name = "comboBoxDbms";
            this.comboBoxDbms.Size = new System.Drawing.Size(447, 23);
            this.comboBoxDbms.TabIndex = 5;
            // 
            // checkBoxDefaultSetting
            // 
            this.checkBoxDefaultSetting.AutoSize = true;
            this.checkBoxDefaultSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDefaultSetting.ForeColor = System.Drawing.Color.White;
            this.checkBoxDefaultSetting.Location = new System.Drawing.Point(607, 3);
            this.checkBoxDefaultSetting.Name = "checkBoxDefaultSetting";
            this.checkBoxDefaultSetting.Size = new System.Drawing.Size(74, 22);
            this.checkBoxDefaultSetting.TabIndex = 6;
            this.checkBoxDefaultSetting.Text = "Default";
            this.checkBoxDefaultSetting.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSetting
            // 
            this.btnDeleteSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteSetting.Location = new System.Drawing.Point(687, 59);
            this.btnDeleteSetting.Name = "btnDeleteSetting";
            this.btnDeleteSetting.Size = new System.Drawing.Size(81, 24);
            this.btnDeleteSetting.TabIndex = 8;
            this.btnDeleteSetting.Text = "Delete";
            this.btnDeleteSetting.UseVisualStyleBackColor = true;
            this.btnDeleteSetting.Click += new System.EventHandler(this.btnDeleteSetting_Click);
            // 
            // btnUpdateSetting
            // 
            this.btnUpdateSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateSetting.Location = new System.Drawing.Point(687, 31);
            this.btnUpdateSetting.Name = "btnUpdateSetting";
            this.btnUpdateSetting.Size = new System.Drawing.Size(81, 22);
            this.btnUpdateSetting.TabIndex = 9;
            this.btnUpdateSetting.Text = "Update";
            this.btnUpdateSetting.UseVisualStyleBackColor = true;
            this.btnUpdateSetting.Click += new System.EventHandler(this.btnUpdateSetting_Click);
            // 
            // btnAddSetting
            // 
            this.btnAddSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddSetting.Location = new System.Drawing.Point(687, 3);
            this.btnAddSetting.Name = "btnAddSetting";
            this.btnAddSetting.Size = new System.Drawing.Size(81, 22);
            this.btnAddSetting.TabIndex = 7;
            this.btnAddSetting.Text = "Add";
            this.btnAddSetting.UseVisualStyleBackColor = true;
            this.btnAddSetting.Click += new System.EventHandler(this.btnAddSetting_Click);
            // 
            // btnTesteConnectionString
            // 
            this.btnTesteConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTesteConnectionString.Location = new System.Drawing.Point(607, 31);
            this.btnTesteConnectionString.Name = "btnTesteConnectionString";
            this.btnTesteConnectionString.Size = new System.Drawing.Size(74, 22);
            this.btnTesteConnectionString.TabIndex = 10;
            this.btnTesteConnectionString.Text = "Test";
            this.btnTesteConnectionString.UseVisualStyleBackColor = true;
            this.btnTesteConnectionString.Click += new System.EventHandler(this.btnTesteConnectionString_Click);
            // 
            // btnStringConnectionFormat
            // 
            this.btnStringConnectionFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStringConnectionFormat.Location = new System.Drawing.Point(607, 59);
            this.btnStringConnectionFormat.Name = "btnStringConnectionFormat";
            this.btnStringConnectionFormat.Size = new System.Drawing.Size(74, 24);
            this.btnStringConnectionFormat.TabIndex = 11;
            this.btnStringConnectionFormat.Text = "Str. Format ";
            this.btnStringConnectionFormat.UseVisualStyleBackColor = true;
            this.btnStringConnectionFormat.Click += new System.EventHandler(this.btnStringConnectionFormat_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(777, 362);
            this.Controls.Add(this.tableLayoutPanelFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings Manager";
            this.tableLayoutPanelFooter.ResumeLayout(false);
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFooter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label lblStringConnection;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label lblDbms;
        private System.Windows.Forms.ComboBox comboBoxDbms;
        private System.Windows.Forms.CheckBox checkBoxDefaultSetting;
        private System.Windows.Forms.ListView listViewSettings;
        private System.Windows.Forms.Button btnAddSetting;
        private System.Windows.Forms.Button btnDeleteSetting;
        private System.Windows.Forms.ColumnHeader columnHeaderDefault;
        private System.Windows.Forms.ColumnHeader columnHeaderAlias;
        private System.Windows.Forms.ColumnHeader columnHeaderStringConnection;
        private System.Windows.Forms.ColumnHeader columnHeaderDbms;        
        private System.Windows.Forms.Button btnUpdateSetting;
        private System.Windows.Forms.Button btnTesteConnectionString;
        private System.Windows.Forms.Button btnStringConnectionFormat;
    }
}