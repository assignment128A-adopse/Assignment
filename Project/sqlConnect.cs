using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Project
{
    public partial class sqlConnect : Form
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public sqlConnect()
        {
            InitializeComponent();
        }


        /// <summary>
        /// SQL Server 
        /// Configure for the use of integrated
        /// security
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSQLserverCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        /// <summary>
        /// Test the SQL Server connection string
        /// based upon the user supplied settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        


    }
}