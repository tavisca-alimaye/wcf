using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestForEmployeeManagementService.ServiceReferenceForTesting;
using System.ServiceModel;

namespace TestForEmployeeManagementService
{
    [TestClass]
    public class UnitTestsForEmployeeManagementService
    {
        CreateEmployeeClient clientForCreation = new CreateEmployeeClient();
        GetDetailsClient clientForRetrieval = new GetDetailsClient();
        //int choice;
        
        [TestMethod]
        public void AddEmployeeWithNewId()
        {
            Employee emp1 = new Employee();
            Employee emp2 = new Employee();
            emp1.EmpId = 20;
            emp1.EmpName = "Arnav";
            clientForCreation.AddEmployee(emp1);

            emp2 = clientForRetrieval.SearchById(emp1.EmpId);
            Assert.AreEqual(emp1.EmpName, emp2.EmpName);

        }

        [TestMethod]
        public void AddEmployeeWithDuplicateId()
        {
            Employee emp1 = new Employee();
            Employee emp2 = new Employee();
            try
            {
                emp1.EmpId = 1;
                emp1.EmpName = "Arnav";
                clientForCreation.AddEmployee(emp1);
                emp2.EmpId = 1;
                emp2.EmpName = "Dhruv";
                clientForCreation.AddEmployee(emp2);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "Duplicate Id");
            }
        }

        [TestMethod]
        public void AddEmployeeWithNullParameters()
        {
            Employee emp1 = new Employee();
            try
            {
                emp1.EmpId = -5;
                emp1.EmpName = null;
                clientForCreation.AddEmployee(emp1);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name,"ArgumentNullFault");
            }
        }

        [TestMethod]
        public void AddRemarkToNonExistentEmployeeShouldThrowException()
        {
            try
            {
                clientForCreation.AddRemark(50, "asdasd");
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "NoEmployeeForAddingRemark");
            }
        }

        [TestMethod]
        public void RemarkShouldNotBeNullException()
        {
            try
            {
                clientForCreation.AddRemark(1, null);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "RemarkIsNull");
            }
        }
                
    }
}
