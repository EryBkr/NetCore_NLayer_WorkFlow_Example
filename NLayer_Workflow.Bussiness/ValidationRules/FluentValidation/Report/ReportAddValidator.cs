using FluentValidation;
using Microsoft.Extensions.Primitives;
using NLayer_Workflow.Entities.DTO.ReportDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.Report
{
    public class ReportAddValidator : AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(i => i.Description).NotNull().WithMessage("Tanım boş geçilemez");
            RuleFor(i => i.Detail).NotNull().WithMessage("Detay alanı boş geçilemez");
        } 
    }
}
