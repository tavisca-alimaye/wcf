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
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestAddEmployeeWithUniqueId", DataAccessMethod.Sequential)]
        public void AddEmployeeWithNewId()
        {
            Employee emp1 = new Employee();
            Employee emp2 = new Employee();

            emp1.EmpId = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
            emp1.EmpName = testContextInstance.DataRow["EmpName"].ToString();
            //emp1.EmpName = "Arnav";
            _clientForCreation.AddEmployee(emp1);

            emp2 = _clientForRetrieval.SearchById(emp1.EmpId);
            Assert.AreEqual(emp1.EmpName, emp2.EmpName);

        }

        [TestMethod]
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestAddEmployeeWithDuplicateId", DataAccessMethod.Sequential)]
        public void AddEmployeeWithDuplicateIdShouldThrowException()
        {
            Employee emp1 = new Employee();
            try
            {
                emp1.EmpId = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
                emp1.EmpName = testContextInstance.DataRow["EmpName"].ToString();
                _clientForCreation.AddEmployee(emp1);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "Duplicate Id");
            }
        }

        [TestMethod]
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestAddEmployeeWithNullParameter", DataAccessMethod.Sequential)]
        public void AddEmployeeWithNullParameterShouldThrowException()
        {
            Employee emp1 = new Employee();
            try
            {
                emp1.EmpId = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
                emp1.EmpName = null;            //was unable to put null value in datasource...so hardcoded it
                _clientForCreation.AddEmployee(emp1);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "EmployeeNameIsNull");
            }
        }

        [TestMethod]
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestAddRemarkToNonExistentEmployee", DataAccessMethod.Sequential)]
        public void AddRemarkToNonExistentEmployeeShouldThrowException()
        {
            int id = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
            string remark = testContextInstance.DataRow["EmpRemark"].ToString();
            try
            {
                _clientForCreation.AddRemark(id, remark);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "NoEmployeeForAddingRemark");
            }
        }

        [TestMethod]
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestRemarkShouldNotBeNullException", DataAccessMethod.Sequential)]
        public void RemarkShouldNotBeNullExceptionShouldBeThrown()
        {
            int id = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
            string remark = null;
            try
            {
                _clientForCreation.AddRemark(id, remark);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "RemarkIsNull");
            }
        }

        [TestMethod]
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestAddingOnlyOneRemark", DataAccessMethod.Sequential)]
        public void RemarkShoulBeAddedToExistentEmployeeHavingNoRemark()
        {
            Employee emp = new Employee();
            emp.EmpId = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
            emp.EmpName = testContextInstance.DataRow["EmpName"].ToString();
            string remark = testContextInstance.DataRow["EmpRemark"].ToString();
            _clientForCreation.AddEmployee(emp);
            _clientForCreation.AddRemark(emp.EmpId, remark);
            emp = _clientForRetrieval.SearchById(emp.EmpId);
            Assert.AreEqual(emp.Remark.RemarkDescription,"Remarking for first time");
        }

        [TestMethod]
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestAddingMoreThanOneRemark", DataAccessMethod.Sequential)]
        public void RemarkShoulBeAddedToExistentEmployeeHavingRemarkAlready()
        {
            Employee emp = new Employee();
            emp.EmpId = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
            emp.EmpName = testContextInstance.DataRow["EmpName"].ToString();
            string remark1 = testContextInstance.DataRow["EmpRemark1"].ToString();
            string remark2 = testContextInstance.DataRow["EmpRemark2"].ToString();
            _clientForCreation.AddEmployee(emp);
            _clientForCreation.AddRemark(emp.EmpId, remark1);
            _clientForCreation.AddRemark(emp.EmpId, remark2);
            emp = _clientForRetrieval.SearchById(emp.EmpId);
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
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestSearchByNameForNonUniqueNames", DataAccessMethod.Sequential)]
        public void SearchByNameForNonUniqueNamesShouldReturnAllEmployeesWithGivenName()
        {
            var empList = _clientForRetrieval.SearchByName("Arnav");
            var len = empList.Length;
            Employee emp1 = new Employee();
            emp1.EmpId = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
            emp1.EmpName = testContextInstance.DataRow["EmpName"].ToString();
            
            _clientForCreation.AddEmployee(emp1);

            empList = _clientForRetrieval.SearchByName("Arnav");
            Assert.AreEqual(empList.Length, len + 1);
        }

        [TestMethod]
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestGetAllEmployees", DataAccessMethod.Sequential)]
        public void GetAllEmployeeListShouldReturnAllEmployees()
        {
            var emp = _clientForRetrieval.GetAllEmployees();
            var len = emp.Length;
            Employee emp1 = new Employee();
            emp1.EmpId = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
            emp1.EmpName = testContextInstance.DataRow["EmpName"].ToString();
            _clientForCreation.AddEmployee(emp1);
            emp = _clientForRetrieval.GetAllEmployees();
            Assert.AreEqual(len + 1, emp.Length);
        }

        [TestMethod]
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestAddingEmployeeWithNegativeId", DataAccessMethod.Sequential)]
        public void PassingEmployeeWithNegativeIdShouldThrowException()
        {
            try
            {
                Employee emp = new Employee();
                emp.EmpId = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
                emp.EmpName = testContextInstance.DataRow["EmpName"].ToString();
            }
            catch(FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "Id not valid");
            }
        }

        [TestMethod]
        [DeploymentItem(@"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\GIT Repos\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml", "TestAddingEmployeeWithInvalidName", DataAccessMethod.Sequential)]
        public void PassingEmployeeNameWithAlphaNumericNameShouldThrowException()
        {
            try
            {
                Employee emp = new Employee();
                emp.EmpId = Int32.Parse(testContextInstance.DataRow["EmpId"].ToString());
                emp.EmpName = testContextInstance.DataRow["EmpName"].ToString();
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "Name must contain letters only");
            }
        }
    }
}
