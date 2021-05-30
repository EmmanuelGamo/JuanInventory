using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuanInventory.Droid.Helpers
{
    public static class AppDataHelper
    {
        public static FirebaseDatabase GetDatabase()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseDatabase database;

            if(app == null)
            {
                var option = new Firebase.FirebaseOptions.Builder()
                    .SetApplicationId("juaninventory-1cfae")
                    .SetApiKey("AIzaSyBGr7ppPxG6lZK4Ch3lzYj6ULMba0bzps8")
                    .SetDatabaseUrl("https://juaninventory-1cfae-default-rtdb.asia-southeast1.firebasedatabase.app")
                    .SetStorageBucket("juaninventory-1cfae.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, option);
                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }
            return database;
        }   
    }
}