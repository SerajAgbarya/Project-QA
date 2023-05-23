namespace WebApplication5.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OfficeOpenXml;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using WebApplication5.Data;
    using WebApplication5.Models;
    using Microsoft.Extensions.Logging;

    public class BirdController : Controller
    {
        private readonly ExcelDbContext _context;
        private const string DatabaseFilePath = "C:\\Users\\USER\\Desktop\\Project-QA\\database.xlsx";
        private readonly ILogger<BirdController> _logger; // Add ILogger instance

        // Inject the ILogger instance into the constructor
        public BirdController(ExcelDbContext context, ILogger<BirdController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index1()
        {
            try
            {
                List<Bird> birds = GetBirdsFromDatabase();

                if (birds.Count == 0)
                {
                    ViewBag.Message = "No birds available.";
                }

                return View(birds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the Index1() method.");
                throw;
            }
        }


        public IActionResult Index()
        {
            try
            {
                List<Bird> birds = GetBirdsFromDatabase();

                if (birds == null)
                {
                    birds = new List<Bird>(); // Create an empty list if no birds found
                }

                return View(birds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the Index() method.");
                throw;
            }
        }




=======
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

>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bird bird)
        {
<<<<<<< HEAD
            if (ModelState.IsValid)
            {
                AddBirdToDatabase(bird);
                return RedirectToAction("Index1");
            }

            return View(bird);
        }

        private List<Bird> GetBirdsFromDatabase()
        {
            try
            {
                List<Bird> birds = new List<Bird>();

                using (var package = new ExcelPackage(new FileInfo(DatabaseFilePath)))
                {
                    var worksheet = package.Workbook.Worksheets["Birds"];

                    if (worksheet != null)
                    {
                        int rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            Bird bird = new Bird
                            {
                                SerialNumber = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                                Species = worksheet.Cells[row, 2].Value?.ToString(),
                                Subspecies = worksheet.Cells[row, 3].Value?.ToString(),
                                HatchDate = DateTime.FromOADate(Convert.ToDouble(worksheet.Cells[row, 4].Value)),
                                CageNumber = worksheet.Cells[row, 5].Value?.ToString(),
                                MasterSerialNumber = Convert.ToInt32(worksheet.Cells[row, 6].Value)
                            };

                            birds.Add(bird);
                        }
                    }
                }

                return birds;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the GetBirdsFromDatabase() method.");
                throw;
            }
        }


        private void AddBirdToDatabase(Bird bird)
        {
            using (var package = new ExcelPackage(new FileInfo(DatabaseFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Birds"];

                var lastRow = worksheet.Dimension?.End.Row ?? 0;

                // Check if the bird with the same serial number already exists
                var existingBird = GetBirdsFromDatabase().FirstOrDefault(b => b.SerialNumber == bird.SerialNumber);
                if (existingBird != null)
                {
                    ViewBag.Message = "Bird with the same serial number already exists.";
                    return;
                }

                worksheet.Cells[lastRow + 1, 1].Value = bird.SerialNumber;
                worksheet.Cells[lastRow + 1, 2].Value = bird.Species;
                worksheet.Cells[lastRow + 1, 3].Value = bird.Subspecies;
                worksheet.Cells[lastRow + 1, 4].Value = bird.HatchDate;
                worksheet.Cells[lastRow + 1, 5].Value = bird.CageNumber;
                worksheet.Cells[lastRow + 1, 6].Value = bird.MasterSerialNumber;

                package.Save();
            }
        }

    }
=======
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

>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
}
