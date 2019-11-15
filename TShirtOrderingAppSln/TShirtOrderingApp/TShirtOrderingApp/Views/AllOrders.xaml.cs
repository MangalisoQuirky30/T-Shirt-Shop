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
            var allOrders = App.Database;
            TshirtOrders = await allOrders.GetTShirtOrders();
            var OrdersToPost = TshirtOrders.Select(x => new TShirtOrder() { ImgSrc = x.ImgSrc , Color = x.Color , Gender = x.Gender , Name = x.Name , ShippingAddress = x.ShippingAddress , Size = x.Size});
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(OrdersToPost);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://10.0.2.2:5000/tshirtorders", content);
            await DisplayAlert("Exception", response.ReasonPhrase , "cool");
        }
    }
}

