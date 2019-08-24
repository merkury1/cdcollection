using CDsViewer.ServiceReference;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace CDsViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataGrid dataGrid;

        public MainWindow()
        {
            InitializeComponent();
            InitializeControls();
        }

        void InitializeControls()
        {
            Button downloadButton = new Button();
            downloadButton.Content = "Pobierz";
            downloadButton.Margin = new Thickness(20, 20, 650, 0);
            downloadButton.Height = 20;
            downloadButton.Width = 100;
            downloadButton.Foreground = new SolidColorBrush(Colors.Red);
            Panel.Children.Add(downloadButton);

            downloadButton.Click += new RoutedEventHandler(DownloadButton_Click);

            dataGrid = new DataGrid();
            dataGrid.Margin = new Thickness(20, 20, 20, 20);
            dataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            dataGrid.Height = 300;
            Panel.Children.Add(dataGrid);

            DataGridTextColumn titleColumn = new DataGridTextColumn();
            titleColumn.Header = "Tytuł";
            titleColumn.Binding = new Binding("Title");
            titleColumn.Width = 100;
            dataGrid.Columns.Add(titleColumn);

            DataGridTextColumn artistColumn = new DataGridTextColumn();
            artistColumn.Header = "Artysta";
            artistColumn.Binding = new Binding("Artist");
            artistColumn.Width = 140;
            dataGrid.Columns.Add(artistColumn);

            DataGridTextColumn countryColumn = new DataGridTextColumn();
            countryColumn.Header = "Kraj";
            countryColumn.Binding = new Binding("Country");
            countryColumn.Width = 140;
            dataGrid.Columns.Add(countryColumn);

            DataGridTextColumn companyColumn = new DataGridTextColumn();
            companyColumn.Header = "Firma";
            companyColumn.Binding = new Binding("Company");
            companyColumn.Width = 140;
            dataGrid.Columns.Add(companyColumn);

            DataGridTextColumn yearColumn = new DataGridTextColumn();
            yearColumn.Header = "Rok";
            yearColumn.Binding = new Binding("Year");
            yearColumn.Width = 140;
            dataGrid.Columns.Add(yearColumn);
        }

        void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceClient client = new ServiceClient();
            List<CD> cdsCollection = new List<CD>();

            try
            {
                cdsCollection = client.GetCDCollection();
            }
            catch
            {
                MessageBox.Show("Problem z połączeniem do serwisu na IIS");
            }

            if (cdsCollection.Count > 0)
            {
                foreach (var cd in cdsCollection)
                {
                    dataGrid.Items.Add(new CD()
                    {
                        Title = cd.Title,
                        Artist = cd.Artist,
                        Country = cd.Country,
                        Company = cd.Company,
                        Year = cd.Year
                    });
                }
            }
        }
    }
}
