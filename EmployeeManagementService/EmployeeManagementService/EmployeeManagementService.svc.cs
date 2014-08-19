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
                {
                    empDatabase.Add(emp);
                }
            }
            catch (FaultException)
            {
                throw new FaultException(new FaultReason("Given Id already exists!!!"), new FaultCode("Duplicate Id"));
            }
            
        }

        void ICreateEmployee.AddRemark(int id, string comments)
        {
            Employee employee = empDatabase.Find(e => e.EmpId.Equals(id));
            try
            {
                if (comments == null || comments == " ")
                    throw new ArgumentNullException();
                if (employee != null)
                {
                    if (employee.Remark == null)
                    {
                        employee.Remark = new Remarks();
                        //employee.remark.RemarkDateTimeStamp = DateTime.Now;
                        employee.Remark.RemarkDescription = comments;
                    }
                    else
                    {
                        employee.Remark.RemarkDateTimeStamp = DateTime.Now;
                        employee.Remark.RemarkDescription += comments;
                    }
                }
                else
                {
                    throw new FaultException(new FaultReason("Employee with given Id does not exist!!!"), new FaultCode("NoEmployeeForAddingRemark"));
                }
            }
            catch (ArgumentNullException)
            {
                throw new FaultException(new FaultReason("Remark cannot be Null or blank!!!"), new FaultCode("RemarkIsNull"));
            }
        }

        List<Employee> IGetDetails.GetAllEmployees()
        {
            return empDatabase;
        }

        List<Employee> IGetDetails.GetSelectedEmployee(string name)
        {
            try
            {
                var emp = empDatabase.FindAll(e => e.EmpName.Equals(name));
                if (emp.Count == 0)
                    throw new NullReferenceException();
                else
                    return emp;
            }
            catch (NullReferenceException)
            {
                throw new FaultException(new FaultReason("Employee with given Name is not present in Database"), new FaultCode("NoEmployeeWithGivenName"));
            }            
        }

        Employee IGetDetails.GetSelectedEmployee(int id)
        {
            try
            {
                Employee emp = empDatabase.Find(e => e.EmpId.Equals(id));
                if (emp == null)
                    throw new NullReferenceException();
                else
                    return emp;
            }
            catch (NullReferenceException)
            {
                throw new FaultException(new FaultReason("Employee with given Id is not present in Database"), new FaultCode("NoEmployeeWithGivenId"));
            }
        }
    }
}
