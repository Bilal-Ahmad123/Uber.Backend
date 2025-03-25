using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Common;
using Grpc.Core;
using Redis.Application.Repositories;
using Redis.Domain.Models;

namespace Redis.Infrastructure.Services
{
    public class MyRedisService : RedisService.RedisServiceBase
    {
        private readonly IRedisRepository _redisRepository;
        public MyRedisService(IRedisRepository redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public override Task<NearbyDriversResponse> GetNearbyDrivers(NearbyDriversRequest request, ServerCallContext context)
        {
            var message = _redisRepository.GetNearbyDrivers(new BuildingBlocks.Events.UpdateUserLocation(new Guid(request.UserId),request.Latitude,request.Longitude));
            var nearbyDrivers = Helper.Deserializer<NearbyDriverModel>(message);
            var response = new NearbyDriversResponse();
            response.DriverIds.AddRange(nearbyDrivers.Drivers.Select(d => d.ToString()));
            return Task.FromResult(response);
        }
    }
}
