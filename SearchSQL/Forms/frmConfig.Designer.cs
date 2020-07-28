namespace SearchSQL
{
    partial class frmConfig
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
            this.tableLayoutPanelConfig = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblStringConnection = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblDbms = new System.Windows.Forms.Label();
            this.cbDbms = new System.Windows.Forms.ComboBox();
            this.checkBoxMainConfig = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelConfig.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelConfig
            // 
            this.tableLayoutPanelConfig.ColumnCount = 2;
            this.tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConfig.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanelConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelConfig.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelConfig.Name = "tableLayoutPanelConfig";
            this.tableLayoutPanelConfig.RowCount = 2;
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.58747F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.41253F));
            this.tableLayoutPanelConfig.Size = new System.Drawing.Size(615, 383);
            this.tableLayoutPanelConfig.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanelConfig.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.46352F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.53648F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.Controls.Add(this.lblAlias, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStringConnection, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAlias, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtConnectionString, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDbms, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbDbms, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxMainConfig, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 92);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblAlias
            // 
            this.lblAlias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlias.Location = new System.Drawing.Point(3, 0);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(104, 30);
            this.lblAlias.TabIndex = 0;
            this.lblAlias.Text = "Alias:";
            this.lblAlias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStringConnection
            // 
            this.lblStringConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStringConnection.Location = new System.Drawing.Point(3, 30);
            this.lblStringConnection.Name = "lblStringConnection";
            this.lblStringConnection.Size = new System.Drawing.Size(104, 30);
            this.lblStringConnection.TabIndex = 1;
            this.lblStringConnection.Text = "String Connection:";
            this.lblStringConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAlias
            // 
            this.txtAlias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAlias.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAlias.Location = new System.Drawing.Point(113, 3);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(333, 22);
            this.txtAlias.TabIndex = 1;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnectionString.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConnectionString.Location = new System.Drawing.Point(113, 33);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(333, 22);
            this.txtConnectionString.TabIndex = 2;
            // 
            // lblDbms
            // 
            this.lblDbms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDbms.Location = new System.Drawing.Point(3, 60);
            this.lblDbms.Name = "lblDbms";
            this.lblDbms.Size = new System.Drawing.Size(104, 32);
            this.lblDbms.TabIndex = 4;
            this.lblDbms.Text = "Dbms:";
            this.lblDbms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbDbms
            // 
            this.cbDbms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDbms.FormattingEnabled = true;
            this.cbDbms.Location = new System.Drawing.Point(113, 63);
            this.cbDbms.Name = "cbDbms";
            this.cbDbms.Size = new System.Drawing.Size(333, 23);
            this.cbDbms.TabIndex = 5;
            // 
            // checkBoxMainConfig
            // 
            this.checkBoxMainConfig.AutoSize = true;
            this.checkBoxMainConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxMainConfig.Location = new System.Drawing.Point(452, 3);
            this.checkBoxMainConfig.Name = "checkBoxMainConfig";
            this.checkBoxMainConfig.Size = new System.Drawing.Size(154, 24);
            this.checkBoxMainConfig.TabIndex = 6;
            this.checkBoxMainConfig.Text = "Main Config";
            this.checkBoxMainConfig.UseVisualStyleBackColor = true;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 383);
            this.Controls.Add(this.tableLayoutPanelConfig);
            this.Name = "frmConfig";
            this.Text = "frmConfig";
            this.tableLayoutPanelConfig.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label lblStringConnection;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label lblDbms;
        private System.Windows.Forms.ComboBox cbDbms;
        private System.Windows.Forms.CheckBox checkBoxMainConfig;
    }
}