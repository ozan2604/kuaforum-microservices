using Application.Features.Commands.AppUserCommands.LoginUser;
using Application.Features.Commands.AppUserCommands.RefreshTokenLogin;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediatr;
        private readonly IPublishEndpoint _publishEndpoint;
        public AuthController(IMediator mediatr, IPublishEndpoint publishEndpoint)
        {
            _mediatr = mediatr;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediatr.Send(loginUserCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromQuery] RefreshTokenLoginCommandRequest request)
        {
            RefreshTokenLoginCommandResponse response = await _mediatr.Send(request);
            return Ok(response);
        }
        
    }
}
