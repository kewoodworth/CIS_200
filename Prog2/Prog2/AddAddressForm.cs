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
    public partial class AddAddressForm : Form
    {
        // Precondition:  None
        // Postcondition: The AddAddressForm GUI is initialized
        public AddAddressForm()
        {
            InitializeComponent();
        }

        internal string NameInput   // Can be accessed by other classes in same namespace
        {
            // Precondition: None
            // Postcondition:  Text in Name textbox is returned
            get { return nameTxt.Text; }

            // Precondition:  None
            // Postcondition:  Text in Name textbox is set to specified value
            set { nameTxt.Text = value; }
        }

        internal string Address1Input   // Can be accessed by other classes in same namespace
        {
            // Precondition: None
            // Postcondition:  Text in Address1 textbox is returned
            get { return address1Txt.Text; }

            // Precondition:  None
            // Postcondition:  Text in Address1 textbox is set to specified value
            set { address1Txt.Text = value; }
        }

        internal string Address2Input   // Can be accessed by other classes in same namespace
        {
            // Precondition: None
            // Postcondition:  Text in Address2 textbox is returned
            get { return address2Txt.Text; }

            // Precondition:  None
            // Postcondition:  Text in Address2 textbox is set to specified value
            set { address2Txt.Text = value; }
        }

        internal string CityInput   // Can be accessed by other classes in same namespace
        {
            // Precondition: None
            // Postcondition:  Text in City textbox is returned
            get { return cityTxt.Text; }

            // Precondition:  None
            // Postcondition:  Text in City textbox is set to specified value
            set { cityTxt.Text = value; }
        }

        internal string StateInput  // Can be accessed by other classes in same namespace
        {
            // Precondition: None
            // Postcondition:  Text in State combo box is returned
            get { return stateCB.Text; }

            // Precondition:  None
            // Postcondition:  Text in State combo box is set to specified value
            set { stateCB.Text = value; }
        }

        internal int ZipInput   // Can be accessed by other classes in same namespace
        {
            // Precondition: None
            // Postcondition:  Text in Zip code textbox is returned
            get { return int.Parse(zipTxt.Text); }

            // Precondition:  None
            // Postcondition:  Text in Zip textbox is set to specified value if value is an int
            set
            {
                if (int.TryParse(zipTxt.Text, out int result))
                    result = value;
            }
        }

        // Precondition:  User attempts to change focus from Name textbox
        // Postcondition:  If no value is entered, focus remains and error provider message is sent
        //                 If value is provided, focus will change
        private void name_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTxt.Text))
            {
                e.Cancel = true;    // Stops focus changing process
                errorProvider1.SetError(nameTxt, "User must provide a name");   // Set error message
            }
        }

        // Precondition:  name_Validating succeeded
        // Postcondition: Any error message set is cleared
        //                Focus is allowed to change
        private void name_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(nameTxt, "");   // Clears error message
        }

        // Precondition:  User attempts to change focus from Address1 textbox
        // Postcondition:  If no value is entered, focus remains and error provider message is sent
        //                 If value is provided, focus will change
        private void address1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(address1Txt.Text))
            {
                e.Cancel = true;    // Stops focus changing process
                errorProvider1.SetError(address1Txt, "User must provide a street address"); // Set error message
            }
        }

        // Precondition:  address1_Validating succeeded
        // Postcondition: Any error message set is cleared
        //                Focus is allowed to change
        private void address1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(address1Txt, "");   // Clears error message
        }

        // Precondition:  User attempts to change focus from City textbox
        // Postcondition:  If no value is entered, focus remains and error provider message is sent
        //                 If value is provided, focus will change
        private void city_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cityTxt.Text))
            {
                e.Cancel = true;    // Stops focus changing process
                errorProvider1.SetError(cityTxt, "User must provide a city");   // Set error message
            }
        }

        // Precondition:  city_Validating succeeded
        // Postcondition: Any error message set is cleared
        //                Focus is allowed to change
        private void city_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cityTxt, "");   // Clears error message
        }

        // Precondition:  User attempts to change focus from State combo box
        // Postcondition:  If no value is selected, focus remains and error provider message is sent
        //                 If value is selected, focus will change
        private void state_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(stateCB.Text))
            {
                e.Cancel = true;    // Stops focus changing process
                errorProvider1.SetError(stateCB, "User must provide a state");  // Set error message
            }
        }

        // Precondition:  state_Validating succeeded
        // Postcondition: Any error message set is cleared
        //                Focus is allowed to change
        private void state_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(stateCB, "");   // Clears error message
        }

        // Precondition:  User attempts to change focus from Zip textbox
        // Postcondition:  If no value is entered, value is not numeric, or value is not within range,
        //                 focus remains and error provider message is sent.
        //                 If valid value is provided, focus will change
        private void zip_Validating(object sender, CancelEventArgs e)
        {
            int value = int.Parse(zipTxt.Text);
            if (string.IsNullOrWhiteSpace(zipTxt.Text))     //  If textbox is null or white space
            {
                e.Cancel = true;    // Stops focus changing process
                errorProvider1.SetError(zipTxt, "User must provide a zip code");    // Set error message

                zipTxt.SelectAll();    // Select text in textbox to ease correction
            }
            else if (!int.TryParse(zipTxt.Text, out value))     //  If value entered cannot be parsed as int
            {
                e.Cancel = true;    // Stops focus changing process
                errorProvider1.SetError(zipTxt, "User must provide a numerical zip code");  // Set error message

                zipTxt.SelectAll();    // Select text in textbox to ease correction
            }
            else if (Address.MIN_ZIP > value  || value > Address.MAX_ZIP)   //  If value is not within valid zip code range
            {
                e.Cancel = true;    // Stops focus changing process
                errorProvider1.SetError(zipTxt, "User must provide a valid zip code");  // Set error message

                zipTxt.SelectAll();    // Select text in textbox to ease correction
            }
        }

        // Precondition:  zip_Validating succeeded
        // Postcondition: Any error message set is cleared
        //                Focus is allowed to change
        private void zip_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(zipTxt, "");    // Clears error message
        }

        // Precondition:  User has clicked Add Address button
        // Postcondition:  If all controls on form validate, Address object is added
        //                 Dialog box is dismissed with OK result
        private void OKbutton_Click(object sender, EventArgs e)
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
