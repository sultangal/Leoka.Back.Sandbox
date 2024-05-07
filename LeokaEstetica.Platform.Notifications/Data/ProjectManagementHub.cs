using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;

[assembly: InternalsVisibleTo("LeokaEstetica.Platform.ProjectManagement")]

namespace LeokaEstetica.Platform.Notifications.Data;

/// <summary>
/// Класс хаба модуля УП (управление проектами).
/// </summary>
internal sealed class ProjectManagementHub : Hub
{
}