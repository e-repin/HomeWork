using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;
using Utils.Models;

namespace DataAccess
{
    public class CustomersRepositoryADO : ICustomersRepository
    {
        private readonly string connection = string.Empty;

        public CustomersRepositoryADO()
        {
            connection = ConfigurationManager.ConnectionStrings["HRSQLProvider"].ConnectionString;
        }
        public int DeleteCustomersId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                var selection = String.Format("DELETE FROM customers WHERE customer_id='{0}'", id);

                var adapter = new SqlCommand(selection, sqlConnection);
                int customer = adapter.ExecuteNonQuery();
                sqlConnection.Close();
                return customer;
            }
        }

        public IList<Customers> GetAllCustomers()
        {
            var customersList = new List<Customers>();
            var selection = "SELECT * FROM customers";
            var adapter = new SqlDataAdapter(selection, connection);
            var customersSet = new DataSet();
            adapter.Fill(customersSet, "customers");
            foreach (DataRow row in customersSet.Tables["customers"].Rows)
            {
                customersList.Add(new Customers((int)row[0], (string)row[1], (int)row[2]));
            }
            return customersList;
        }

        public Customers GetCustomersId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                Customers customer = new Customers();
                sqlConnection.Open();
                var selection = String.Format("FROM customers WHERE customer_id='{0}'", id);

                var adapter = new SqlCommand(selection, sqlConnection);
                var result = adapter.ExecuteReader();

                while (result.Read())
                {
                    object customerId = result.GetValue(0);
                    object customerName = result.GetValue(1);
                    object segmentID = result.GetValue(2);

                    customer.Customer_id = (int)customerId;
                    customer.Customer_name = (string)customerName;
                    customer.Segment_id = (int)segmentID;

                }
                return customer;
            }
        }      

        public int Insert(Customers customers)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                var selection = String.Format("INSERT INTO customers VALUES ('{0}')", customers.Customer_name);

                var command = new SqlCommand(selection, sqlConnection);
                var customer = command.ExecuteNonQuery();
                sqlConnection.Close();
                return customer;
            }
        }
    }
}
