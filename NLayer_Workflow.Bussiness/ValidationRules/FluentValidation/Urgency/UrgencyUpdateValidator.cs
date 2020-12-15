using FluentValidation;
using NLayer_Workflow.Entities.DTO.UrgencyDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.Urgency
{
    public class UrgencyUpdateValidator : AbstractValidator<UrgencyUpdateDto>
    {
        public UrgencyUpdateValidator()
        {
            RuleFor(i => i.Description).NotNull().WithMessage("Tanım boş olamaz");
        }
    }
}
