using System.Text.Json.Serialization;

namespace TimeTracking.Models
{
    public class User
    { 
       // [JsonIgnore]
        public int Id { get; set; }
        public static int IdGenerator { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public List<Reading> ReadingList { get; set; } = new List<Reading>();
        public List<Exercising> ExercisingList { get; set; } = new List<Exercising>();
        public List<Working> WorkingList { get; set; } = new List<Working>();
        public List<Hobby> HobbysList { get; set; } = new List<Hobby>();


        public User(string firstName, string lastName, int age, string username, string password)
        {
            Id = ++IdGenerator;
            IsActive = true;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Username = username;
            Password = password;
        }

    }
}
