using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FacadeApp
{
    interface IVehicle
    {
        string Owner { get; set; }

        string Number { get; set; }

        string Manufacturer { get; set; }

        string Brand { get; set; }

        string Model { get; set; }

        Color Color { get; set; }
    }
}
