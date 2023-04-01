using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public class Solution
    {
        private List<Employee> employees;

        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var final = new Dictionary<string, int>();

            foreach (var group in employees.GroupBy(e => e.Company)) // GroupBy returns IGrouping
            {
                var avgAge = (int)Math.Round(group.Average(e => e.Age));    // Average returns double
                final.Add(group.Key, avgAge);  // group.Key is the key of the IGrouping
            }

            return final.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);  // OrderBy returns IOrderedEnumerable
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {

            var final = new Dictionary<string, int>();

            foreach (var group in employees.GroupBy(e => e.Company))
            {
                var count = group.Count();
                final.Add(group.Key, count);
            }

            return final.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {

            var final = new Dictionary<string, Employee>();

            foreach (var group in employees.GroupBy(e => e.Company))
            {
                var oldestAge = group.OrderByDescending(e => e.Age).FirstOrDefault();
                final.Add(group.Key, oldestAge);
            }

            return final.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);

        }

        public static void Main()
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}


/* 
12
Ainslee Ginsie Galaxy 28
Libbey Apdell Starbucks 44
Illa Stebbings Berkshire 49
Laina Sycamore Berkshire 20
Abbe Parnell Amazon 20
Ludovika Reveley Berkshire 30
Rene Antos Galaxy 44
Vinson Beckenham Berkshire 45
Reed Lynock Amazon 41
Wyndham Bamfield Berkshire 34
Loraine Sappson Amazon 49
Abbe Antonutti Starbucks 47
*/
