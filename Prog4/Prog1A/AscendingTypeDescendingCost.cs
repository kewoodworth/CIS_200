// Program 4
// CIS 200-01  Fall 2018
// Due: 11/26/2018
// By: D8318

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1A
{
    class AscendingTypeDescendingCost : Comparer<Parcel>
    {
        // Precondition:  None
        // Postcondition: Orders Parcels by Type (ascending), and then by Cost (descending)
        public override int Compare(Parcel p1, Parcel p2)
        {
            // Ensure correct handling of null values (in .NET, null less than anything)
            if (p1 == null && p2 == null)   // both null?
                return 0;                 

            if (p1 == null)     // only p1 null?
                return -1;  

            if (p2 == null)     // only p2 null?
                return 1;   

            string parcel1 = p1.GetType().ToString();
            string parcel2 = p2.GetType().ToString();

            if (parcel1 == parcel2)     // same type?
                return (-1) * p1.CalcCost().CompareTo(p2.CalcCost());   // Reverses order of CalcCost (descending)

            return parcel1.CompareTo(parcel2);
        }
    }
}
