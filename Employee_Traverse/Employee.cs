using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Traverse
{

    public class Employee : IComparable<Employee>
    {
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public string Manager { get; set; }

        public Employee(string empName, string manager, int salary)
        {
            this.EmpName = empName;
            this.Salary = salary;
            this.Manager = manager;
        }

        public int CompareTo(Employee other)
        {
            if (other == null) return -1;
            return string.Compare(this.EmpName, other.EmpName,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
