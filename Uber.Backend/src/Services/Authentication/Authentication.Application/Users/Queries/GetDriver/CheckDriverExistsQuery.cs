using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;

namespace Authentication.Application.Users.Queries.GetDriver;
public record CheckDriverExistsQuery(string Email):IQuery<CheckDriverExistsResult>;

public record CheckDriverExistsResult(Guid DriverId);

