using Binance.Net.ClientWPF.MVVM;
using System.Windows.Controls;
using Binance.Net.ClientWPF.BotAlgos;
using System.Threading.Tasks;
using System.Threading;

namespace Binance.Net.ClientWPF.UserControls
{
    /// <summary>
    /// Interaction logic for SymbolUserControl.xaml
    /// </summary>
    public partial class SymbolUserControl : UserControl
    {
        public SymbolUserControl()
        {
            InitializeComponent();          
        }

        CancellationTokenSource cts = new CancellationTokenSource();

        private async void cbBot_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BuySell bs = new BuySell();
            if (cbBot.IsChecked == true)
            {
                btnActivate.IsEnabled = true;
            }
            else
            {
                btnActivate.IsEnabled = false;
                await bs.CancelAsync();
                CancellationToken token = cts.Token;
                //await bs.Trade(token);
                cts.Cancel();
            }
        }
        private async void btnActivate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BuySell bs = new BuySell();
            if (btnActivate.Content.ToString() == "Start")
            {
                btnActivate.Content = "Stop";
                CancellationToken token = cts.Token;
                //Task.Run(async () =>
                //{
                    await bs.Trade(token);
                //});
            }
            else
            {
                btnActivate.Content = "Start";
            }
        }
    }
}
