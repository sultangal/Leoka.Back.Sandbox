using LeokaEstetica.Platform.Core.Enums;
using LeokaEstetica.Platform.Services.Strategies.ProjectManagement.SprintTaskSearch;
using NUnit.Framework;

namespace LeokaEstetica.Platform.Tests.SearchTests;

/// <summary>
/// Класс тестирует поиск задач по названию задачи для включения их в спринт.
/// </summary>
[TestFixture]
internal class SearchIncludeSprintTaskByTaskNameStrategyTest : BaseServiceTest
{
    [Test]
    public async Task SearchIncludeSprintTaskByTaskNameStrategyAsyncTest()
    {
        var result = await BaseSearchSprintTaskAlgorithm.SearchSearchAgileObjectByTaskNameAsync(
            new SearchAgileObjectByTaskNameStrategy(ProjectManagmentRepository), "тестовая задача", 274, 2,
            SearchAgileObjectTypeEnum.Sprint);

        Assert.IsTrue(result.Any());
    }
}