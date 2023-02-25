namespace Scheduling_Appointment
{
    partial class CustomerRecordsForm
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
            this.customerRecordsDGV = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbAddress2 = new System.Windows.Forms.TextBox();
            this.tbPostalCode = new System.Windows.Forms.TextBox();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.customerRecordsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // customerRecordsDGV
            // 
            this.customerRecordsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerRecordsDGV.Location = new System.Drawing.Point(18, 18);
            this.customerRecordsDGV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.customerRecordsDGV.Name = "customerRecordsDGV";
            this.customerRecordsDGV.RowHeadersWidth = 62;
            this.customerRecordsDGV.Size = new System.Drawing.Size(684, 309);
            this.customerRecordsDGV.TabIndex = 0;
            this.customerRecordsDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.customerRecordsDGV_DataBindingComplete);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 337);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 35);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(140, 337);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(261, 337);
            this.btnModify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(112, 35);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(382, 337);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(504, 337);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 35);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(740, 18);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name";
            this.lblName.Click += new System.EventHandler(this.Name);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(740, 98);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(68, 20);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(740, 138);
            this.lblAddress2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(81, 20);
            this.lblAddress2.TabIndex = 10;
            this.lblAddress2.Text = "Address 2";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(740, 177);
            this.lblCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(35, 20);
            this.lblCity.TabIndex = 11;
            this.lblCity.Text = "City";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(740, 218);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(64, 20);
            this.lblCountry.TabIndex = 12;
            this.lblCountry.Text = "Country";
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Location = new System.Drawing.Point(740, 258);
            this.lblPostalCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(95, 20);
            this.lblPostalCode.TabIndex = 13;
            this.lblPostalCode.Text = "Postal Code";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(740, 297);
            this.lblPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(115, 20);
            this.lblPhoneNumber.TabIndex = 14;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(910, 8);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(148, 26);
            this.tbName.TabIndex = 19;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(910, 48);
            this.tbId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(148, 26);
            this.tbId.TabIndex = 20;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(910, 88);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(148, 26);
            this.tbAddress.TabIndex = 21;
            // 
            // tbAddress2
            // 
            this.tbAddress2.Location = new System.Drawing.Point(910, 128);
            this.tbAddress2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAddress2.Name = "tbAddress2";
            this.tbAddress2.Size = new System.Drawing.Size(148, 26);
            this.tbAddress2.TabIndex = 22;
            // 
            // tbPostalCode
            // 
            this.tbPostalCode.Location = new System.Drawing.Point(910, 248);
            this.tbPostalCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPostalCode.Name = "tbPostalCode";
            this.tbPostalCode.Size = new System.Drawing.Size(148, 26);
            this.tbPostalCode.TabIndex = 25;
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(910, 286);
            this.tbPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(148, 26);
            this.tbPhoneNumber.TabIndex = 27;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(740, 58);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(26, 20);
            this.lblId.TabIndex = 28;
            this.lblId.Text = "ID";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(626, 337);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 35);
            this.btnBack.TabIndex = 29;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(910, 207);
            this.tbCountry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(148, 26);
            this.tbCountry.TabIndex = 30;
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(910, 171);
            this.tbCity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(148, 26);
            this.tbCity.TabIndex = 31;
            // 
            // CustomerRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 393);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbCountry);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.tbPhoneNumber);
            this.Controls.Add(this.tbPostalCode);
            this.Controls.Add(this.tbAddress2);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblPostalCode);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.customerRecordsDGV);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Text = "Customer Records";
            ((System.ComponentModel.ISupportInitialize)(this.customerRecordsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerRecordsDGV;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbAddress2;
        private System.Windows.Forms.TextBox tbPostalCode;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.TextBox tbCity;
    }
}