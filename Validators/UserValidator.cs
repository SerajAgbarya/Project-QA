namespace WebApplication5.Validators;
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


    private bool BeValidUsername(string username)
    {
        // Implement your username validation logic here
        // Return true if the username is valid, otherwise return false

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
        return true;
    }
}




