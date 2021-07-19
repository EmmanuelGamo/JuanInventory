using Firebase.Auth;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Xamarin.Essentials;
using JuanInventory.ViewModels;
using JuanInventory.Model;

namespace JuanInventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScreen : ContentPage
    {
        public string WebAPIkey = "AIzaSyB3yVcNZZKDuA011L-7VkmQyFxwiWf1PF4";
        
        public MainScreen()
        {
            InitializeComponent();
            BindingContext = new AddItemViewModel();
            GetProfileInformationAndRefreshToken();
        }

        async private void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var savefirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken",""));
                var RefreshedContent = await authProvider.RefreshAuthAsync(savefirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                        
            }
           catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Login Timeout", "OK");
            }
                
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
   
        private void ImageButton_Clicked(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new AddItem());
        }

        public async void ListView_ItemTapped(object sender, ItemTappedEventArgs args)
        {
            var addData = args.Item as AddData;
            if (addData == null) return;

            await Navigation.PushModalAsync(new ItemDetails(addData));
            lstAddDatas.SelectedItem = null;
        }
    }
}