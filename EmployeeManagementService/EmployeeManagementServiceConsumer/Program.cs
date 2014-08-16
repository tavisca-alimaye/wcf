using EmployeeManagementServiceConsumer.EmployeeManagementServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateEmployeeClient client = new CreateEmployeeClient();

            for (int i = 0; i < 3; i++)
            {
                Employee emp = new Employee();
                Console.WriteLine("EmployeeID : ");
                emp.EmpId = int.Parse(Console.ReadLine());
                Console.WriteLine("Employee Name : ");
                emp.EmpName = Console.ReadLine();
                client.AddEmployee(emp); 
            }

            Console.WriteLine("Give Employee Id for adding a remark -->");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Add remark");
            var comments = Console.ReadLine();
            client.AddRemark(id, comments);
            client.Close();
        }
    }
}