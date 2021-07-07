using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS2.Foundation.Operations.Notifications
{
    public class NotificationCollection : List<Notification>
    {
        public NotificationCollection Errors =>
            new NotificationCollection(AsReadOnly().Where(n => n.Type == NotificationType.Error));

        public NotificationCollection Warnings =>
            new NotificationCollection(AsReadOnly().Where(n => n.Type == NotificationType.Warning));

        public NotificationCollection Informations =>
            new NotificationCollection(AsReadOnly().Where(n => n.Type == NotificationType.Information));

        public NotificationCollection()
        {
        }

        public NotificationCollection(IEnumerable<Notification> collection) : base(collection)
        {
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var notification in AsReadOnly())
            {
                builder.AppendLine(notification.Message);
            }

            return builder.ToString();
        }
    }
}