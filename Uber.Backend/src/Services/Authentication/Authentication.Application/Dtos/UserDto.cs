

namespace Authentication.Application.Dtos;
public record RiderDto
(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    string Country,
    string ContactNumber
);
