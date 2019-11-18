namespace UPVApp
{
    partial class AddAddressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.address1Txt = new System.Windows.Forms.TextBox();
            this.address2Txt = new System.Windows.Forms.TextBox();
            this.cityTxt = new System.Windows.Forms.TextBox();
            this.stateCB = new System.Windows.Forms.ComboBox();
            this.zipTxt = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.zipLabel = new System.Windows.Forms.Label();
            this.OKbutton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(70, 12);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(125, 20);
            this.nameTxt.TabIndex = 0;
            this.nameTxt.Validating += new System.ComponentModel.CancelEventHandler(this.name_Validating);
            this.nameTxt.Validated += new System.EventHandler(this.name_Validated);
            // 
            // address1Txt
            // 
            this.address1Txt.Location = new System.Drawing.Point(70, 38);
            this.address1Txt.Name = "address1Txt";
            this.address1Txt.Size = new System.Drawing.Size(125, 20);
            this.address1Txt.TabIndex = 1;
            this.address1Txt.Validating += new System.ComponentModel.CancelEventHandler(this.address1_Validating);
            this.address1Txt.Validated += new System.EventHandler(this.address1_Validated);
            // 
            // address2Txt
            // 
            this.address2Txt.Location = new System.Drawing.Point(70, 64);
            this.address2Txt.Name = "address2Txt";
            this.address2Txt.Size = new System.Drawing.Size(125, 20);
            this.address2Txt.TabIndex = 2;
            // 
            // cityTxt
            // 
            this.cityTxt.Location = new System.Drawing.Point(70, 90);
            this.cityTxt.Name = "cityTxt";
            this.cityTxt.Size = new System.Drawing.Size(125, 20);
            this.cityTxt.TabIndex = 3;
            this.cityTxt.Validating += new System.ComponentModel.CancelEventHandler(this.city_Validating);
            this.cityTxt.Validated += new System.EventHandler(this.city_Validated);
            // 
            // stateCB
            // 
            this.stateCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateCB.FormattingEnabled = true;
            this.stateCB.Items.AddRange(new object[] {
            "AK",
            "AL",
            "AR",
            "AZ",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "IA",
            "ID",
            "IL",
            "IN",
            "KS",
            "KY",
            "LA",
            "MA",
            "MD",
            "ME",
            "MI",
            "MN",
            "MO",
            "MS",
            "MT",
            "NC",
            "ND",
            "NE",
            "NH",
            "NJ",
            "NM",
            "NV",
            "NY",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VA",
            "VT",
            "WA",
            "WI",
            "WV",
            "WY"});
            this.stateCB.Location = new System.Drawing.Point(70, 116);
            this.stateCB.Name = "stateCB";
            this.stateCB.Size = new System.Drawing.Size(125, 21);
            this.stateCB.TabIndex = 4;
            this.stateCB.Validating += new System.ComponentModel.CancelEventHandler(this.state_Validating);
            this.stateCB.Validated += new System.EventHandler(this.state_Validated);
            // 
            // zipTxt
            // 
            this.zipTxt.Location = new System.Drawing.Point(70, 143);
            this.zipTxt.Name = "zipTxt";
            this.zipTxt.Size = new System.Drawing.Size(125, 20);
            this.zipTxt.TabIndex = 5;
            this.zipTxt.Validating += new System.ComponentModel.CancelEventHandler(this.zip_Validating);
            this.zipTxt.Validated += new System.EventHandler(this.zip_Validated);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(26, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Name:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(16, 41);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(48, 13);
            this.addressLabel.TabIndex = 7;
            this.addressLabel.Text = "Address:";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(37, 93);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(27, 13);
            this.cityLabel.TabIndex = 8;
            this.cityLabel.Text = "City:";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(29, 119);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(35, 13);
            this.stateLabel.TabIndex = 9;
            this.stateLabel.Text = "State:";
            // 
            // zipLabel
            // 
            this.zipLabel.AutoSize = true;
            this.zipLabel.Location = new System.Drawing.Point(39, 146);
            this.zipLabel.Name = "zipLabel";
            this.zipLabel.Size = new System.Drawing.Size(25, 13);
            this.zipLabel.TabIndex = 10;
            this.zipLabel.Text = "Zip:";
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(118, 188);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(94, 23);
            this.OKbutton.TabIndex = 11;
            this.OKbutton.Text = "Add Address";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(19, 188);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddAddressForm
            // 
            this.AcceptButton = this.OKbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(234, 241);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.zipLabel);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.zipTxt);
            this.Controls.Add(this.stateCB);
            this.Controls.Add(this.cityTxt);
            this.Controls.Add(this.address2Txt);
            this.Controls.Add(this.address1Txt);
            this.Controls.Add(this.nameTxt);
            this.Name = "AddAddressForm";
            this.Text = "AddAddressForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox zipTxt;
        private System.Windows.Forms.ComboBox stateCB;
        private System.Windows.Forms.TextBox cityTxt;
        private System.Windows.Forms.TextBox address2Txt;
        private System.Windows.Forms.TextBox address1Txt;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label nameLabel;
    }
}