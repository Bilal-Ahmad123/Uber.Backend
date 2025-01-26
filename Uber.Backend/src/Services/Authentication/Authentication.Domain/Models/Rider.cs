

namespace Authentication.Domain.Models
{
    public class Rider:Entity<UserId>
    {
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string ContactNumber { get; private set; } = default!;
        public string Country { get; private set; } = default!;
        public static Rider Create(string firstName, string lastName, string email, string contactNo, string country)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
            ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
            ArgumentException.ThrowIfNullOrWhiteSpace(email);
            ArgumentException.ThrowIfNullOrWhiteSpace(contactNo);
            ArgumentException.ThrowIfNullOrWhiteSpace(country);

            return new Rider
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                ContactNumber = contactNo,
                Country = country
            };
        }
    }

}
