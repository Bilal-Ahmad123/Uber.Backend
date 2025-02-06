using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Dtos;
public record DriverDto(
    string Email,
    string FirstName,
    string LastName,
    string Country,
    string ContactNumber
    );
