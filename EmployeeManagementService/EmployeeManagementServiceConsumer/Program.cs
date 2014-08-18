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
            int choice;            
            Employee emp = new Employee();

            do
            {
                choice = DisplayMenu();
                switch (choice)
                {
                    case 1:
                    {
                        do
                        {
                            Console.WriteLine("Enter Employee ID:");
                            emp.EmpId = int.Parse(Console.ReadLine());
                            if (IsEmployeeIdUnique(clientForRetrieval, emp.EmpId))
                            {
                                Console.WriteLine("Enter Employee Name:");
                                emp.EmpName = Console.ReadLine();
                                clientForCreation.AddEmployee(emp);
                                break;
                            }
                            else
                                Console.WriteLine("Employee Id must be unique....Employee with given Id already exists");
                        } while (true);
                        break;
                    }
                    case 2:
                    {
                        do
                        {
                            Console.WriteLine("Enter Employee ID to add remark:");
                            emp.EmpId = int.Parse(Console.ReadLine());
                            if (IsEmployeeIdUnique(clientForRetrieval, emp.EmpId))
                            {
                                Console.WriteLine("Employee with given Id doesn't exist...please Enter correct Id!!!");
                            }
                            else
                            {
                                Console.WriteLine("Enter remarks :");
                                clientForCreation.AddRemark(emp.EmpId, Console.ReadLine());
                                break;
                            }
                        } while (true);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Enter Employee Id :");
                        emp = clientForRetrieval.SearchById(int.Parse(Console.ReadLine()));
                        if (emp == null)
                            Console.WriteLine("Employee with given Id does not exist!!");
                        else                        
                            DisplayEmployeeDetails(emp);
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Enter Employee Name :");
                        emp = clientForRetrieval.SearchByName(Console.ReadLine());
                        if (emp == null)
                            Console.WriteLine("Employee with given Name does not exist!!");
                        else
                            DisplayEmployeeDetails(emp);
                        break;
                    }
                    case 5:
                    {
                        var empList = clientForRetrieval.GetAllEmployees();
                        break;
                    }
                }
            } while (choice != 0);

        }

        private static void DisplayEmployeeDetails(Employee emp)
        {
            Console.WriteLine("Employee ID : {0}", emp.EmpId);
            Console.WriteLine("Employee Name : {0}", emp.EmpName);
            if (emp.remark != null)
            {
                Console.WriteLine("Remarks for employee");
                Console.WriteLine("Remark Time : {0}", emp.remark.RemarkDateTimeStamp);
                Console.WriteLine("Remarks:\n {0}", emp.remark.RemarkDescription);
            }
        }

        private static bool IsEmployeeIdUnique(GetDetailsClient client,int id)
        {
            var emp = client.SearchById(id);
            if (emp != null)
            {                
                return false;
            }
            else
                return true;
        }

        

        private static int DisplayMenu()
        {
            Console.WriteLine("1.Add an Employee");
            Console.WriteLine("2.Add a remark");
            Console.WriteLine("3.Search Employee By Id");
            Console.WriteLine("4.Search Employee By Name");
            Console.WriteLine("5.Get whole Employee List");
            Console.WriteLine("0.Exit");
            Console.WriteLine("Choose your action :");
            string choice = Console.ReadLine();
            return int.Parse(choice);
        }

        
    }
}