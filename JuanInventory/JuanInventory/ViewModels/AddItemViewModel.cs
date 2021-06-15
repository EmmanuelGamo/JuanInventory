using JuanInventory.Model;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Firebase.Database;
using System.Threading.Tasks;
using JuanInventory.Services;

namespace JuanInventory.ViewModels
{
    public class AddItemViewModel : BaseViewModel 
    {
        public string ItemName { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        public string Notes { get; set; }

        private DBFirebase services;

        public Command AddItemCommand { get; }

        private ObservableCollection<AddData> _AddDatas = new ObservableCollection<AddData>();
        public ObservableCollection<AddData> AddDatas
        {
            get { return _AddDatas; }
            set 
            {
                _AddDatas = value;
                OnPropertyChanged();
            }
        }
        public AddItemViewModel()
        {
            services = new DBFirebase();
            AddDatas = services.getAddData();

            AddItemCommand = new Command(async () => await addDataAsync(ItemName, Category, Date, Notes));
        }

        public async Task addDataAsync(string ItemName, string Category, string Date, string Notes)
        {
            
            await services.AddData(ItemName, Category, Date, Notes);
        }
    }

    
}
