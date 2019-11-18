namespace UPVApp
{
    partial class AddLetterForm
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
            this.returnAddressCB = new System.Windows.Forms.ComboBox();
            this.destinationAddressCB = new System.Windows.Forms.ComboBox();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.returnAddressLabel = new System.Windows.Forms.Label();
            this.destinationAddressLabel = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // returnAddressCB
            // 
            this.returnAddressCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.returnAddressCB.FormattingEnabled = true;
            this.returnAddressCB.Location = new System.Drawing.Point(122, 12);
            this.returnAddressCB.Name = "returnAddressCB";
            this.returnAddressCB.Size = new System.Drawing.Size(150, 21);
            this.returnAddressCB.TabIndex = 0;
            this.returnAddressCB.Validating += new System.ComponentModel.CancelEventHandler(this.returnCB_Validating);
            this.returnAddressCB.Validated += new System.EventHandler(this.returnCB_Validated);
            // 
            // destinationAddressCB
            // 
            this.destinationAddressCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationAddressCB.FormattingEnabled = true;
            this.destinationAddressCB.Location = new System.Drawing.Point(122, 39);
            this.destinationAddressCB.Name = "destinationAddressCB";
            this.destinationAddressCB.Size = new System.Drawing.Size(150, 21);
            this.destinationAddressCB.TabIndex = 1;
            this.destinationAddressCB.Validating += new System.ComponentModel.CancelEventHandler(this.destinationCB_Validating);
            this.destinationAddressCB.Validated += new System.EventHandler(this.destinationCB_Validated);
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(122, 66);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(100, 20);
            this.costTextBox.TabIndex = 2;
            this.costTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.cost_Validating);
            this.costTextBox.Validated += new System.EventHandler(this.cost_Validated);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(122, 105);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "Add Letter";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(41, 105);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // returnAddressLabel
            // 
            this.returnAddressLabel.AutoSize = true;
            this.returnAddressLabel.Location = new System.Drawing.Point(33, 15);
            this.returnAddressLabel.Name = "returnAddressLabel";
            this.returnAddressLabel.Size = new System.Drawing.Size(83, 13);
            this.returnAddressLabel.TabIndex = 5;
            this.returnAddressLabel.Text = "Return Address:";
            // 
            // destinationAddressLabel
            // 
            this.destinationAddressLabel.AutoSize = true;
            this.destinationAddressLabel.Location = new System.Drawing.Point(12, 42);
            this.destinationAddressLabel.Name = "destinationAddressLabel";
            this.destinationAddressLabel.Size = new System.Drawing.Size(104, 13);
            this.destinationAddressLabel.TabIndex = 6;
            this.destinationAddressLabel.Text = "Destination Address:";
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Location = new System.Drawing.Point(85, 69);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(31, 13);
            this.costLabel.TabIndex = 7;
            this.costLabel.Text = "Cost:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddLetterForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(294, 141);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.destinationAddressLabel);
            this.Controls.Add(this.returnAddressLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(this.destinationAddressCB);
            this.Controls.Add(this.returnAddressCB);
            this.Name = "AddLetterForm";
            this.Text = "AddLetterForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox returnAddressCB;
        private System.Windows.Forms.ComboBox destinationAddressCB;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label returnAddressLabel;
        private System.Windows.Forms.Label destinationAddressLabel;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}