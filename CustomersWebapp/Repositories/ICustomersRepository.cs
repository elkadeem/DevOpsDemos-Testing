using CustomersWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersWebapp.Repositories
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> Get();

        Task<bool> Add(Customer customer);
    }

    public class CustomersRepository : ICustomersRepository
    {
        private readonly CustomersDbContext customersDbContext;

        public CustomersRepository(CustomersDbContext customersDbContext)
        {
            this.customersDbContext = customersDbContext;
        }
        public async Task<bool> Add(Customer customer)
        {
           await customersDbContext.Customers
                .AddAsync(customer);

            var result = await customersDbContext.SaveChangesAsync();
            return result > 0;
        }

        public Task<List<Customer>> Get()
        {
            return customersDbContext.Customers
                .ToListAsync();
        }
    }
}
