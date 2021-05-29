using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

using Firebase.Database;

namespace JuanInventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public string WebAPIkey = "AIzaSyB3yVcNZZKDuA011L-7VkmQyFxwiWf1PF4";
        public Settings()
        {
            InitializeComponent();
            GetProfileInformationandRefreshToken();
            
        }

       async private void GetProfileInformationandRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var saveFirebaseauth = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                var RefreshedContent = await authProvider.RefreshAuthAsync(saveFirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                Fullname.Text = saveFirebaseauth.User.DisplayName;
                UserEmail.Text = saveFirebaseauth.User.Email;
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "login timeout", "OK");
            }
        }


         private void LOGOUT_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}