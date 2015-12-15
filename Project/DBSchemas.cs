using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Project
{
    public partial class DBSchemas : Form
    {
        public DBSchemas()
        {
            InitializeComponent();
            this.CenterToParent();
            TableListbox.Items.Clear();
            FillArrays();
        }

        //Variable Declaration
        ArrayList arrTables; // used to hold a list of views and tables
        public string mSelectedTable; //

        //Method to fill the arrays.
        public void FillArrays()
        {
            try
            {
                StoreTables();
                // clear internal lists
                TableListbox.Items.Clear();

                // update the lists from the arrays holding the
                // tables and views
                TableListbox.Items.AddRange(arrTables.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Error");
                this.Dispose();
            }
        }

        public void StoreTables()
        {
            // temporary holder for the schema information for the current
            // database connection
            DataTable SchemaTable;

            arrTables = new ArrayList();

            // clean up the menu so the menu item does not
            // hang while this function executes
            this.Refresh();

            // make sure we have a connection
            if (Properties.Settings.Default.ConnString != string.Empty)
            {
                // start up the connection using the current connection string
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                {
                    try
                    {
                        // open the connection to the database 
                        conn.Open();

                        // Get the Tables
                        SchemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });

                        // Store the table names in the class scoped array list of table names
                        for (int i = 0; i < SchemaTable.Rows.Count; i++)
                        {
                            arrTables.Add(SchemaTable.Rows[i].ItemArray[2].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // break and notify if the connection fails
                        MessageBox.Show(ex.Message, "Connection Error");
                    }
                }
            }
        }

        //Triggered when we select an Item in the TableList.
        private void TableListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tblName;

            try
            {
                tblName = TableListbox.SelectedItem.ToString();
            }
            catch
            {
                return;
            }

            // make sure we have a connection
            if (Properties.Settings.Default.ConnString != string.Empty)
            {
                // start up the connection using the current connection string
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                {

                    try
                    {
                        // open the connection to the database 
                        conn.Open();
                        FieldListbox.Items.Clear();

                        DataTable dtField = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tblName });

                        foreach (DataRow dr in dtField.Rows)
                        {
                            FieldListbox.Items.Add(dr["COLUMN_NAME"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Connection Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("There is no connection string current defined.", "Connection String");
            }
        }
    
        //Triggered when the Show Button is pressed.
        private void ShowButton_Click(object sender, EventArgs e)
        {
            Variables.selectedtablename = TableListbox.SelectedItem.ToString();
            int j = 0;
            //adding items to the fieldnames array.
            Variables.fieldnames = new String[FieldListbox.Items.Count];
            foreach (Object item in FieldListbox.Items)
            {
                Variables.fieldnames[j++] = item.ToString();
            }

            //creating an instance of the <Project> form and bring to font.
            var ProjectForm = Application.OpenForms.OfType<Project>().Single();
            ProjectForm.FillDataGridView();
            this.Close();
        }
    }
}
//Storing some variables to use them in the Project Form.
class Variables
{
    public static string selectedtablename;
    //public static string[] selectedfieldsname;
    public static string[] fieldnames;
}