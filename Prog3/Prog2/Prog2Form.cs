// Grading ID:  D8318
// Program 3
// CIS 200-01, Fall 2018
// Due: 11/12/2018

// File: Prog2Form.cs
// This class creates the main GUI for Program 2. It provides a
// File menu with About and Exit items, an Insert menu with Address and
// Letter items, and a Report menu with List Addresses and List Parcels
// items.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        private UserParcelView upv; // The UserParcelView
        private List<Address> addressList;  //  List of addresses
        private List<Parcel> parcelList;    //  List of parcels

        // object for deserializing upv in binary format
        private BinaryFormatter reader = new BinaryFormatter();
        private FileStream input; // stream for reading from a file

        // object for serializing upv in binary format
        private BinaryFormatter formatter = new BinaryFormatter();
        private FileStream output; // stream for writing to a file

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display.
        public Prog2Form()
        {
            InitializeComponent();

            upv = new UserParcelView();

            //// Test Data - Magic Numbers OK
            //upv.AddAddress("Rrose Selavy", "5454 Dada Ave.", "Apt. 66", "New York", "Ny", 10019);
            //upv.AddAddress("Leonora Carrington", "9632 Hyena Blvd.", "Ojai", "CA", 90322);
            //upv.AddAddress("Meret Oppenheim", "54 Teacup Ln.", "Apt. 3", "Chicago", "IL", 34998);
            //upv.AddAddress("Joan Miro", "9021 Sculpture Dr.", "Portland", "OR", 98069);
            //upv.AddAddress("Hugo Ball", "901 Century Ct.", "Miami", "FL", 20001);
            //upv.AddAddress("Leonor Fini", "306 Lake Pl.", "Unit 4C", "Denver", "CO", 76663);
            //upv.AddAddress("Tristan Tzara", "5050 Paris St.", "Omaha", "NE", 55091);
            //upv.AddAddress("Marcel Duchamp", "669 R. Mutt NE", "Woodinville", "WA", 99886);

            ////Test data -Parcel objects
            //upv.AddLetter(upv.AddressAt(0), upv.AddressAt(1), 3.75M);
            //upv.AddLetter(upv.AddressAt(3), upv.AddressAt(4), 2.25M);
            //upv.AddGroundPackage(upv.AddressAt(5), upv.AddressAt(6), 10, 5.5, 2, 2);
            //upv.AddGroundPackage(upv.AddressAt(6), upv.AddressAt(7), 7, 3, 1.5, 17);
            //upv.AddNextDayAirPackage(upv.AddressAt(0), upv.AddressAt(7), 10, 12, 6.5, 9, 12.50M);
            //upv.AddNextDayAirPackage(upv.AddressAt(1), upv.AddressAt(6), 30, 24, 12, 83, 25.0M);
            //upv.AddTwoDayAirPackage(upv.AddressAt(2), upv.AddressAt(5), 24, 13.5, 3, 77, TwoDayAirPackage.Delivery.Early);
            //upv.AddTwoDayAirPackage(upv.AddressAt(3), upv.AddressAt(4), 36, 36, 36, 45, TwoDayAirPackage.Delivery.Saver);

            addressList = new List<Address>();
            parcelList = new List<Parcel>();
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // Newline shorthand

            MessageBox.Show($"Grading ID: D8318{NL}" +
                            $"CIS200-01 Fall 2018{NL}" +
                            $"Program 3: This program explores file I/O and object serialization and expands the GUI application developed in Program 2.{NL}" +
                            $"Due: Monday, November 12, 2018");
        }

        // Precondition:  File, Open menu item activated
        // Postcondition: User can select data file to open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create and show dialog box enabling user to open file
            DialogResult result; // result of OpenFileDialog
            string fileName; // name of file containing data

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // get specified name
            }

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {
                // show error if user specified invalid file
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // create FileStream to obtain read access to file
                    input = new FileStream(
                       fileName, FileMode.Open, FileAccess.Read);
                }
            }

            // deserialize and store data
            try
            {
                // get next UPV in file
                UserParcelView thisUPV =
                   (UserParcelView)reader.Deserialize(input);

                upv = thisUPV;
            }
            catch (SerializationException)
            {
                input?.Close(); // close FileStream

                // notify user if no items in file
                MessageBox.Show("No more records in file", string.Empty,
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Precondition:  File, Save As menu item activated
        // Postcondition: User is prompted to create a data file
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create and show dialog box enabling user to save file
            DialogResult result;
            string fileName; // name of file to save data

            using (SaveFileDialog fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false; // let user create file

                // retrieve the result of the dialog box
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // get specified file name
            }

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {
                // show error if user specified invalid file
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // save file via FileStream if user specified valid file
                    try
                    {
                        // open file with write access
                        output = new FileStream(fileName,
                           FileMode.Create, FileAccess.Write);
                    }
                    catch (IOException)
                    {
                        // notify user if file could not be opened
                        MessageBox.Show("Error opening file", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // store UPV and serialize
            try
            {
                formatter.Serialize(output, upv);
            }
            catch (SerializationException)
            {
                MessageBox.Show("Error Writing to File", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Format", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Insert, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result
            int zip; // Address zip code

            if (result == DialogResult.OK) // Only add if OK
            {
                if (int.TryParse(addressForm.ZipText, out zip))
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        zip); // Use form's properties to create address
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
                                   // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            reportTxt.Text = result.ToString();

            // -- OR --
            // Not using StringBuilder, just use TextBox directly

            //reportTxt.Clear();
            //reportTxt.AppendText("Addresses:");
            //reportTxt.AppendText(NL); // Remember, \n doesn't always work in GUIs
            //reportTxt.AppendText(NL);

            //foreach (Address a in upv.AddressList)
            //{
            //    reportTxt.AppendText(a.ToString());
            //    reportTxt.AppendText(NL);
            //    reportTxt.AppendText("------------------------------");
            //    reportTxt.AppendText(NL);
            //}

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Insert, Letter menu item activated
        // Postcondition: The Letter dialog box is displayed. If data entered
        //                are OK, a Letter is created and added to the list
        //                of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog
            decimal fixedCost;     // The letter's cost

            if (upv.AddressCount < LetterForm.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return; // Exit now since can't create valid letter
            }

            letterForm = new LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                if (decimal.TryParse(letterForm.FixedCostText, out fixedCost))
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        fixedCost); // Letter to be inserted
                }
               else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose(); // Best practice for dialog boxes
                                  // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Parcels menu item activated
        // Postcondition: The list of parcels is displayed in the parcelResultsTxt
        //                text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            decimal totalCost = 0;                      // Running total of parcel shipping costs
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Parcels:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                result.Append(p.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
                totalCost += p.CalcCost();
            }

            result.Append(NL);
            result.Append($"Total Cost: {totalCost:C}");

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Edit, User selects Address item to edit
        // Postcondition:  After user selects Address object, dialog is displayed to edit address information
        private void addressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectAddress selectAddress = new SelectAddress(upv.AddressList);    // The Select Address dialog box form
            DialogResult result = selectAddress.ShowDialog();   // Show form as dialog and store result

            if (result == DialogResult.OK) // If user clicks Select Address button - Open Address Form dialog
            {
                int editIndex = selectAddress.EditAddressIndex;     //  Index of selected Address in List
                Address editAddress = upv.AddressAt(editIndex);     //  Holds the Address object being updated

                AddressForm addressForm = new AddressForm();    // The address dialog box form

                //  Assigns Address object attributes to form attributes
                addressForm.AddressName = editAddress.Name;
                addressForm.Address1 = editAddress.Address1;
                addressForm.Address2 = editAddress.Address2;
                addressForm.City = editAddress.City;
                addressForm.State = editAddress.State;
                addressForm.ZipText = editAddress.Zip.ToString();

                DialogResult editingAddress = addressForm.ShowDialog(); // Show form as dialog and store result

                //  If user accepts, attributes are updated
                if (editingAddress == DialogResult.OK)
                {
                    editAddress.Name = addressForm.AddressName;
                    editAddress.Address1 = addressForm.Address1;
                    editAddress.Address2 = addressForm.Address2;
                    editAddress.City = addressForm.City;
                    editAddress.State = addressForm.State;
                    editAddress.Zip = int.Parse(addressForm.ZipText);
                }
            }
        }
    }
}