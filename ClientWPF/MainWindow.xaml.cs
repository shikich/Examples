using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using Binance.Net.ClientWPF.UserControls;

namespace Binance.Net.ClientWPF
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

        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Symbol", ListSortDirection.Descending));

        }
    }
}
