using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Services.Interfaces
{
    public interface IMenus
    {
        void StartApp();
        void StartMenu();
        void LoginMenu();
        void RegisterMenu();
        void UserMenu(User user);
        void ExitApp();
    }
}
