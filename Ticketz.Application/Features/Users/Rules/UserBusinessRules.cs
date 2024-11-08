using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Users.Constants;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Users.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserMailCannotBeDuplicatedWhenInserted(string email)
    {
        User result = await _userRepository.GetAsync(x => x.Email == email);

        if (result != null)
        {
            throw new BusinessException(UsersMessages.UserExists);
        }
    }
}
