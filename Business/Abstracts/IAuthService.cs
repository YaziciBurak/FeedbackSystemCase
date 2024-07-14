using Business.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    Task<IDataResult<AccessToken>> Login(UserForLoginDto user);
    Task<DataResult<AccessToken>> RegisterUser(UserForRegisterDto UserForRegisterDto);
    Task<DataResult<AccessToken>> CreateAccessToken(User user);

}
