using Firebase.Database;
using Firebase.Database.Query;
using JuanInventory.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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

        public ObservableCollection<AddData> getAddData()
        {
            var AddDataData = client
                .Child("AddItems")
                .AsObservable<AddData>()
                .AsObservableCollection();
            
            return AddDataData;
        }

        public async Task AddData(string ItemName, string Category, string Date, string Notes)
        {
            AddData s = new AddData() { ItemName = ItemName, Category = Category, Date = Date, Notes = Notes };
            await client
                .Child("AddData")
                .PostAsync(s);
        }
    }
}
