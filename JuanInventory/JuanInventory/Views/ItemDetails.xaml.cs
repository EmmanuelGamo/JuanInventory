using JuanInventory.Model;
using JuanInventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JuanInventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetails : ContentPage
    {
        DBFirebase services;
        public ItemDetails(AddData addData)
        {
            InitializeComponent();
            BindingContext = addData;
            services = new DBFirebase();
        }

        public async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            await services.UpdateData(ItemName.Text, Date.Text, Category.Text, Notes.Text);
            await Navigation.PushModalAsync(new NavigationPage(new Dashboard()));
        }

        public async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            await services.DeleteData(ItemName.Text, Date.Text, Category.Text, Notes.Text);
            await Navigation.PushModalAsync(new NavigationPage(new Dashboard()));
        }

        
    }
}