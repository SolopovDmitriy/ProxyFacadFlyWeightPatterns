using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FacadeApp
{
    class VechilceCollection: ObservableCollection<IVehicle>
    {
        public void AddVechicle(IVehicle vehicle)
        {
            this.Add(vehicle);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.Remove(vehicle);
        }
    }
}
