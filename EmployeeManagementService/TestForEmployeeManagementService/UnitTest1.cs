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
                //Assert.IsTrue(Assert.AreEqual(f.Code.Name, "Duplicate Id") && Assert.AreEqual(f.Reason, "Given Id already exists!!!"));
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
                
    }
}
