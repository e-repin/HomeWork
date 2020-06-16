using System.Collections.Generic;
using Utils.Models;

namespace Utils.Interfaces
{
    public interface ICustomersRepository
    {
        IList<Customers> GetAllCustomers();
        Customers GetCustomersId(int id);
        int Insert(Customers customer);
        int DeleteCustomersId(int id);
    }
}
