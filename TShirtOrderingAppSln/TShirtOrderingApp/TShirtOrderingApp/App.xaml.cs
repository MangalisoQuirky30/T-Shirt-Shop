using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TShirtOrderingApp.Services;
using TShirtOrderingApp.Views;
using TShirtShopLibrary;
using System.IO;

namespace TShirtOrderingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        //    DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
            
        }




        private static TShirtOrders database;

        public static TShirtOrders Database
        {
            get
            {
                if (database == null)
                {
                    database = new TShirtOrders(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "newtshirtorders.db3"));
                }
                return database;
            }
        }




        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
