using Business.Abstracts;
using Business.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public AuthManager(ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, 
        IUserService userService, IUserRepository userRepository)
    {
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _userService = userService;
        _userRepository = userRepository;
    }

    public async Task<DataResult<AccessToken>> CreateAccessToken(User user)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == user.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");
    }

    public async Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
    {
        var user = await _userService.GetByMail(userForLoginDto.Email);
        var createAccessToken = await CreateAccessToken(user.Data);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
    }

    public async Task<DataResult<AccessToken>> RegisterUser(UserForRegisterDto UserForRegisterDto)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(UserForRegisterDto.Password, out passwordHash, out passwordSalt);
        var user = new User
        {
            Email = UserForRegisterDto.Email,
            UserName = UserForRegisterDto.UserName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
        };
        await _userRepository.AddAsync(user);
        var createAccessToken = await CreateAccessToken(user);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "User registered successfully");
    }
}
