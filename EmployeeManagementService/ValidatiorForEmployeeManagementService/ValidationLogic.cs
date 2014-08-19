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

namespace ValidatiorForEmployeeManagementService
{
    public class ValidationLogic : IParameterInspector
    {

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            throw new NotImplementedException();
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            if (operationName == "AddEmployee")
            {
                Employee ip = (Employee)inputs[0];
                
                if (ip.EmpName == null)
                    throw new FaultException(new FaultReason("Passed parameter is not of type Employee"), new FaultCode("Parameter not valid"));
            }
            return null;
        }
    }
}
