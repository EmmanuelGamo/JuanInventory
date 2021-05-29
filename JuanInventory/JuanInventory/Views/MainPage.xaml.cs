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

namespace JuanInventory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyB3yVcNZZKDuA011L-7VkmQyFxwiWf1PF4";
        
        public MainPage()
        {
           
            InitializeComponent();
            
        }
       
        async private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.SignUp());
        }

        async private void LoginButton_Clicked(object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email.Text, Password.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontent);
                await Navigation.PushAsync(new Views.Dashboard());
               
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid user email or password", "OK");
            }
        }

        async private void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ForgotPassword());
        }
    }
}
