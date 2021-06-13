using System;
using Xamarin.Forms;
using Firebase.Auth;
using Xamarin.Forms.Xaml;

namespace JuanInventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage

    {
        public string WebAPIkey = "AIzaSyB3yVcNZZKDuA011L-7VkmQyFxwiWf1PF4";
   
        public SignUp()
        {
            {
                InitializeComponent();
            
          
            }

        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email.Text, Password.Text, Name.Text);
                string gettoken = auth.FirebaseToken;
                await authProvider.UpdateProfileAsync(auth.FirebaseToken, Name.Text, "");
                await App.Current.MainPage.DisplayAlert("Alert","Registration Complete!","Ok");
                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
            }

        }
    }
}