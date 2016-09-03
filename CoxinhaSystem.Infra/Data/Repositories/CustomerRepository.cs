using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Models;
using System.Linq;
using Microsoft.Data.Entity;

namespace CoxinhaSystem.Infra.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public Customer GetByPhone(string phoneNumber)
        {
            var phone = _context.Phones
                .Include(p => p.Customer)
                .Where(p => p.PhoneNumber.Equals(phoneNumber))
                .FirstOrDefault();
            if (phone != null)
            {
                return phone.Customer;
            }
            else
            {
                return null;
            }
        }

        public Customer GetByPhoneComplete(string phoneNumber)
        {
            var phone = _context.Phones
                .Include(p => p.Customer)
                .ThenInclude(c => c.Addresses)
                .Where(p => p.PhoneNumber.Equals(phoneNumber))
                .FirstOrDefault();
            if (phone != null)
            {
                return phone.Customer;
            }
            else
            {
                return null;
            }
        }
    }
}