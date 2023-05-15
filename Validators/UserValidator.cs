using FluentValidation;
using WebApplication5.Models;

using FluentValidation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Length(6, 8).WithMessage("Username must be between 6 and 8 characters.")
            .Must(BeValidUsername).WithMessage("Username can only contain letters and up to 2 digits.");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(8, 10).WithMessage("Password must be between 8 and 10 characters.")
            .Must(BeValidPassword).WithMessage("Password must contain at least one letter, one digit, and one special character.");
    }

    private bool BeValidUsername(string username)
    {
        // Implement your username validation logic here
        // Return true if the username is valid, otherwise return false
        // For example:
        // You can use regular expressions to validate the username format
        // Regex pattern: @"^[a-zA-Z]{4,6}\d{0,2}$"
        // This pattern allows between 6 and 8 characters, with at most 2 digits
        // Adjust the pattern according to your specific requirements
        // Example validation logic:
        // return Regex.IsMatch(username, @"^[a-zA-Z]{4,6}\d{0,2}$");
        return true;
    }

    private bool BeValidPassword(string password)
    {
        // Implement your password validation logic here
        // Return true if the password is valid, otherwise return false
        // Example validation logic:
        // Password must contain at least one letter, one digit, and one special character
        // You can use regular expressions or other validation methods
        // Example validation logic:
        // return Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!#%^&*()_+|~=`{}[:;<>?,.\/])[A-Za-z\d@$!#%^&*()_+|~=`{}[:;<>?,.\/]{8,10}$");
        return true;
    }
}

