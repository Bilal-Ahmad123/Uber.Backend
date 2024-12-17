using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Backend.Redis.Configuration;
public class CacheConfigurationSection
{
    public const string SectionName = "ConnectionStrings:RedisCacheConnection";
    public RedisConnection? RedisConnection { get; init; }

}
