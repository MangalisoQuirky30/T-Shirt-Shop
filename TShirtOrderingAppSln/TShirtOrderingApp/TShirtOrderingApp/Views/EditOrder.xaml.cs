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
    public partial class EditOrder : ContentPage
    {
        public EditOrder()
        {
            InitializeComponent();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }
    }
}