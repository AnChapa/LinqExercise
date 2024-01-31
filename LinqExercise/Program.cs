using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */
            Console.WriteLine("Array of numbers:");
            foreach (int i in numbers)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n-------------------------------");
            //TODO: Print the Sum of numbers
            Console.WriteLine($"The sum of the numbers:\n{numbers.Sum()}");
            Console.WriteLine("-------------------------------");

            //TODO: Print the Average of numbers
            Console.WriteLine($"The average of the numbers:\n{numbers.Average()}");
            Console.WriteLine("-------------------------------");

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Ordered in ascending order:");
            var orderedNumA = from num in numbers orderby num select num;
            foreach (int i in orderedNumA)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n-------------------------------");

            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("Ordered in descending order:");
            var orderedNumD = from num in numbers orderby num descending select num;
            foreach (int i in orderedNumD)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n-------------------------------");

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Numbers greater than 6:");
            var greatSix = from num in numbers where num > 6 select num;
            foreach (int i in greatSix)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n-------------------------------");

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("First 4 in ascending:");
            var fourNum = orderedNumA.Take(4);
            foreach (int i in fourNum)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n-------------------------------");

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Descending with age added:");
            numbers.SetValue(27, 4);
            orderedNumD = from num in numbers orderby num descending select num;
            fourNum = orderedNumD.Take(4); 
            foreach (int i in fourNum)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n-------------------------------");

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Employees with C or S:");
            List<Employee> filteredEmployees = employees.Where(employee => employee.FirstName.StartsWith("S") || employee.FirstName.StartsWith("C")).ToList();
            var orderedEmployees = filteredEmployees.OrderBy(employee => employee.FirstName).ToList();
            orderedEmployees.ForEach(employee => Console.WriteLine(employee.FullName));
            Console.WriteLine("-------------------------------");

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over 26:");
            filteredEmployees = employees.Where(employee => employee.Age > 26).ToList();
            orderedEmployees = filteredEmployees.OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName).ToList();
            orderedEmployees.ForEach(employee => Console.WriteLine(employee.FullName));
            Console.WriteLine("-------------------------------");

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("Sum of employees years of experience when they have worked less than or equal to 10 and are over 35:");
            filteredEmployees = employees.Where(employee => employee.Age > 35 && employee.YearsOfExperience <= 10).ToList();
            int sumExper = 0;
            filteredEmployees.ForEach(employee => sumExper += employee.YearsOfExperience);
            Console.WriteLine(sumExper);
            Console.WriteLine("-------------------------------");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("Average of employees years of experience when they have worked less than or equal to 10 and are over 35:");
            List<int> expList = new List<int>();
            filteredEmployees.ForEach(employee => expList.Add(employee.YearsOfExperience));
            Console.WriteLine(expList.Average());
            Console.WriteLine("-------------------------------");

            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Added new employee:");
            Employee ezio = new Employee("Ezio", "Auditore", 53, 33);
            employees.Insert(employees.Count, ezio);
            employees.ForEach(employee => Console.WriteLine(employee.FullName));
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
