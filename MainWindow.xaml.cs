using PostForApi.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace PostForApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //VARIABLES
        private DataTable dataTable = new DataTable();

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "localhost",
                IntegratedSecurity = true,
                InitialCatalog = "FreyaRestaurant222"
            };
            Debug.WriteLine(connectionString.ToString());

            using (SqlConnection con = new SqlConnection(connectionString.ToString()))
            {
                try
                {
                    con.Open();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("Connection error: " + ex.Message);
                }

                string commandText = "select top 100 id, startDate, finishDate, paidDate, totalValueWithVat from STOrder";
                SqlCommand command = new SqlCommand(commandText, con);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dataTable);
                    con.Close();
                    da.Dispose();
                }
                catch(Exception ex)
                {
                    Debug.Write("Command error: " + ex.Message);
                }
            }

            Model model = new Model();

            for(int i = 0; i < dataTable.Columns.Count; i++)
            {
                Header header = new Header();
                header.ColumnName = dataTable.Columns[i].ColumnName;
                header.Size = 100;
                header.Type = dataTable.Columns[i].DataType.ToString();

                model.Headers.Add(header);
            }

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                
            }

        }
    }
}
