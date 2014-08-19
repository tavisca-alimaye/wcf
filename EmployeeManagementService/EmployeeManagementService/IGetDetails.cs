using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementService
{
    [ServiceContract]
    public interface IGetDetails
    {
        [OperationContract]
        List<Employee> GetAllEmployees();

        [OperationContract(Name = "SearchByName")]
        List<Employee> GetSelectedEmployee(string name);

        [OperationContract(Name = "SearchById")]
        Employee GetSelectedEmployee(int id);
    }
}
