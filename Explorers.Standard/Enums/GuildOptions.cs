using System;

namespace WowDotNetAPI.Enums
{
    [Flags]
    public enum GuildOptions
    {
        None = 0,
        GetMembers = 1,
        GetAchievements = 2,
        GetNews = 4,
        GetEverything = GetMembers | GetAchievements | GetNews
    }
}