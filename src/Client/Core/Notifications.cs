namespace GakuGym.Client;

enum NotificationType
{
    Info,
    Error
}

internal record Notification
(
    string           message,
    NotificationType type,
    DateTimeOffset   created
);

internal static class Notifications
{
    private static List<Notification> notifications = new List<Notification>();

    public static IEnumerable<Notification> All => notifications;

    public static event Action? OnNotificationsChange;

    public static void Close(Notification notification)
    {
        notifications.Remove(notification);
    }

    public static void Push(NotificationType type, string message)
    {
        notifications.Add(new(message, type, DateTimeOffset.UtcNow));

        OnNotificationsChange?.Invoke();
    }

    public static void PushFeedback(string message) => Push(NotificationType.Info, message);
    public static void PushError(string message) => Push(NotificationType.Error, message);
}

