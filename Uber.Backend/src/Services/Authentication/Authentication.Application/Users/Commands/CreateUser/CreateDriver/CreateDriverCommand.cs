using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Users.Commands.CreateUser.CreateDriver;
public  record CreateDriverCommand(RiderDto Driver):ICommand<CreateDriverResult>;
public record CreateDriverResult(Guid Id);
