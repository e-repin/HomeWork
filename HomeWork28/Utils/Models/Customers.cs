using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Models
{
    public class Customers
    {
        public Customers()
        {
        }
        public Customers(int cI, string cN, int sI)
        {
            Customer_id = cI;
            Customer_name = cN;
            Segment_id = sI;
        }

        public string Customer_name { get; set; }
        public int Customer_id { get; set; }
        public int Segment_id { get; set; }

        public override string ToString()
        {
            return $"{Customer_id}, {Customer_name}, {Segment_id}";
        }
    }
}
