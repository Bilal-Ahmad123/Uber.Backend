using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Service;
public interface IDriverService
{
    public void SendCreateDriverEvent(DriverDto driver, Guid id);
}
