﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver.Application.Ride.Commands.SendContinuousTripLocation;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Driver.Infrastructure.SignalREndpoints.Driver;
public class SendContinuousRideLocationHubUpdates : Hub
{
    //public async Task SendContinuousRideLocationUpdates(Guid rideId, Guid driverId, Guid riderId, double longitude,double latitude, string vehicleType)
    //{
    //    //await sender.Send(new SendContinuousRideLocationCommand(rideId, driverId, longitude, latitude, riderId,vehicleType));
    //}
}
