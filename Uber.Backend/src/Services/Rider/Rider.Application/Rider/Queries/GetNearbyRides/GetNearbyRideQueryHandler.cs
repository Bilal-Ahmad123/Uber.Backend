﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Rider.Application.Services;

namespace Rider.Application.Rider.Queries.GetNearbyRides;
public class GetNearbyRideQueryHandler(IRedisProtoClientService redisProtoClientService,IVehicleProtoClientService vehicleProtoClientService) : IQueryHandler<GetNearbyRideQuery, GetNearbyRideQueryResult>
{
    public  Task<GetNearbyRideQueryResult> Handle(GetNearbyRideQuery request, CancellationToken cancellationToken)
    {
       var drivers =  redisProtoClientService.GetNearbyDrivers(new BuildingBlocks.Events.UpdateUserLocation(request.RiderId,request.Latitude,request.Longitude));
       var vehicles = vehicleProtoClientService.NearbyVehicleDetails(drivers.DriverIds,drivers.DriversWithTimeAway);
       return Task.FromResult(new GetNearbyRideQueryResult(vehicles));
    }
}
