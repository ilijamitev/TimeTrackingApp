using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Services.Interfaces
{
    public interface IUserMenuService
    {
        void TrackActivity(User user);
        void UserStatistics(User user);
        void AccountManagment(User user);
    }
}
