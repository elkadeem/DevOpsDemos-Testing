using CustomersWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CustomersWebapp.Controllers
{
    public class CustomersController : Controller
    {
        //Problems ???
        public IActionResult Index(CustomersViewModel model)
        {
            var list = new List<Customer> {
                new Customer { ID = 1, Name = "Name 1", Email = "Emai 1", Phone = "Phone" },
                new Customer { ID = 1, Name = "Name 2", Email = "Emai 2", Phone = "Phone" },
                new Customer { ID = 1, Name = "Name 3", Email = "Emai 3", Phone = "Phone" },
                new Customer { ID = 1, Name = "Name 4", Email = "Emai 4", Phone = "Phone" },
            };

            return View(list);
        }


        public IActionResult Create()
        {
            return View();
        }

        //How many test cases needed?????
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCustomerModel model)
        {
            if(ModelState.IsValid)
            {
                //ToDo: Save it to database
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

    }

    public class CreateCustomerModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
    }

    public class CustomersViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Department { get; set; }

        public int? ManagerId { get; set; }
        
    }
}
