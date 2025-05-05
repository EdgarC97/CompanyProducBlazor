namespace CompanyProductBlazor.Services.Interfaces
{
    public interface INotificationService
    {
        event Action<string, string, NotificationType> OnNotification;
        void ShowNotification(string title, string message, NotificationType type);
    }

    public enum NotificationType
    {
        Success,
        Error,
        Info,
        Warning
    }
}