using CustomersWebapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomersWebapp.Controllers
{
    public class CustomersController : Controller
    {
        //Problems ???
        public IActionResult Index(string name, string email, string phone)
        {

            var list = new List<Customer> {
                new Customer { ID = 1, Name = "Name 1", Email = "Emai 1", Phone = "Phone" },
                new Customer { ID = 1, Name = "Name 2", Email = "Emai 2", Phone = "Phone" },
                new Customer { ID = 1, Name = "Name 3", Email = "Emai 3", Phone = "Phone" },
                new Customer { ID = 1, Name = "Name 4", Email = "Emai 4", Phone = "Phone" },
            };
            return View(list);
        }
    }
}
