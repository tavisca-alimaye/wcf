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
        const string _dataSourcePath = @"D:\Wcf final assignment\wcf\EmployeeManagementService\EmployeeManagementService\DataSource.xml";
        //int choice;
        private TestContext _testContextInstance;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        [TestMethod]
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestAddEmployeeWithUniqueId", DataAccessMethod.Sequential)]
        public void AddEmployeeWithNewId()
        {
            Employee emp1 = new Employee();
            Employee emp2 = new Employee();

            emp1.EmpId = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
            emp1.EmpName = _testContextInstance.DataRow["EmpName"].ToString();
            //emp1.EmpName = "Arnav";
            _clientForCreation.AddEmployee(emp1);

            emp2 = _clientForRetrieval.SearchById(emp1.EmpId);
            Assert.AreEqual(emp1.EmpName, emp2.EmpName);

        }

        [TestMethod]
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestAddEmployeeWithDuplicateId", DataAccessMethod.Sequential)]
        public void AddEmployeeWithDuplicateIdShouldThrowException()
        {
            Employee emp1 = new Employee();
            try
            {
                emp1.EmpId = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
                emp1.EmpName = _testContextInstance.DataRow["EmpName"].ToString();
                _clientForCreation.AddEmployee(emp1);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "Duplicate Id");
            }
        }

        [TestMethod]
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestAddEmployeeWithNullParameter", DataAccessMethod.Sequential)]
        public void AddEmployeeWithNullParameterShouldThrowException()
        {
            Employee emp1 = new Employee();
            try
            {
                emp1.EmpId = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
                emp1.EmpName = null;            //was unable to put null value in datasource...so hardcoded it
                _clientForCreation.AddEmployee(emp1);
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "EmployeeNameIsNull");
            }
        }

        [TestMethod]
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestAddRemarkToNonExistentEmployee", DataAccessMethod.Sequential)]
        public void AddRemarkToNonExistentEmployeeShouldThrowException()
        {
            int id = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
            string remark = _testContextInstance.DataRow["EmpRemark"].ToString();
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
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestRemarkShouldNotBeNullException", DataAccessMethod.Sequential)]
        public void RemarkShouldNotBeNullExceptionShouldBeThrown()
        {
            int id = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
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
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestAddingOnlyOneRemark", DataAccessMethod.Sequential)]
        public void RemarkShoulBeAddedToExistentEmployeeHavingNoRemark()
        {
            Employee emp = new Employee();
            emp.EmpId = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
            emp.EmpName = _testContextInstance.DataRow["EmpName"].ToString();
            string remark = _testContextInstance.DataRow["EmpRemark"].ToString();
            _clientForCreation.AddEmployee(emp);
            _clientForCreation.AddRemark(emp.EmpId, remark);
            emp = _clientForRetrieval.SearchById(emp.EmpId);
            Assert.AreEqual(emp.Remark.RemarkDescription,"Remarking for first time");
        }

        [TestMethod]
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestAddingMoreThanOneRemark", DataAccessMethod.Sequential)]
        public void RemarkShoulBeAddedToExistentEmployeeHavingRemarkAlready()
        {
            Employee emp = new Employee();
            emp.EmpId = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
            emp.EmpName = _testContextInstance.DataRow["EmpName"].ToString();
            string remark1 = _testContextInstance.DataRow["EmpRemark1"].ToString();
            string remark2 = _testContextInstance.DataRow["EmpRemark2"].ToString();
            _clientForCreation.AddEmployee(emp);
            _clientForCreation.AddRemark(emp.EmpId, remark1);
            _clientForCreation.AddRemark(emp.EmpId, remark2);
            emp = _clientForRetrieval.SearchById(emp.EmpId);
            Assert.AreEqual(emp.Remark.RemarkDescription, "Remarking for first timeRemarking for second time");
        }

        [TestMethod]
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestSearchingForExistentEmployee", DataAccessMethod.Sequential)]
        public void SearchByIdForExistentEmployeeShouldReturnEmployee()
        {
            Employee emp1 = new Employee();
            emp1.EmpId = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
            emp1.EmpName = _testContextInstance.DataRow["EmpName"].ToString();
            _clientForCreation.AddEmployee(emp1);
            Employee emp2 = _clientForRetrieval.SearchById(emp1.EmpId);
            Assert.AreEqual(emp2.EmpId, emp1.EmpId);
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
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestSearchByNameForNonUniqueNames", DataAccessMethod.Sequential)]
        public void SearchByNameForNonUniqueNamesShouldReturnAllEmployeesWithGivenName()
        {
            var empList = _clientForRetrieval.SearchByName("Arnav");
            var len = empList.Length;
            Employee emp1 = new Employee();
            emp1.EmpId = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
            emp1.EmpName = _testContextInstance.DataRow["EmpName"].ToString();
            
            _clientForCreation.AddEmployee(emp1);

            empList = _clientForRetrieval.SearchByName("Arnav");
            Assert.AreEqual(empList.Length, len + 1);
        }

        [TestMethod]
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestGetAllEmployees", DataAccessMethod.Sequential)]
        public void GetAllEmployeeListShouldReturnAllEmployees()
        {
            var emp = _clientForRetrieval.GetAllEmployees();
            var len = emp.Length;
            Employee emp1 = new Employee();
            emp1.EmpId = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
            emp1.EmpName = _testContextInstance.DataRow["EmpName"].ToString();
            _clientForCreation.AddEmployee(emp1);
            emp = _clientForRetrieval.GetAllEmployees();
            Assert.AreEqual(len + 1, emp.Length);
        }

        [TestMethod]
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestAddingEmployeeWithNegativeId", DataAccessMethod.Sequential)]
        public void PassingEmployeeWithNegativeIdShouldThrowException()
        {
            try
            {
                Employee emp = new Employee();
                emp.EmpId = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
                emp.EmpName = _testContextInstance.DataRow["EmpName"].ToString();
            }
            catch(FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "Id not valid");
            }
        }

        [TestMethod]
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "TestAddingEmployeeWithInvalidName", DataAccessMethod.Sequential)]
        public void PassingEmployeeNameWithAlphaNumericNameShouldThrowException()
        {
            try
            {
                Employee emp = new Employee();
                emp.EmpId = Int32.Parse(_testContextInstance.DataRow["EmpId"].ToString());
                emp.EmpName = _testContextInstance.DataRow["EmpName"].ToString();
            }
            catch (FaultException f)
            {
                Assert.AreEqual(f.Code.Name, "Name must contain letters only");
            }
        }
    }
}
