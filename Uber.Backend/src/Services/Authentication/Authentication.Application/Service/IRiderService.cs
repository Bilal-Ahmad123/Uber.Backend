using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Service;
public interface IRiderService
{
    public void SendCreateRiderEvent(RiderDto rider, Guid id);
}
