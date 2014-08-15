using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManager
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICreateEmployee
    {

        [OperationContract]
        void AddEmployee(int id,string name);

        [OperationContract]
        void AddRemark(Employee e);

        [OperationContract]
        Employee GetEmployee(int empId);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmployeeID { get; set; }

        [DataMember]
        public string EmployeeName { get; set; }

        [DataMember]
        public Remarks remark;



        internal void AddEmp(int id,string name)
        {
            /*Console.WriteLine("EmployeeID :");
            EmployeeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Employee Name :");
            EmployeeName = Console.ReadLine();*/
            EmployeeID = id;
            EmployeeName = name;
        }
    }

    public class Remarks
    {
        public DateTime RemarkDateTimeStamp { get; set; }
        public string RemarkDescription { get; set; }
        public Remarks()
        {
            RemarkDateTimeStamp = DateTime.Now;
            RemarkDescription = null;
        }
    }
}
