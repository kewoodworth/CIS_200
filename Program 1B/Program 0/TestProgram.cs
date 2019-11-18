using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//  Grading ID:  D8318
//  CIS 200-01
//  Program 1B
//  Due Wednesday, October 3
//  Purpose: This program explores the use of LINQ to produce simple reports.

namespace Program_0
{
    class Program
    {
        public static object Name { get; private set; }

        static void Main(string[] args)
        {
            const decimal STAMP = 0.49M;            //  constant variable - sets price for one stamp
            const decimal EXPRESS_FEE = 20.00M;     //  constant variable - sets price for express fee of NextDayAirPackage
            const int AM = 0;                       //  constant variable - sets enum value for AM (Early) TwoDayAirPackage delivery
            const int PM = 1;                       //  constant variable - sets enum value for PM (Saver) TwoDayAirPackage delivery

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
            Letter post1 = new Letter(ad1A, ad1B, STAMP);
            Letter post2 = new Letter(ad2A, ad2B, STAMP);
            Letter post3 = new Letter(ad3A, ad3B, STAMP);

            //  creates three Ground Package objects
            GroundPackage ground1 = new GroundPackage(ad1B, ad1A, 10, 5.5, 2, 2);
            GroundPackage ground2 = new GroundPackage(ad2B, ad2A, 7, 3, 1.5, 3);
            GroundPackage ground3 = new GroundPackage(ad3B, ad3A, 20, 36, 15, 45);

            //  creates three Next Day Air objects
            NextDayAirPackage nextDayAir1 = new NextDayAirPackage(ad5A, ad5B, 10, 12, 6.5, 9, EXPRESS_FEE);
            NextDayAirPackage nextDayAir2 = new NextDayAirPackage(ad2A, ad2B, 30, 24, 12, 83, EXPRESS_FEE);
            NextDayAirPackage nextDayAir3 = new NextDayAirPackage(ad3A, ad1B, 55, 15, 35, 27, EXPRESS_FEE);

            //  creates three Two Day Air objects
            TwoDayAirPackage twoDayAir1 = new TwoDayAirPackage(ad3A, ad3B, 24, 13.5, 3, 77, PM);
            TwoDayAirPackage twoDayAir2 = new TwoDayAirPackage(ad4A, ad4B, 36, 36, 36, 45, AM);
            TwoDayAirPackage twoDayAir3 = new TwoDayAirPackage(ad5A, ad2B, 8, 14, 3, 15, PM);

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

            //  Precondition:  a list is created for Parcel objects
            //  Postcondition:  information of Parcel objects in list are printed to console
            foreach (var currentParcel in parcels)
            {
                WriteLine(currentParcel);
                WriteLine();
            }

            //  used in test to ensure appropriate ToString output of address objects
            //var addresses = new List<Address>() { ad1A, ad1B, ad2A, ad2B, ad3A, ad3B, ad4A, ad4B, ad5A, ad5B };
            //foreach (var currentAddress in addresses)
            //{
            //    WriteLine($"{currentAddress}{Environment.NewLine}");
            //}

            WriteLine("==================================================================================\n");

            //  LINQ:  Select all Parcels and order by destination zip (descending)
            var orderByDestinationZip =
                from item in parcels
                orderby item.DestinationAddress.Zip descending
                select item;

            WriteLine("A. Select all Parcels and order by destination zip (descending)");
            foreach (var item in orderByDestinationZip)
            {
                WriteLine($"{item.GetType().Name} {item.ParcelNumber}:  {item.DestinationAddress.Zip}");
            }
            WriteLine();

            //  LINQ:  Select all Parcels and order by cost (ascending)
            var orderByCost =
                from item in parcels
                orderby item.CalcCost()
                select item;

            WriteLine("B. Select all Parcles and order by cost (ascending)");
            foreach (var item in orderByCost)
            {
                WriteLine($"{item.GetType().Name} {item.ParcelNumber}:  {item.CalcCost():C}");
            }
            WriteLine();

            //  LINQ:  Select all Parcels and order by Parcel type (ascending) and then cost (descending)
            var orderByTypeAndCost =
                from item in parcels
                orderby item.GetType().Name ascending, item.CalcCost() descending
                select item;

            WriteLine("C. Select all Parcels and order by Parcel type (ascending) and then cost (descending)");
            foreach (var item in orderByTypeAndCost)
            {
                WriteLine($"{item.GetType().Name} {item.ParcelNumber}:  {item.CalcCost():C}");
            }
            WriteLine();

            //  LINQ:  Select all AirPackage objects that are heavy and order by weight (descending)
            var heavyAirPackages =
                from item in parcels
                    where ( item is AirPackage ) && ( ((AirPackage)item).IsHeavy() )
                let lbs = ((AirPackage)item).Weight
                orderby lbs descending
                select item;

            WriteLine("D. Select all AirPackage objects that are heavy and order by weight (descending)");
            foreach (var item in heavyAirPackages)
            {
                WriteLine($"{item.GetType().Name} {item.ParcelNumber}:  {(item as Package).Weight} lbs.");
            }
            WriteLine();
        }
    }
}
