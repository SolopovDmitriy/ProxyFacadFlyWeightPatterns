using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyApp
{
    class Employee
    {
        public int Id { get; set; }

        public string Fio { get; set; }

        public DateTime BirthDate { get; set; }

        public Employee()
        {
            //Console.WriteLine("constructor without parameters is done");
        }


        public Employee(int id, string fio, DateTime birthDate)
        {
            Id = id;
            Fio = fio;
            BirthDate = birthDate;
            //Console.WriteLine("constructor done");
        }

        public override string ToString()
        {
            return $"Id: {Id}, Fio: {Fio}; Birth Date: {BirthDate};";
        }
    }
}
