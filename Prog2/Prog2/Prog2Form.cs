// Grading ID:  D8318
// Program 2
// CIS 200-01, Fall 2018
// Due: 10/24/2018

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        private UserParcelView upv;         //  Initialize UserParcelView
        string NL = Environment.NewLine;    //  Stores NewLine shortcut

        //  Precondition: None
        //  Postcondition:  Initializes program and all test objects
        public Prog2Form()
        {
            InitializeComponent();

            upv = new UserParcelView();     

            //  creates eight test Address objects
            upv.AddAddress("Rrose Selavy", "5454 Dada Ave.", "Apt. 66", "New York", "Ny", 10019);
            upv.AddAddress("Leonora Carrington", "9632 Hyena Blvd.", "Ojai", "CA", 90322);
            upv.AddAddress("Meret Oppenheim", "54 Teacup Ln.", "Apt. 3", "Chicago", "IL", 34998);
            upv.AddAddress("Joan Miro", "9021 Sculpture Dr.", "Portland", "OR", 98069);
            upv.AddAddress("Hugo Ball", "901 Century Ct.", "Miami", "FL", 20001);
            upv.AddAddress("Leonor Fini", "306 Lake Pl.", "Unit 4C", "Denver", "CO", 76663);
            upv.AddAddress("Tristan Tzara", "5050 Paris St.", "Omaha", "NE", 55091);
            upv.AddAddress("Marcel Duchamp", "669 R. Mutt NE", "Woodinville", "WA", 99886);

            //  creates eight test Parcel objects
            upv.AddLetter(upv.AddressAt(0), upv.AddressAt(1), 3.75M);
            upv.AddLetter(upv.AddressAt(3), upv.AddressAt(4), 2.25M);
            upv.AddGroundPackage(upv.AddressAt(5), upv.AddressAt(6), 10, 5.5, 2, 2);
            upv.AddGroundPackage(upv.AddressAt(6), upv.AddressAt(7), 7, 3, 1.5, 17);
            upv.AddNextDayAirPackage(upv.AddressAt(0), upv.AddressAt(7), 10, 12, 6.5, 9, 12.50M);
            upv.AddNextDayAirPackage(upv.AddressAt(1), upv.AddressAt(6), 30, 24, 12, 83, 25.0M);
            upv.AddTwoDayAirPackage(upv.AddressAt(2), upv.AddressAt(5), 24, 13.5, 3, 77, TwoDayAirPackage.Delivery.Early);
            upv.AddTwoDayAirPackage(upv.AddressAt(3), upv.AddressAt(4), 36, 36, 36, 45, TwoDayAirPackage.Delivery.Saver);
        }

        // Precondition:  The File >> About menu item has been selected
        // Postcondition:  A message box displays with information about this program
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Grading ID: D8318{NL}" +
                            $"CIS200-01 Fall 2018{NL}" +
                            $"Program 2:  Explores the creation of a simple GUI, use of dialog boxes, validation, and exception handling{NL}" +
                            $"Due: Wednesday, October 24, 2018");
        }

        // Precondition:  The File >> Exit menu item has been selected
        // Postcondition:  The program is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  The Insert >> Address menu item has been selected
        // Postcondition:  A dialog box prompts the user for new Address information.
        //                 If the user submits, a new Address object is created.
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAddressForm addAddress = new AddAddressForm();   //  Calls Add Address Form
            DialogResult result = addAddress.ShowDialog();      //  Result from dialog - OK/Cancel?

            if (result == DialogResult.OK)  //  Address is created if user selects OK from dialog box
            {
                upv.AddAddress(addAddress.NameInput, addAddress.Address1Input, addAddress.Address2Input,
                            addAddress.CityInput, addAddress.StateInput, addAddress.ZipInput);
            }
        }

        // Precondition:  The Insert >> Letter menu item has been selected
        // Postcondition:  A dialog box prompts the user for new Letter information.
        //                 If the user submits, a new Letter object is created.
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLetterForm addLetter = new AddLetterForm(upv.AddressList);   //  Calls Add Letter Form
            DialogResult result = addLetter.ShowDialog();                   //  Result from dialog - OK/Cancel?

            if (result == DialogResult.OK)  //  Letter object is created if user selects OK from dialog box
            {
                upv.AddLetter(upv.AddressAt(addLetter.ReturnAddress), upv.AddressAt(addLetter.DestinationAddress),
                              decimal.Parse(addLetter.FixedCost));
            }
        }

        // Precondition:  The Report >> List Addresses menu item has been selected
        // Postcondition:  All Address objects are displayed in the form
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder addressReport = new StringBuilder();  //  Creates string to store Address objects

            foreach (Address a in upv.AddressList)
            {
                addressReport.Append($"{a.ToString()}{NL}{NL}");    //  Adds address objects in List to StringBuilder addressReport
            }

            displayBox.Text = $"Addresses:{NL}" +
                              $"------------------------------{NL}{NL}"+
                              $"{addressReport.ToString()}";
        }

        // Precondition:  The Report >> List Parcels menu item has been selected
        // Postcondition:  All Parcel objects are displayed in the form
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder parcelReport = new StringBuilder();   //  Creates string to store Parcel objects

            foreach (Parcel p in upv.ParcelList)
            {
                parcelReport.Append($"{p.ToString()}{NL}{NL}{NL}**********{NL}{NL}");    //  Adds parcel objects in List to StringBuilder parcelReport
            }

            displayBox.Text = $"Parcels:{NL}" +
                              $"------------------------------{NL}{NL}" +
                              $"{parcelReport.ToString()}";
        }
    }
}
