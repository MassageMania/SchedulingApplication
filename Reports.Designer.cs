
namespace Scheduling_Appointment
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.lblReports = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.cbAppointmentType = new System.Windows.Forms.ComboBox();
            this.cbConsultant = new System.Windows.Forms.ComboBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.btnRunAppTypReport = new System.Windows.Forms.Button();
            this.btnConsultantReport = new System.Windows.Forms.Button();
            this.btnCustomerReport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAppType = new System.Windows.Forms.Label();
            this.lblConsultant = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblInstructional = new System.Windows.Forms.Label();
            this.lblTypeInstructional = new System.Windows.Forms.Label();
            this.lblCustomerInstructional = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Location = new System.Drawing.Point(33, 28);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(66, 20);
            this.lblReports.TabIndex = 0;
            this.lblReports.Text = "Reports";
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(37, 70);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowHeadersWidth = 62;
            this.dgvReport.RowTemplate.Height = 28;
            this.dgvReport.Size = new System.Drawing.Size(822, 345);
            this.dgvReport.TabIndex = 1;
            // 
            // cbAppointmentType
            // 
            this.cbAppointmentType.FormattingEnabled = true;
            this.cbAppointmentType.Location = new System.Drawing.Point(196, 25);
            this.cbAppointmentType.Name = "cbAppointmentType";
            this.cbAppointmentType.Size = new System.Drawing.Size(121, 28);
            this.cbAppointmentType.TabIndex = 2;
            // 
            // cbConsultant
            // 
            this.cbConsultant.FormattingEnabled = true;
            this.cbConsultant.Location = new System.Drawing.Point(459, 25);
            this.cbConsultant.Name = "cbConsultant";
            this.cbConsultant.Size = new System.Drawing.Size(121, 28);
            this.cbConsultant.TabIndex = 3;
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(730, 25);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(121, 28);
            this.cbCustomer.TabIndex = 4;
            // 
            // btnRunAppTypReport
            // 
            this.btnRunAppTypReport.Location = new System.Drawing.Point(37, 424);
            this.btnRunAppTypReport.Name = "btnRunAppTypReport";
            this.btnRunAppTypReport.Size = new System.Drawing.Size(153, 95);
            this.btnRunAppTypReport.TabIndex = 5;
            this.btnRunAppTypReport.Text = "Type Report";
            this.btnRunAppTypReport.UseVisualStyleBackColor = true;
            this.btnRunAppTypReport.Click += new System.EventHandler(this.btnRunAppTypReport_Click);
            // 
            // btnConsultantReport
            // 
            this.btnConsultantReport.Location = new System.Drawing.Point(248, 424);
            this.btnConsultantReport.Name = "btnConsultantReport";
            this.btnConsultantReport.Size = new System.Drawing.Size(167, 95);
            this.btnConsultantReport.TabIndex = 6;
            this.btnConsultantReport.Text = "Consultant Report";
            this.btnConsultantReport.UseVisualStyleBackColor = true;
            this.btnConsultantReport.Click += new System.EventHandler(this.btnConsultantReport_Click);
            // 
            // btnCustomerReport
            // 
            this.btnCustomerReport.Location = new System.Drawing.Point(528, 424);
            this.btnCustomerReport.Name = "btnCustomerReport";
            this.btnCustomerReport.Size = new System.Drawing.Size(156, 95);
            this.btnCustomerReport.TabIndex = 7;
            this.btnCustomerReport.Text = "Customer Report";
            this.btnCustomerReport.UseVisualStyleBackColor = true;
            this.btnCustomerReport.Click += new System.EventHandler(this.btnCustomerReport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(703, 432);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 87);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAppType
            // 
            this.lblAppType.AutoSize = true;
            this.lblAppType.Location = new System.Drawing.Point(147, 28);
            this.lblAppType.Name = "lblAppType";
            this.lblAppType.Size = new System.Drawing.Size(43, 20);
            this.lblAppType.TabIndex = 9;
            this.lblAppType.Text = "Type";
            // 
            // lblConsultant
            // 
            this.lblConsultant.AutoSize = true;
            this.lblConsultant.Location = new System.Drawing.Point(367, 33);
            this.lblConsultant.Name = "lblConsultant";
            this.lblConsultant.Size = new System.Drawing.Size(86, 20);
            this.lblConsultant.TabIndex = 10;
            this.lblConsultant.Text = "Consultant";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(646, 33);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(78, 20);
            this.lblCustomer.TabIndex = 11;
            this.lblCustomer.Text = "Customer";
            // 
            // lblInstructional
            // 
            this.lblInstructional.AutoSize = true;
            this.lblInstructional.Location = new System.Drawing.Point(875, 70);
            this.lblInstructional.Name = "lblInstructional";
            this.lblInstructional.Size = new System.Drawing.Size(300, 200);
            this.lblInstructional.TabIndex = 12;
            this.lblInstructional.Text = resources.GetString("lblInstructional.Text");
            // 
            // lblTypeInstructional
            // 
            this.lblTypeInstructional.AutoSize = true;
            this.lblTypeInstructional.Location = new System.Drawing.Point(875, 284);
            this.lblTypeInstructional.Name = "lblTypeInstructional";
            this.lblTypeInstructional.Size = new System.Drawing.Size(326, 20);
            this.lblTypeInstructional.TabIndex = 13;
            this.lblTypeInstructional.Text = "** Type Button only reports for 30 days out. **\r\n";
            // 
            // lblCustomerInstructional
            // 
            this.lblCustomerInstructional.AutoSize = true;
            this.lblCustomerInstructional.Location = new System.Drawing.Point(875, 318);
            this.lblCustomerInstructional.Name = "lblCustomerInstructional";
            this.lblCustomerInstructional.Size = new System.Drawing.Size(197, 60);
            this.lblCustomerInstructional.TabIndex = 14;
            this.lblCustomerInstructional.Text = "** Customer reports ALL **\r\n** appointments for a **\r\n**  specific customer. **\r\n" +
    "";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 577);
            this.Controls.Add(this.lblCustomerInstructional);
            this.Controls.Add(this.lblTypeInstructional);
            this.Controls.Add(this.lblInstructional);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblConsultant);
            this.Controls.Add(this.lblAppType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCustomerReport);
            this.Controls.Add(this.btnConsultantReport);
            this.Controls.Add(this.btnRunAppTypReport);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.cbConsultant);
            this.Controls.Add(this.cbAppointmentType);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.lblReports);
            this.Name = "Reports";
            this.Text = "All Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.ComboBox cbAppointmentType;
        private System.Windows.Forms.ComboBox cbConsultant;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Button btnRunAppTypReport;
        private System.Windows.Forms.Button btnConsultantReport;
        private System.Windows.Forms.Button btnCustomerReport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAppType;
        private System.Windows.Forms.Label lblConsultant;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblInstructional;
        private System.Windows.Forms.Label lblTypeInstructional;
        private System.Windows.Forms.Label lblCustomerInstructional;
    }
}