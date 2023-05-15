namespace WebApplication5.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using WebApplication5.Models;

    public class BirdController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Retrieve birds from the database or other data source
            List<Bird> birds = new List<Bird>
        {
            new Bird { SerialNumber = 1, Species = "Sparrow", Subspecies = "House Sparrow", HatchDate = new DateTime(2022, 1, 1), CageNumber = "A1", MasterSerialNumber = 123 },
            new Bird { SerialNumber = 2, Species = "Parrot", Subspecies = "Amazon Parrot", HatchDate = new DateTime(2021, 5, 15), CageNumber = "B2", MasterSerialNumber = 456 },
            // Add more birds as needed
        };

            return View(birds);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bird bird)
        {
            // TODO: Validate bird input and save to the database or other data source
            if (ModelState.IsValid)
            {
                // TODO: Save the bird to the database or other data source

                // Redirect to the Index action to display the list of birds
                return RedirectToAction("Index");
            }

            // If the model state is invalid, return to the Create view with the invalid bird model
            return View(bird);
        }
    }

}
