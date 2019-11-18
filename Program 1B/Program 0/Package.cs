//  Grading ID:  D8318
//  CIS 200-01
//  Program 1B
//  Due Wednesday, October 3
//  Purpose: This program explores the use of LINQ to produce simple reports.
//  Package Class  >>  Derived from Parcel, creates abstract Package object

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_0
{
    public abstract class Package : Parcel
    {
        private double _length;     //  backing field variable - package length
        private double _width;      //  backing field variable - package width
        private double _height;     //  backing field variable - package height
        private double _weight;     //  backing field variable - package weight

        //  Precondition:  a Package object is instantiated in Main
        //  Postcondition:  creates absract Package object, assigns variables
        protected Package(Address originAddress, Address destinationAddress, 
                          double length, double width, double height, double weight)
            : base(originAddress, destinationAddress)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }

        //  Precondition:  Length must be provided in constructor as a non-negative integer
        //  Postcondition:  gets and sets Length value after validating
        public double Length
        {
            get { return _length; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Length)} must be a positive integer");
                }
                else
                _length = value;
            }
        }

        //  Precondition:  Width must be provided in constructor as a non-negative integer
        //  Postcondition:  gets and sets Width value after validating
        public double Width
        {
            get { return _width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Width)} must be a positive integer");
                }
                else
                _width = value;
            }
        }

        //  Precondition:  Height must be provided in constructor as a non-negative integer
        //  Postcondition:  gets and sets Height value after validating
        public double Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Height)} must be a positive integer");
                }
                _height = value;
            }
        }

        //  Precondition:  Weight must be provided in constructor as a non-negative integer
        //  Postcondition:  gets and sets Weight value after validating
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Weight)} must be a positive integer");
                }
                _weight = value;
            }
        }

        //  Helper property for total number of inches in package dimensions
        protected double TotalDimension
        {
            get
            {
                return (Length + Width + Height);
            }
        }

        //  Precondition:  overrides method in Parcel
        //  Postcondition:  returns string representation of Letter object
        public override string ToString() =>
            $"{base.ToString()}{Environment.NewLine}" +
            $"Package dimensions: {Length} in. x {Width} in. x {Height} in.{Environment.NewLine}" +
            $"Package weight: {Weight} lbs.";
    }
}
