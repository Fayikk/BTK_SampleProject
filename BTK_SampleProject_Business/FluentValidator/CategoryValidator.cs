using BTK_SampleProject.Entities;
using FluentValidation;

namespace BTK_SampleProject_Business.FluentValidator
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryDescription).MinimumLength(5).WithMessage("Kategori Açıklaması 5'ten Küçük Olamaz");
            RuleFor(x => x.CategoryName).MaximumLength(10).WithMessage("Kategori Adı 10'dan Büyük Olamaz");
        }
    }
}
