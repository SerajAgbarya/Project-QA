namespace WebApplication5.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using FluentValidation.Results;
    using FluentValidation;
    using System.Collections.Generic;
    using System.Linq;
    using WebApplication5.Models;

    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

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
        }

        public IActionResult Register()
        {
            return View();
        }

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
