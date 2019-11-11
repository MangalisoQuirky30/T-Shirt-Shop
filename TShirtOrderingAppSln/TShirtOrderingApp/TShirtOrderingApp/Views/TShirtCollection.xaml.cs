using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TShirtCollection : ContentPage
    {
        public TShirtCollection()
        {
            InitializeComponent();
        }

        public void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new new_order());
        }
    }
}