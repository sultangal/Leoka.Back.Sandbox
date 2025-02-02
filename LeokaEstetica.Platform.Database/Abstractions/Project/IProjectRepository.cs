using LeokaEstetica.Platform.Models.Dto.Input.Project;
using LeokaEstetica.Platform.Models.Dto.Output.Project;
using LeokaEstetica.Platform.Models.Dto.Output.Vacancy;
using LeokaEstetica.Platform.Models.Entities.Configs;
using LeokaEstetica.Platform.Models.Entities.Project;
using LeokaEstetica.Platform.Models.Entities.ProjectTeam;

namespace LeokaEstetica.Platform.Database.Abstractions.Project;

/// <summary>
/// Абстракция репозитория пользователя.
/// </summary>
public interface IProjectRepository
{
    /// <summary>
    /// Метод фильтрует проекты в зависимости от фильтров.
    /// </summary>
    /// <param name="filters">Фильтры.</param>
    /// <returns>Список проектов после фильтрации.</returns>
    Task<IEnumerable<CatalogProjectOutput>> FilterProjectsAsync(FilterProjectInput filters);
    
    /// <summary>
    /// Метод создает новый проект пользователя.
    /// </summary>
    /// <param name="createProjectInput">Входная модель.</param>
    /// <returns>Данные нового проекта.</returns>
    Task<UserProjectEntity> CreateProjectAsync(CreateProjectInput createProjectInput);

    /// <summary>
    /// Метод получает названия полей для таблицы проектов пользователя.
    /// Все названия столбцов этой таблицы одинаковые у всех пользователей.
    /// </summary>
    /// <returns>Список названий полей таблицы.</returns>
    Task<IEnumerable<ProjectColumnNameEntity>> UserProjectsColumnsNamesAsync();

    /// <summary>
    /// Метод проверяет, создан ли уже такой заказ под текущим пользователем с таким названием.
    /// </summary>
    /// <param name="projectName">Название проекта.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Создал либо нет.</returns>
    Task<bool> CheckCreatedProjectByProjectNameAsync(string projectName, long userId);

    /// <summary>
    /// Метод получает список проектов пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="isCreateVacancy">Признак создания вакансии.</param>
    /// <returns>Список проектов.</returns>
    Task<UserProjectResultOutput> UserProjectsAsync(long userId, bool isCreateVacancy);

    /// <summary>
    /// TODO: Подумать, давать ли всем пользователям возможность просматривать каталог проектов или только тем, у кого есть подписка.
    /// Метод получает список проектов для каталога.
    /// </summary>
    /// <returns>Список проектов.</returns>
    Task<IEnumerable<CatalogProjectOutput>> CatalogProjectsAsync();

    /// <summary>
    /// Метод обновляет проект пользователя.
    /// </summary>
    /// <param name="updateProjectInput">Входная модель.</param>
    /// <returns>Данные нового проекта.</returns>
    Task<UpdateProjectOutput> UpdateProjectAsync(UpdateProjectInput updateProjectInput);

    /// <summary>
    /// Метод получает проект для изменения или просмотра.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Данные проекта.</returns>
    Task<(UserProjectEntity UserProject, ProjectStageEntity ProjectStage)> GetProjectAsync(long projectId);

    /// <summary>
    /// Метод получает стадии проекта для выбора.
    /// </summary>
    /// <returns>Стадии проекта.</returns>
    Task<IEnumerable<ProjectStageEntity>> ProjectStagesAsync();

    /// <summary>
    /// Метод получает список вакансий проекта. Список вакансий, которые принадлежат владельцу проекта.
    /// </summary>
    /// <param name="projectId">Id проекта, вакансии которого нужно получить.</param>
    /// <returns>Список вакансий.</returns>
    Task<IEnumerable<ProjectVacancyOutput>> ProjectVacanciesAsync(long projectId);

    /// <summary>
    /// Метод прикрепляет вакансию к проекту.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="vacancyId">Id вакансии.</param>
    /// <returns>Флаг успеха.</returns>
    Task<bool> AttachProjectVacancyAsync(long projectId, long vacancyId);

    /// <summary>
    /// Метод получает список вакансий проекта, которые можно прикрепить к проекту.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="isInviteProject">Признак приглашения в проект.</param>
    /// <returns>Список вакансий проекта.</returns>
    Task<IEnumerable<ProjectVacancyEntity>> ProjectVacanciesAvailableAttachAsync(long projectId, long userId,
        bool isInviteProject);

