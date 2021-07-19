using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using Xamarin.Essentials;
using JuanInventory.Views;

namespace JuanInventory
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", "")))       //one time login
            {
                MainPage = new NavigationPage(new Dashboard());
                {
                    
                };
            }
            else
            {
                MainPage = new NavigationPage(new SplashPage())
                {
                    BarBackgroundColor = Color.FromHex("#6B7A99"),
                    BarTextColor = Color.Black,

                };

            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
