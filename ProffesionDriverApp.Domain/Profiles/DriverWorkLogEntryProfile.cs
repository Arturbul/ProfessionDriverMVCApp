﻿using AutoMapper;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace Domain.Profiles
{
    public class DriverWorkLogEntryProfile : Profile
    {
        public DriverWorkLogEntryProfile()
        {
            CreateMap<DriverWorkLogEntry, DriverWorkLogEntryViewModel>()
                .ForMember(dest => dest.Driver, opt => opt.MapFrom(src => src.Driver));

            CreateMap<DriverWorkLogEntryViewModel, DriverWorkLogEntry>()
                .ForMember(dest => dest.Driver, opt => opt.MapFrom(src => src.Driver));
        }
    }
}