    /// <summary>
    /// Метод записывает отклик на проект.
    /// Отклик может быть с указанием вакансии, на которую идет отклик (если указана VacancyId).
    /// Отклик может быть без указаниея вакансии, на которую идет отклик (если не указана VacancyId).
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="vacancyId">Id вакансии.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Выходная модель с записанным откликом.</returns>
    Task<ProjectResponseEntity> WriteProjectResponseAsync(long projectId, long? vacancyId, long userId);

    /// <summary>
    /// Метод находит Id владельца проекта.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Id владельца проекта.</returns>
    Task<long> GetProjectOwnerIdAsync(long projectId);

    /// <summary>
    /// Метод получает данные команды проекта.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Данные команды проекта.</returns>
    Task<ProjectTeamEntity> GetProjectTeamAsync(long projectId);

    /// <summary>
    /// Метод получает список участников команды проекта по Id команды.
    /// </summary>
    /// <param name="teamId">Id проекта.</param>
    /// <returns>Список участников команды проекта.</returns>
    Task<List<ProjectTeamMemberEntity>> GetProjectTeamMembersAsync(long teamId);

    /// <summary>
    /// Метод получает названия полей для таблицы команды проекта пользователя.
    /// </summary>
    /// <returns>Список названий полей таблицы.</returns>
    Task<IEnumerable<ProjectTeamColumnNameEntity>> ProjectTeamColumnsNamesAsync();

    /// <summary>
    /// Метод добавляет пользователя в команду проекта.
    /// </summary>
    /// <param name="userId">Id пользователя, который будет добавлен в команду проекта.</param>
    /// <param name="vacancyId">Id вакансии.</param>
    /// <param name="teamId">Id команды проекта.</param>
    /// <param name="role">Роль пользователя в проекте..</param>
    /// <returns>Данные добавленного пользователя.</returns>
    Task<ProjectTeamMemberEntity> AddProjectTeamMemberAsync(long userId, long? vacancyId, long teamId, string? role);

    /// <summary>
    /// Метод находит Id команды проекта.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Id команды.</returns>
    Task<long> GetProjectTeamIdAsync(long projectId);

    /// <summary>
    /// Метод получает список проектов для дальнейшей фильтрации.
    /// </summary>
    /// <returns>Список проектов без выгрузки в память, так как этот список будем еще фильтровать.</returns>
    Task<List<CatalogProjectOutput>> GetFiltersProjectsAsync();

    /// <summary>
    /// Метод проверяет владельца проекта.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Признак является ли пользователь владельцем проекта.</returns>
    Task<bool> CheckProjectOwnerAsync(long projectId, long userId);

    /// <summary>
    /// Метод удаляет вакансию проекта.
    /// </summary>
    /// <param name="vacancyId">Id вакансии.</param>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Признак удаления вакансии проекта.</returns>
    Task<bool> DeleteProjectVacancyByIdAsync(long vacancyId, long projectId);

    /// <summary>
    // TODO: Если при удалении проекта надо будет также чистить сообщения нейросети, то надо доработать будет метод.
    /// Метод удаляет вакансии проекта.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Признак результата удаления, список вакансий, которые отвязаны от проекта, название проекта.</returns>
    Task<(bool Success, List<string> RemovedVacancies, string ProjectName)> RemoveProjectAsync(long projectId,
        long userId);

    /// <summary>
    /// Метод получает название проекта по его Id.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Название проекта.</returns>
    Task<string> GetProjectNameByProjectIdAsync(long projectId);

    /// <summary>
    /// Метод првоеряет, находится ли проект на модерации.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Признак модерации.</returns>
    Task<bool> CheckProjectModerationAsync(long projectId);
    
    /// <summary>
    /// Метод првоеряет, находится ли проект в архиве.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Признак нахождения в архиве.</returns>
    Task<bool> CheckProjectArchivedAsync(long projectId);
    
    /// <summary>
    /// Метод получает список вакансий доступных к отклику.
    /// Для владельца проекта будет возвращаться пустой список.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Список вакансий доступных к отклику.</returns>
    Task<IEnumerable<ProjectVacancyEntity>> GetAvailableResponseProjectVacanciesAsync(long userId, long projectId);

    /// <summary>
    /// Метод получает название вакансии проекта по ее Id.
    /// </summary>
    /// <param name="vacancyId">Id вакансии.</param>
    /// <returns>Название вакансии.</returns>
    Task<string> GetProjectVacancyNameByIdAsync(long vacancyId);
    
