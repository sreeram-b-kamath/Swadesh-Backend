using System;

namespace Shared;


public class JwtTokenDto
{
    public UserData User { get; set; }
    public Tokens Tokens { get; set; }
}
public class UserData
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool InitialLogin { get; set; }
}
public class Tokens
{
    public TokenData Access { get; set; }
    public TokenData Refresh { get; set; }
}

public class TokenData
{
    public string Token { get; set; }
    public DateTime? Expires { get; set; }
}