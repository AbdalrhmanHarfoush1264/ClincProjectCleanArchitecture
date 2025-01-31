﻿using ClincProject.Core.Features.AppointmentStatuses.Queries.Responses;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.AppointmentStatusMapping
{
    public partial class AppointmentStatusProfile
    {
        public void GetAppointmentStatusListMapping()
        {
            CreateMap<AppointmentStatus, GetAppointmentStatusListResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AppointmentStatusId));
        }
    }
}
