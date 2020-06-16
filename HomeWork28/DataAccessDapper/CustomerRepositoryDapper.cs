using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Utils.Interfaces;
using Utils.Models;

namespace DataAccessDapper
{
    public class CustomerRepositoryDapper : ICustomersRepository
    {
        private readonly string connection = string.Empty;

        public CustomerRepositoryDapper()
        {
            connection = ConfigurationManager.ConnectionStrings["HRSQLProvider"].ConnectionString;
        }
        public int DeleteCustomersId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                var selection = "DELETE FROM customers WHERE customer_id = @Id";
                var customers = sqlConnection.Execute(selection, new { id });
                return customers;
            }
        }
        public IList<Customers> GetAllCustomers()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                var selection = "SELECT * FROM customers";
                var customers = sqlConnection.Query<Customers>(selection).AsList();
                return customers;
            }
        }
        public Customers GetCustomersId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                var selection = "SELECT * FROM customers WHERE customer_id = @Id";
                var customers = sqlConnection.Query<Customers>(selection, new { id }).FirstOrDefault();
                return customers;
            }
        }
        public int Insert(Customers customers)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                var insertion = "INSERT INTO customers VALUES (@Name, @Segment)";
                var numCustomer = sqlConnection.Execute(insertion, new { Name = customers.Customer_name, Segment= customers.Segment_id});
                return numCustomer;
            }
        }
    }
}
