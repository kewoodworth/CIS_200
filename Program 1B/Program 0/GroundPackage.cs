//  Grading ID:  D8318
//  CIS 200-01
//  Program 1B
//  Due Wednesday, October 3
//  Purpose: This program explores the use of LINQ to produce simple reports.
//  GroundPackage Class  >>  Derived from Package, creates GroundPackage object

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_0
{
    public class GroundPackage : Package
    {
        //  Precondition:  a GroundPackage object is instantiated in Main
        //  Postcondition:  creates GroundPackage object, assigns variables
        public GroundPackage(Address originAddress, Address destinationAddress,
                             double length, double width, double height, double weight)
            : base(originAddress, destinationAddress, length, width, height, weight)
        {
        }

        //  Precondition:  Origin and Destination addresses are provided in constructor, calculates distance between Zip codes
        //  Postcondition:  returns the absolute value of the difference between Zip codes to be used in CalcCost method
        public int ZoneDistance
        {
            get
            {
                return Math.Abs(OriginAddress.Zip / 10000 - DestinationAddress.Zip / 10000);
            }
        }

        //  Precondition:  overrides abstract method in Parcel, calculates cost of shipping GroundPackage object
        //  Postcondition:  returns the calculated cost to ship
        public override decimal CalcCost()
        {
            decimal Cost;
            const double DIMENSION_FACTOR = 0.20;               //  dimension coefficient in cost equation
            const double WEIGHT_FACTOR = 0.05;                  //  dimension coefficient in cost equation
            Cost = (decimal)(DIMENSION_FACTOR * (TotalDimension) + WEIGHT_FACTOR * (ZoneDistance + 1) * Weight);
            return Cost;
        }

        //  Precondition:  overrides method in Package
        //  Postcondition:  returns string representation of GroundPackage object
        public override string ToString() =>
            $"{base.ToString()}";
    }
}
