using FluentValidation;
using OnlineShop.Application.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Abstractions
{
    public class Validation<T> : AbstractValidator<T>, IValidation
    {
    }
}
