using LeokaEstetica.Platform.Core.Constants;
using LeokaEstetica.Platform.Redis.Abstractions;
using LeokaEstetica.Platform.Redis.Extensions;
using LeokaEstetica.Platform.Redis.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace LeokaEstetica.Platform.Redis.Services;

/// <summary>
/// Класс реализует методы сервиса работы с кэшем Redis.
/// </summary>
public sealed class RedisService : IRedisService
{
    private readonly IDistributedCache _redis;

    public RedisService(IDistributedCache redis)
    {
        _redis = redis;
    }

    /// <summary>
    /// Метод сохраняет ConnectionId подключения SignalR в кэш.
    /// </summary>
    /// <param name="connectionId">Id подключения, который создает SignalR.</param>
    /// <param name="userCode">Код пользователя.</param>
    // public async Task SaveConnectionIdCacheAsync(string connectionId, string userCode)
    // {
    //     // Записываем ConnectionId в кэш редиса.
    //     await _redis.SetStringAsync(userCode,
    //         ProtoBufExtensions.Serialize(connectionId),
    //         new DistributedCacheEntryOptions
    //         {
    //             AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(12)
    //         });
    // }

    /// <summary>
    /// Метод получает ConnectionId подключения для SignalR.
    /// </summary>
    /// <param name="key">Ключ поиска.</param>
    /// <returns>ConnectionId.</returns>
    // public async Task<string> GetConnectionIdCacheAsync(string key)
    // {
    //     var result = await _redis.GetStringAsync(key);
    //
    //     return result;
    // }

    /// <summary>
    /// Метод сохраняет в кэш меню профиля пользователя.
    /// </summary>
    /// <param name="profileMenuRedis">Класс для кэша.</param>
    public async Task SaveProfileMenuCacheAsync(ProfileMenuRedis profileMenuRedis)
    {
        await _redis.SetStringAsync(GlobalConfigKeysCache.PROFILE_MENU_KEY,
            ProtoBufExtensions.Serialize(profileMenuRedis),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(12)
            });
    }

    /// <summary>
    /// Метод получает из кэша меню профиля пользователя.
    /// </summary>param>
    public async Task<ProfileMenuRedis> GetProfileMenuCacheAsync()
    {
        var items = await _redis.GetStringAsync(GlobalConfigKeysCache.PROFILE_MENU_KEY);

        if (string.IsNullOrEmpty(items))
        {
            return new ProfileMenuRedis();
        }
        
        var result = ProtoBufExtensions.Deserialize<ProfileMenuRedis>(items);

        return result;
    }
}