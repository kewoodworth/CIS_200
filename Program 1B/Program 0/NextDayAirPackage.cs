//  Grading ID:  D8318
//  CIS 200-01
//  Program 1B
//  Due Wednesday, October 3
//  Purpose: This program explores the use of LINQ to produce simple reports.
//  NextDayAirPackage Class  >>  Derived from AirPackage, creates NextDayAirPackage

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_0
{
    public class NextDayAirPackage : AirPackage
    {
        private decimal _expressFee;     //  backing field variable - Express Fee

        //  Precondition:  a NextDayAirPackage object is instantiated in Main
        //  Postcondition:  creates NextDayAirPackage object, assigns variables
        public NextDayAirPackage(Address originAddress, Address destinationAddress,
                                 double length, double width, double height, double weight, decimal fee)
            : base(originAddress, destinationAddress, length, width, height, weight)
        {
            ExpressFee = fee;
        }

        public decimal ExpressFee 
        {
            get { return _expressFee; } 
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(ExpressFee)} must be valid US currency");
                }
                else
                    _expressFee = value;
            }
        }

        //  Precondition:  overrides abstract method in Package, calculates cost of shipping NextDayAirPackage object
        //  Postcondition:  returns the calculated cost to ship
        public override decimal CalcCost()
        {
            decimal Cost;
            const double DIMENSION_FACTOR = 0.40;   //  dimension coefficient in cost equation
            const double WEIGHT_FACTOR = 0.30;      //  weight coefficient in cost equation
            const double HEAVY_FACTOR = 0.25;       //  heavy coefficient in cost equation
            const double LARGE_FACTOR = 0.25;       //  large coefficient in cost equation
            Cost = (decimal)(DIMENSION_FACTOR * TotalDimension + WEIGHT_FACTOR * Weight) + ExpressFee;

            if (IsHeavy())
                Cost += (decimal)(HEAVY_FACTOR * Weight);

            if (IsLarge())
                Cost += (decimal)(LARGE_FACTOR * TotalDimension);

            return Cost;
        }

        //  Precondition:  overrides method in AirPackage
        //  Postcondition:  returns string representation of NextDayAirPackage object
        public override string ToString() =>
            $"{base.ToString()}";
    }
}
