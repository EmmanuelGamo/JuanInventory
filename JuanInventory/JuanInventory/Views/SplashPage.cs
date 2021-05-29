using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace JuanInventory.Views
{
    public class SplashPage : ContentPage
    {
        Image splashImage;
        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new  AbsoluteLayout();
            splashImage = new Image
            {
                Source = "Applogo.png",
                WidthRequest = 300,
                HeightRequest = 300,

            };
            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            sub.Children.Add(splashImage);
            this.BackgroundColor = Color.FromHex("#d7dee4");
            this.Content = sub;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            splashImage.Opacity = 0;
            await splashImage.FadeTo(1, 4000);
       
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}