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

namespace Binance.Net.ClientWPF.BotAlgos
{
    public class BuySell
    {
        //MainViewModel m = new MainViewModel();
        //MessageBoxService mb = new MessageBoxService();
        //SymbolUserControl u = new SymbolUserControl();

        //public object o;
        //public decimal botBuy;
        ////public decimal BotBuy
        ////{
        ////    get { return Convert.ToDecimal(u.txtPriceBuy.Text); }
        ////    set
        ////    {
        ////        botBuy = value;
        ////    }
        ////}
        //public decimal botBuyAmount;
        //public decimal userAmount = 0.0074m;

        //public async Task Trade(CancellationToken token)
        //{
        //    SymbolUserControl u = new SymbolUserControl();
        //    //if (u.cbBot.IsChecked == true)
        //    //{
        //    //    while (u.btnActivate.IsEnabled == true)
        //    //    {

        //            //u.txtPriceBuy.Text = "pega";

        //            ////u.txtPriceBuy.Text = m.SelectedSymbol.Price.ToString();//
        //            //u.txtAmountBuy.Text = userAmount.ToString();//

        //            //m.SelectedSymbol.TradePrice = botBuy;//
        //            //m.SelectedSymbol.TradeAmount = userAmount;//

        //            await BuyAsync();
        //    //    }
        //    //}
        //    //return;
        //}

        //public async Task ConditionTrade()
        //{
        //    if (botBuy + (botBuy * 0.05m) <= m.SelectedSymbol.TradePrice)
        //    {
        //        await SellAsync();//
        //    }

        //    if (botBuy - (botBuy * 0.01m) > m.SelectedSymbol.TradePrice)
        //    {
        //        await SellAsync();//
        //    }
        //}

        //public async Task BuyAsync()
        //{
        //    //using (var client = new BinanceClient())
        //    //{
        //    //    SymbolUserControl u = new SymbolUserControl();
        //    //    var result = await client.Spot.Order.PlaceOrderAsync(m.SelectedSymbol.Symbol, OrderSide.Buy, OrderType.Limit, Convert.ToDecimal(u.txtAmountBuy.Text), price: Convert.ToDecimal(u.txtPriceBuy.Text), timeInForce: TimeInForce.GoodTillCancel);
        //    //    if (result.Success)
        //    //    {
        //    //        //
        //    //        await ConditionTrade();

        //    //        //MessageBoxService.ShowMessage("Order placed!", "Sucess", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        //    //    }
        //    //    else
        //    //        mb.ShowMessage($"Order placing failed: {result.Error.Message}", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        //    //}

        //    //await m.Buy(o);          
        //}

        //public async Task SellAsync()
        //{
        //    //using (var client = new BinanceClient())
        //    //{
        //    //    var result = await client.Spot.Order.PlaceOrderAsync(m.SelectedSymbol.Symbol, OrderSide.Sell, OrderType.Limit, m.SelectedSymbol.TradeAmount, price: m.SelectedSymbol.TradePrice, timeInForce: TimeInForce.GoodTillCancel);
        //    //    if (result.Success)
        //    //    {

        //    //        //
        //    //        //messageBoxService.ShowMessage("Order placed!", "Sucess", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        //    //    }
        //    //    else
        //    //        mb.ShowMessage($"Order placing failed: {result.Error.Message}", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        //    //}

        //    //await m.Sell(o);
        //}
        //public async Task CancelAsync()
        //{
        //    //var order = (OrderViewModel)o;
        //    //using (var client = new BinanceClient())
        //    //{
        //    //    if (order != null)
        //    //    {
        //    //        var result = await client.Spot.Order.CancelOrderAsync(m.SelectedSymbol.Symbol, order.Id);
        //    //        if (result.Success)
        //    //        {

        //    //            //
        //    //            //messageBoxService.ShowMessage("Order canceled!", "Sucess", MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        //    //        }
        //    //        else
        //    //            mb.ShowMessage($"Order canceling failed: {result.Error.Message}", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        //    //    }
        //    //    else
        //    //    {
        //    //        mb.ShowMessage($"Order canceling failed: order.ID = null", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        //    //    }
        //    //}
        //    //await m.Cancel(order);
        //}

        ////necessary

        //public async Task Update()
        //{

        //}
    }
}
