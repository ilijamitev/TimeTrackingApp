using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Services
{
    public interface IStatsMenu
    {
        void ReadingStats(User user);
        void ExercisingStats(User user);
        void WorkingStats(User user);
        void HobbiesStats(User user);
        void GlobalStats(User user);
    }
}
