using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using Lucene.Net;
using Version = Lucene.Net.Util.Version;
using Lucene.Net.Store;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;


namespace Project
{
  
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.KeyPreview = true;
           
        }

        //Connecting to the Access database.
        public void AccessConn(string path)
        {
            try
            {
                Properties.Settings.Default.CurrentDataModel = "MyAccess";
                Properties.Settings.Default.CurrentDatabaseType = "Access";

                // Set the access database connection properties
                Properties.Settings.Default.ProviderString = "Microsoft.ACE.OLEDB.12.0";

                // Set the access database connection string
                Properties.Settings.Default.ConnString = "Provider=" + Properties.Settings.Default.ProviderString +
                                    ";Data Source=" + path;

                // Save the properties
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source: " + ex.Message, "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Properties.Settings.Default.ConnString != string.Empty)
            {
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                {
                    try
                    {
                        // test the connection with an open attempt
                        conn.Open();
                        MessageBox.Show("Access connection successful", "Connection Status");
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
   
        //Creating a datatable and filling the dataGridView.
        DataTable dt;
        public void FillDataGridView()
        {
            dt = new DataTable();
            dt.Clear();
            dataGridView.DataSource = dt;
            using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
            {
                conn.Open();
                string strsql = string.Format("SELECT * FROM {0}", Variables.selectedtablename);
                using (OleDbCommand com = new OleDbCommand(strsql, conn))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = com;
                        da.Fill(dt);
                    }
                }
            }
        }

        //Creating a Lucene.Net index
        Lucene.Net.Store.Directory createIndex(DataTable table)
        {
            var directory = new RAMDirectory();

            using (Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
            using (var writer = new IndexWriter(directory, analyzer, new IndexWriter.MaxFieldLength(1000)))
            { // the writer and analyzer will popuplate the directory with documents

                string fieldNum = "";
                string[] fields = new string[Variables.fieldnames.Count()];

                foreach (DataRow row in table.Rows)
                {
                    var document = new Document();

                    for (int i = 0; i < Variables.fieldnames.Count(); i++)
                    {
                        document.Add(new Field(Variables.fieldnames[i], row[Variables.fieldnames[i]].ToString(), Field.Store.YES, Field.Index.ANALYZED));
                        fieldNum += "{" + i + "} ";
                        fields[i] += row[Variables.fieldnames[i]].ToString();

                    }

                    document.Add(new Field("FullText", string.Format(fieldNum, fields), Field.Store.YES, Field.Index.ANALYZED));
                    fieldNum = "";
                    Array.Clear(fields, 0, fields.Length);

                    writer.AddDocument(document);
                }
                writer.Optimize();
                writer.Flush(true, true, true);
            }
            return directory;
        }
        
        //The method that searhes the database.
        DataTable search(string textSearch)
        {
            var table = dt.Clone();
            var Index = createIndex(dt);

            using (var reader = IndexReader.Open(Index, true))
            using (var searcher = new IndexSearcher(reader))
            {
                using (Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
                {
                    var queryParser = new QueryParser(Version.LUCENE_30, "FullText", analyzer);

                    queryParser.AllowLeadingWildcard = true;

                    var query = queryParser.Parse(textSearch);

                    var collector = TopScoreDocCollector.Create(1000, true);

                    searcher.Search(query, collector);

                    var matches = collector.TopDocs().ScoreDocs;

                    foreach (var item in matches)
                    {
                        var id = item.Doc;
                        var doc = searcher.Doc(id);

                        var row = table.NewRow();

                        for (int i = 0; i < Variables.fieldnames.Count(); i++)
                        {
                            row[Variables.fieldnames[i]] = doc.GetField(Variables.fieldnames[i]).StringValue;
                        }
                        table.Rows.Add(row);
                    }
                }
            }
            return table;
        }

        //Trimming the textbox text and  calling the search method.
        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(SearchTextbox.Text))
                {
                    var query = SearchTextbox.Text.Trim();

                    var results = search(query);

                    dataGridView.DataSource = results;
                }
                else
                {
                    throw  new EmptySearchTextBox();
                }
              
            }
            catch (Exception)
            {           
              
            }
           
        }

        //Activating the SearchButton_Click if you press the "ENTER" button.
        private void Project_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(this, new EventArgs());
            }
        }

        //refreshing the dataGriedView with the selected table.
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Table Selection Error");
                
            }

            
        }

        //Handles the Menu Items
        //===================================================================
        //Open a FileDialog to select a database.
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // opens the file dialog to select a database
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "Database Files (*.accdb, *.mdb)|*.accdb;*.mdb|" +
              "All files (*.*)|*.*"; ;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = openFileDialog.FileName;
                    // calling the connection method with the path
                    AccessConn(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Closing the connection with the database.
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ConnString = "temp";
        }

        //Exiting the program.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //Showing the DBSchemas.cs from for selecting the Tables and Fields.
        private void tablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBSchemas form = new DBSchemas();
            form.Show();
        }
        //====================================================================
    }
}