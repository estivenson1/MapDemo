using MapDemoApp.Models;
using MapDemoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapDemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockPage : ContentPage
    {
        public StockPage()
        {
            InitializeComponent();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Stock stock = new Stock { Symbol = ctSymbol.Text };
           bool r= await  DbService.Api.InsertAsync(stock);
           await DisplayAlert("Información", r.ToString(), "Aceptar");
        }

        private async void BtnFill_Clicked(object sender, EventArgs e)
        {
            lbFill.Text = "";
          var lst= await DbService.Api.GetItemsAsync<Stock>();
            foreach (var item in lst)
            {
                lbFill.Text = lbFill.Text + $"Codigo: {item.Id} Symbol: {item.Symbol}" + Environment.NewLine;
            }
        }

        private async void BtnGetById_Clicked(object sender, EventArgs e)
        {
            lbGetById.Text = "";
            int id = Convert.ToInt32(ctId.Text);
            string symbol = ctNombre.Text;
            Expression<Func<Stock, bool>> filter =  ri => ri.Id==id && ri.Symbol == symbol;
            //var lst = await DbService.Api.QueryTable()
            var item = await DbService.Api.QueryTable<Stock>(filter).FirstAsync();
            lbGetById.Text = $"Codigo: {item.Id} Symbol: {item.Symbol}";
        }
    }
}