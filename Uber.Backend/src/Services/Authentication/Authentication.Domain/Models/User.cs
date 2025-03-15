using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Models;
public class User:Entity<UserId>
{
    public string Email { get; private set; } = default!;
    public static User Create(UserId id, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        return new User
        {
            Id = id,
            Email = email
        };
    }
}
