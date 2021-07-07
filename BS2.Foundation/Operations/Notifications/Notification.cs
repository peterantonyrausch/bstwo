namespace BS2.Foundation.Operations.Notifications
{
    public class Notification
    {
        public string Key { get; set; }

        public string Message { get; set; }

        public NotificationType Type { get; }

        private Notification(NotificationType type, string key, string message)
        {
            Type = type;
            Key = key;
            Message = message;
        }

        private Notification(NotificationType type, string message)
            : this(type, string.Empty, message)
        {
        }

        public static Notification Information(string key, string message)
        {
            return new Notification(NotificationType.Information, key, message);
        }

        public static Notification Information(string message)
        {
            return new Notification(NotificationType.Information, message);
        }

        public static Notification Warning(string key, string message)
        {
            return new Notification(NotificationType.Warning, key, message);
        }

        public static Notification Warning(string message)
        {
            return new Notification(NotificationType.Warning, message);
        }

        public static Notification Error(string key, string message)
        {
            return new Notification(NotificationType.Error, key, message);
        }

        public static Notification Error(string message)
        {
            return new Notification(NotificationType.Error, message);
        }
    }
}