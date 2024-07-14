using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class FeedbackBusinessRules: BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public FeedbackBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CheckIfUserIdExists(int userId)
    {
        var userExists = await _userRepository.GetAsync(x => x.Id == userId);
        if (userExists == null) throw new Exception(FeedbackMessages.UserIdNotExist);
    }
}
