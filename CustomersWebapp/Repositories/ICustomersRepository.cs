using CustomersWebapp.Models;

namespace CustomersWebapp.Repositories
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> Get();

        Task<bool> Add(Customer customer);
        Task<Customer> Get(int id);
    }
}
