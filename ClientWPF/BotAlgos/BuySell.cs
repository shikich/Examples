using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.Net.ClientWPF.ViewModels;
using Binance.Net.ClientWPF.UserControls;
using System.Threading;
using Binance.Net.ClientWPF.MessageBox;
using Binance.Net.Enums;
using Binance.Net.ClientWPF.MVVM;

namespace Binance.Net.ClientWPF.BotAlgos
{
    public class BuySell : ObservableObject
    {
        MainViewModel m = new MainViewModel();
        SymbolUserControl u = new SymbolUserControl();
        MessageBoxService mb = new MessageBoxService();

        public object o;
        public decimal botBuy;
        private BinanceSymbolViewModel selectedSymbolBot;
        public BinanceSymbolViewModel SelectedSymbolBot
        {
            get { return selectedSymbolBot; }
            set
            {
                selectedSymbolBot = value;
                RaisePropertyChangedEvent("SymbolIsSelected");
                RaisePropertyChangedEvent("SelectedSymbol");
                m.ChangeSymbol();
            }
        }

        //public decimal BotBuy
        //{
        //    get { return botBuy; }
        //    set
        //    {
        //        botBuy = value;
        //        RaisePropertyChangedEvent("SymbolIsSelected");
        //        RaisePropertyChangedEvent("SelectedSymbol");
        //        m.ChangeSymbol();
        //    }
        //}

        public decimal botBuyAmount;
        public decimal userAmount = 0.0074m;
        public decimal UserAmount
        {
            get { return userAmount; }
            set
            {
                userAmount = value;
                RaisePropertyChangedEvent("UserAmount");
            }
        }

        public async Task Trade(CancellationToken token, object o)
        {
            SymbolUserControl u = new SymbolUserControl();
            //if (u.cbBot.IsChecked == true)
            //{
            //    while (u.btnActivate.IsEnabled == true)
            //    {

                    //u.txtPriceBuy.Text = m.SelectedSymbol.Price;

                    //u.txtPriceBuy.Text = u.tbPrice.Text;//
                    u.txtAmountBuy.Text = userAmount.ToString();//

                    //m.SelectedSymbol.TradePrice = botBuy;//
                    //m.SelectedSymbol.TradeAmount = userAmount;//

                    await BuyAsync();
            //    }
            //}
            //return;
        }

        public async Task ConditionTrade()
        {
            if (botBuy + (botBuy * 0.05m) <= selectedSymbolBot.TradePrice)
            {
                await SellAsync();//
            }

            if (botBuy - (botBuy * 0.01m) > selectedSymbolBot.TradePrice)
            {
                await SellAsync();//
            }
        }

        public async Task BuyAsync()
        {
            using (var client = new BinanceClient())
            {
                SymbolUserControl u = new SymbolUserControl();
                var result = await client.Spot.Order.PlaceOrderAsync(SelectedSymbolBot.Symbol, OrderSide.Buy, OrderType.Limit, SelectedSymbolBot.TradeAmount, price: SelectedSymbolBot.TradePrice, timeInForce: TimeInForce.GoodTillCancel);
                if (result.Success)
                {
                    //
                    await ConditionTrade();

                    //MessageBoxService.ShowMessage("Order placed!", "Sucess", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
                else
                    mb.ShowMessage($"Order placing failed: {result.Error.Message}", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            await m.Buy(o);
        }

        public async Task SellAsync()
        {
            using (var client = new BinanceClient())
            {
                var result = await client.Spot.Order.PlaceOrderAsync(SelectedSymbolBot.Symbol, OrderSide.Sell, OrderType.Limit, SelectedSymbolBot.TradeAmount, price: SelectedSymbolBot.TradePrice, timeInForce: TimeInForce.GoodTillCancel);
                if (result.Success)
                {

                    //
                    //messageBoxService.ShowMessage("Order placed!", "Sucess", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
                else
                    mb.ShowMessage($"Order placing failed: {result.Error.Message}", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            //await m.Sell(o);
        }
        public async Task CancelAsync()
        {
            var order = (OrderViewModel)o;
            using (var client = new BinanceClient())
            {
                if (order != null)
                {
                    var result = await client.Spot.Order.CancelOrderAsync(SelectedSymbolBot.Symbol, order.Id);
                    if (result.Success)
                    {

                        //
                        //messageBoxService.ShowMessage("Order canceled!", "Sucess", MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    }
                    else
                        mb.ShowMessage($"Order canceling failed: {result.Error.Message}", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                else
                {
                    mb.ShowMessage($"Order canceling failed: order.ID = null", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }

            //await m.Cancel(order);
        }

        //necessary

        public async Task Update()
        {

        }
    }
}