    /// <summary>
    /// Метод находит почту владельца проекта по Id проекта.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Почта владельца проекта.</returns>
    Task<string> GetProjectOwnerEmailByProjectIdAsync(long projectId);

    /// <summary>
    /// Метод проверяет добавляли ли уже пользоваетля в команду проекта.
    /// Если да, то не даем добавить повторно, чтобы не было дублей.
    /// </summary>
    /// <param name="teamId">Id команды проекта.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Признак проверки.</returns>
    Task<bool> CheckProjectTeamMemberAsync(long teamId, long userId);

    /// <summary>
    /// Метод получает список проектов пользователя из архива.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список архивированных проектов.</returns>
    Task<IEnumerable<ArchivedProjectEntity>> GetUserProjectsArchiveAsync(long userId);

    /// <summary>
    /// Метод получает Id проекта по Id вакансии, которая принадлежит этому проекту.
    /// </summary>
    /// <param name="vacancyId">Id вакансии.</param>
    /// <returns>Id проекта.</returns>
    Task<long> GetProjectIdByVacancyIdAsync(long vacancyId);
    
    /// <summary>
    /// Метод получает название проекта по его Id.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Название проекта.</returns>
    Task<string> GetProjectNameByIdAsync(long projectId);

    /// <summary>
    /// Метод удаляет участника проекта из команды.
    /// </summary>
    /// <param name="userId">Id пользователя</param>
    /// <param name="projectTeamId">Id команды проекта.</param>
    Task DeleteProjectTeamMemberAsync(long userId, long projectTeamId);

    /// <summary>
    /// Метод покидания команды проекта.
    /// </summary>
    /// <param name="userId">Id пользователя</param>
    /// <param name="projectTeamId">Id команды проекта.</param>
    Task LeaveProjectTeamAsync(long userId, long projectTeamId);
    
    /// <summary>
    /// Метод проверяет, есть ли пользователь в команде проекта.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Признак проверки.</returns>
    Task<bool> CheckExistsProjectTeamMemberAsync(long projectId, long userId);

    /// <summary>
    /// Метод добавляет проект в архив.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="userId">Id пользователя.</param>
    Task AddProjectArchiveAsync(long projectId, long userId);

    /// <summary>
    /// Метод проверяет, находится ли такой проект в архиве.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Признак проверки.</returns>
    Task<bool> CheckProjectArchiveAsync(long projectId);

    /// <summary>
    /// Метод удаляет из архива проект.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="userId">Id пользователя.</param>
    Task<bool> DeleteProjectArchiveAsync(long projectId, long userId);

    /// <summary>
    /// Метод получает кол-во проектов пользователя в каталоге.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Кол-во проектов в каталоге.</returns>
    Task<long> GetUserProjectsCatalogCountAsync(long userId);
    
    /// <summary>
    /// Метод получает Id команды проекта по Id проекта.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <returns>Id команды.</returns>
    Task<long> GetProjectTeamIdByProjectIdAsync(long projectId);

    /// <summary>
    /// Метод получает список Id пользователей, которые находся в команде проекта.
    /// </summary>
    /// <param name="teamId">Id команды.</param>
    /// <returns>Список Id пользователей.</returns>
    Task<IEnumerable<long>> GetProjectTeamMemberIdsAsync(long teamId);

    /// <summary>
    /// Метод записывает название проекта в управлении проектами.
    /// </summary>
    /// <param name="projectId">Id проекта.</param>
    /// <param name="projectManagementName">Название проекта в управлении проектами.</param>
    Task SetProjectManagementNameAsync(long projectId, string projectManagementName);
    
    /// <summary>
    /// Метод назначает участнику команды проекта роль.
    /// <param name="userId">Id пользователя.</param>
    /// <param name="role">Роль.</param>
    /// <param name="teamId">Id команды проекта.</param>
    /// </summary>
    Task SetProjectTeamMemberRoleAsync(long userId, string? role, long teamId);
    
    /// <summary>
    /// Метод исключает пользователя из команды проекта.
    /// <param name="userId">Id пользователя.</param>
    /// <param name="teamId">Id команды проекта.</param>
    /// </summary>
    Task RemoveUserProjectTeamAsync(long userId, long teamId);

	/// <summary>
	/// Метод обновляет видимость проекта
	/// </summary>
	/// <param name="projectId">Id проекта.</param>
	/// <param name="isPublic">Видимость проекта.</param>
	/// <returns>Возращает признак видимости проекта.</returns>
	Task<UpdateProjectOutput> UpdateVisibleProjectAsync(long projectId, bool isPublic);
}