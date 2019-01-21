using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.App.Notifications
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(string key, string message) =>
            _notifications.Add(new Notification(key, message));

        public void AddNotification(Notification notification) =>
            _notifications.Add(notification);

        public void AddNotifications(IEnumerable<Notification> notifications) =>
            _notifications.AddRange(notifications);


        public void AddNotifications(ValidationResult validationResult)
        {
            var errors = validationResult.Errors;

            if (!errors.Any()) return ;

            errors.ForEach(n => 
               AddNotification(n.ErrorCode, n.ErrorMessage)
            );
          
        }
    }

    internal static class NotificationContextExtensions
    {
        internal static void ForEach<T>(this IEnumerable<T> elements, Action<T> callbackAction)
        {
            foreach (var element in elements)
                callbackAction?.Invoke(element);
        }
    }
}
