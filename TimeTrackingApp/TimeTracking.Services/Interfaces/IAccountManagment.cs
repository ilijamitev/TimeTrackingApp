using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Services
{
    public interface IAccountManagment
    {
        void ChangePassword(User user);
        void ChangeFirstName(User user);
        void ChangeLastName(User user);
        void DeactivateAccount(User user);

    }
}
