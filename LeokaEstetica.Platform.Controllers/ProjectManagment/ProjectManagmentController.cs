﻿using AutoMapper;
using LeokaEstetica.Platform.Base;
using LeokaEstetica.Platform.Base.Filters;
using LeokaEstetica.Platform.Models.Dto.Output.Project;
using LeokaEstetica.Platform.Models.Dto.Output.ProjectManagment;
using LeokaEstetica.Platform.Services.Abstractions.Project;
using LeokaEstetica.Platform.Services.Abstractions.ProjectManagment;
using Microsoft.AspNetCore.Mvc;

namespace LeokaEstetica.Platform.Controllers.ProjectManagment;

/// <summary>
/// Контроллер управления проектами.
/// </summary>
[ApiController]
[Route("project-managment")]
[AuthFilter]
public class ProjectManagmentController : BaseController
{
   private readonly IProjectService _projectService;
   private readonly IProjectManagmentService _projectManagmentService;
   private readonly IMapper _mapper;

   /// <summary>
   /// Конструктор.
   /// </summary>
   /// <param name="projectService">Сервис проектов пользователей.</param>
   /// <param name="projectManagmentService">Сервис управления проектами.</param>
   /// <param name="mapper">Маппер.</param>
   public ProjectManagmentController(IProjectService projectService,
      IProjectManagmentService projectManagmentService,
      IMapper mapper)
   {
      _projectService = projectService;
      _projectManagmentService = projectManagmentService;
      _mapper = mapper;
   }

   /// <summary>
   /// TODO: Подумать, стоит ли выводить в рабочее пространство архивные проекты и те, что находятся на модерации.
   /// Метод получает список проектов пользователя.
   /// </summary>
   /// <returns>Список проектов пользователя.</returns>
   [HttpGet]
   [Route("user-projects")]
   [ProducesResponseType(200, Type = typeof(UserProjectResultOutput))]
   [ProducesResponseType(400)]
   [ProducesResponseType(403)]
   [ProducesResponseType(500)]
   [ProducesResponseType(404)]
   public async Task<UserProjectResultOutput> UserProjectsAsync()
   {
      var result = await _projectService.UserProjectsAsync(GetUserName(), false);

      return result;
   }

   /// <summary>
   /// Метод получает список стратегий представления рабочего пространства.
   /// </summary>
   /// <returns>Список стратегий.</returns>
   [HttpGet]
   [Route("view-strategies")]
   [ProducesResponseType(200, Type = typeof(IEnumerable<ViewStrategyOutput>))]
   [ProducesResponseType(400)]
   [ProducesResponseType(403)]
   [ProducesResponseType(500)]
   [ProducesResponseType(404)]
   public async Task<IEnumerable<ViewStrategyOutput>> GetViewStrategiesAsync()
   {
      var items = await _projectManagmentService.GetViewStrategiesAsync();
      var result = _mapper.Map<IEnumerable<ViewStrategyOutput>>(items);

      return result;
   }
}