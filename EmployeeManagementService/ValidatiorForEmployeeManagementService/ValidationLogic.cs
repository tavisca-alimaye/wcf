using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using EmployeeManagementService;
using System.Text.RegularExpressions;

namespace ValidatiorForEmployeeManagementService
{
    public class ValidationLogic : IParameterInspector
    {

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            if (operationName == "AddEmployee")
            {
                Employee ip = (Employee)inputs[0];
                if (ip.EmpId < 0)
                    throw new FaultException(new FaultReason("Employee Id must be greater than 0"), new FaultCode("Id not valid"));
                else if (ip.EmpName == null)
                    throw new FaultException(new FaultReason("Employee name must not be null"), new FaultCode("EmployeeNameIsNull"));
                else if (!(Regex.IsMatch(ip.EmpName, @"^[a-zA-Z]+$")))
                    throw new FaultException(new FaultReason("Employee name must contain only letters"), new FaultCode("Name must contain letters only"));
                else
                    return null;
            }
            return null;
        }
    }
}
