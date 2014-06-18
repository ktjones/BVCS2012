using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch._09___Ex._04_Lib
{
    public abstract class Vehicles
    {
    
    }

    public abstract class Train : Vehicles
    {
    
    }

    public class PassengerTrain : Train, IPassengerCarrier
    {

    }

    public class FreightTrain : Train, IHeavyLoadCarrier
    {

    }

    public class T424DoubleBogey : Train
    {

    }

    
    public abstract class Car : Vehicles
    {

    }

    public class Compact : Car, IPassengerCarrier
    {
    
    }

    public class SUV : Car, IPassengerCarrier
    {
    
    }

    public class Pickup : Car, IHeavyLoadCarrier, IPassengerCarrier
    {
    
    }

    public interface IPassengerCarrier
    {

    }

    public interface IHeavyLoadCarrier
    {

    }
    
}
