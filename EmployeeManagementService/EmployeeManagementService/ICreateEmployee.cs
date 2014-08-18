using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICreateEmployee
    {

        [OperationContract]
        void AddEmployee(Employee emp);

        [OperationContract]
        void AddRemark(int id, string comments);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmpId { get; set; }

        [DataMember]
        public string EmpName { get; set; }

        [DataMember]
        public Remarks remark;

        public Employee()
        {
            EmpId = -1;
            EmpName = null;
            remark = new Remarks();
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
