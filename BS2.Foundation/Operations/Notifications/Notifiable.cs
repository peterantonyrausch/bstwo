using System.Collections.Generic;
using BS2.Foundation.Validations;

namespace BS2.Foundation.Operations.Notifications
{
    public abstract class Notifiable
    {
        public NotificationCollection Notifications { get; }
        public bool HasErrors => Notifications.Errors.Count > 0;
        public bool HasWarnings => Notifications.Warnings.Count > 0;
        public bool HasInformations => Notifications.Informations.Count > 0;

        protected Notifiable()
        {
            Notifications = new NotificationCollection();
        }

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }

        public void AddError(string key, string message)
        {
            Notifications.Add(Notification.Error(key, message));
        }

        public void AddError(string message)
        {
            Notifications.Add(Notification.Error(message));
        }

        public void AddWarning(string message)
        {
            Notifications.Add(Notification.Warning(message));
        }

        public void AddWarning(string key, string message)
        {
            Notifications.Add(Notification.Warning(key, message));
        }

        public void AddInformation(string message)
        {
            Notifications.Add(Notification.Information(message));
        }

        public void AddInformation(string key, string message)
        {
            Notifications.Add(Notification.Information(key, message));
        }

        public void AddValidations(List<ValidationResult> validationErrors)
        {
            foreach (var validationError in validationErrors)
            {
                foreach (var validationErrorMemberName in validationError.MemberNames)
                {
                    AddError(validationErrorMemberName, validationError.ErrorMessage);
                }
            }
        }

        public void AddValidation(ValidationResult validationError)
        {
            foreach (var validationErrorMemberName in validationError.MemberNames)
            {
                AddError(validationErrorMemberName, validationError.ErrorMessage);
            }
        }
    }
}