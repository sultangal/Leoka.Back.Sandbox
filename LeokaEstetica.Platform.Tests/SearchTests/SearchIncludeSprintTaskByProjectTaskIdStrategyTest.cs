using LeokaEstetica.Platform.Core.Enums;
using LeokaEstetica.Platform.Services.Strategies.ProjectManagement.SprintTaskSearch;
using NUnit.Framework;

namespace LeokaEstetica.Platform.Tests.SearchTests;

/// <summary>
/// Класс тестирует поиск задач по Id задачи в рамках проекта для включения их в спринт.
/// </summary>
[TestFixture]
internal class SearchIncludeSprintTaskByProjectTaskIdStrategyTest : BaseServiceTest
{
    [Test]
    public async Task SearchIncludeSprintTaskByProjectTaskIdStrategyAsyncTest()
    {
        var result = await BaseSearchSprintTaskAlgorithm.SearchAgileObjectByObjectIdAsync(
            new SearchAgileObjectByObjectIdStrategy(ProjectManagmentRepository), 15, 274, 2,
            SearchAgileObjectTypeEnum.Task);

        Assert.IsTrue(result.Any());
    }
}