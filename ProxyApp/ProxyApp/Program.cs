using System;
using System.Collections.Generic;

namespace ProxyApp
{
    class Program
    {


        static void TestLazy()
        {
            //Lazy<Employee> employee1 = new Lazy<Employee>();
            //Console.WriteLine(employee1.Value.Fio);
            // Employee employee2 = new Employee();

            //Employee employee3 = new Employee(2, "Peter", DateTime.Now);


            Lazy<Employee> employee4 = new Lazy<Employee>(() => new Employee(2, "Alex", DateTime.Now));
            Console.WriteLine(employee4.Value.Fio);
        }

        static void TestForeach()
        {
            List<int> numbers = new List<int>();
            numbers.Add(5);
            numbers.Add(1);
            numbers.Add(6);
            numbers.Add(9);
            numbers.Add(2);

            foreach (int item in numbers)
            {
                if (item == 6)
                {
                    numbers.Add(116);
                    break;
                    //return;
                }
                
            }
            Console.WriteLine(numbers);
        }


        static void WorkWithDatabase(IDateSource<Employee> dateSource)
        {
            int id = 2;
            Console.WriteLine("try get employee with id = 2 before remove");
            Console.WriteLine(dateSource.GetRow(id));
            dateSource.RemoveRow(id);
            Console.WriteLine("try get employee with id = 2 after remove");
            Console.WriteLine(dateSource.GetRow(id));
            Console.WriteLine();

            Console.WriteLine("try to add employee with id = 10");
            dateSource.AddRow(new Employee { Id = 10, Fio = "Tom", BirthDate = new DateTime(2000, 5, 25) });
            Console.WriteLine("check employee with id = 10 was inserted");
            Console.WriteLine(dateSource.GetRow(10));
            Console.WriteLine();

            Console.WriteLine("try to update employee with id = 10");
            dateSource.UpdateRow(10, new Employee {Fio = "John", BirthDate = new DateTime(2001, 11, 5) });
            Console.WriteLine("check employee with id = 10 was updated");
            Console.WriteLine(dateSource.GetRow(10));

        }


        static void Main(string[] args)
        {
            /*
             * Proxy - Создаем новый обьект, который используется как посредник для доступа к иному обьекту.
             * Поскольку есть перехват вызова - то возможно что-то выполнить до или после запроса к основному обьекту
             */

            IDateSource<Employee> employeeDataSource = new EmployeeDataSource();

            /*Console.WriteLine(employeeDataSource.GetRow(5));
            Console.WriteLine(employeeDataSource.GetRow(5));
            Console.WriteLine(employeeDataSource.GetRow(5));
            Console.WriteLine(employeeDataSource.GetRow(5));*/

            IDateSource<Employee> employeeDataSourceProxy = EmployeeDataSourceProxy.Instance;

            WorkWithDatabase(employeeDataSourceProxy);
            //WorkWithDatabase(employeeDataSource);
            //TestForeach();
            // TestLazy();


        }
    }
}
