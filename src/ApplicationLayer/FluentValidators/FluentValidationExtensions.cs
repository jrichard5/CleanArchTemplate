﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.FluentValidators
{
    public static class FluentValidationExtensions
    {
        public static void ValidateOrThrowInfoException<T>(this IValidator<T> validator, T instance)
        {
            var result = validator.Validate(instance);
            if (!result.IsValid)
            {
                var ex = new ValidationException(result.Errors);
                var customErrorMessage = String.Join(" | ", result.Errors);
                throw new ArgumentException(customErrorMessage, ex);
            }
        }
    }
}
