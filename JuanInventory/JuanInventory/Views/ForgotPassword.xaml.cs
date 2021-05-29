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
using Firebase.Database.Query;


namespace JuanInventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ContentPage
    {
        public string WebAPIkey = "AIzaSyB3yVcNZZKDuA011L-7VkmQyFxwiWf1PF4";
        
        public ForgotPassword()
        {
            InitializeComponent();
        }
   
        public async void Send_Clicked(object sender, EventArgs e)

        {

            var authReset = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {

                
                    var email = UserEmail.Text;

                    var auth = authReset.SendPasswordResetEmailAsync(UserEmail.Text);
                    await App.Current.MainPage.DisplayAlert("Alert", "Email Sent", "OK");
                    await Navigation.PushAsync(new MainPage());


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid email or password", "OK");
            }
        }

       
    }
}