using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Services.Interfaces
{
    public interface IRegisterService
    {
        User CreateNewUser();
        string GetName(string firstOrLast);
        int GetAge();
        string GetUsername();
        string GetPassword();
    }
}
