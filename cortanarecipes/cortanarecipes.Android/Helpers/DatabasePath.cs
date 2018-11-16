using cortanarecipes.Droid.Helpers;
using cortanarecipes.Helpers;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace cortanarecipes.Droid.Helpers
{
    public class DatabasePath : IDBPath
    {

        public DatabasePath()
        {
        }

        public string GetDbPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "EFCoreDB.db");
        }
    }
}