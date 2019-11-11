using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShirtShopLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrder : ContentPage
    {
        public NewOrder()
        {
            InitializeComponent();
        }

        private async void PlaceOrderBtn_Clicked(object sender, EventArgs e)
        {

            TShirtOrder order = new TShirtOrder
            {
                Name = custName.Text.ToUpper(),
                Gender = custGender.Text.ToUpper(),
                Color = tShirtColor.Text.ToUpper(),
                Size = tShirtSize.Text.ToUpper(),
                ShippingAddress = custShippingAddress.Text.ToUpper()
            };

            if (tShirtColor.Text.ToLower() == "red")
            {
                order.ImgSrc = "red.jpg";
            }

            if (tShirtColor.Text.ToLower() == "green")
            {
                order.ImgSrc = "green.jpg";
            }

            if (tShirtColor.Text.ToLower() == "black")
            {
                order.ImgSrc = "black.jpg";
            }

            if (tShirtColor.Text.ToLower() == "orange")
            {
                order.ImgSrc = "orange.jpg";
            }

            if (tShirtColor.Text.ToLower() == "white")
            {
                order.ImgSrc = "white.jpg";
            }



            var orders = App.Database;
            await orders.InsertTShirtOrder(order);

            custName.Text = "";
            custGender.Text = "";
            tShirtColor.Text = "";
            custShippingAddress.Text = "";
            tShirtSize.Text = "";

            //await Navigation.PushAsync(new NewOrder());

        }
    }
}