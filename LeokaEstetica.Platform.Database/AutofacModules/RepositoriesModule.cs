﻿using Autofac;
using LeokaEstetica.Platform.Core.Attributes;
using LeokaEstetica.Platform.Database.Abstractions.Header;
using LeokaEstetica.Platform.Database.Abstractions.Landing;
using LeokaEstetica.Platform.Database.Abstractions.Moderation;
using LeokaEstetica.Platform.Database.Abstractions.Profile;
using LeokaEstetica.Platform.Database.Abstractions.Project;
using LeokaEstetica.Platform.Database.Abstractions.User;
using LeokaEstetica.Platform.Database.Abstractions.Vacancy;
using LeokaEstetica.Platform.Database.Chat;
using LeokaEstetica.Platform.Database.Repositories.Chat;
using LeokaEstetica.Platform.Database.Repositories.Header;
using LeokaEstetica.Platform.Database.Repositories.Landing;
using LeokaEstetica.Platform.Database.Repositories.Moderation.Vacancy;
using LeokaEstetica.Platform.Database.Repositories.Profile;
using LeokaEstetica.Platform.Database.Repositories.Project;
using LeokaEstetica.Platform.Database.Repositories.User;
using LeokaEstetica.Platform.Database.Repositories.Vacancy;

namespace LeokaEstetica.Platform.Database.AutofacModules;

[CommonModule]
public class RepositoriesModule : Module
{
    public static void InitModules(ContainerBuilder builder)
    {
        // Репозиторий хидера.
        builder
            .RegisterType<HeaderRepository>()
            .Named<IHeaderRepository>("HeaderRepository")
            .InstancePerLifetimeScope();
        builder
            .RegisterType<HeaderRepository>()
            .As<IHeaderRepository>()
            .InstancePerLifetimeScope();
            
        // Репозиторий лендингов.
        builder
            .RegisterType<LandingRepository>()
            .Named<ILandingRepository>("LandingRepository")
            .InstancePerLifetimeScope();
        builder
            .RegisterType<LandingRepository>()
            .As<ILandingRepository>()
            .InstancePerLifetimeScope();
            
        // Репозиторий пользователей.
        builder
            .RegisterType<UserRepository>()
            .Named<IUserRepository>("LandingRepository")
            .InstancePerLifetimeScope();
        builder
            .RegisterType<UserRepository>()
            .As<IUserRepository>()
            .InstancePerLifetimeScope();
            
        // Репозиторий профиля.
        builder
            .RegisterType<ProfileRepository>()
            .Named<IProfileRepository>("ProfileRepository")
            .InstancePerLifetimeScope();
        builder
            .RegisterType<ProfileRepository>()
            .As<IProfileRepository>()
            .InstancePerLifetimeScope();
        
        // Репозиторий проектов.
        builder
            .RegisterType<ProjectRepository>()
            .Named<IProjectRepository>("ProjectRepository")
            .InstancePerLifetimeScope();
        builder
            .RegisterType<ProjectRepository>()
            .As<IProjectRepository>()
            .InstancePerLifetimeScope();
        
        // Репозиторий вакансий.
        builder
            .RegisterType<VacancyRepository>()
            .Named<IVacancyRepository>("VacancyRepository")
            .InstancePerLifetimeScope();
        builder
            .RegisterType<VacancyRepository>()
            .As<IVacancyRepository>()
            .InstancePerLifetimeScope();
        
        // Репозиторий модерации вакансий.
        builder
            .RegisterType<VacancyModerationRepository>()
            .Named<IVacancyModerationRepository>("VacancyModerationRepository")
            .InstancePerLifetimeScope();
        builder
            .RegisterType<VacancyModerationRepository>()
            .As<IVacancyModerationRepository>()
            .InstancePerLifetimeScope();
        
        // Репозиторий чата.
        builder
            .RegisterType<ChatRepository>()
            .Named<IChatRepository>("ChatRepository")
            .InstancePerLifetimeScope();
        builder
            .RegisterType<ChatRepository>()
            .As<IChatRepository>()
            .InstancePerLifetimeScope();
    }
}