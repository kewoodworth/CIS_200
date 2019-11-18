// Grading ID:  D8318
// Program 3
// CIS 200-01, Fall 2018
// Due: 11/12/2018

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
    public partial class SelectAddress : Form
    {
        private List<Address> addressList;  // List of addresses used to fill combo boxes
        private UserParcelView upv; // The UserParcelView

        public SelectAddress(List<Address> addresses)
        {
            InitializeComponent();
            addressList = addresses;
            upv = new UserParcelView();

            //  Combo box is populated with Address items in addressList
            foreach (Address a in addressList)
            {
                editAddressCB.Items.Add(a.Name);
            }
        }

        public int EditAddressIndex
        {
            // Precondition:  User has selected from destAddCbo
            // Postcondition: The index of the selected address returned
            get
            {
                return editAddressCB.SelectedIndex;
            }

            // Precondition:  -1 <= value < addressList.Count
            // Postcondition: The specified index is selected
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    editAddressCB.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("EditAddressIndex", value,
                        "Index must be valid");
            }
        }

        // Precondition:  User selects the Address in the Combo Box
        // Postcondition:  Dialog result is OK and Prog2Form opens Address object in Address Form
        private void selectButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        // Precondition:  User selects cancel button
        // Postcondition:  Dialog box is dismissed
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
