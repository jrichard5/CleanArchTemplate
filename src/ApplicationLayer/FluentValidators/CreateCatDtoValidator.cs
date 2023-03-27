using ApplicationLayer.DTO_or_Interface;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.FluentValidators
{
    public class CreateCatDtoValidator : AbstractValidator<CreateCatDto>
    {
        public CreateCatDtoValidator()
        {
            RuleFor(aCat => aCat.CatName).NotEmpty().Length(2, 64);
            RuleFor(aCat => aCat.CatOwner).NotEmpty().Length(2, 64);
        }
    }
}
