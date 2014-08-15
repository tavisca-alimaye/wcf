using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumerEmployeeManagement.ServiceReference1;

namespace ConsumerEmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new EmployeeManagementClient();
            client.AddEmployee(12, "Arnav");
        }
    }
}
