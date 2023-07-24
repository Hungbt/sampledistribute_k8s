using auth.Models;
using core.Models;
using core.Settings.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security;

namespace auth.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private readonly IAzureActiveDirectoryConfiguration _azureAADConfiguration;
        public AccountController(IAzureActiveDirectoryConfiguration azureAADConfiguration)
        {
            _azureAADConfiguration = azureAADConfiguration;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            IPublicClientApplication app = PublicClientApplicationBuilder.Create(_azureAADConfiguration.ClientId)
                                                .WithAuthority(_azureAADConfiguration.Authority)
                                                .Build();

            var accounts = await app.GetAccountsAsync();

            AuthenticationResult result = null;
            var tokenScopes = new[] { $"{_azureAADConfiguration.Scopes}" };

            if (accounts.Any())
                result = await app.AcquireTokenSilent(tokenScopes, accounts.FirstOrDefault()).ExecuteAsync();
            else
            {
                try
                {
                    var securePassword = ToSecureString(model.Password);
                    result = await app.AcquireTokenByUsernamePassword(tokenScopes, model.Email, securePassword)
                                      .ExecuteAsync();
                }
                catch (MsalException exc) when (exc.ErrorCode == "unknown_user_type" || exc.ErrorCode == "invalid_grant")
                {
                    return StatusCode(400, new ApiResponseModel("Invalid email or password"));
                }
                catch (MsalException exc)
                {
                    return StatusCode(500, new ApiResponseModel(exc.Message));
                }
                catch (Exception exc)
                {
                    return StatusCode(500, new ApiResponseModel(exc.Message));
                }
            }
            return Ok(new ApiResponseModel<ResponseLoginModel>()
            {
                Data = new ResponseLoginModel
                {
                    AccessToken = result.AccessToken,
                    IdToken = result.IdToken,
                }
            });
        }
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<object> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        private SecureString ToSecureString(string source)
        {
            var securePassword = new SecureString();
            foreach (var c in source)
                securePassword.AppendChar(c);
            return securePassword;
        }
    }
}
