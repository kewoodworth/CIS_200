//  Grading ID:  D8318
//  CIS 200-01
//  Program 1B
//  Due Wednesday, October 3
//  Purpose: This program explores the use of LINQ to produce simple reports.
//  TwoDayAirPackage Class  >>  Derived from AirPackage, creates TwoDayAirPackage object

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_0
{
    public class TwoDayAirPackage : AirPackage
    {
        private Delivery _deliveryType;                 //  backing field variable - delivery type

        public enum Delivery : int { Early, Saver }     //  defines enum values for Delivery type

        //  Precondition:  a TwoDayAirPackage object is instantiated in Main
        //  Postcondition:  creates TwoDayAirPackage object, assigns variables
        public TwoDayAirPackage(Address originAddress, Address destinationAddress,
                                double length, double width, double height, double weight, int delivery)
            : base(originAddress, destinationAddress, length, width, height, weight)
        {
            //  validates the delivery type
            if (delivery > 1)
                throw new ArgumentOutOfRangeException(nameof(delivery), delivery, $"Delivery window must be AM or PM");
            else
            DeliveryType = (Delivery)delivery;      //  explicitly converts from int to Delivery type variable
        }

        //  Precondition:  constructor provides delivery type once validated in constructor
        //  Postcondition:  assigns delivery type from Delivery enum types
        public Delivery DeliveryType
        {
            get { return _deliveryType; }
            set { _deliveryType = value; }
        }

        //  Precondition:  overrides abstract method in Package, calculates cost of shipping TwoDayAirPackage object
        //  Postcondition:  returns the calculated cost to ship
        public override decimal CalcCost()
        {
            decimal Cost;
            const double DIMENSION_FACTOR = 0.25;   //  dimension coefficient in cost equation
            const double WEIGHT_FACTOR = 0.25;      //  weight coefficient in cost equation
            const decimal DISCOUNT_FACTOR = 0.10M;  //  discount factor in cost equation

            Cost = (decimal)(DIMENSION_FACTOR * TotalDimension + WEIGHT_FACTOR * Weight);
            if (DeliveryType == Delivery.Saver)
                Cost *= (1 - DISCOUNT_FACTOR);
            return Cost;
        }

        //  Precondition:  overrides method in AirPackage
        //  Postcondition:  returns string representation of TwoDayAirPackage object
        public override string ToString() =>
            $"{base.ToString()}{Environment.NewLine}" +
            $"Delivery Type: {DeliveryType}";
    }
}
