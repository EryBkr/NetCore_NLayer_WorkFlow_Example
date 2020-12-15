using FluentValidation;
using NLayer_Workflow.Entities.DTO.WorkDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.Work
{
    public class WorkUpdateValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateValidator()
        {
            RuleFor(i => i.Name).NotNull().WithMessage("Görev adı boş olamaz");
            RuleFor(i => i.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen aciliyet durumu seçiniz");
        }
    }
}
