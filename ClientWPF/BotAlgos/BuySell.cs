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
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Binance.Net.Objects;
using Binance.Net.Objects.Spot;
using Binance.Net.Objects.Spot.UserStream;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Sockets;
using Binance.Net.ClientWPF.BotAlgos;

namespace Binance.Net.ClientWPF.BotAlgos
{
    public class BuySell : ObservableObject
    {
        MainViewModel m = new MainViewModel();
        SymbolUserControl u = new SymbolUserControl();
        MessageBoxService mb = new MessageBoxService();

        public object o;
        public decimal botBuy;
        public decimal botSell;


        //need user balance info
        public decimal busd;

        private BinanceSymbolViewModel selectedSymbolBot;
        public BinanceSymbolViewModel SelectedSymbolBot
        {
            get { return selectedSymbolBot; }
            set
            {
                selectedSymbolBot = value;
                botBuy = selectedSymbolBot.Price;
                mb.ShowMessage($" {botBuy}", "", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                RaisePropertyChangedEvent("SymbolIsSelected");
                RaisePropertyChangedEvent("SelectedSymbol");
                m.ChangeSymbol();
            }
        }

        public decimal botBuyAmount;
        public decimal userAmount = 0.0074m;
        public decimal UserAmount
        {
            get { return userAmount; }
            set
            {
                userAmount = 0.0074m;
                RaisePropertyChangedEvent("UserAmount");
            }
        }

        public async Task Trade(CancellationToken token, BinanceSymbolViewModel bot)
        {

            SelectedSymbolBot = bot;
            await BuyAsync();
        }

        public async Task ConditionTrade()
        {
            await Wait();
        }
        public async Task Wait()
        {
            {
                //+ we earn
                if (botBuy + (botBuy * 0.005m) <= SelectedSymbolBot.Price)
                {
                    await SellAsync();//
                }

                //- we lost

                if (botBuy - (botBuy * 0.001m) > SelectedSymbolBot.Price)
                {
                    await SellAsync();//
                }

                //cancellation realize if order inactual
                //if (botBuy)
                {

                }
            }
        }

        public async Task BuyAsync()
        {
            using (var client = new BinanceClient())
            {
                SymbolUserControl u = new SymbolUserControl();
                var result = await client.Spot.Order.PlaceOrderAsync(SelectedSymbolBot.Symbol, OrderSide.Buy, OrderType.Limit, m.UserAmount, price: SelectedSymbolBot.TradePrice, timeInForce: TimeInForce.GoodTillCancel);
                if (result.Success)
                {
                    //
                    m.ChangeSymbol();
                    await ConditionTrade();

                    //MessageBoxService.ShowMessage("Order placed!", "Sucess", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
                else
                    mb.ShowMessage($"Order placing failed: {result.Error.Message}", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            //await m.Buy(o);
        }

        public async Task SellAsync()
        {
            using (var client = new BinanceClient())
            {
                var result = await client.Spot.Order.PlaceOrderAsync(SelectedSymbolBot.Symbol, OrderSide.Sell, OrderType.Limit, m.UserAmount, price: SelectedSymbolBot.Price, timeInForce: TimeInForce.GoodTillCancel);
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
        public async Task CancelAsync(object o)
        {
            var order = (OrderViewModel)o;
            using (var client = new BinanceClient())
            {
                if (order != null)
                {
                    var result = await client.Spot.Order.CancelOrderAsync(SelectedSymbolBot.Symbol, order.Id);
                    if (result.Success)
                    {
                        m.ChangeSymbol();

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
