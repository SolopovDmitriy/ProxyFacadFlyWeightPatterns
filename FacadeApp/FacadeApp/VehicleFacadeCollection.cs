using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FacadeApp
{
    class VehicleFacadeCollection<IVehicle>
    {
        private ObservableCollection<IVehicle> _vehicles;

        public VehicleFacadeCollection()
        {
            _vehicles = new ObservableCollection<IVehicle>();
        }
        public void AddVechicle(IVehicle vehicle)
        {
            this._vehicles.Add(vehicle);
        }
        public void RemoveVehicle(IVehicle vehicle)
        {
            this._vehicles.Remove(vehicle);
        }
        public int Count
        {
            get { return _vehicles.Count; }
        }
    }
}
