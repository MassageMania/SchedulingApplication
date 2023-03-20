
namespace Scheduling_Appointment
{
    partial class Appointments
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
            this.appointmentsDGV = new System.Windows.Forms.DataGridView();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddModify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnCustomerRecords = new System.Windows.Forms.Button();
            this.btnAllAppointments = new System.Windows.Forms.Button();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.dtpLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // appointmentsDGV
            // 
            this.appointmentsDGV.AllowUserToAddRows = false;
            this.appointmentsDGV.AllowUserToDeleteRows = false;
            this.appointmentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsDGV.Location = new System.Drawing.Point(33, 102);
            this.appointmentsDGV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.appointmentsDGV.Name = "appointmentsDGV";
            this.appointmentsDGV.ReadOnly = true;
            this.appointmentsDGV.RowHeadersWidth = 62;
            this.appointmentsDGV.Size = new System.Drawing.Size(779, 249);
            this.appointmentsDGV.TabIndex = 1;
            this.appointmentsDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.appointmentsDGV_DataBindingComplete);
            // 
            // btnWeek
            // 
            this.btnWeek.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnWeek.Location = new System.Drawing.Point(33, 32);
            this.btnWeek.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(122, 60);
            this.btnWeek.TabIndex = 2;
            this.btnWeek.Text = "Week";
            this.btnWeek.UseVisualStyleBackColor = false;
            this.btnWeek.Click += new System.EventHandler(this.btnWeek_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnMonth.Location = new System.Drawing.Point(198, 32);
            this.btnMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(122, 60);
            this.btnMonth.TabIndex = 3;
            this.btnMonth.Text = "Month";
            this.btnMonth.UseVisualStyleBackColor = false;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAdd.Location = new System.Drawing.Point(33, 392);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(222, 61);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddModify
            // 
            this.btnAddModify.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAddModify.Location = new System.Drawing.Point(272, 393);
            this.btnAddModify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddModify.Name = "btnAddModify";
            this.btnAddModify.Size = new System.Drawing.Size(122, 60);
            this.btnAddModify.TabIndex = 7;
            this.btnAddModify.Text = "Modify";
            this.btnAddModify.UseVisualStyleBackColor = false;
            this.btnAddModify.Click += new System.EventHandler(this.btnAddModify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCancel.Location = new System.Drawing.Point(544, 393);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 60);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDelete.Location = new System.Drawing.Point(414, 393);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 60);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(673, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 59);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(588, 461);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(179, 96);
            this.btnReports.TabIndex = 14;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnCustomerRecords
            // 
            this.btnCustomerRecords.Location = new System.Drawing.Point(33, 461);
            this.btnCustomerRecords.Name = "btnCustomerRecords";
            this.btnCustomerRecords.Size = new System.Drawing.Size(179, 96);
            this.btnCustomerRecords.TabIndex = 15;
            this.btnCustomerRecords.Text = "Customers";
            this.btnCustomerRecords.UseVisualStyleBackColor = true;
            this.btnCustomerRecords.Click += new System.EventHandler(this.btnCustomerRecords_Click);
            // 
            // btnAllAppointments
            // 
            this.btnAllAppointments.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAllAppointments.Location = new System.Drawing.Point(690, 34);
            this.btnAllAppointments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAllAppointments.Name = "btnAllAppointments";
            this.btnAllAppointments.Size = new System.Drawing.Size(122, 60);
            this.btnAllAppointments.TabIndex = 16;
            this.btnAllAppointments.Text = "All";
            this.btnAllAppointments.UseVisualStyleBackColor = false;
            this.btnAllAppointments.Click += new System.EventHandler(this.btnAllAppointments_Click);
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "MM/dd/yyyy";
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(343, 66);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(323, 26);
            this.dtp.TabIndex = 17;
            // 
            // dtpLabel
            // 
            this.dtpLabel.AutoSize = true;
            this.dtpLabel.Location = new System.Drawing.Point(339, 32);
            this.dtpLabel.Name = "dtpLabel";
            this.dtpLabel.Size = new System.Drawing.Size(91, 20);
            this.dtpLabel.TabIndex = 18;
            this.dtpLabel.Text = "Date Picker";
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(836, 692);
            this.Controls.Add(this.dtpLabel);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.btnAllAppointments);
            this.Controls.Add(this.btnCustomerRecords);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.btnWeek);
            this.Controls.Add(this.appointmentsDGV);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Appointments";
            this.Text = "Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView appointmentsDGV;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddModify;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnCustomerRecords;
        private System.Windows.Forms.Button btnAllAppointments;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label dtpLabel;
    }
}