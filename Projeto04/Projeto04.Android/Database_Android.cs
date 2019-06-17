using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Projeto04.Droid;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(Database_Android))]
namespace Projeto04.Droid
{
    class Database_Android : IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var nomeDB = "projeto04.db3";
            var caminhoDB = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), nomeDB);

            return new SQLiteConnection(caminhoDB);
        }
    }
}