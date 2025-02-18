﻿namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        readonly int _passengersCapacity;
        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _passengersCapacity = passengersCapacity;
        }
        public int PassengersCapacityIs()
        {
            return _passengersCapacity;
        }
        public override string ToString()
        {
            return base.ToString().Replace("\n}", ",\n    passengersCapacity=" + _passengersCapacity + "\n}");
        }
        public override bool Equals(object obj)
        {
            var plane = obj as PassengerPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   _passengersCapacity == plane._passengersCapacity;
        }
        public override int GetHashCode()
        {
            var hashCode = 751774561;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _passengersCapacity.GetHashCode();
            return hashCode;
        }
    }
}