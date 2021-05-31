using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FlyweightApp
{
    class VehicleFlyweightFactory
    {
        private List<IVehicle> _vehicles;
        public List<IVehicle> Vehicles
        {
            get { return _vehicles; }
        }
        public VehicleFlyweightFactory()
        {
            _vehicles = new List<IVehicle>();
        }
        public IVehicle GetFlyweightVehicle(IVehicle vehicle)
        {
            foreach (var item in _vehicles)
            {
                if (item.GetHashCode() == vehicle.GetHashCode())
                {
                    return item;
                }
            }
            _vehicles.Add(vehicle);
            return vehicle;
        }
        public Car GetFlyweightVehicle(string owner, string number, string manuf, string brand, string model, Color color)
        {
            throw new NotImplementedException();
        }
    }
}
