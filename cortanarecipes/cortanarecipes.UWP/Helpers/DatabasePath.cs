using cortanarecipes.Helpers;
using cortanarecipes.UWP.Helpers;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace cortanarecipes.UWP.Helpers
{
    public class DatabasePath : IDBPath
    {
        public DatabasePath()
        {
        }

        public string GetDbPath()
        {
            return Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "EFCore.db");
        }
    }
}
