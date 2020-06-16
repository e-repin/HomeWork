using DataAccessDapper;
using System;
using Utils.Models;

namespace HomeWork28
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = new CustomerRepositoryDapper();
            //var customerManager = CustumerManager();

            //Get id
            var customerId = customerManager.GetCustomersId(1);
            Console.WriteLine("GetCustomersId");
            Console.WriteLine(customerId);            

            //Insert
            var createCustomer = new Customers();
            createCustomer.Customer_name = "Evgeniy";
            createCustomer.Segment_id = 1;
            
            Console.WriteLine("Insert");

            var customer1 = customerManager.Insert(createCustomer);
            Console.WriteLine(customer1);

            //Delete
            customerManager.DeleteCustomersId(7);

            //Get all
            var customersAll = customerManager.GetAllCustomers();
            Console.WriteLine("GetAllCustomers");
            foreach (var item in customersAll)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
