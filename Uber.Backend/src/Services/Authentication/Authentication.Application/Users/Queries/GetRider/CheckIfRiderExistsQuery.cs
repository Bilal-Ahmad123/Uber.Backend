using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;

namespace Authentication.Application.Users.Queries.GetUser;
public record CheckIfRiderExistsQuery(string Email):IQuery<CheckIfUserExistsResult>;
public record CheckIfUserExistsResult(bool Exists);
