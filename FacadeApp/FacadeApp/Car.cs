using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FacadeApp
{
    class Car : IVehicle
    {
        private string _owner;
        private string _number;
        private string _manuf;
        private string _brand;
        private string _model;
        private Color _color;
        public string Owner { get => _owner; set => _owner = value; }
        public string Number { get => _number; set => _number = value; }
        public string Manufacturer { get => _manuf; set => _manuf = value; }
        public string Brand { get => _brand; set => _brand = value; }
        public string Model { get => _model; set => _model = value; }
        public Color Color { get => _color; set => _color = value; }

        public Car()
        {
            Owner = default;
            Number = default;
            Manufacturer = default;
            Brand = default;
            Model = default;
            Owner = default;
        }
        public Car(string owner, string number, string manuf, string brand, string model, Color color)
        {
            Owner = owner;
            Number = number;
            Manufacturer = manuf;
            Brand = brand;
            Model = model;
            Color = color;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Owner, Number, Manufacturer, Brand, Model, Color).GetHashCode();
        }
        public override string ToString()
        {
            return $"Car: {GetHashCode()}";
        }
    }
}
