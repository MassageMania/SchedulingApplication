namespace SchedulingApplication
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.appointmentMonth = new System.Windows.Forms.MonthCalendar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnMonthlyReport = new System.Windows.Forms.Button();
            this.btnUserSchedules = new System.Windows.Forms.Button();
            this.btnCustomersandAppts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(39, 302);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(376, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(269, 302);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(155, 302);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // appointmentMonth
            // 
            this.appointmentMonth.Location = new System.Drawing.Point(273, 50);
            this.appointmentMonth.Name = "appointmentMonth";
            this.appointmentMonth.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(249, 162);
            this.dataGridView1.TabIndex = 5;
            // 
            // btnWeek
            // 
            this.btnWeek.Location = new System.Drawing.Point(12, 12);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(75, 23);
            this.btnWeek.TabIndex = 6;
            this.btnWeek.Text = "Week";
            this.btnWeek.UseVisualStyleBackColor = true;
            // 
            // btnMonth
            // 
            this.btnMonth.Location = new System.Drawing.Point(93, 12);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(75, 23);
            this.btnMonth.TabIndex = 7;
            this.btnMonth.Text = "Month";
            this.btnMonth.UseVisualStyleBackColor = true;
            // 
            // btnMonthlyReport
            // 
            this.btnMonthlyReport.Location = new System.Drawing.Point(39, 234);
            this.btnMonthlyReport.Name = "btnMonthlyReport";
            this.btnMonthlyReport.Size = new System.Drawing.Size(91, 39);
            this.btnMonthlyReport.TabIndex = 8;
            this.btnMonthlyReport.Text = "Monthly Reports";
            this.btnMonthlyReport.UseVisualStyleBackColor = true;
            // 
            // btnUserSchedules
            // 
            this.btnUserSchedules.Location = new System.Drawing.Point(200, 234);
            this.btnUserSchedules.Name = "btnUserSchedules";
            this.btnUserSchedules.Size = new System.Drawing.Size(91, 39);
            this.btnUserSchedules.TabIndex = 9;
            this.btnUserSchedules.Text = "User Schedules";
            this.btnUserSchedules.UseVisualStyleBackColor = true;
            // 
            // btnCustomersandAppts
            // 
            this.btnCustomersandAppts.Location = new System.Drawing.Point(360, 234);
            this.btnCustomersandAppts.Name = "btnCustomersandAppts";
            this.btnCustomersandAppts.Size = new System.Drawing.Size(91, 39);
            this.btnCustomersandAppts.TabIndex = 10;
            this.btnCustomersandAppts.Text = "Customers and Appointments";
            this.btnCustomersandAppts.UseVisualStyleBackColor = true;
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 337);
            this.Controls.Add(this.btnCustomersandAppts);
            this.Controls.Add(this.btnUserSchedules);
            this.Controls.Add(this.btnMonthlyReport);
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.btnWeek);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.appointmentMonth);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Name = "Appointments";
            this.Text = "Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.MonthCalendar appointmentMonth;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnMonthlyReport;
        private System.Windows.Forms.Button btnUserSchedules;
        private System.Windows.Forms.Button btnCustomersandAppts;
    }
}