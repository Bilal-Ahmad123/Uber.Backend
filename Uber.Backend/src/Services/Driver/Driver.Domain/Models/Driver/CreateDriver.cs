using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.Domain.Models.Driver;
public record CreateDriver(Guid DriverId, string FirstName, string LastName, string Country, string ContactNo);
