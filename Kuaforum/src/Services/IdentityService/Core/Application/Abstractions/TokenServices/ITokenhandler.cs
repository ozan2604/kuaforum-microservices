using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.TokenServices
{
    public interface ITokenhandler
    {
      Token CreateAccessToken(int second, AppUser appUser);   
      string CreateRefreshToken();
    }
}
