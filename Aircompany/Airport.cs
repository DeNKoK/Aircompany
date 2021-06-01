using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        readonly List<Plane> Planes;
        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }
        public List<PassengerPlane> GetPassengersPlanes()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();
            for (var i = 0; i < Planes.Count; i++)
            {
                if (Planes[i].GetType() == typeof(PassengerPlane))
                {
                    passengerPlanes.Add((PassengerPlane)Planes[i]);
                }
            }
            return passengerPlanes;
        }
        public PassengerPlane GetMaxPassengerCapacity()
        {
            PassengerPlane max = (PassengerPlane)Planes[0];
            for (var i = 0; i < Planes.Count; i++)
            {
                PassengerPlane plane = (PassengerPlane)Planes[i];
                if (plane.PassengersCapacityIs() > max.PassengersCapacityIs())
                {
                    max = plane;
                }
            }
            return max;
        }
        public List<PassengerPlane> GetPassengerPlanesWithMaxPassengersCapacity()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();
            PassengerPlane max = GetMaxPassengerCapacity();
            for (var i = 0; i < Planes.Count; i++)
            {
                PassengerPlane plane = (PassengerPlane)Planes[i];
                if (plane.PassengersCapacityIs() == max.PassengersCapacityIs())
                {
                    passengerPlanes.Add((PassengerPlane)Planes[i]);
                }
            }
            return passengerPlanes;
        }
        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();
            for (var i = 0; i < Planes.Count; i++)
            {
                if (Planes[i].GetType() == typeof(MilitaryPlane))
                {
                    militaryPlanes.Add((MilitaryPlane)Planes[i]);
                }
            }
            return militaryPlanes;
        }
        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> transportMilitaryPlanes = new List<MilitaryPlane>();
            for (var i = 0; i < Planes.Count; i++)
            {
                MilitaryPlane plane = (MilitaryPlane)Planes[i];
                if (plane.PlaneTypeIs() == MilitaryType.TRANSPORT)
                {
                    transportMilitaryPlanes.Add((MilitaryPlane)Planes[i]);
                }
            }
            return transportMilitaryPlanes;
        }
        public IEnumerable<Plane> GetPlanes()
        {
            return Planes;
        }
        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxFlightDistance()));
        }
        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxSpeed()));
        }
        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }
        public override string ToString()
        {
            return "Airport\n{\n    " + string.Join(",\n    ", Planes.Select(x => x.GetModel())) + "\n}";
        }
    }
}