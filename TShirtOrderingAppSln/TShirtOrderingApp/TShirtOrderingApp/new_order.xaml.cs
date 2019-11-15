using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShirtOrderingApp.Views;
using TShirtShopLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtOrderingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class new_order : ContentPage
    {
        public new_order()
        {
            InitializeComponent();
        }

        private async void PlaceOrderBtn_Clicked(object sender, EventArgs e)
        {

            TShirtOrder order = new TShirtOrder
            {
                Name = NcustName.Text.ToUpper(),
                Gender = NcustGender.Text.ToUpper(),
                Color = NtShirtColor.Text.ToUpper(),
                Size = NtShirtSize.Text.ToUpper(),
                ShippingAddress = NcustShippingAddress.Text.ToUpper(),
                Status = false ,
            };

            if (NtShirtColor.Text.ToLower() == "red")
            {
                order.ImgSrc = "red.jpg";
            }
            if (NtShirtColor.Text.ToLower() == "black")
            {
                order.ImgSrc = "black.jpg";
            }

            if (NtShirtColor.Text.ToLower() == "green")
            {
                order.ImgSrc = "green.jpg";
            }

            if (NtShirtColor.Text.ToLower() == "white")
            {
                order.ImgSrc = "white.jpg";
            } else
            {
                order.ImgSrc = "black.jpg";
            }

            var orders = App.Database;
            await orders.InsertTShirtOrder(order);

            NcustName.Text = "";
            NcustGender.Text = "";
            NtShirtColor.Text = "";
            NcustShippingAddress.Text = "";
            NtShirtSize.Text = "";

            await Navigation.PushAsync(new AllOrders());

        }
    }
}