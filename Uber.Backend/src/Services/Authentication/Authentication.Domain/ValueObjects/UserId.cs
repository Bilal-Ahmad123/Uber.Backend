﻿using Authentication.Domain.Exceptions;

namespace Authentication.Domain.ValueObjects;
public class UserId
{
    public Guid Value { get; }
    private UserId(Guid value) => Value = value;
    public static UserId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if(value == Guid.Empty)
        {
            throw new DomainException("RiderId cannot be empty");
        }
        return new UserId(value);
    }
}
