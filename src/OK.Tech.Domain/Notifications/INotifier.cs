using System.Collections.Generic;

namespace OK.Tech.Domain.Notifications
{
    public interface INotifier
    {
        bool HasNotifications();

        IList<Notification> GetNotifications();

        void Handle(Notification notification);
    }
}