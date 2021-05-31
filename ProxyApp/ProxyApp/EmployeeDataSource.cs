using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProxyApp
{
    class EmployeeDataSource : IDateSource<Employee>
    {
        List<Employee> _employees;

        public EmployeeDataSource()
        {
            _employees = new List<Employee>()
            {
                new Employee(){Id=1, Fio="Брюса Лии", BirthDate = new DateTime(1875, 5, 25)},
                new Employee(){Id=2, Fio="Чака Норриса", BirthDate = new DateTime(1925, 2, 13)},
                new Employee(){Id=3, Fio="Бабушка Чака Нoрриса", BirthDate = new DateTime(1715, 1, 3)},
                new Employee(){Id=4, Fio="Жан Клод Ван Дамма", BirthDate = new DateTime(1980, 1, 30)},
                new Employee(){Id=5, Fio="Помело Андерсон", BirthDate = new DateTime(1983, 7, 11)},
            };
        }
        public void AddRow(Employee data)
        {
            _employees.Add(data);
            Thread.Sleep(500);
            Console.WriteLine("One Row Added");
        }

        public IEnumerable<Employee> GetAllRows()
        {
            Thread.Sleep(500);
            return _employees;
        }

        public Employee GetRow(int id)
        {
            Thread.Sleep(1500);
            foreach (var item in _employees)
            {
                if(item.Id == id)
                {
                    Console.WriteLine("One Row Found");
                    return item;
                }
            }
            Console.WriteLine("Nothing not Found");
            return null;
        }

        public void RemoveRow(int id)
        {
            Thread.Sleep(1500);
            _employees.RemoveAll(employee => employee.Id == id);
        }

        public void UpdateRow(int id, Employee uData)
        {
            Employee employee = _employees.Find(employee => employee.Id == id);
            if (employee == null)
            {
                return;
            }
            int index = _employees.IndexOf(employee);
            uData.Id = id;
            _employees[index] = uData;
        }


    }
}
