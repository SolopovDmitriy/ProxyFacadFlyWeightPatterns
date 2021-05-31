using System;
using System.Collections.Generic;
using System.Drawing;

namespace FlyweightApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string str_1 = "hello";
            string str_2 = "hello";
            string str_3 = "hello";

            if (ReferenceEquals(str_1, str_2) && ReferenceEquals(str_2, str_3))
            {
                Console.WriteLine("Совпадают");
            }
            else
            {
                Console.WriteLine("Не совпадают");
            }

            /*
             * 1. Неизменность внутреннего состояния 
             * 2. Фабрика
             */

            Car[] cars = new Car[]
            {
                new Car() {Brand="BMW", Model="X9",   Color=Color.Pink, Manufacturer="BMW Ko", Number="ВС 1545 ПО", Owner = "Санек"},
                new Car() {Brand="BMW", Model="X6.5", Color=Color.Blue, Manufacturer="BMW Ko", Number="ВС 4561 ПО", Owner = "Санек"},
                new Car() {Brand="BMW", Model="X3",   Color = Color.Red},
                new Car() {Brand="BMW", Model="X3",   Color = Color.Red}
            };

            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }

            VehicleFlyweightFactory vehicleFlyweightFactory = new VehicleFlyweightFactory();
            
            List<IVehicle> carsFlyweight = new List<IVehicle>();
            foreach (var item in cars)
            {
                carsFlyweight.Add(vehicleFlyweightFactory.GetFlyweightVehicle(item));
            }

            Console.WriteLine($"Всего обьектов в колеекции авто: {carsFlyweight.Count}");
            Console.WriteLine($"Всего созданных уникальных авто: {vehicleFlyweightFactory.Vehicles.Count}");
        }
    }
}
