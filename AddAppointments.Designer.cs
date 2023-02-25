
namespace Scheduling_Appointment
{
    partial class AddModAppointments
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
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndtime = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblContact = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbContact = new System.Windows.Forms.TextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.cbCustomerName = new System.Windows.Forms.ComboBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(18, 40);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(124, 20);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(18, 85);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(70, 20);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Location";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(18, 131);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 20);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(18, 217);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(44, 20);
            this.lblStartTime.TabIndex = 3;
            this.lblStartTime.Text = "Start";
            // 
            // lblEndtime
            // 
            this.lblEndtime.AutoSize = true;
            this.lblEndtime.Location = new System.Drawing.Point(18, 255);
            this.lblEndtime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndtime.Name = "lblEndtime";
            this.lblEndtime.Size = new System.Drawing.Size(38, 20);
            this.lblEndtime.TabIndex = 4;
            this.lblEndtime.Text = "End";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(18, 300);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(89, 20);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MM/dd/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(129, 177);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(239, 26);
            this.dtpDate.TabIndex = 4;
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(150, 80);
            this.tbLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(218, 26);
            this.tbLocation.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 389);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 35);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(258, 389);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(18, 345);
            this.lblContact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(65, 20);
            this.lblContact.TabIndex = 14;
            this.lblContact.Text = "Contact";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(106, 289);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(262, 26);
            this.tbDescription.TabIndex = 7;
            // 
            // tbContact
            // 
            this.tbContact.Location = new System.Drawing.Point(106, 334);
            this.tbContact.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbContact.Name = "tbContact";
            this.tbContact.Size = new System.Drawing.Size(262, 26);
            this.tbContact.TabIndex = 8;
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(150, 125);
            this.tbType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(218, 26);
            this.tbType.TabIndex = 3;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "MM/dd/yyyy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStart.Location = new System.Drawing.Point(129, 213);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(239, 26);
            this.dtpStart.TabIndex = 5;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "MM/dd/yyyy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEnd.Location = new System.Drawing.Point(129, 249);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(239, 26);
            this.dtpEnd.TabIndex = 6;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(19, 177);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 20);
            this.lblDate.TabIndex = 22;
            this.lblDate.Text = "Date";
            // 
            // cbCustomerName
            // 
            this.cbCustomerName.FormattingEnabled = true;
            this.cbCustomerName.Location = new System.Drawing.Point(149, 37);
            this.cbCustomerName.Name = "cbCustomerName";
            this.cbCustomerName.Size = new System.Drawing.Size(219, 28);
            this.cbCustomerName.TabIndex = 23;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(138, 389);
            this.btnModify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(112, 35);
            this.btnModify.TabIndex = 24;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // AddModAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 474);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.cbCustomerName);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.tbContact);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblEndtime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblCustomerName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddModAppointments";
            this.Text = "Add/Modify Appointments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndtime;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbContact;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cbCustomerName;
        private System.Windows.Forms.Button btnModify;
    }
}