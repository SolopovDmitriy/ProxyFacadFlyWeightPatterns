using System;
using System.Drawing;

namespace FacadeApp
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             Фасад - создай простой интерфейс для работы с сложной системой, библиотекой, фреймворком.
             */

            VechilceCollection vehicles = new VechilceCollection();
            //vehicles.AddVechicle(); //моя обертка - тоже самое
            //vehicles.Add(); //метод роодительского обьекта- тоже самое

            Car car = new Car() { Brand = "Volwo", Color = Color.Red, Model = "CX70", Manufacturer = "VolWo Co", Owner = "Я" };


            VehicleFacadeCollection<IVehicle> vehicleFacadeCollection = new VehicleFacadeCollection<IVehicle>();
            vehicleFacadeCollection.AddVechicle(car);
            Console.WriteLine(vehicleFacadeCollection.Count);
            
            vehicleFacadeCollection.RemoveVehicle(car);
            Console.WriteLine(vehicleFacadeCollection.Count);
        }
    }
}
