using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

using System.Threading.Tasks;
using Application.Dto_s;

namespace Application.Helpers
{
    public class PostToMenuValidator : AbstractValidator<PostToMenuDto>
    {
        public PostToMenuValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Item Name is required")
                .Length(1, 40).WithMessage("Name must be between 1 and 40 characters");
            RuleFor(x => x.PrimaryImage)
                .NotEmpty().WithMessage("Primary image URL is required.")
                .Must(x => Uri.IsWellFormedUriString(x, UriKind.Absolute)).WithMessage("Primary image must be a valid URL.");
            RuleFor(x => x.Money)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.MenuCategoryId)
                .GreaterThan(0).WithMessage("Valid MenuCategoryId is required.");
            RuleFor(x => x.RestaurantId)
                .NotEmpty().WithMessage("RestaurantId is required");
            RuleFor(x => x.MenuFilterIds)
                .NotEmpty().WithMessage("MenuFilterIds should not be empty."); RuleFor(x => x.IngredientIds);
            RuleFor(x => x.IngredientIds)
                .NotEmpty().WithMessage("At least one ingredient is required.")
                .Must(ids => ids.All(id => id > 0 && id < 3))
                .WithMessage("All ingredient IDs should be greater than 0 and less than 3.");


        }
    }
}
