<<<<<<< HEAD
﻿namespace WebApplication5.Validators;
using FluentValidation;
using OfficeOpenXml;
using System.Text.RegularExpressions;
using WebApplication5.Data;
using WebApplication5.Models;
using System.IO;

public class UserValidator : AbstractValidator<User>
{
    private readonly string _databasePath;

    public UserValidator(ExcelDbContext excelDbContext, string databasePath)
    {
        _databasePath = databasePath;

        RuleFor(user => user.Id)
            .NotEmpty().WithMessage("Id is required.")
            .Must(id => CheckIdExists(id)).WithMessage("Id does not exist in the database.");

        RuleFor(user => user.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Length(6, 8).WithMessage("Username must be between 6 and 8 characters.")
            .Must(BeValidUsername).WithMessage("Invalid username format.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(8, 10).WithMessage("Password must be between 8 and 10 characters.")
            .Matches(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[$!#]).*$")
            .WithMessage("Password must contain at least one letter, one digit, and one special character (!$#).");
    }

    private bool CheckIdExists(string id)
    {
        using (var package = new ExcelPackage(new FileInfo(_databasePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Users"];

            if (worksheet == null)
            {
                // Handle the case when the worksheet doesn't exist
                return false;
            }

            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++) // Assuming the first row is for headers
            {
                string cellId = worksheet.Cells[row, 1].Value?.ToString();

                if (cellId == id)
                {
                    return true;
                }
            }

            return false;
        }
    }


=======
﻿using FluentValidation;
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

>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
    private bool BeValidUsername(string username)
    {
        // Implement your username validation logic here
        // Return true if the username is valid, otherwise return false
<<<<<<< HEAD

        // Example validation logic:
        // Username must be at least 4 characters long and contain only alphanumeric characters

        if (string.IsNullOrEmpty(username))
        {
            // Username cannot be null or empty
            return false;
        }

        if (username.Length < 4)
        {
            // Username must be at least 4 characters long
            return false;
        }

        if (!Regex.IsMatch(username, "^[a-zA-Z0-9]+$"))
        {
            // Username can only contain alphanumeric characters
            return false;
        }

        // All validation checks passed, username is valid
=======
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
>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
        return true;
    }
}

<<<<<<< HEAD



=======
>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
