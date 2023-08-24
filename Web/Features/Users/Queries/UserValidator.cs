using System;
using FluentValidation;
using Web.Domain;

namespace Web.Users.Queries;


public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.FirstName).NotNull();
        RuleFor(user => user.LastName).NotNull();
        RuleFor(user => user.Created).NotNull();
    }
}

