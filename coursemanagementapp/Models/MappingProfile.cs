using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using coursemanagementapp.Data;

namespace coursemanagementapp.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<KursKayit, KursKayitViewModel>();
    }
}
