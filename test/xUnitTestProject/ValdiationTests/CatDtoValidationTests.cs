using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.FluentValidators;
using Microsoft.AspNetCore.Identity;
using FluentValidation.TestHelper;

namespace xUnitTestProject.ValdiationTests
{
    public class CatDtoValidationTests
    {
        [Fact]
        public async Task CreateCatDtoValidator_Valid_Success()
        {
            var validCatDto = new CreateCatDto { CatName = "Test", CatOwner = "TestOwner" };
            var validator = new CreateCatDtoValidator();

            var result = validator.TestValidate(validCatDto);

            result.ShouldNotHaveValidationErrorFor(x => x.CatName);
            result.ShouldNotHaveValidationErrorFor(x => x.CatOwner);
            result.ShouldNotHaveAnyValidationErrors();
        }
        [Fact]
        public async Task CreateDtoValidator_TooShortNames_Invalid()
        {
            var invalidCatDto = new CreateCatDto { CatName = "T", CatOwner = "T" };
            var validator = new CreateCatDtoValidator();

            var result = validator.TestValidate(invalidCatDto);

            result.ShouldHaveValidationErrorFor(x => x.CatName);
            result.ShouldHaveValidationErrorFor(x => x.CatOwner);
        }

        [Fact]
        public async Task CreateDtoValidator_TooLongNames_Invalid()
        {
            var invalidCatDto = new CreateCatDto { CatName = "Mr. PufflepantsTheThird cattypingonkeybaordal;kdfjhaioufhaikdhfklajhfiouahiuoqwehiourhkljasdfnkljasdfhklajsdhf", CatOwner = "reiopuqorpiuqoperiuqopweiqpoiurepoqiueropiqurepoiquerpoiquerpoqiwueropqiwuerpoiquwerpoiquweropiuqerpoiuqoperiuqpoewruqwopeiuqopwieqopiweopiqwe" };
            var validator = new CreateCatDtoValidator();

            var result = validator.TestValidate(invalidCatDto);

            result.ShouldHaveValidationErrorFor(x => x.CatName);
            result.ShouldHaveValidationErrorFor(x => x.CatOwner);
        }
    }
}
