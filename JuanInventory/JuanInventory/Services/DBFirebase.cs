using Firebase.Database;
using Firebase.Database.Query;
using JuanInventory.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Linq;

namespace JuanInventory.Services
{
    public class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase()
        {
            var auth = "iBAatd8YRluv1P3MRtPrgRzDvyZijqwsVmT7kuRF";
            client = new FirebaseClient(
            "https://juaninventory-1cfae-default-rtdb.asia-southeast1.firebasedatabase.app/",

            new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(auth)
            });
        }

        internal Task UpdateData(object text1, object text2, object text3)
        {
            throw new System.NotImplementedException();
        }

        public ObservableCollection<AddData> getAddData()
        {
            var AddDataData = client
                .Child("Items")
                .AsObservable<AddData>()
                .AsObservableCollection();
            
            return AddDataData;
        }

        public async Task AddData(string ItemName, string Category, string Date, string Notes)
        {
            AddData s = new AddData() { ItemName = ItemName, Category = Category, Date = Date, Notes = Notes };
            await client
                .Child("Items")
                .PostAsync(s);
            await App.Current.MainPage.DisplayAlert("Alert", ItemName + " has been added to your Items.", "OK");
        
        }
        
        public async Task UpdateData(string ItemName, string Category, string Date, string Notes)
        {
            var toUpdateData = (await client
                .Child("Items")
                .OnceAsync<AddData>()).FirstOrDefault
                (a => a.Object.ItemName == ItemName);

            AddData s = new AddData() { ItemName = ItemName, Category = Category, Date = Date, Notes = Notes };
            await client
                .Child("Items")
                .Child(toUpdateData.Key)
                .PutAsync(s);
        }

        public async Task DeleteData(string ItemName, string Category, string Date, string Notes)
        {
            var toDeleteData = (await client
                .Child("Items")
                .OnceAsync<AddData>()).FirstOrDefault
                (a => a.Object.ItemName == ItemName && a.Object.Category == Category);
            await client.Child("Items").Child(toDeleteData.Key).DeleteAsync();
        }

    }
}
