using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeManager : ICreateEmployee
    {
        public List<Employee> empDatabase = new List<Employee>();

        void ICreateEmployee.AddEmployee(Employee emp)
        {
            empDatabase.Add(emp);
        }

        void ICreateEmployee.AddRemark(int id, string comments)
        {
            Employee employee = empDatabase.Find(e => e.EmpId.Equals(id));
            if (employee != null)
            {
                if (employee.remark.RemarkDescription == null)
                {
                    employee.remark.RemarkDateTimeStamp = DateTime.Now;
                    employee.remark.RemarkDescription = comments;
                }
                else
                {
                    employee.remark.RemarkDateTimeStamp = DateTime.Now;
                    employee.remark.RemarkDescription += comments;
                }
            }
            else
            {
                throw new Exception("No employee with given ID");
            }
        }
    }
}
