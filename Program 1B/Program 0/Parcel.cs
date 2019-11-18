//  Grading ID:  D8318
//  CIS 200-01
//  Program 1B
//  Due Wednesday, October 3
//  Purpose: This program explores the use of LINQ to produce simple reports.
//  Parcel Abstract Class  >>  To instantiate Parcel objects with method to calculate cost and return string representation of object

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_0
{
    public abstract class Parcel
    {
        public Address OriginAddress { get; set;  }             //  backing field variable - origin address
        public Address DestinationAddress { get; set;  }        //  backing field variable - destination address
        protected static int Count { get; private set; }        //  backing field variable - counts parcel objects
        public int ParcelNumber { get; }                        //  backing field variable - stores parcel count

        //  Precondition:  a Parcel object is instantiated in Main
        //  Postcondition:  creates abstract Parcel object, assigns variables, counts number of Parcel objects
        protected Parcel(Address originAddress, Address destinationAddress)
        {
            OriginAddress = originAddress;
            DestinationAddress = destinationAddress;
            ++Count;
            ParcelNumber = Count;
        }

        //  Precondition:  drived classes override abstract method and provide cost
        //  Postcondition:  sends cost from derived class to ToString below
        public abstract decimal CalcCost();

        //  Precondition:  derived classes override to make concrete
        //  Postcondition:  returns string representation for Parcel object, including cost from derived class
        public override string ToString() =>
            $"{ParcelNumber}.  {this.GetType().Name}{Environment.NewLine}" +
            $"--------------------------{Environment.NewLine}" +
            $"Origin Address:  {Environment.NewLine}{OriginAddress}{Environment.NewLine}" +
            $"Destination Address:  {Environment.NewLine}{DestinationAddress}{Environment.NewLine}" +
            $"Cost to ship:  {CalcCost():C}";
    }
}
