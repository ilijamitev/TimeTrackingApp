using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Models
{
    public class Hobby : IActivity
    {
        public int Id { get; set; }
        public static int IdGenerator { get; set; } = 0;
        public double TimeSpentOnActivity { get; set; }
        public string HobbyName { get; set; }
       
        public Hobby(string hobbyName)
        {
            Id = ++IdGenerator;
            HobbyName = hobbyName;
        }
    }
}
