namespace LeokaEstetica.Platform.Notifications.Abstractions;

/// <summary>
/// Абстракция сервиса уведомлений проектов.
/// </summary>
public interface IProjectNotificationsService
{
    /// <summary>
    /// Метод отправляет уведомление об успешном создании проекта пользователя.
    /// </summary>
    /// <param name="title">Заголовок уведомления.</param>
    /// <param name="notifyText">Текст уведомления.</param>
    /// <param name="notificationLevel">Уровень уведомления.</param>
    /// <param name="userCode">Код пользователя.</param>
    Task SendNotificationSuccessCreatedUserProjectAsync(string title, string notifyText, string notificationLevel);
    
    /// <summary>
    /// Метод отправляет уведомление об ошибке при создании проекта пользователя.
    /// </summary>
    /// <param name="title">Заголовок уведомления.</param>
    /// <param name="notifyText">Текст уведомления.</param>
    /// <param name="notificationLevel">Уровень уведомления.</param>
    /// <param name="userCode">Код пользователя.</param>
    Task SendNotificationErrorCreatedUserProjectAsync(string title, string notifyText, string notificationLevel);
    
    /// <summary>
    /// Метод отправляет уведомление о дубликате проекта пользователя.
    /// </summary>
    /// <param name="title">Заголовок уведомления.</param>
    /// <param name="notifyText">Текст уведомления.</param>
    /// <param name="notificationLevel">Уровень уведомления.</param>
    /// <param name="userCode">Код пользователя.</param>
    Task SendNotificationWarningDublicateUserProjectAsync(string title, string notifyText, string notificationLevel);
    
    /// <summary>
    /// Метод отправляет уведомление об успехе при изменении проекта пользователя.
    /// </summary>
    /// <param name="title">Заголовок уведомления.</param>
    /// <param name="notifyText">Текст уведомления.</param>
    /// <param name="notificationLevel">Уровень уведомления.</param>
    /// <param name="userCode">Код пользователя.</param>
    Task SendNotificationSuccessUpdatedUserProjectAsync(string title, string notifyText, string notificationLevel);
    
    /// <summary>
    /// Метод отправляет уведомление об ошибке при изменении проекта пользователя.
    /// </summary>
    /// <param name="title">Заголовок уведомления.</param>
    /// <param name="notifyText">Текст уведомления.</param>
    /// <param name="notificationLevel">Уровень уведомления.</param>
    /// <param name="userCode">Код пользователя.</param>
    Task SendNotificationErrorUpdatedUserProjectAsync(string title, string notifyText, string notificationLevel);
    
    /// <summary>
    /// Метод отправляет уведомление об успешной привязке вакансии к проекту.
    /// </summary>
    /// <param name="title">Заголовок уведомления.</param>
    /// <param name="notifyText">Текст уведомления.</param>
    /// <param name="notificationLevel">Уровень уведомления.</param>
    /// <param name="userCode">Код пользователя.</param>
    Task SendNotificationSuccessAttachProjectVacancyAsync(string title, string notifyText, string notificationLevel);
    
    /// <summary>
    /// Метод отправляет уведомление об дубликате при привязке вакансии к проекту.
    /// </summary>
    /// <param name="title">Заголовок уведомления.</param>
    /// <param name="notifyText">Текст уведомления.</param>
    /// <param name="notificationLevel">Уровень уведомления.</param>
    /// <param name="userCode">Код пользователя.</param>
    Task SendNotificationErrorDublicateAttachProjectVacancyAsync(string title, string notifyText, string notificationLevel);
}