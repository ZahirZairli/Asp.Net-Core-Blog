using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş saxlanıla bilməz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş saxlanıla bilməz");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog şəkli boş saxlanıla bilməz");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog başlığı maksimum 150 simvoldan ibarət olmalıdır");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog başlığı minimum 5 simvoldan ibarət olmalıdır");
            RuleFor(x => x.BlogContent).MinimumLength(50).WithMessage("Blog kontenti minimum 50 simvoldan ibarət olmalıdır");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Zəhmət olmasa bir kategorya seçin");
        }
    }
}
