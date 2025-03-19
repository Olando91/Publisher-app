using Publisher_GUI.Data.Repositories;
using Publisher_GUI.Models.Authorization;

namespace Data.Services.Authentication;

public class AuthorizationService
{
    private readonly AuthorizationRepository _authRepo;

    public AuthorizationService(AuthorizationRepository authRepo)
    {
        _authRepo = authRepo;
    }

    public async Task<LoginResponseModel> HandleLogin(LoginModel loginModel)
    {
        try
        {
            var res = await _authRepo.CheckCredentials(loginModel);

            return res;
        }
        catch (Exception e)
        {
            throw e;
        }
    } 
}
