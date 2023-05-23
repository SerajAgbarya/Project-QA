<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using WebApplication5.Validators;
using WebApplication5.Models;
using WebApplication5.Data;
using System.Linq;
using OfficeOpenXml;
using ClosedXML.Excel;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication5.Controllers
{
    public class UserController : Controller
    {
        private readonly ExcelDbContext _dbContext;
        private readonly UserValidator _validator;


        public UserController(ExcelDbContext dbContext, UserValidator validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }


=======
﻿namespace WebApplication5.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using FluentValidation.Results;
    using FluentValidation;
    using System.Collections.Generic;
    using System.Linq;
    using WebApplication5.Models;

    public class UserController : Controller
    {
>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
        public IActionResult Login()
        {
            return View();
        }
<<<<<<< HEAD
        private bool CheckUserCredentials(string username, string password)
        {
            // Perform your custom logic here to check if the user credentials are valid
            // against the desired data source (e.g., a list, a file, an API, etc.)

            // Example: Checking against a list of predefined users
            List<User> users = new List<User>
            {
              new User { Username = "user1", Password = "password1" },
              new User { Username = "user2", Password = "password2" },
              new User { Username = "user3", Password = "password3" }
             };

            return users.Any(u => u.Username == username && u.Password == password);
        }
        private bool CheckUserExists(string username, string password)
        {
            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo("C:\\Users\\USER\\Desktop\\Project-QA\\database.xlsx")))
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Sheet1"];

                    if (worksheet == null)
                    {
                        // Handle the case where the worksheet doesn't exist
                        return false;
                    }

                    // Check the number of rows in the worksheet
                    int rowCount = worksheet.Dimension.Rows;

                    // Iterate through each row to check if the user exists
                    for (int row = 2; row <= rowCount; row++)
                    {
                        string storedUsername = worksheet.Cells[row, 2].Value?.ToString();
                        string storedPassword = worksheet.Cells[row, 3].Value?.ToString();

                        if (storedUsername == username && storedPassword == password)
                        {
                            return true; // User exists
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or print the exception for debugging
                Console.WriteLine("Error occurred while checking user existence: " + ex.Message);
            }

            return false; // User does not exist
        }






        public IActionResult ReadExcelData()
        {
            // Specify the path to your Excel file
            string filePath = "C:\\Users\\USER\\Desktop\\Project-QA\\database.xlsx";

            // Open the Excel file and retrieve user data
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1); // Assuming the first worksheet
                var rows = worksheet.RowsUsed();

                foreach (var row in rows.Skip(1)) // Assuming the user data starts from the second row
                {
                    string username = row.Cell(1).GetString();
                    string password = row.Cell(2).GetString();

                    // Process the user data as needed
                    // For example, you can store the user data in a list or perform any validation or business logic
                    Console.WriteLine($"Username: {username}, Password: {password}");
                }
            }

            return View();
        }



        [HttpPost]
        [HttpPost]
        [HttpPost]
        public IActionResult Login(User user)
        {
            bool isUserExists = CheckUserExists(user.Username, user.Password);

            if (isUserExists)
            {
                // TODO: Perform login logic
                return RedirectToAction("Homepage","Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "You should sign up first");
                return View(user);
            }
        }
        public IActionResult CreateExcelFile()
        {
            // Create a new workbook
            var workbook = new XLWorkbook();

            // Add a worksheet to the workbook
            var worksheet = workbook.Worksheets.Add("Users");

            // Add column headers
            worksheet.Cell(1, 1).Value = "Username";
            worksheet.Cell(1, 2).Value = "Password";

            // Add user data
            worksheet.Cell(2, 1).Value = "user1";
            worksheet.Cell(2, 2).Value = "password1";

            worksheet.Cell(3, 1).Value = "user2";
            worksheet.Cell(3, 2).Value = "password2";

            // Save the workbook to a file
            string filePath = "C:\\Users\\USER\\Desktop\\Project-QA\\database.xlsx";
            workbook.SaveAs(filePath);

            return View();
        }



        public IActionResult Index()
        {
            var users = _dbContext.Users.ToList();
            return View(users);
        }


        public IActionResult Create(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]

        [HttpPost]
        public IActionResult Register(User user)
        {
            bool isUserExists = CheckUserExists(user.Username, user.Password);

            if (isUserExists)
            {
                ModelState.AddModelError("", "User already exists. Please sign in.");
                return View(user);
            }

            if (!IsValidId(user.Id))
            {
                ModelState.AddModelError("", "ID should be a number.");
                return View(user);
            }

            if (!IsValidUsername(user.Username))
            {
                ModelState.AddModelError("", "Invalid username format.");
                return View(user);
            }

            if (!IsValidPassword(user.Password))
            {
                ModelState.AddModelError("", "Invalid password format.");
                return View(user);
            }

            // TODO: Add the user to the Excel database
            using (var package = new ExcelPackage(new FileInfo("C:\\Users\\USER\\Desktop\\Project-QA\\database.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                var lastRow = worksheet.Dimension?.End.Row ?? 0;

                // Add the user data to the next available row
                worksheet.Cells[lastRow + 1, 1].Value = user.Id;
                worksheet.Cells[lastRow + 1, 2].Value = user.Username;
                worksheet.Cells[lastRow + 1, 3].Value = user.Password;

                // Save the changes to the Excel file
                if (!isUserExists)
                {
                    package.Save();
                } 
            }

            return RedirectToAction("Index", "Home");
        }



        private bool IsValidId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                // ID cannot be null or empty
                return false;
            }
            if (!Regex.IsMatch(id, "^[0-9]+$"))
            {
                // ID should be a number
                return false;
            }
            return true;

          
        }


        private bool IsValidUsername(string username)
        {
            // Implement your username validation logic here
            // Return true if the username is valid, otherwise return false

            // Example validation logic:
            // Username must be at least 6 characters long and contain only alphanumeric characters

            if (string.IsNullOrEmpty(username))
            {
                // Username cannot be null or empty
                return false;
            }

            if (username.Length < 6 || username.Length > 8)
            {
                // Username must be between 6 and 8 characters long
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

        private bool IsValidPassword(string password)
        {
            // Implement your password validation logic here
            // Return true if the password is valid, otherwise return false

            // Example validation logic:
            // Password must be between 8 and 10 characters long
            // Password must contain at least one letter, one digit, and one special character (!$#)

            if (string.IsNullOrEmpty(password))
            {
                // Password cannot be null or empty
                return false;
            }

            if (password.Length < 8 || password.Length > 10)
            {
                // Password must be between 8 and 10 characters long
                return false;
            }

            if (!Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[$!#]).*$"))
            {
                // Password must contain at least one letter, one digit, and one special character (!$#)
                return false;
            }

            // All validation checks passed, password is valid
            return true;
=======

        [HttpPost]
        public IActionResult Login(User user)
        {
            UserValidator validator = new UserValidator();
            ValidationResult results = validator.Validate(user);

            if (results.IsValid)
            {
                // TODO: Perform login logic
                return RedirectToAction("Index", "Home");
            }

            foreach (ValidationFailure failure in results.Errors)
            {
                ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }

            return View(user);
>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
        }

        public IActionResult Register()
        {
            return View();
        }
<<<<<<< HEAD
       
    }
        
    }
 


=======

        [HttpPost]
        public IActionResult Register(User user)
        {
            UserValidator validator = new UserValidator();
            ValidationResult results = validator.Validate(user);

            if (results.IsValid)
            {
                // TODO: Perform registration logic
                return RedirectToAction("Index", "Home");
            }

            foreach (ValidationFailure failure in results.Errors)
            {
                ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }

            return View(user);
        }
    }

}
>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
