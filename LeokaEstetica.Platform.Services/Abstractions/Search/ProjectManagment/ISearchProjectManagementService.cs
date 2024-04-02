using LeokaEstetica.Platform.Core.Enums;
using LeokaEstetica.Platform.Models.Dto.Output.Search.ProjectManagement;

namespace LeokaEstetica.Platform.Services.Abstractions.Search.ProjectManagment;

/// <summary>
/// Абстракция сервиса поиска в модуле управления проектами.
/// </summary>
public interface ISearchProjectManagementService
{
    /// <summary>
    /// Метод поиска задач.
    /// Поиск происходит по атрибутам, которые передали.
    /// </summary>
    /// <param name="searchText">Поисковый текст.</param>
    /// <param name="projectIds">Список Id проектов, по которым будет поиск.</param>
    /// <param name="isById">Признак поиска по Id задачи.</param>
    /// <param name="isByName">Признак поиска по названию задачи.</param>
    /// <param name="isByDescription">Признак поиска по описанию задачи.</param>
    /// <returns>Список найденных задач.</returns>
    Task<IEnumerable<SearchTaskOutput>> SearchTaskAsync(string searchText, IEnumerable<long> projectIds, bool isById,
        bool isByName, bool isByDescription);

    /// <summary>
    /// Метод ищет задачи, истории, эпики, ошибки по разным критериям.
    /// </summary>
    /// <param name="searchText">Поисковый текст./</param>
    /// <param name="isSearchByProjectTaskId">Признак поиска по Id задачи в рамках проекта.</param>
    /// <param name="isSearchByTaskName">Признак поиска по названию задачи.</param>
    /// <param name="isSearchByTaskDescription">Признак поиска по совпадению в описании.</param>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="account">Аккаунт.</param>
    /// <param name="searchAgileObjectType">Тип поиска Agile-объекта.</param>
    /// <returns>Найденные задачи, истории, эпики, ошибки.</returns>
    Task<IEnumerable<SearchTaskOutput>> SearchAgileObjectAsync(string searchText, bool isSearchByProjectTaskId,
        bool isSearchByTaskName, bool isSearchByTaskDescription, long projectId, string account,
        SearchAgileObjectTypeEnum searchAgileObjectType);
}