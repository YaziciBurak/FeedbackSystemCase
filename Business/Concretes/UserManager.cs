using AutoMapper;
using Business.Abstracts;
using Business.Responses.Users;
using Core.Utilities.Results;
using Core.Utilities.Security.Entities;
using DataAccess.Abstracts;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserManager(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<List<GetListUserResponse>>> GetAllAsync()
    {
        List<User> users = await _userRepository.GetAllAsync();
        List<GetListUserResponse> responses = _mapper.Map<List<GetListUserResponse>>(users);
        return new SuccessDataResult<List<GetListUserResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdUserResponse>> GetById(int id)
    {
        User users = await _userRepository.GetAsync(x => x.Id == id);
        GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(users);
        return new SuccessDataResult<GetByIdUserResponse>(response);
    }

    public async Task<DataResult<User>> GetByMail(string email)
    {
        return new SuccessDataResult<User>(await _userRepository.GetAsync(x => x.Email == email));
    }
}
