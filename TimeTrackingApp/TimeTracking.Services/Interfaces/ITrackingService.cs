using TimeTracking.Models;

namespace TimeTracking.Services.Interfaces
{
    public interface ITrackingService
    {
        double TrackTime();
        void TrackReading(User user);
        int GetBookPages();
        BookGenre GetBookGenre();
        void TrackExercising(User user);
        void TrackWorking(User user);
        void TrackOtherHobby(User user);

    }
}
