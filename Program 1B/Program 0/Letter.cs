//  Grading ID:  D8318
//  CIS 200-01
//  Program 1B
//  Due Wednesday, October 3
//  Purpose: This program explores the use of LINQ to produce simple reports.
//  Letter Class  >>  Derived from Parcel, calculates cost to ship Letter object

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_0
{
    public class Letter : Parcel
    {
        private decimal _stamp;     //  backing field variable - stamp price

        //  Precondition:  a Letter object is instantiated in Main
        //  Postcondition:  creates Letter object, assigns variables
        public Letter(Address originAddress, Address destinationAddress, decimal stamp)
            : base(originAddress, destinationAddress)
        {
            Stamp = stamp;
        }

        public decimal Stamp
        {
            get { return _stamp; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Stamp)} must be valid US currency");
                }
                else
                    _stamp = value;
            }
        }

        //  Precondition:  overrides abstract method in Parcel, takes stamp price from instantiated Letter object
        //  Postcondition:  returns the calculated cost to ship - cost of the stamp
        public override decimal CalcCost()
        {
            return Stamp;
        }

        //  Precondition:  overrides method in Parcel
        //  Postcondition:  returns string representation of Letter object
        public override string ToString() =>
            $"{base.ToString()}";
    }
}
