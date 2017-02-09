using System;
using WowDotNetAPI.Enums;

namespace WowDotNetAPI.Extensions
{
    internal static class EnumExtensions
    {
        internal static string GetHost(this Region source)
        {
            switch (source)
            {
                case Region.Eu:
                    return "https://eu.api.battle.net";
                case Region.Kr:
                    return "https://kr.api.battle.net";
                case Region.Tw:
                    return "https://tw.api.battle.net";
                case Region.Cn:
                    return "https://www.battlenet.com.cn";
                case Region.Us:
                    return "https://us.api.battle.net/";
                case Region.Sea:
                    return "https://sea.api.battle.net/";
                default:
                    throw new ArgumentException($"{source} does not have host", nameof(source));
            }
        }
    }
}
