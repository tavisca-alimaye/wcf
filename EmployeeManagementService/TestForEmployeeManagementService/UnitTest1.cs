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
        public void AddEmployeeWithDuplicateIdShouldThrowException()
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
        public void AddEmployeeWithNullParametersShouldThrowException()
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
        public void RemarkShouldNotBeNullExceptionShouldBeThrown()
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

        [TestMethod]
        public void RemarkShoulBeAddedToExistentEmployeeHavingNoRemark()
        {
            Employee emp = new Employee();
            emp.EmpId = 33;
            emp.EmpName = "Abhijeet";
            clientForCreation.AddEmployee(emp);
            clientForCreation.AddRemark(33, "Remarking for first time");
            emp = clientForRetrieval.SearchById(33);
            Assert.AreEqual(emp.remark.RemarkDescription,"Remarking for first time");
        }

        [TestMethod]
        public void RemarkShoulBeAddedToExistentEmployeeHavingRemarkAlready()
        {
            Employee emp = new Employee();
            emp.EmpId = 31;
            emp.EmpName = "Abhijeet";
            clientForCreation.AddEmployee(emp);
            clientForCreation.AddRemark(31, "Remarking for first time");
            clientForCreation.AddRemark(31, "Remarking for second time");
            emp = clientForRetrieval.SearchById(31);
            Assert.AreEqual(emp.remark.RemarkDescription, "Remarking for first timeRemarking for second time");
        }

        [TestMethod]
        public void SearchByIdForExistentEmployeeShouldReturnEmployee()
        {
            Employee emp = clientForRetrieval.SearchById(1);
            Assert.AreEqual(emp.EmpId, 1);
        }

        [TestMethod]
        public void SearchByIdForNonExistentEmployeeShouldGiveException()
        {
            try
            {
                Employee emp = clientForRetrieval.SearchById(-100);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "NoEmployeeWithGivenId");
            }
        }

        [TestMethod]
        public void SearchByNameForExistentUniqueEmployeeShouldReturnEmployee()
        {
            var emp = clientForRetrieval.SearchByName("Arnav");
            Assert.AreEqual(emp[0].EmpName, "Arnav");
        }

        [TestMethod]
        public void SearchByNameForNonExistentEmployeeShouldGiveException()
        {
            try
            {
                var emp = clientForRetrieval.SearchByName("ganpati");
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "NoEmployeeWithGivenName");
            }
        }

        [TestMethod]
        public void SearchByNameForNonUniqueNamesShouldReturnAllEmployeesWithGivenName()
        {
            Employee emp1 = new Employee();
            emp1.EmpId = 1000;
            emp1.EmpName = "Arnav";
            
            clientForCreation.AddEmployee(emp1);

            var empList = clientForRetrieval.SearchByName("Arnav");
            Assert.AreEqual(empList.Length, 3);
        }

        [TestMethod]
        public void GetAllEmployeeListShouldReturnAllEmployees()
        {
            var emp = clientForRetrieval.GetAllEmployees();
            var len = emp.Length;
            Employee emp1 = new Employee();
            emp1.EmpId = 2000;
            emp1.EmpName = "Swapnil";
            clientForCreation.AddEmployee(emp1);
            emp = clientForRetrieval.GetAllEmployees();
            Assert.AreEqual(len + 1, emp.Length);
        }
    }
}
