using DataAccessDapper;
using System.Collections.Generic;
using Utils.Interfaces;
using Utils.Models;

namespace BusinessLogic
{
    public class CustumerManager
    {
        private readonly ICustomersRepository custumerRepository;

        public CustumerManager()
        {
            custumerRepository = new CustomerRepositoryDapper();
            //CustomersRepositoryADO();
        }

        public IList<Customers> GetAllCustomers()
        {
            return custumerRepository.GetAllCustomers();
        }
    }
}
