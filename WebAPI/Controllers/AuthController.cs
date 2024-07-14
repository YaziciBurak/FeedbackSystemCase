using Business.Abstracts;
using Business.Dtos;
using Core.Utilities.Security.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
        var result = await _authService.Login(userForLoginDto);
        return HandleDataResult(result);
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
    {
        var result = await _authService.RegisterUser(userForRegisterDto);
        return HandleDataResult(result);
    }
}
