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
    class DescendingZip : Comparer<Parcel>
    {
        // Precondition:  None
        // Postcondition: Orders Parcels by Destination Zip Code - Descending
        public override int Compare(Parcel p1, Parcel p2)
        {
            // Ensure correct handling of null values (in .NET, null less than anything)
            if (p1 == null && p2 == null) // Both null?
                return 0;                 

            if (p1 == null) // only p1 is null?
                return -1;  

            if (p2 == null) // only p2 is null?
                return 1;   

            return (-1) * p1.DestinationAddress.Zip.CompareTo(p2.DestinationAddress.Zip); // Reverses natural order, zip descending
        }
    }
}
