namespace LeokaEstetica.Platform.Database.Abstractions.Notification;

/// <summary>
/// Абстракция репозитория уведомлений.
/// </summary>
public interface INotificationsRepository
{
    /// <summary>
    /// Метод записывает уведомление о приглашении пользователя в проект.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="vacancyId">Id вакансии.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="projectName">Название проекта.</param>
    Task AddNotificationInviteProjectAsync(long projectId, long? vacancyId, long userId, string projectName);
}