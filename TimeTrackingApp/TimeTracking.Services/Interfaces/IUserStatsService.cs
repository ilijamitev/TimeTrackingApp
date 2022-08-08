using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Services
{
    public interface IUserStatsService
    {
        double GetTotalTime<T>(List<T> activities) where T : IActivity;
        double GetAverageTime<T>(List<T> activities) where T : IActivity;
        int GetNumberOfPages(List<Reading> readingList);
        string GetFavouriteBookGenre(List<Reading> readings);
        string GetFavouriteExercisingType(List<Exercising> exerciseList);
        string GetHomeVsOfficeWorking(List<Working> workingList);
        void ShowHobbies(List<Hobby> hobbiesList);
        string GetTotalTimeOfAllActivities(User user);
        string GetFavouriteActivity(User user);
        string GetMostRepeatedActivity(User user);
        string GetActivityWithGreatestTime(User user);
    }
}
