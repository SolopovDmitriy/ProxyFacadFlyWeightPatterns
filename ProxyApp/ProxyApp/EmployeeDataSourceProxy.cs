using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyApp
{
    class EmployeeDataSourceProxy : IDateSource<Employee>
    {
        private static readonly Lazy<EmployeeDataSourceProxy> _instance = 
            new Lazy<EmployeeDataSourceProxy>(() => new EmployeeDataSourceProxy());

        private EmployeeDataSourceProxy()
        {

        }

        private readonly IDateSource<Employee> _dateSource = new EmployeeDataSource(); //доступ к конечному обьекту

        private static List<Employee> _cashe = new List<Employee>(); //кеш обьектов - ранее полученные данные
        
        public static EmployeeDataSourceProxy Instance
        {
            get
            {
                return EmployeeDataSourceProxy._instance.Value;
            }
        }

        public void AddRow(Employee data)
        {
            _dateSource.AddRow(data);
            _cashe.Add(data);
        }

        public Employee GetRow(int id)
        {
            //  rewrite to LINQ   
            // Employee employee = _cashe.Find(x => x.Id == id);
            foreach (var item in _cashe)
            {
                if (item.Id == id)
                {
                    Console.WriteLine("Получил данные из кеша");
                    return item;
                }
            }
            Employee emp = _dateSource.GetRow(id);
            if (emp != null)
            {
                _cashe.Add(emp);
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllRows()
        {
            // ignore cash
            return _dateSource.GetAllRows();
        }

        public void RemoveRow(int id)
        {
            //// version1
            //Employee employeeFound = null;
            //foreach (var employee in _cashe)
            //{
            //    if (employee.Id == id)
            //    {
            //        employeeFound = employee;
            //    }
            //}

            //Console.WriteLine("Удаляем данные из кеша");
            //if (employeeFound != null)
            //{
            //    _cashe.Remove(employeeFound);
            //}
            //_dateSource.RemoveRow(id);


            // version2            
            //foreach (var employee in _cashe)
            //{
            //    if (employee.Id == id)
            //    {
            //        _cashe.Remove(employee); // "Удаляем данные из кеша"
            //        break;
            //    }
            //}   
            //_dateSource.RemoveRow(id);


            // version3    
            //_cashe.RemoveAll( x => x.Id == id);  // Удаляем данные из кеша            
            //_dateSource.RemoveRow(id);
        }






        public void UpdateRow(int id, Employee uData)
        {
            Employee employee = _cashe.Find(employee => employee.Id == id);
            if(employee == null)
            {
                return;
            }
            int index = _cashe.IndexOf(employee);
            uData.Id = id;
            _cashe[index] = uData;

            // update in database
            _dateSource.UpdateRow(id, uData);
        }
    }
}
