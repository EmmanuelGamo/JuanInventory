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
                var content = await auth.GetFreshAuthAsync();
                string gettoken = auth.FirebaseToken;
                await authProvider.UpdateProfileAsync(auth.FirebaseToken, Name.Text, "");
                if (content.User.IsEmailVerified == false)
                {

                    await authProvider.SendEmailVerificationAsync(gettoken);
                    await App.Current.MainPage.DisplayAlert("Alert", "Registration Complete! A confirmation email has been sent to your email.", "Ok");
                }
         
                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
            }

        }
    }
}