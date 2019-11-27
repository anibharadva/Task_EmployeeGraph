using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee_Traverse
{
    public class EmployeeTask
    {
        // Variables class level 
        private  Dictionary<string, Employee> employees;
        private  GraphTask<Employee> graph;
        private  List<Employee> empList;

        //Calculate total budget spent at manager(vertice) level = Sum of vertice + Tuples under
        public long calculateBudget(string empManager)
        {
            var totalBudget = 0;
            var graphUtil = new GraphUtil();
            var path = new List<Employee>();
            graphUtil.DFS<Employee>(graph, employees[empManager], v => path.Add(v));
            foreach (var item in path)
            {
                totalBudget += item.Salary;
            }
            return totalBudget;
        }
        //Get Vertices into IEnumberable from Lists
        public  IEnumerable<Employee> GetVertices()
        {
            List<Employee> emps = empList;
            return emps.ToList();
        }
        //Get Tuples for Vertices from the Dictionary
        public  IEnumerable<Tuple<Employee, Employee>> GetTuples()
        {
            List<Tuple<Employee, Employee>> empTupleList = new List<Tuple<Employee, Employee>>();
            try
            {
                foreach (KeyValuePair<string, Employee> kvp in employees)
                {
                    if (!string.IsNullOrEmpty(kvp.Value.Manager))
                    {
                        empTupleList.Add(new Tuple<Employee, Employee>(employees[kvp.Value.Manager], kvp.Value));
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }

            return empTupleList.ToList();
        }
        //parse the CSV data and generate vertices & Tuple Lists - INIT Graph
        public EmployeeTask(string[] csvLines)
        {

            employees = new Dictionary<string, Employee>();
            empList = new List<Employee>();
            var csvData = csvLines.Select(deli => deli.Split('\t'));
            var csv = from line in csvData select (from dataLn in line select dataLn);
            int top = 0;
            foreach (var n in csv)
            {
                var p = n.GetEnumerator();
                while (p.MoveNext())
                {
                    try
                    {
                        var data = p.Current.ToString().Split(',');
                        if (string.IsNullOrEmpty(data[0]))
                        {
                            Console.WriteLine("ER001 : Employee ID is null or Empty in the Data File !!");
                            continue;
                        }

                        if (string.IsNullOrEmpty(data[1]) && top < 1)
                        {
                            top++;
                        }
                        else if (string.IsNullOrEmpty(data[1]) && top == 1)
                        {
                            Console.WriteLine("ER002 : Multiple CEOs found and Data file incorrect !!");
                            continue;
                        }
                        int empSalary = 0;
                        if (Int32.TryParse(data[2], out empSalary))
                        {

                            var empl = new Employee(data[0], data[1], empSalary);
                            try
                            {
                                empList.Add(empl);
                                if (employees.ContainsKey(empl.EmpName))
                                {
                                    Console.WriteLine("ER004: Multiple Reporting Identified ");
                                        }
                                else { employees.Add(empl.EmpName, empl); }
                                
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("EX001: While Adding data to the Lists ", e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("ER003 : Employee Salary not an Integer !!");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("EX002: While parsing Data ", e);
                    }
                }
                p.Dispose();
            }

            var empsObjs = GetVertices();
            var empTuples = GetTuples();
            graph = new GraphTask<Employee>(empsObjs, empTuples);

        }
    }
}
