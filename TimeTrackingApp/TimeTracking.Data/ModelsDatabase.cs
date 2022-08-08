using Newtonsoft.Json;
using TimeTracking.Models;

namespace TimeTracking.Data
{
    [Serializable]
    public class ModelsDatabase
    {
        public static List<User> UsersList { get; set; } = new List<User>();

    }
    public class DatabaseService
    {
        private static string _userDatabaseDir = @"../../../../userDatabaseDir/";
        private static string _userDatabase = $@"{_userDatabaseDir}/userDatabase.txt";
        public DatabaseService()
        {
            if (!Directory.Exists(_userDatabaseDir))
            {
                Directory.CreateDirectory(_userDatabaseDir);
            }
        }

        public void SaveToDatabase()
        {
            File.WriteAllText(_userDatabase, "");
            string userSerialized = JsonConvert.SerializeObject(ModelsDatabase.UsersList);
            File.WriteAllText(_userDatabase, userSerialized);
        }

        public void GetFromDatabase()
        {
            if (File.Exists(_userDatabase))
            {
                using StreamReader sr = new(_userDatabase);
                string userSerialized = sr.ReadToEnd();
                ModelsDatabase.UsersList = JsonConvert.DeserializeObject<List<User>>(userSerialized);
            }
        }
    }
}
