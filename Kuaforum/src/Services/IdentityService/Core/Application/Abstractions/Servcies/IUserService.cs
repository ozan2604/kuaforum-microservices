using Application.Dtos.UserDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Servcies
{
    public interface IUserService
    {
        Task<CreateUserResponseDto> CreateAsync(CreateUserDto createUserRequestDto);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime AccessTokenDate, int addOnAccessTokenDate);
    }
}
