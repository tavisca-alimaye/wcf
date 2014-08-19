using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestForEmployeeManagementService.ServiceReferenceForTesting;
using System.ServiceModel;

namespace TestForEmployeeManagementService
{
    [TestClass]
    public class UnitTestsForEmployeeManagementService
    {
        CreateEmployeeClient _clientForCreation = new CreateEmployeeClient();
        GetDetailsClient _clientForRetrieval = new GetDetailsClient();
        //int choice;
        
        [TestMethod]
        public void AddEmployeeWithNewId()
        {
            Employee emp1 = new Employee();
            Employee emp2 = new Employee();
            emp1.EmpId = 20;
            emp1.EmpName = "Arnav";
            _clientForCreation.AddEmployee(emp1);

            emp2 = _clientForRetrieval.SearchById(emp1.EmpId);
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
                _clientForCreation.AddEmployee(emp1);
                emp2.EmpId = 1;
                emp2.EmpName = "Dhruv";
                _clientForCreation.AddEmployee(emp2);
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
                emp1.EmpId = 15;
                emp1.EmpName = null;
                _clientForCreation.AddEmployee(emp1);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "EmployeeNameIsNull");
            }
        }

        [TestMethod]
        public void AddRemarkToNonExistentEmployeeShouldThrowException()
        {
            try
            {
                _clientForCreation.AddRemark(50, "asdasd");
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
                _clientForCreation.AddRemark(1, null);
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
            emp.EmpId = 41;
            emp.EmpName = "Abhijeet";
            _clientForCreation.AddEmployee(emp);
            _clientForCreation.AddRemark(41, "Remarking for first time");
            emp = _clientForRetrieval.SearchById(41);
            Assert.AreEqual(emp.Remark.RemarkDescription,"Remarking for first time");
        }

        [TestMethod]
        public void RemarkShoulBeAddedToExistentEmployeeHavingRemarkAlready()
        {
            Employee emp = new Employee();
            emp.EmpId = 43;
            emp.EmpName = "Abhijeet";
            _clientForCreation.AddEmployee(emp);
            _clientForCreation.AddRemark(43, "Remarking for first time");
            _clientForCreation.AddRemark(43, "Remarking for second time");
            emp = _clientForRetrieval.SearchById(43);
            Assert.AreEqual(emp.Remark.RemarkDescription, "Remarking for first timeRemarking for second time");
        }

        [TestMethod]
        public void SearchByIdForExistentEmployeeShouldReturnEmployee()
        {
            Employee emp = _clientForRetrieval.SearchById(1);
            Assert.AreEqual(emp.EmpId, 1);
        }

        [TestMethod]
        public void SearchByIdForNonExistentEmployeeShouldGiveException()
        {
            try
            {
                Employee emp = _clientForRetrieval.SearchById(-100);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "NoEmployeeWithGivenId");
            }
        }

        [TestMethod]
        public void SearchByNameForExistentUniqueEmployeeShouldReturnEmployee()
        {
            var emp = _clientForRetrieval.SearchByName("Arnav");
            Assert.AreEqual(emp[0].EmpName, "Arnav");
        }

        [TestMethod]
        public void SearchByNameForNonExistentEmployeeShouldGiveException()
        {
            try
            {
                var emp = _clientForRetrieval.SearchByName("ganpati");
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "NoEmployeeWithGivenName");
            }
        }

        [TestMethod]
        public void SearchByNameForNonUniqueNamesShouldReturnAllEmployeesWithGivenName()
        {
            var empList = _clientForRetrieval.SearchByName("Arnav");
            var len = empList.Length;
            Employee emp1 = new Employee();
            emp1.EmpId = 1001;
            emp1.EmpName = "Arnav";
            
            _clientForCreation.AddEmployee(emp1);

            empList = _clientForRetrieval.SearchByName("Arnav");
            Assert.AreEqual(empList.Length, len + 1);
        }

        [TestMethod]
        public void GetAllEmployeeListShouldReturnAllEmployees()
        {
            var emp = _clientForRetrieval.GetAllEmployees();
            var len = emp.Length;
            Employee emp1 = new Employee();
            emp1.EmpId = 2000;
            emp1.EmpName = "Swapnil";
            _clientForCreation.AddEmployee(emp1);
            emp = _clientForRetrieval.GetAllEmployees();
            Assert.AreEqual(len + 1, emp.Length);
        }

        [TestMethod]
        public void AddingEmployeeWithNegativeIdShouldThrowException()
        {
            try
            {
                Employee emp = new Employee();
                emp.EmpId = -7;
                emp.EmpName = "Akshay";
            }
            catch(FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "Id not valid");
            }
        }

        [TestMethod]
        public void AddingEmployeeNameWithAlphaNumericNameShouldThrowException()
        {
            try
            {
                Employee emp = new Employee();
                emp.EmpId = 117;
                emp.EmpName = "Arnav21%^";
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "Name must contain letters only");
            }
        }
    }
}
