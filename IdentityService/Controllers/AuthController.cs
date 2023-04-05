using IdentityService.UseCases.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    #region Fields

    private readonly ISender _sender;

    #endregion

    #region Constructors and Destructors

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    #endregion

    #region Public Methods

    [HttpGet(Name = "Test")]
    public string Test()
    {
        return "Deneme";
    }

    [HttpPost(Name = "Register")]
    public async Task<IActionResult> Register(RegisterCommand request) 
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }

    #endregion
}