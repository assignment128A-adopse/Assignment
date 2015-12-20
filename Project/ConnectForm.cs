using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Project
{
    public partial class ConnectForm : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ConnectForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Browse for an access database
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // opens the file dialog to select a database
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFile.Title = "MS Access Database";
            openFile.Filter = "Database Files (*.accdb, *.mdb)|*.accdb;*.mdb|" + "All files (*.*)|*.*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtAccessDBname.Text = openFile.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Close the form
        /// </summary>
        private void btnAccessCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Test an MS Access database connection
        /// </summary>
        private void btnAccessTest_Click(object sender, EventArgs e)
        {
            try
            {
                // Future use; if a current data model and database
                // type need to be identified and saved with the connect
                // string to identify its purpose
                Properties.Settings.Default.CurrentDataModel = "MyAccess";
                Properties.Settings.Default.CurrentDatabaseType = "Access";

                // Set the access database connection properties
                Properties.Settings.Default.ProviderString = txtAccessProvider.Text;
                Properties.Settings.Default.Password = txtAccessPassword.Text;
                Properties.Settings.Default.UserID = txtAccessUserID.Text;
                Properties.Settings.Default.ServerName = txtAccessDBname.Text;

                // Set the access database connection string
                Properties.Settings.Default.ConnString = "Provider=" + Properties.Settings.Default.ProviderString +
                                    ";Password=" + Properties.Settings.Default.Password +
                                    ";User ID=" + Properties.Settings.Default.UserID +
                                    ";Data Source=" + Properties.Settings.Default.ServerName;

                // Save the properties
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                // inform the user if the connection could not be saved
                MessageBox.Show("Failed to connect to data source: " + ex.Message, "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Test Connection
            if (Properties.Settings.Default.ConnString != string.Empty)
            {
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                {
                    try
                    {
                        // test the connection with an open attempt
                        conn.Open();
                        MessageBox.Show("Access connection test successful", "Connection Test");
                    }
                    catch (Exception ex)
                    {
                        // inform the user if the connection failed
                        MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Persist and test an Access database connection
        /// </summary>
        private void btnAccessOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Future use; if a current data model and database
                // type need to be identified and saved with the connect
                // string to identify its purpose
                Properties.Settings.Default.CurrentDataModel = "MyAccess";
                Properties.Settings.Default.CurrentDatabaseType = "Access";

                // Set the access database connection properties
                Properties.Settings.Default.ProviderString = txtAccessProvider.Text;
                Properties.Settings.Default.Password = txtAccessPassword.Text;
                Properties.Settings.Default.UserID = txtAccessUserID.Text;
                Properties.Settings.Default.ServerName = txtAccessDBname.Text;

                // Set the access database connection string
                Properties.Settings.Default.ConnString = "Provider=" + Properties.Settings.Default.ProviderString +
                                    ";Password=" + Properties.Settings.Default.Password +
                                    ";User ID=" + Properties.Settings.Default.UserID +
                                    ";Data Source=" + Properties.Settings.Default.ServerName;

                // Save the properties
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                // Inform the user if the connection was not saved
                MessageBox.Show(ex.Message, "Error saving connection information.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Test Connection
            if (Properties.Settings.Default.ConnString != string.Empty)
            {
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                {
                    try
                    {
                        // test the database connection string with an open attempt
                        conn.Open();
                        this.Dispose();

                        // creating a form instance and calling it
                        DBSchemas form = new DBSchemas();
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        // inform the user if the connection failed
                        MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }        

        /// <summary>
        /// SQL Server 
        /// Configure for the use of integrated
        /// security
        /// </summary>
        private void cbxIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            // if the user has checked the SQL Server connection
            // option to use integrated security, configure the
            //user ID and password controls accordingly

            if (cbxIntegratedSecurity.Checked == true)
            {
                txtSqlServerUserID.Text = string.Empty;
                txtSqlServerPassword.Text = string.Empty;

                txtSqlServerUserID.Enabled = false;
                txtSqlServerPassword.Enabled = false;
            }
            else
            {
                txtSqlServerUserID.Enabled = true;
                txtSqlServerPassword.Enabled = true;
            }
        }

        /// <summary>
        /// Close the form
        /// </summary>
        private void btnSQLserverCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Test the SQL Server connection string
        /// based upon the user supplied settings
        /// </summary>
        private void btnSqlServerTest_Click(object sender, EventArgs e)
        {
            try
            {
                // Future use; if a current data model and database
                // type need to be identified and saved with the connect
                // string to identify its purpose
                Properties.Settings.Default.CurrentDataModel = "MySqlServer";
                Properties.Settings.Default.CurrentDatabaseType = "SqlServer";

                // Set the properties for the connection string
                Properties.Settings.Default.ProviderString = txtSqlServerProvider.Text;
                Properties.Settings.Default.Password = txtSqlServerPassword.Text;
                Properties.Settings.Default.UserID = txtSqlServerUserID.Text;
                Properties.Settings.Default.ServerName = txtSqlServerDBName.Text;
                Properties.Settings.Default.InitialCatalog = txtSqlServerInitialCat.Text;

                // configure the connection string based upon the use
                // of integrated security
                if (cbxIntegratedSecurity.Checked == true)
                {
                    Properties.Settings.Default.ConnString =
                        "Provider=" + Properties.Settings.Default.ProviderString +
                        ";Data Source=" + Properties.Settings.Default.ServerName +
                        ";Initial Catalog=" + Properties.Settings.Default.InitialCatalog +
                        ";Integrated Security=SSPI;";
                }
                else
                {
                    Properties.Settings.Default.ConnString =
                        "Provider=" + Properties.Settings.Default.ProviderString +
                        ";Password=" + Properties.Settings.Default.Password +
                        ";User ID=" + Properties.Settings.Default.UserID +
                        ";Data Source=" + Properties.Settings.Default.ServerName +
                        ";Initial Catalog=" + Properties.Settings.Default.InitialCatalog;
                }
                // Save the property settings
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                // inform the user if the connection was not saved
                MessageBox.Show(ex.Message, "Error saving connection information.");
            }

            //Test Connection
            if (Properties.Settings.Default.ConnString != string.Empty)
            {
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                {
                    try
                    {
                        // test the connection with an open attempt
                        conn.Open();
                        MessageBox.Show("Connection Attempt Successful.", "Connection Test");
                    }
                    catch (Exception ex)
                    {
                        // inform the user if the connection test failed
                        MessageBox.Show(ex.Message, "Connection Test");
                    }
                }
            }
        }

        /// <summary>
        /// Persist and test an SQL Server connection
        /// </summary>
        private void btnSqlServerOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Future use; if a current data model and database
                // type need to be identified and saved with the connect
                // string to identify its purpose
                Properties.Settings.Default.CurrentDataModel = "MySqlServer";
                Properties.Settings.Default.CurrentDatabaseType = "SqlServer";

                // Set the properties for the connection 
                Properties.Settings.Default.ProviderString = txtSqlServerProvider.Text;
                Properties.Settings.Default.Password = txtSqlServerPassword.Text;
                Properties.Settings.Default.UserID = txtSqlServerUserID.Text;
                Properties.Settings.Default.ServerName = txtSqlServerDBName.Text;
                Properties.Settings.Default.InitialCatalog = txtSqlServerInitialCat.Text;

                // configure the connection string based upon
                // the use of integrated security
                if (cbxIntegratedSecurity.Checked == true)
                {
                    Properties.Settings.Default.ConnString =
                        "Provider=" + Properties.Settings.Default.ProviderString +
                        ";Data Source=" + Properties.Settings.Default.ServerName +
                        ";Initial Catalog=" + Properties.Settings.Default.InitialCatalog +
                        ";Integrated Security=SSPI;";
                }
                else
                {
                    Properties.Settings.Default.ConnString =
                        "Provider=" + Properties.Settings.Default.ProviderString +
                        ";Password=" + Properties.Settings.Default.Password +
                        ";User ID=" + Properties.Settings.Default.UserID +
                        ";Data Source=" + Properties.Settings.Default.ServerName +
                        ";Initial Catalog=" + Properties.Settings.Default.InitialCatalog;
                }
                // Save the property settings
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                // inform the user if the connection information was not saved
                MessageBox.Show(ex.Message, "Error saving connection information.");
            }

            //Test Connection
            if (Properties.Settings.Default.ConnString != string.Empty)
            {
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                {
                    try
                    {
                        // test the connection with an open attempt
                        conn.Open();
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        // inform the user if the connection was not saved
                        MessageBox.Show(ex.Message, "Connection Test");
                    }
                }
            }
        }
                
    }
}