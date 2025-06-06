﻿using CompanyProductBlazor.Services.Interfaces;

namespace CompanyProductBlazor.Services
{
    public enum NotificationType
    {
        Success,
        Error,
        Warning,
        Info
    }

    public class NotificationService : INotificationService
    {
        public event Action<string, string, NotificationType> OnNotification;

        public void ShowNotification(string title, string message, NotificationType type)
        {
            OnNotification?.Invoke(title, message, type);
        }
    }
}