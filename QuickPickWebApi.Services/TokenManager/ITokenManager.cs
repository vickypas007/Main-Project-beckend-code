using QuickPickWebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickPickWebApi.Services.TokenManager
{
    public interface ITokenManager
    {
        string GenerateToken(Login login);
        // bool IsTokenExpiring(double tokenExpiringDateTimeTicks);
        string RefreshToken(string token);
        // Task BlackListToken(string token);
    }
}
