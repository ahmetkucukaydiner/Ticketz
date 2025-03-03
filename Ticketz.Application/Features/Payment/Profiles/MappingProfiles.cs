using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Payment.Commands;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Payment.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreatePaymentCommand, Domain.Entities.Payment>().ReverseMap();
            CreateMap<Domain.Entities.Payment, CreatedPaymentResponse>().ReverseMap();
        }
    }
}
