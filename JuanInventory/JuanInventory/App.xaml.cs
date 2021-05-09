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
namespace JuanInventory
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseToken", "")))       //one time login
            {
                MainPage = new NavigationPage(new Views.MainScreen());
                {
                    
                };
            }
            else
            {
                MainPage = new NavigationPage(new MainPage())
                {
                   

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
