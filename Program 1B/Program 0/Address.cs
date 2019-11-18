//  Grading ID:  D8318
//  CIS 200-01
//  Program 1B
//  Due Wednesday, October 3
//  Purpose: This program explores the use of LINQ to produce simple reports.
//  Address Class  >>  Takes Address object information, assigns values to variables, returns object as string

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_0
{
    public class Address
    {
        private string _name;               //  backing field variable - name on parcel
        private string _address1;           //  backing field variable - address line 1
        private string _address2;           //  backing field variable - address line 2
        private string _city;               //  backing field variable - city
        private string _state;              //  backing field variable - state
        private int _zip;                   //  backing field variable - zip code
        public const int MIN_ZIP = 0;       //  minimum ZipCode value
        public const int MAX_ZIP = 99999;   //  maximum ZipCode value

        //  six-parameter constructor
        //  Precondition:  a six parameter Address object is instantiated in Main
        //  Postcondition:  creates six parameter Address object, assigns variable values through properties
        public Address(string name, string address1, string address2, string city, string state, int zip)
        {
            Name = name;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
        }

        //  overloaded five-parameter constructor - (omits _address2)
        //  Precondition:  a five parameter Address object is instantiated in Main
        //  Postcondition:  creates five parameter Address object, assigns variable values through properties
        public Address(string name, string address1, string city, string state, int zip)
            : this(name, address1, string.Empty, city, state, zip)
        {
            //  No body needed
            //  Calls previous constructor, sets Address2 to empty string
        }

        //  Precondition:  Name must be provided in constructor as a valid string
        //  Postcondition:  gets and sets Name value after validating
        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"Please enter a valid {nameof(Address)}");
                }
                else
                _name = value.Trim();
            }
        }

        //  Precondition:  Address line 1 must provided be in constructor as a valid string
        //  Postcondition:  gets and sets Address1 value after validating
        public string Address1
        {
            get { return _address1; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"Please enter a valid {nameof(Address)}");
                }
                else
                _address1 = value.Trim();
            }
        }

        //  Precondition:  Address line 2 must provided be in first constructor as a valid string or will be set to empty string in second constructor if none exists
        //  Postcondition:  gets and sets Address2 value
        public string Address2
        {
            get { return _address2; }
            set { _address2 = value.Trim(); }
        }

        //  Precondition:  City must provided be in constructor as a valid string
        //  Postcondition:  gets and sets City value after validating
        public string City
        {
            get { return _city; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"Please enter a valid {nameof(City)} value");
                }
                else
                _city = value.Trim();
            }
        }

        //  Precondition:  State must provided be in constructor as a valid string
        //  Postcondition:  gets and sets State value after validating
        public string State
        {
            get { return _state; }
            set
            {
                if (value.Length > 2)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(State)} must be entered as the State's two letter identifier");
                }
                else
                _state = value.Trim();
            }
        }

        //  Precondition:  Zip code must provided be in constructor as a valid int with five digits
        //  Postcondition:  gets and sets Zip value after validating
        public int Zip
        {
            get { return _zip; }
            set
            {
                if (value <= MIN_ZIP || value > MAX_ZIP)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Zip)} must be a valid zip code");
                }
                else
                _zip = value;
            }
        }

        //  Precondition:  Address object is created, all values assigned to variables
        //  Postcondition:  Returns a string representation of the Address object
        public override string ToString()
        {
            string address;

            address = Name + Environment.NewLine + Address1 + Environment.NewLine;

            if (!String.IsNullOrWhiteSpace(Address2))
                address += Address2 + Environment.NewLine;

            address += City + ", " + State + " " + Zip.ToString("D5");

            return address;
        }
    }
}
