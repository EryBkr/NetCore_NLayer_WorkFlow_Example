using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.AppUser;
using NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.Report;
using NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.Urgency;
using NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.Work;
using NLayer_Workflow.Entities.DTO.AppUserDTO;
using NLayer_Workflow.Entities.DTO.ReportDTO;
using NLayer_Workflow.Entities.DTO.UrgencyDTO;
using NLayer_Workflow.Entities.DTO.WorkDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Extensions
{
    public static class StartupValidatorResolvers
    {
        public static void ValidatorConfigurations(this IServiceCollection services)
        {
            //ilk parametredeki DTO için ilgili Validasyonu çalıştır 
            services.AddTransient<IValidator<UrgencyAddDto>, UrgencyAddValidator>();
            services.AddTransient<IValidator<UrgencyUpdateDto>, UrgencyUpdateValidator>();
            services.AddTransient<IValidator<UserAddDto>, UserAddValidator>();
            services.AddTransient<IValidator<UserSignInDto>, UserSignInValidator>();
            services.AddTransient<IValidator<UserUpdateDto>, UserUpdateValidator>();
            services.AddTransient<IValidator<ReportAddDto>, ReportAddValidator>();
            services.AddTransient<IValidator<ReportUpdatetDto>, ReportUpdateValidator>();
            services.AddTransient<IValidator<WorkAddDto>, WorkAddValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateValidator>();
        }
    }
}
