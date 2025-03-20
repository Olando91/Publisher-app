namespace Publisher_GUI.Models.Authorization;

public class LoginResponseModel
{
    public string Token { get; set; }
    public long TokenExpired { get; set; }
    public string RefreshToken { get; set; }

    public LoginResponseModel()
    {        
    }

    public LoginResponseModel(string token, long tokenExpired, string refreshToken)
    {
        Token = token;
        TokenExpired = tokenExpired;
        RefreshToken = refreshToken;
    }
}
