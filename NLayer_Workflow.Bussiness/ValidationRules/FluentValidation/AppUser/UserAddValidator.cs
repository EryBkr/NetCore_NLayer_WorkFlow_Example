using FluentValidation;
using NLayer_Workflow.Entities.DTO.AppUserDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.AppUser
{
    public class UserAddValidator:AbstractValidator<UserAddDto>
    {
        public UserAddValidator()
        {
            RuleFor(i => i.UserName).NotNull().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(i => i.Password).NotNull().WithMessage("Parola boş olamaz");
            RuleFor(i => i.ConfirmPassword).NotNull().WithMessage("Parola onay alanı boş olamaz");
            RuleFor(i => i.ConfirmPassword).Equal(i => i.Password).WithMessage("Parolalar eşleşmiyor");
            RuleFor(i => i.Email).NotNull().WithMessage("Email boş olamaz").EmailAddress().WithMessage("Geçersiz email adresi");
            RuleFor(i => i.Name).NotNull().WithMessage("İsim boş olamaz");
            RuleFor(i => i.Surname).NotNull().WithMessage("Soyadı boş olamaz");

        }
    }
}
