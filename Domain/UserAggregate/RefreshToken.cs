﻿namespace Domain.UserAggregate;

public class RefreshToken
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Token { get; set; }

    public virtual User User { get; set; }
}
