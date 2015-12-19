namespace Project
{
    partial class sqlConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sqlConnect));
            this.TabSqlServer = new System.Windows.Forms.TabPage();
            this.gbxSqlServer2 = new System.Windows.Forms.GroupBox();
            this.lblSqlServerName = new System.Windows.Forms.Label();
            this.txtSqlServerDBName = new System.Windows.Forms.TextBox();
            this.gbxSqlServer4 = new System.Windows.Forms.GroupBox();
            this.lblSqlServerUserID = new System.Windows.Forms.Label();
            this.lblSqlServerPassword = new System.Windows.Forms.Label();
            this.txtSqlServerUserID = new System.Windows.Forms.TextBox();
            this.txtSqlServerPassword = new System.Windows.Forms.TextBox();
            this.cbxIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.gbxSqlServer5 = new System.Windows.Forms.GroupBox();
            this.btnSqlServerOK = new System.Windows.Forms.Button();
            this.btnSqlServerTest = new System.Windows.Forms.Button();
            this.btnSQLserverCancel = new System.Windows.Forms.Button();
            this.gbxSqlServer1 = new System.Windows.Forms.GroupBox();
            this.lblSqlServerProvider = new System.Windows.Forms.Label();
            this.txtSqlServerProvider = new System.Windows.Forms.TextBox();
            this.gbxSqlServer3 = new System.Windows.Forms.GroupBox();
            this.lblSqlServerInitialCat = new System.Windows.Forms.Label();
            this.txtSqlServerInitialCat = new System.Windows.Forms.TextBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabSqlServer.SuspendLayout();
            this.gbxSqlServer2.SuspendLayout();
            this.gbxSqlServer4.SuspendLayout();
            this.gbxSqlServer5.SuspendLayout();
            this.gbxSqlServer1.SuspendLayout();
            this.gbxSqlServer3.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabSqlServer
            // 
            this.TabSqlServer.Controls.Add(this.gbxSqlServer3);
            this.TabSqlServer.Controls.Add(this.gbxSqlServer1);
            this.TabSqlServer.Controls.Add(this.gbxSqlServer5);
            this.TabSqlServer.Controls.Add(this.gbxSqlServer4);
            this.TabSqlServer.Controls.Add(this.gbxSqlServer2);
            this.TabSqlServer.Location = new System.Drawing.Point(4, 22);
            this.TabSqlServer.Name = "TabSqlServer";
            this.TabSqlServer.Size = new System.Drawing.Size(352, 438);
            this.TabSqlServer.TabIndex = 1;
            this.TabSqlServer.Text = "SQL Server";
            this.TabSqlServer.UseVisualStyleBackColor = true;
            this.TabSqlServer.Visible = false;
            // 
            // gbxSqlServer2
            // 
            this.gbxSqlServer2.Controls.Add(this.txtSqlServerDBName);
            this.gbxSqlServer2.Controls.Add(this.lblSqlServerName);
            this.gbxSqlServer2.Location = new System.Drawing.Point(8, 103);
            this.gbxSqlServer2.Name = "gbxSqlServer2";
            this.gbxSqlServer2.Size = new System.Drawing.Size(336, 80);
            this.gbxSqlServer2.TabIndex = 13;
            this.gbxSqlServer2.TabStop = false;
            this.gbxSqlServer2.Text = "Data Source";
            // 
            // lblSqlServerName
            // 
            this.lblSqlServerName.Location = new System.Drawing.Point(24, 24);
            this.lblSqlServerName.Name = "lblSqlServerName";
            this.lblSqlServerName.Size = new System.Drawing.Size(80, 16);
            this.lblSqlServerName.TabIndex = 0;
            this.lblSqlServerName.Text = "Server Name: ";
            // 
            // txtSqlServerDBName
            // 
            this.txtSqlServerDBName.Location = new System.Drawing.Point(40, 43);
            this.txtSqlServerDBName.Name = "txtSqlServerDBName";
            this.txtSqlServerDBName.Size = new System.Drawing.Size(248, 20);
            this.txtSqlServerDBName.TabIndex = 3;
            // 
            // gbxSqlServer4
            // 
            this.gbxSqlServer4.Controls.Add(this.cbxIntegratedSecurity);
            this.gbxSqlServer4.Controls.Add(this.txtSqlServerPassword);
            this.gbxSqlServer4.Controls.Add(this.txtSqlServerUserID);
            this.gbxSqlServer4.Controls.Add(this.lblSqlServerPassword);
            this.gbxSqlServer4.Controls.Add(this.lblSqlServerUserID);
            this.gbxSqlServer4.Location = new System.Drawing.Point(8, 272);
            this.gbxSqlServer4.Name = "gbxSqlServer4";
            this.gbxSqlServer4.Size = new System.Drawing.Size(336, 104);
            this.gbxSqlServer4.TabIndex = 14;
            this.gbxSqlServer4.TabStop = false;
            this.gbxSqlServer4.Text = "User Credentials";
            // 
            // lblSqlServerUserID
            // 
            this.lblSqlServerUserID.Location = new System.Drawing.Point(23, 21);
            this.lblSqlServerUserID.Name = "lblSqlServerUserID";
            this.lblSqlServerUserID.Size = new System.Drawing.Size(64, 23);
            this.lblSqlServerUserID.TabIndex = 0;
            this.lblSqlServerUserID.Text = "User ID:";
            this.lblSqlServerUserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSqlServerPassword
            // 
            this.lblSqlServerPassword.Location = new System.Drawing.Point(23, 49);
            this.lblSqlServerPassword.Name = "lblSqlServerPassword";
            this.lblSqlServerPassword.Size = new System.Drawing.Size(64, 23);
            this.lblSqlServerPassword.TabIndex = 1;
            this.lblSqlServerPassword.Text = "Password:";
            this.lblSqlServerPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSqlServerUserID
            // 
            this.txtSqlServerUserID.Location = new System.Drawing.Point(88, 22);
            this.txtSqlServerUserID.Name = "txtSqlServerUserID";
            this.txtSqlServerUserID.Size = new System.Drawing.Size(200, 20);
            this.txtSqlServerUserID.TabIndex = 2;
            // 
            // txtSqlServerPassword
            // 
            this.txtSqlServerPassword.Location = new System.Drawing.Point(88, 51);
            this.txtSqlServerPassword.Name = "txtSqlServerPassword";
            this.txtSqlServerPassword.PasswordChar = '*';
            this.txtSqlServerPassword.Size = new System.Drawing.Size(200, 20);
            this.txtSqlServerPassword.TabIndex = 3;
            // 
            // cbxIntegratedSecurity
            // 
            this.cbxIntegratedSecurity.AutoSize = true;
            this.cbxIntegratedSecurity.Location = new System.Drawing.Point(88, 81);
            this.cbxIntegratedSecurity.Name = "cbxIntegratedSecurity";
            this.cbxIntegratedSecurity.Size = new System.Drawing.Size(137, 17);
            this.cbxIntegratedSecurity.TabIndex = 4;
            this.cbxIntegratedSecurity.Text = "Use Integrated Security";
            this.cbxIntegratedSecurity.UseVisualStyleBackColor = true;
            this.cbxIntegratedSecurity.CheckedChanged += new System.EventHandler(this.cbxIntegratedSecurity_CheckedChanged);
            // 
            // gbxSqlServer5
            // 
            this.gbxSqlServer5.Controls.Add(this.btnSQLserverCancel);
            this.gbxSqlServer5.Controls.Add(this.btnSqlServerTest);
            this.gbxSqlServer5.Controls.Add(this.btnSqlServerOK);
            this.gbxSqlServer5.Location = new System.Drawing.Point(8, 384);
            this.gbxSqlServer5.Name = "gbxSqlServer5";
            this.gbxSqlServer5.Size = new System.Drawing.Size(336, 48);
            this.gbxSqlServer5.TabIndex = 15;
            this.gbxSqlServer5.TabStop = false;
            // 
            // btnSqlServerOK
            // 
            this.btnSqlServerOK.Location = new System.Drawing.Point(231, 16);
            this.btnSqlServerOK.Name = "btnSqlServerOK";
            this.btnSqlServerOK.Size = new System.Drawing.Size(75, 23);
            this.btnSqlServerOK.TabIndex = 0;
            this.btnSqlServerOK.Text = "OK";
            this.btnSqlServerOK.Click += new System.EventHandler(this.btnSqlServerOK_Click);
            // 
            // btnSqlServerTest
            // 
            this.btnSqlServerTest.Location = new System.Drawing.Point(126, 16);
            this.btnSqlServerTest.Name = "btnSqlServerTest";
            this.btnSqlServerTest.Size = new System.Drawing.Size(75, 23);
            this.btnSqlServerTest.TabIndex = 1;
            this.btnSqlServerTest.Text = "Test";
            this.btnSqlServerTest.Click += new System.EventHandler(this.btnSqlServerTest_Click);
            // 
            // btnSQLserverCancel
            // 
            this.btnSQLserverCancel.Location = new System.Drawing.Point(16, 16);
            this.btnSQLserverCancel.Name = "btnSQLserverCancel";
            this.btnSQLserverCancel.Size = new System.Drawing.Size(80, 23);
            this.btnSQLserverCancel.TabIndex = 2;
            this.btnSQLserverCancel.Text = "Cancel";
            this.btnSQLserverCancel.Click += new System.EventHandler(this.btnSQLserverCancel_Click);
            // 
            // gbxSqlServer1
            // 
            this.gbxSqlServer1.Controls.Add(this.txtSqlServerProvider);
            this.gbxSqlServer1.Controls.Add(this.lblSqlServerProvider);
            this.gbxSqlServer1.Location = new System.Drawing.Point(8, 15);
            this.gbxSqlServer1.Name = "gbxSqlServer1";
            this.gbxSqlServer1.Size = new System.Drawing.Size(336, 80);
            this.gbxSqlServer1.TabIndex = 16;
            this.gbxSqlServer1.TabStop = false;
            this.gbxSqlServer1.Text = "SQL Server Data Provider";
            // 
            // lblSqlServerProvider
            // 
            this.lblSqlServerProvider.Location = new System.Drawing.Point(24, 24);
            this.lblSqlServerProvider.Name = "lblSqlServerProvider";
            this.lblSqlServerProvider.Size = new System.Drawing.Size(96, 16);
            this.lblSqlServerProvider.TabIndex = 4;
            this.lblSqlServerProvider.Text = "Provider Name: ";
            // 
            // txtSqlServerProvider
            // 
            this.txtSqlServerProvider.Location = new System.Drawing.Point(32, 43);
            this.txtSqlServerProvider.Name = "txtSqlServerProvider";
            this.txtSqlServerProvider.Size = new System.Drawing.Size(256, 20);
            this.txtSqlServerProvider.TabIndex = 6;
            this.txtSqlServerProvider.Text = "SQLOLEDB";
            // 
            // gbxSqlServer3
            // 
            this.gbxSqlServer3.Controls.Add(this.txtSqlServerInitialCat);
            this.gbxSqlServer3.Controls.Add(this.lblSqlServerInitialCat);
            this.gbxSqlServer3.Location = new System.Drawing.Point(8, 184);
            this.gbxSqlServer3.Name = "gbxSqlServer3";
            this.gbxSqlServer3.Size = new System.Drawing.Size(336, 80);
            this.gbxSqlServer3.TabIndex = 17;
            this.gbxSqlServer3.TabStop = false;
            this.gbxSqlServer3.Text = "Initial Catalog";
            // 
            // lblSqlServerInitialCat
            // 
            this.lblSqlServerInitialCat.Location = new System.Drawing.Point(24, 24);
            this.lblSqlServerInitialCat.Name = "lblSqlServerInitialCat";
            this.lblSqlServerInitialCat.Size = new System.Drawing.Size(176, 16);
            this.lblSqlServerInitialCat.TabIndex = 0;
            this.lblSqlServerInitialCat.Text = "SQL Server Initial Catalog";
            // 
            // txtSqlServerInitialCat
            // 
            this.txtSqlServerInitialCat.Location = new System.Drawing.Point(40, 43);
            this.txtSqlServerInitialCat.Name = "txtSqlServerInitialCat";
            this.txtSqlServerInitialCat.Size = new System.Drawing.Size(248, 20);
            this.txtSqlServerInitialCat.TabIndex = 3;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabSqlServer);
            this.TabControl1.Location = new System.Drawing.Point(3, 3);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(360, 464);
            this.TabControl1.TabIndex = 8;
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 468);
            this.Controls.Add(this.TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection";
            this.TabSqlServer.ResumeLayout(false);
            this.gbxSqlServer2.ResumeLayout(false);
            this.gbxSqlServer2.PerformLayout();
            this.gbxSqlServer4.ResumeLayout(false);
            this.gbxSqlServer4.PerformLayout();
            this.gbxSqlServer5.ResumeLayout(false);
            this.gbxSqlServer1.ResumeLayout(false);
            this.gbxSqlServer1.PerformLayout();
            this.gbxSqlServer3.ResumeLayout(false);
            this.gbxSqlServer3.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabPage TabSqlServer;
        internal System.Windows.Forms.GroupBox gbxSqlServer3;
        internal System.Windows.Forms.TextBox txtSqlServerInitialCat;
        internal System.Windows.Forms.Label lblSqlServerInitialCat;
        internal System.Windows.Forms.GroupBox gbxSqlServer1;
        internal System.Windows.Forms.TextBox txtSqlServerProvider;
        internal System.Windows.Forms.Label lblSqlServerProvider;
        internal System.Windows.Forms.GroupBox gbxSqlServer5;
        internal System.Windows.Forms.Button btnSQLserverCancel;
        internal System.Windows.Forms.Button btnSqlServerTest;
        internal System.Windows.Forms.Button btnSqlServerOK;
        internal System.Windows.Forms.GroupBox gbxSqlServer4;
        private System.Windows.Forms.CheckBox cbxIntegratedSecurity;
        internal System.Windows.Forms.TextBox txtSqlServerPassword;
        internal System.Windows.Forms.TextBox txtSqlServerUserID;
        internal System.Windows.Forms.Label lblSqlServerPassword;
        internal System.Windows.Forms.Label lblSqlServerUserID;
        internal System.Windows.Forms.GroupBox gbxSqlServer2;
        internal System.Windows.Forms.TextBox txtSqlServerDBName;
        internal System.Windows.Forms.Label lblSqlServerName;
        internal System.Windows.Forms.TabControl TabControl1;

    }
}

