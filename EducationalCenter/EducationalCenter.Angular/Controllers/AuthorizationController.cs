using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Configuration;
using EducationalCenter.Common.Dtos.Api.Responses;
using EducationalCenter.Common.Dtos.User;
using EducationalCenter.Common.Enums;
using EducationalCenter.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalCenter.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IOptions<SecurityOptions> _securityOptions;
        private readonly IJwtHandlerService _jwtHandlerService;
        private readonly ILoggerService _loggerService;

        public AuthorizationController(UserManager<ApplicationUser> userManager, IMapper mapper, IOptions<SecurityOptions> securityOptions, IJwtHandlerService jwtHandlerService,
            ILoggerService loggerService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _securityOptions = securityOptions;
            _jwtHandlerService = jwtHandlerService;
            _loggerService = loggerService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserRegistrationDto userForRegistration)
        {
            _loggerService.GenerateRequestLog(userForRegistration, LogType.RegistrationRequest);

            if (userForRegistration == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _mapper.Map<ApplicationUser>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto {IsSuccessfulRegistration = false, Errors = errors });
            }

            await AddUserToRole(userForRegistration.EMail, user);

            var response = new RegistrationResponseDto { IsSuccessfulRegistration = true };

            _loggerService.GenerateResponseLog(userForRegistration, response, LogType.RegistrationRequest);

            return Ok(response);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            _loggerService.GenerateRequestLog(userForAuthentication, LogType.AuthorizationRequest);

            var user = await _userManager.FindByNameAsync(userForAuthentication.EMail);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            {
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            }

            var signingCredentials = _jwtHandlerService.GetSigningCredentials();
            var claims = await _jwtHandlerService.GetClaims(user);
            var tokenOptions = _jwtHandlerService.GenerateTokenOptions(signingCredentials, claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            var response = new AuthResponseDto { IsAuthSuccessful = true, Token = token };

            _loggerService.GenerateResponseLog(userForAuthentication, response, LogType.AuthorizationRequest);

            return Ok(response);
        }

        private async Task AddUserToRole(string email, ApplicationUser user)
        {
            if (email == _securityOptions.Value.AdminUserEmail)
            {
                await _userManager.AddToRoleAsync(user, "admin");
            }
            else if (email == _securityOptions.Value.ManagerUserEmail)
            {
                await _userManager.AddToRoleAsync(user, "manager");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "student");
            }
        }
    }
}
