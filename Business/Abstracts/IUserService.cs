using Business.Responses.Feedbacks;
using Business.Responses.Users;
using Core.Utilities.Results;
using Core.Utilities.Security.Entities;

namespace Business.Abstracts;

public interface IUserService
{
    Task<DataResult<User>> GetByMail(string email);
    Task<IDataResult<List<GetListUserResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdUserResponse>> GetById(int id);
}
