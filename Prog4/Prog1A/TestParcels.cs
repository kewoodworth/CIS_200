// Program 4
// CIS 200-01  Fall 2018
// Due: 11/26/2018
// By: D8318

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1A
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            //  creates ten Address objects
            Address ad1A = new Address("Rrose Selavy", "5454 Dada Ave.", "Apt. 66", "New York", "Ny", 10019);
            Address ad1B = new Address("Leonora Carrington", "9632 Hyena Blvd.", "Ojai", "CA", 90322);
            Address ad2A = new Address("Meret Oppenheim", "54 Teacup Ln.", "Apt. 3", "Chicago", "IL", 34998);
            Address ad2B = new Address("Joan Miro", "9021 Sculpture Dr.", "Portland", "OR", 98069);
            Address ad3A = new Address("Hugo Ball", "901 Century Ct.", "Miami", "FL", 20001);
            Address ad3B = new Address("Leonor Fini", "306 Lake Pl.", "Unit 4C", "Denver", "CO", 76663);
            Address ad4A = new Address("Tristan Tzara", "5050 Paris St.", "Omaha", "NE", 55091);
            Address ad4B = new Address("Marcel Duchamp", "669 R. Mutt NE", "Woodinville", "WA", 99886);
            Address ad5A = new Address("Hannah Hoch", "22019 Gingko St.", "Apt. 60", "Austin", "TX", 78704);
            Address ad5B = new Address("Andre Breton", "9077 Basil Ave.", "New Orleans", "LA", 43329);

            //  creates three Letter objects
            Letter post1 = new Letter(ad1A, ad1B, 3.95M);
            Letter post2 = new Letter(ad2A, ad2B, 3.95M);
            Letter post3 = new Letter(ad3A, ad3B, 3.95M);

            //  creates three Ground Package objects
            GroundPackage ground1 = new GroundPackage(ad1B, ad1A, 10, 5.5, 2, 2);
            GroundPackage ground2 = new GroundPackage(ad2B, ad2A, 7, 3, 1.5, 3);
            GroundPackage ground3 = new GroundPackage(ad3B, ad3A, 20, 36, 15, 45);

            //  creates three Next Day Air objects
            NextDayAirPackage nextDayAir1 = new NextDayAirPackage(ad5A, ad5B, 10, 12, 6.5, 9, 15M);
            NextDayAirPackage nextDayAir2 = new NextDayAirPackage(ad2A, ad2B, 30, 24, 12, 83, 15M);
            NextDayAirPackage nextDayAir3 = new NextDayAirPackage(ad3A, ad1B, 55, 15, 35, 27, 15M);

            //  creates three Two Day Air objects
            TwoDayAirPackage twoDayAir1 = new TwoDayAirPackage(ad3A, ad3B, 24, 13.5, 3, 77, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage twoDayAir2 = new TwoDayAirPackage(ad4A, ad4B, 36, 36, 36, 45, TwoDayAirPackage.Delivery.Early);
            TwoDayAirPackage twoDayAir3 = new TwoDayAirPackage(ad5A, ad2B, 8, 14, 3, 15, TwoDayAirPackage.Delivery.Saver);

            //  creates List to store Parcel objects
            var parcels = new List<Parcel>()
                {
                post1,
                post2,
                post3,
                ground1,
                ground2,
                ground3,
                nextDayAir1,
                nextDayAir2,
                nextDayAir3,
                twoDayAir1,
                twoDayAir2,
                twoDayAir3
                };

            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            parcels.Sort(); // Sort by cost - ascending (default)
            Console.Out.WriteLine("Sorted list (natural order: by cost - ascending):");
            foreach (Parcel p in parcels)
                Console.WriteLine($"{p.GetType().Name}: {p.CalcCost():C}");
            Pause();

            parcels.Sort(new DescendingZip()); // Sort by destination zip - descending

            Console.Out.WriteLine("Sorted list (descending destination zip code) using Comparer:");
            foreach (Parcel p in parcels)
                Console.WriteLine($"{p.GetType().Name}: {p.DestinationAddress.Zip}");
            Pause();

            parcels.Sort(new AscendingTypeDescendingCost()); // Sort by type - ascending, then cost - descending

            Console.Out.WriteLine("Sorted list (ascending type, descending cost) using Comparer:");
            foreach (Parcel p in parcels)
                Console.WriteLine($"{p.GetType().Name}: {p.CalcCost():C}");
            Pause();
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
