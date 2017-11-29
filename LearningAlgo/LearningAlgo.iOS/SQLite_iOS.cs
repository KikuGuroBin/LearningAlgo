using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using LearningAlgo.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))] 
namespace LearningAlgo.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); 
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, "LearningAlgoSQLite.db3");     
            return new SQLiteConnection(new SQLitePlatformIOS(), path);
        }
    }
}