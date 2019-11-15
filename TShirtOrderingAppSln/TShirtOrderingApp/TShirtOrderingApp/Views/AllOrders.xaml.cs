using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TShirtShopLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllOrders : ContentPage
    {
        public IList<TShirtOrder> TshirtOrders { get; set; }
        private string myOrder { get; set; }

        public AllOrders()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
           

            var orders = App.Database;

            TshirtOrders = await orders.GetTShirtOrders();

            BindingContext = this;
        }

        public async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new new_order());
        }


        private async void itemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var orders = (sender as Xamarin.Forms.ListView);
            var ordersX = orders.SelectedItem;
           
            var eachOrder = (ordersX as TShirtShopLibrary.TShirtOrder);

            var x = eachOrder.Name;

            
            TshirtOrders.Add(new TShirtOrder()
            {
                Name = eachOrder.Name,
                Color = eachOrder.Color,
                ShippingAddress = eachOrder.ShippingAddress,
                Gender = eachOrder.Gender,
                Size = eachOrder.Size,
            });

            BindingContext = this;

            await Navigation.PushAsync(new EditOrder());

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var info = App.Database;
            
            HttpClient client = new HttpClient();

            var torder = new TShirtOrder()
            {
                Name = "Mangaliso",
                ShippingAddress = "wynberg",
            };

            var json = JsonConvert.SerializeObject(torder);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

          

            try
            {
                var response = await client.PostAsync("https://10.0.2.2:5001/tshirtorders", content);
                await DisplayAlert("Exception", response.ReasonPhrase , "Ok");
            }
            catch(Exception ex)
            {

                await DisplayAlert("Exception", ex.Message, "Ok");
            }
        }
    }
}
