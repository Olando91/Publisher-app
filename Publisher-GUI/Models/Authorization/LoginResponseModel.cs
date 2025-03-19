namespace Publisher_GUI.Models.Authorization;

public class LoginResponseModel
{
    public string Token { get; set; }
    public long TokenExpired { get; set; }

    public LoginResponseModel()
    {        
    }

    public LoginResponseModel(string token, long tokenExpired)
    {
        Token = token;
        TokenExpired = tokenExpired;
    }
}
