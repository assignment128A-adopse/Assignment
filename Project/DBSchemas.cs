using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace Project
{
    public partial class DBSchemas : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DBSchemas()
        {
            InitializeComponent();
            this.CenterToParent();
            TableListbox.Items.Clear();
            FillArrays();
        }

        //Used to hold a list of views and tables
        ArrayList arrTables; 

        //Method to fill the arrays.
        public void FillArrays()
        {
            try
            {
                StoreTables();
                //Clear internal lists
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

            //Make sure we have a connection
            if (Properties.Settings.Default.ConnString != string.Empty)
            {
                //Start up the connection using the current connection string
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                {
                    try
                    {
                        //Open the connection to the database 
                        conn.Open();

                        //Get the Tables
                        SchemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });

                        //Store the table names in the class scoped array list of table names
                        for (int i = 0; i < SchemaTable.Rows.Count; i++)
                        {
                            arrTables.Add(SchemaTable.Rows[i].ItemArray[2].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        //Break and notify if there's a connection failure
                        MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //Make sure we have a connection
            if (Properties.Settings.Default.ConnString != string.Empty)
            {
                //Start up the connection using the current connection string
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                {
                    try
                    {
                        //Open the connection to the database 
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
                        //Break and notify if there's a connection failure
                        MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("There is no connection string current defined.", "Connection String", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        //Triggered when the Show Button is pressed.
        private void ShowButton_Click(object sender, EventArgs e)
        {
            Variables.selectedTableName = TableListbox.SelectedItem.ToString();
            int j = 0;
            //Adding items to the fieldNames array.
            Variables.fieldNames = new String[FieldListbox.Items.Count];
            foreach (Object item in FieldListbox.Items)
            {
                Variables.fieldNames[j++] = item.ToString();
            }

            int k = 0;
            //Adding items to the selectedFieldsName array.
            Variables.selectedFieldsName = new String[FieldListbox.SelectedItems.Count];
            foreach (Object item in FieldListbox.SelectedItems)
            {
                Variables.selectedFieldsName[k++] = item.ToString();
            }

            //Creating an instance of the <Project> form and bring to font.
            var ProjectForm = Application.OpenForms.OfType<Project>().Single();
            ProjectForm.FillDataGridView();
            this.Dispose();
        }
    }
}

//Declairing some variables to use them in the <Project> Form.
class Variables
{
    public static string selectedTableName;
    public static string[] selectedFieldsName;
    public static string[] fieldNames;
}