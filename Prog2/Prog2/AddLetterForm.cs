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
    public partial class AddLetterForm : Form
    {
        private List<Address> listAddresses;    //  List of addresses

        // Precondition:  None
        // Postcondition:  AddLetterForm GUI is initialized
        public AddLetterForm(List<Address> addresses)
        {
            InitializeComponent();
            listAddresses = addresses;  //  Populates Address List in initialization

            //  Stores list of addresses as items in Address Combo Boxes
            foreach (Address a in listAddresses)
            {
                returnAddressCB.Items.Add(a.Name);
                destinationAddressCB.Items.Add(a.Name);
            }
        }

        internal int ReturnAddress  //  Can be accessed by other classes in the same namespace
        {
            // Precondition: None
            // Postcondition:  Text in Return Address combo box is returned
            get { return returnAddressCB.SelectedIndex; }

            // Precondition:  None
            // Postcondition:  Text in Return Address combo box is set to specified value
            set { returnAddressCB.SelectedIndex = value; }
        }

        internal int DestinationAddress  //  Can be accessed by other classes in the same namespace
        {
            // Precondition: None
            // Postcondition:  Text in Destination Address combo box is returned
            get { return destinationAddressCB.SelectedIndex; }

            // Precondition:  None
            // Postcondition:  Text in Destination Address combo box is set to specified value
            set { destinationAddressCB.SelectedIndex = value; }
        }

        internal string FixedCost  //  Can be accessed by other classes in the same namespace
        {
            // Precondition: None
            // Postcondition:  Text in Cost textbox is returned
            get { return costTextBox.Text; }

            // Precondition: None
            // Postcondition:  Text in Cost textbox is set to specified value
            set { costTextBox.Text = value; }
        }

        // Precondition:  User attempts to change focus from Return Address Combo Box
        // Postcondition:  If no selection has been made, focus remains and error provider message is sent
        //                 If selection is made, focus will change
        private void returnCB_Validating(object sender, CancelEventArgs e)
        {
            if (returnAddressCB.SelectedIndex == -1)    // if no address has been selected
            {
                e.Cancel = true;    //  Stops focus from changing
                errorProvider1.SetError(returnAddressCB, "Select your return address");     //  Set error message
            }
        }

        // Precondition:  returnCB_Validating succeeded
        // Postcondition: Any error message set is cleared
        //                Focus is allowed to change
        private void returnCB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(returnAddressCB, "");   //  Clears error icon
        }

        // Precondition:  User attempts to change focus from Destination Address Combo Box
        // Postcondition:  If no selection has been made, focus remains and error provider message is sent
        //                 If selection is made, focus will change
        private void destinationCB_Validating(object sender, CancelEventArgs e)
        {
            if (destinationAddressCB.SelectedIndex == -1)    // if no address has been selected
            {
                e.Cancel = true;    //  Stops focus from changing
                errorProvider1.SetError(destinationAddressCB, "Select your destination address");     //  Set error message
            }
            else if (destinationAddressCB.SelectedIndex == returnAddressCB.SelectedIndex)   // if return and destination addresses match
            {
                e.Cancel = true;    //  Stops focus from changing
                errorProvider1.SetError(destinationAddressCB, "Destination cannot match return address");     //  Set error message
            }
        }

        // Precondition:  destinationCB_Validating succeeded
        // Postcondition: Any error message set is cleared
        //                Focus is allowed to change
        private void destinationCB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(destinationAddressCB, "");   //  Clears error icon
        }

        // Precondition:  User attempts to change focus from Cost textbox
        // Postcondition:  If no value is entered, focus remains and error provider message is sent
        //                 If entered value is a valid decimal, focus will change
        private void cost_Validating(object sender, CancelEventArgs e)
        {
            decimal value;
            if (!decimal.TryParse(costTextBox.Text, out value))     //  If value entered cannot be parsed as decimal
            {
                e.Cancel = true;    //  Stops focus from changing
                errorProvider1.SetError(costTextBox, "Enter postage cost");     //  Set error message

                costTextBox.SelectAll();    // Select text in textbox to ease correction
            }
        }

        // Precondition:  cost_Validating succeeded
        // Postcondition: Any error message set is cleared
        //                Focus is allowed to change
        private void cost_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(costTextBox, "");   //  Clears error icon
        }

        // Precondition:  User has clicked Add Letter button
        // Postcondition:  If all controls on form validate, Letter object is added
        //                 Dialog box is dismissed with OK result
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        // Precondition:  User has clicked on Cancel button
        // Postcondition:  Dialog box is dismissed
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
