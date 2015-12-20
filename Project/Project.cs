using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Version = Lucene.Net.Util.Version;

namespace Project
{
    public partial class Project : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Project()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.KeyPreview = true;
        }

        string path = System.IO.Directory.GetCurrentDirectory();
        //Creating a Lucene.Net index
        Lucene.Net.Store.Directory createIndex(DataTable table)
        {
            try
            {
                Lucene.Net.Store.Directory directory = Lucene.Net.Store.FSDirectory.Open(path);

                using (Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
                using (var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED))
                { // the writer and analyzer will popuplate the directory with documents

                    string fieldNum = "";
                    string[] fields = new string[Variables.fieldNames.Count()];

                    foreach (DataRow row in table.Rows)
                    {
                        Properties.Settings.Default.document = new Document();

                        for (int i = 0; i < Variables.fieldNames.Count(); i++)
                        {
                            Properties.Settings.Default.document.Add(new Field(Variables.fieldNames[i], row[Variables.fieldNames[i]].ToString(), Field.Store.YES, Field.Index.ANALYZED));
                            fieldNum += "{" + i + "} ";
                            fields[i] += row[Variables.fieldNames[i]].ToString();
                        }

                        Properties.Settings.Default.document.Add(new Field("FullText", string.Format(fieldNum, fields), Field.Store.YES, Field.Index.ANALYZED));
                        fieldNum = "";
                        Array.Clear(fields, 0, fields.Length);

                        writer.AddDocument(Properties.Settings.Default.document);
                    }

                    writer.Optimize();
                    writer.Commit(); //Add This
                }
                return directory;
            }
            catch (Exception)
            {
                MessageBox.Show("Some Error occured", "Error!");
                return null;
            }
        }

        IndexReader reader;
        //Searhes the index we just created.
        DataTable search(string textSearch)
        {
            try
            {
                var table = dt.Clone();
                var Index = createIndex(dt);

                reader = IndexReader.Open(Index, true);
                Lucene.Net.Store.Directory directory = Lucene.Net.Store.FSDirectory.Open(new System.IO.DirectoryInfo(path));

                using (reader = IndexReader.Open(Index, true))
                using (Lucene.Net.Search.Searcher searcher = new Lucene.Net.Search.IndexSearcher(Lucene.Net.Index.IndexReader.Open(directory, true)))
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

                            for (int i = 0; i < Variables.fieldNames.Count(); i++)
                            {
                                row[Variables.fieldNames[i]] = doc.GetField(Variables.fieldNames[i]).StringValue;
                            }

                            table.Rows.Add(row);
                        }
                    }
                }
                return table;
            }
            catch (Exception)
            {
                MessageBox.Show("Some Error occured", "Error!");
                return null;
            }
        }

        //Trimming the textbox text and calling the search method.
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
                    throw new EmptySearchTextBox();
                }

            }
            catch (Exception)
            {

            }
        }
 
        DataTable dt;
        //Creating a datatable and filling the dataGridView.
        public void FillDataGridView()
        {
            dt = new DataTable();
            dt.Clear();
            dataGridView.DataSource = dt;

            using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
            {
                conn.Open();
                string strsql = string.Format("SELECT * FROM {0}", Variables.selectedTableName);
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

        //Activating the "SearchButton_Click" event if you press the "ENTER" button.
        private void Project_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(this, new EventArgs());
            }
        }

        //Refreshing the dataGridView with the selected table.
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

        /// <summary>
        /// Handles the Menu Items
        /// </summary>

        //Showing the ConnectForm.cs
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectForm form = new ConnectForm();
            form.Show();
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
        //===================================================================
    }
}

