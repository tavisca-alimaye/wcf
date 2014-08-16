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
            CreateEmployeeClient clientForCreation = new CreateEmployeeClient();
            GetDetailsClient clientForRetrieval = new GetDetailsClient();

            for (int i = 0; i < 3; i++)
            {
                Employee emp = new Employee();
                Console.WriteLine("EmployeeID : ");
                emp.EmpId = int.Parse(Console.ReadLine());
                Console.WriteLine("Employee Name : ");
                emp.EmpName = Console.ReadLine();
                clientForCreation.AddEmployee(emp); 
            }

            Console.WriteLine("Give Employee Id for adding a remark -->");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Add remark");
            var comments = Console.ReadLine();
            clientForCreation.AddRemark(id, comments);
            clientForCreation.Close();
            
            var employeeWithGivenId = clientForRetrieval.SearchById(1);
            var employeeWithGivenName = clientForRetrieval.SearchByName("Dhruv");
            clientForRetrieval.Close();
        }
    }
}