using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Bu hissə boş saxlanıla bilməz!");
            RuleFor(X => X.WriterMail).NotEmpty().WithMessage("Bu hissə boş saxlanıla bilməz!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Bu hissə boş saxlanıla bilməz!");
            //RuleFor(x => x.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifrə ən azı bir böyük hərfdən ibarət olmalıdır!(Xahiş olunur azərbaycan klaviyaturasından istifade etməyin)");
            //RuleFor(x => x.WriterPassword).Matches(@"[a-z]+").WithMessage("Şifrə ən azı bir kiçik hərfdən ibarət olmalıdır!");
            //RuleFor(x => x.WriterPassword).Matches(@"[0-9]+").WithMessage("Şifrə ən azı bir rəqəmdən ibarət olmalıdır!");
            RuleFor(x => x.WriterPassword).Must(PasswordContain).WithMessage("Şifrəniz ən azı bir böyük,bir balaca və bir rəqəmdən ibarət olmalıdır!(Qeyd: şifrədə böyük Azərbaycan şriftlərindən istifadə etməyin!) ");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Xahiş olunur minimum 2 hərfdən istifadə edin!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Xahiş olunur maksimum 50 hərfdən istifadə edin!");
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.WriterPassword != x.WriterPassword2)
                {
                    context.AddFailure(nameof(x.WriterPassword), "Daxil edilən şifrələr bir biri ilə eyni olmalıdır!");
                }
            });
        }

            private bool PasswordContain(string zahir)
            {
                try
                {
                    Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(zahir);
                }
                catch (Exception)
                {
                    return false;
                }
            }
    }
}
