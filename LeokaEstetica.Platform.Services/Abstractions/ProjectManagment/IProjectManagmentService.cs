﻿using LeokaEstetica.Platform.Models.Entities.ProjectManagment;

namespace LeokaEstetica.Platform.Services.Abstractions.ProjectManagment;

/// <summary>
/// Абстракция сервиса управления проектами.
/// </summary>
public interface IProjectManagmentService
{
    /// <summary>
    /// Метод получает список стратегий представления рабочего пространства.
    /// </summary>
    /// <returns>Список стратегий.</returns>
    Task<IEnumerable<ViewStrategyEntity>> GetViewStrategiesAsync();
}