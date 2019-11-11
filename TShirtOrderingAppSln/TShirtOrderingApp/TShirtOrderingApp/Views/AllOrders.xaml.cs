using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private void itemListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}
 