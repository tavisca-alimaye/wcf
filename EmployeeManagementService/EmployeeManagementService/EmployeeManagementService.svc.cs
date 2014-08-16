﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagementService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
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
                if (employee.remark == null)
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
