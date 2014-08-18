using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace EmployeeManagementService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EmployeeManager : ICreateEmployee,IGetDetails
    {
        public List<Employee> empDatabase = new List<Employee>();

        void ICreateEmployee.AddEmployee(Employee emp)
        {
            try
            {
                if (empDatabase.Exists(e => e.EmpId == emp.EmpId))
                {                    
                    throw new FaultException();
                }
                else
                    empDatabase.Add(emp);
            }
            catch (FaultException)
            {
                throw new FaultException(new FaultReason("Given Id already exists!!!"), new FaultCode("Duplicate Id"));
            }
            
        }

        void ICreateEmployee.AddRemark(int id, string comments)
        {
            Employee employee = empDatabase.Find(e => e.EmpId.Equals(id));
            if (employee != null)
            {
                if (employee.remark == null)
                {
                    employee.remark = new Remarks();
                    //employee.remark.RemarkDateTimeStamp = DateTime.Now;
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

        List<Employee> IGetDetails.GetAllEmployees()
        {
            return empDatabase;
        }

        Employee IGetDetails.GetSelectedEmployee(string name)
        {
            return (empDatabase.Find(e => e.EmpName.Equals(name)));
        }

        Employee IGetDetails.GetSelectedEmployee(int id)
        {
            return (empDatabase.Find(e => e.EmpId.Equals(id)));
        }
    }
}
