using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Employee_Traverse;
using System.IO;

namespace Employee_Tests
{
    [TestClass]
    public class UnitTest1
    {
        //  Positive scenario
        [TestMethod]
        public void sampleTest()
        {
            var lines = File.ReadAllLines("../../sampleData1.txt");
            EmployeeTask employees = new EmployeeTask(lines);
            Assert.AreEqual(4743, employees.calculateBudget("Employee1"));
            Assert.AreEqual(1000, employees.calculateBudget("Employee2"));
            Assert.AreEqual(2243, employees.calculateBudget("Employee3"));
        }

        // Scenario 1 : Unexpected Data Type (Salary)
        [TestMethod]
        public void sampleTest1()
        {
            var lines = File.ReadAllLines("../../sampleData2.txt");
            EmployeeTask employees = new EmployeeTask(lines);
            Assert.ThrowsException<Exception>(() => employees.calculateBudget("Employee3"));
        }

        // Scenario 2 : Multiple CEOs found
        [TestMethod]
        public void sampleTest2()
        {
            var lines = File.ReadAllLines("../../sampleData3.txt");
            EmployeeTask employees = new EmployeeTask(lines);
            Assert.ThrowsException<Exception>(() => employees.calculateBudget("Employee3"));
        }

        //Multiple Scenarios: Multi-Reporting found
        [TestMethod]
        public void sampleTest3()
        {
            var lines = File.ReadAllLines("../../sampleData4.txt");
            EmployeeTask employees = new EmployeeTask(lines);
            Assert.ThrowsException<Exception>(() => employees.calculateBudget("Employee4"));
        }
    }
}
