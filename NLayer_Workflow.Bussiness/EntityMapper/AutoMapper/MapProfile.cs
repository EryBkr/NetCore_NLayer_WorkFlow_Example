using AutoMapper;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO.AppUserDTO;
using NLayer_Workflow.Entities.DTO.NotificationDTO;
using NLayer_Workflow.Entities.DTO.ReportDTO;
using NLayer_Workflow.Entities.DTO.UrgencyDTO;
using NLayer_Workflow.Entities.DTO.WorkDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Bussiness.EntityMapper.AutoMapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            #region Urgency-UrgencyDTO
            CreateMap<UrgencyAddDto, Urgency>();
            CreateMap<Urgency, UrgencyAddDto>();

            CreateMap<UrgencyListDto, Urgency>();
            CreateMap<Urgency, UrgencyListDto>();

            CreateMap<UrgencyUpdateDto, Urgency>();
            CreateMap<Urgency, UrgencyUpdateDto>();
            #endregion

            #region User-UserDTO
            CreateMap<UserAddDto, AppUser>();
            CreateMap<AppUser, UserAddDto>();

            CreateMap<UserUpdateDto, AppUser>();
            CreateMap<AppUser, UserUpdateDto>();

            CreateMap<AppUser, UserSignInDto>();
            CreateMap<UserSignInDto, AppUser>();
            #endregion

            #region Notification-NotificationDTO
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Work-WorkDTO
            CreateMap<Work, WorkAddDto>();
            CreateMap<WorkAddDto, Work>();

            CreateMap<WorkDetailDto, Work>();
            CreateMap<Work, WorkDetailDto>();

            CreateMap<WorkListDto, Work>();
            CreateMap<Work, WorkListDto>();

            CreateMap<WorkIncludedListDto, Work>();
            CreateMap<Work, WorkIncludedListDto>();

            CreateMap<WorkUpdateDto, Work>();
            CreateMap<Work, WorkUpdateDto>();
            #endregion

            #region Report-ReportDTO
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportAddDto, Report>();

            CreateMap<Report, ReportUpdatetDto>();
            CreateMap<ReportUpdatetDto, Report>();
            #endregion
        }
    }
}
