using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SubscribeValidator : AbstractValidator<NewsLetter>
    {
        public SubscribeValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu hissə boş saxlanıla bilməz");
        }
    }
}
