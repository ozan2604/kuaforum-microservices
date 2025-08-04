using Application.Abstractions.Servcies;
using Application.Dtos.UserDtos;
using Application.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AppUserCommands.CreateUser
{
    public class CreateUserCommandHandler :  IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
       readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            //CreateUserCommandRequest -> CreateUserDto automapper kullanmak bir kereye mahsus kullanmak maliyetlidir

            CreateUserResponseDto response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password
            });

            return new()
            {
                Succeeded = response.Succeeded,
                Message = response.Message
            }; 

        }
    }
   
}
