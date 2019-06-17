using Projeto04.UWP;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(Database_uwp))]
namespace Projeto04.UWP
{
    public class Database_uwp : IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var nomeDB = "projeto04.db3";
            var caminhoDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, nomeDB);

            return new SQLiteConnection(caminhoDB);
        }
    }
}
