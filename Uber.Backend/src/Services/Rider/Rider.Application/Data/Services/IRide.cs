﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Rider.Domain.Models;

namespace Rider.Application.Data.Services;
public interface IRide
{
    Task RequestRide(RequestRideEvent requestRide);
}
