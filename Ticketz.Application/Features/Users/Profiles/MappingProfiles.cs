using AutoMapper;
using Core.Application.Responses;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Users.Commands.Create;
using Ticketz.Application.Features.Users.Commands.Delete;
using Ticketz.Application.Features.Users.Commands.Update;
using Ticketz.Application.Features.Users.Queries.GetById;
using Ticketz.Application.Features.Users.Queries.GetList;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserResponse>().ReverseMap();

        CreateMap<User, DeleteUserCommand>().ReverseMap();
        CreateMap<User, DeletedUserResponse>().ReverseMap();

        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UpdatedUserResponse>().ReverseMap();

        CreateMap<User, GetByIdUserQuery>().ReverseMap();
        CreateMap<User, GetByIdUserResponse>().ReverseMap();

        CreateMap<Paginate<User>, GetListResponse<GetListUserListItemDto>>().ReverseMap();
    }
}
