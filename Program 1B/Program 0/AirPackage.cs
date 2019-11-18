//  Grading ID:  D8318
//  CIS 200-01
//  Program 1B
//  Due Wednesday, October 3
//  Purpose: This program explores the use of LINQ to produce simple reports.
//  AirPackage Class  >>  Derived from Package, creates AirPackage object

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_0
{
    public abstract class AirPackage : Package
    {
        private const double HEAVY = 75;      //  constant variable to indicate a heavy package
        private const double LARGE = 100;     //  constant variable to indicate a large package

        //  Precondition:  a AirPackage object is instantiated in Main
        //  Postcondition:  creates abstract AirPackage object, assigns variables
        public AirPackage(Address originAddress, Address destinationAddress,
                          double length, double width, double height, double weight)
            : base(originAddress, destinationAddress, length, width, height, weight)
        {
        }

        //  Precondition:  weight parameter is provided in constructor
        //  Postcondition:  determines if Parcel weight is considered Heavy
        public bool IsHeavy ()
        {
            return (Weight >= HEAVY);
        }

        //  Precondition:  length, width, height parameters are provided in constructor
        //  Postcondition:  determines if Parcel size is considered Large
        public bool IsLarge ()
        {
            return (TotalDimension >= LARGE) ;
        }

        //  Precondition:  overrides method in Package
        //  Postcondition:  returns string representation of AirPackage object
        public override string ToString() =>
            $"{base.ToString()}{Environment.NewLine}" +
            $"Heavy:  {IsHeavy()}{Environment.NewLine}" +
            $"Large:  {IsLarge()}";
    }
}
