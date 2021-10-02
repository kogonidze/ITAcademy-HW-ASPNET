using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Configuration;
using EducationalCenter.Common.Dtos.Api.Responses;
using EducationalCenter.Common.Dtos.User;
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

        public AuthorizationController(UserManager<ApplicationUser> userManager, IMapper mapper, IOptions<SecurityOptions> securityOptions, IJwtHandlerService jwtHandlerService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _securityOptions = securityOptions;
            _jwtHandlerService = jwtHandlerService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserRegistrationDto userForRegistration)
        {
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
            
            return Ok(new RegistrationResponseDto { IsSuccessfulRegistration = true });
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.EMail);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            {
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            }

            var signingCredentials = _jwtHandlerService.GetSigningCredentials();
            var claims = _jwtHandlerService.GetClaims(user);
            var tokenOptions = _jwtHandlerService.GenerateTokenOptions(signingCredentials, claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
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
