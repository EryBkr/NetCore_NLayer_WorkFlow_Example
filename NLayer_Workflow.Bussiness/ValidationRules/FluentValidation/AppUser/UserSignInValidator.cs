using FluentValidation;
using NLayer_Workflow.Entities.DTO.AppUserDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.AppUser
{
    public class UserSignInValidator : AbstractValidator<UserSignInDto>
    {
        public UserSignInValidator()
        {
            RuleFor(i => i.UserName).NotNull().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(i => i.Password).NotNull().WithMessage("Parola boş olamaz");
        }
    }
}
