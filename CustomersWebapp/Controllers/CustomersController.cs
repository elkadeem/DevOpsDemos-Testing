using CustomersWebapp.Models;
using Microsoft.AspNetCore.Authorization;
using CustomersWebapp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CustomersWebapp.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {

        private readonly ICustomersRepository customersRepository;
        public CustomersController(ICustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;
        }
        //Problems ???
        public async Task<IActionResult> Index(CustomersViewModel model)
        {
            var list = await customersRepository.Get();
            return View(list);
        }


        public IActionResult Create()
        {
            return View();
        }

        //How many test cases needed?????
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await customersRepository.Add(new Customer()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Phone = model.Phone,
                });

                if (result)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError("", "An error while saving");
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
