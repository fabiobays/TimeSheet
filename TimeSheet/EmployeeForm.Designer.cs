namespace TimeSheet
{
    partial class EmployeeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.labelSelectMonthYear = new System.Windows.Forms.Label();
            this.comboBoxPaymentMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxPaymentYear = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxNetPay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTaxes = new System.Windows.Forms.TextBox();
            this.labelTax = new System.Windows.Forms.Label();
            this.textBoxTotalPay = new System.Windows.Forms.TextBox();
            this.labelTotalPay = new System.Windows.Forms.Label();
            this.labelTaxes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTaxes = new System.Windows.Forms.DataGridView();
            this.Taxes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Current = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTotalPay = new System.Windows.Forms.DataGridView();
            this.Pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSeparator = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewTimeSheet = new System.Windows.Forms.DataGridView();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoursWorked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoursWorked2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btSave = new System.Windows.Forms.Button();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btnGoback = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaxes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotalPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimeSheet)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSelectMonthYear
            // 
            this.labelSelectMonthYear.AutoSize = true;
            this.labelSelectMonthYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectMonthYear.ForeColor = System.Drawing.Color.White;
            this.labelSelectMonthYear.Location = new System.Drawing.Point(12, 12);
            this.labelSelectMonthYear.Name = "labelSelectMonthYear";
            this.labelSelectMonthYear.Size = new System.Drawing.Size(141, 20);
            this.labelSelectMonthYear.TabIndex = 0;
            this.labelSelectMonthYear.Text = "Select Month/Year";
            // 
            // comboBoxPaymentMonth
            // 
            this.comboBoxPaymentMonth.FormattingEnabled = true;
            this.comboBoxPaymentMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxPaymentMonth.Location = new System.Drawing.Point(16, 36);
            this.comboBoxPaymentMonth.Name = "comboBoxPaymentMonth";
            this.comboBoxPaymentMonth.Size = new System.Drawing.Size(77, 21);
            this.comboBoxPaymentMonth.TabIndex = 1;
            // 
            // comboBoxPaymentYear
            // 
            this.comboBoxPaymentYear.FormattingEnabled = true;
            this.comboBoxPaymentYear.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029"});
            this.comboBoxPaymentYear.Location = new System.Drawing.Point(99, 36);
            this.comboBoxPaymentYear.Name = "comboBoxPaymentYear";
            this.comboBoxPaymentYear.Size = new System.Drawing.Size(77, 21);
            this.comboBoxPaymentYear.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.labelTaxes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridViewTaxes);
            this.groupBox1.Controls.Add(this.dataGridViewTotalPay);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(192, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 281);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monthly Report";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxNetPay);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxTaxes);
            this.groupBox2.Controls.Add(this.labelTax);
            this.groupBox2.Controls.Add(this.textBoxTotalPay);
            this.groupBox2.Controls.Add(this.labelTotalPay);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(269, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 130);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary";
            // 
            // textBoxNetPay
            // 
            this.textBoxNetPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNetPay.Location = new System.Drawing.Point(106, 88);
            this.textBoxNetPay.Name = "textBoxNetPay";
            this.textBoxNetPay.ReadOnly = true;
            this.textBoxNetPay.Size = new System.Drawing.Size(100, 26);
            this.textBoxNetPay.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Net Pay:";
            // 
            // textBoxTaxes
            // 
            this.textBoxTaxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTaxes.Location = new System.Drawing.Point(106, 55);
            this.textBoxTaxes.Name = "textBoxTaxes";
            this.textBoxTaxes.ReadOnly = true;
            this.textBoxTaxes.Size = new System.Drawing.Size(100, 26);
            this.textBoxTaxes.TabIndex = 3;
            // 
            // labelTax
            // 
            this.labelTax.AutoSize = true;
            this.labelTax.Location = new System.Drawing.Point(9, 59);
            this.labelTax.Name = "labelTax";
            this.labelTax.Size = new System.Drawing.Size(55, 20);
            this.labelTax.TabIndex = 2;
            this.labelTax.Text = "Taxes:";
            // 
            // textBoxTotalPay
            // 
            this.textBoxTotalPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTotalPay.Location = new System.Drawing.Point(106, 23);
            this.textBoxTotalPay.Name = "textBoxTotalPay";
            this.textBoxTotalPay.ReadOnly = true;
            this.textBoxTotalPay.Size = new System.Drawing.Size(100, 26);
            this.textBoxTotalPay.TabIndex = 1;
            // 
            // labelTotalPay
            // 
            this.labelTotalPay.AutoSize = true;
            this.labelTotalPay.Location = new System.Drawing.Point(7, 25);
            this.labelTotalPay.Name = "labelTotalPay";
            this.labelTotalPay.Size = new System.Drawing.Size(78, 20);
            this.labelTotalPay.TabIndex = 0;
            this.labelTotalPay.Text = "Total Pay:";
            // 
            // labelTaxes
            // 
            this.labelTaxes.AutoSize = true;
            this.labelTaxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaxes.Location = new System.Drawing.Point(19, 145);
            this.labelTaxes.Name = "labelTaxes";
            this.labelTaxes.Size = new System.Drawing.Size(51, 20);
            this.labelTaxes.TabIndex = 3;
            this.labelTaxes.Text = "Taxes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Pay";
            // 
            // dataGridViewTaxes
            // 
            this.dataGridViewTaxes.AllowUserToAddRows = false;
            this.dataGridViewTaxes.AllowUserToDeleteRows = false;
            this.dataGridViewTaxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Taxes,
            this.Current});
            this.dataGridViewTaxes.Location = new System.Drawing.Point(19, 168);
            this.dataGridViewTaxes.Name = "dataGridViewTaxes";
            this.dataGridViewTaxes.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTaxes.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTaxes.Size = new System.Drawing.Size(244, 105);
            this.dataGridViewTaxes.TabIndex = 1;
            // 
            // Taxes
            // 
            this.Taxes.HeaderText = "Taxes";
            this.Taxes.Name = "Taxes";
            this.Taxes.ReadOnly = true;
            this.Taxes.Width = 150;
            // 
            // Current
            // 
            this.Current.HeaderText = "Current";
            this.Current.Name = "Current";
            this.Current.ReadOnly = true;
            this.Current.Width = 50;
            // 
            // dataGridViewTotalPay
            // 
            this.dataGridViewTotalPay.AllowUserToAddRows = false;
            this.dataGridViewTotalPay.AllowUserToDeleteRows = false;
            this.dataGridViewTotalPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTotalPay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pay,
            this.Hours,
            this.Rate,
            this.Total});
            this.dataGridViewTotalPay.Location = new System.Drawing.Point(19, 47);
            this.dataGridViewTotalPay.Name = "dataGridViewTotalPay";
            this.dataGridViewTotalPay.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTotalPay.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTotalPay.Size = new System.Drawing.Size(445, 92);
            this.dataGridViewTotalPay.TabIndex = 0;
            // 
            // Pay
            // 
            this.Pay.HeaderText = "Pay";
            this.Pay.Name = "Pay";
            this.Pay.ReadOnly = true;
            // 
            // Hours
            // 
            this.Hours.HeaderText = "Hours";
            this.Hours.Name = "Hours";
            this.Hours.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Personal Info";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.ForeColor = System.Drawing.Color.White;
            this.labelFirstName.Location = new System.Drawing.Point(1, 147);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(60, 13);
            this.labelFirstName.TabIndex = 6;
            this.labelFirstName.Text = "First Name:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(67, 144);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(112, 20);
            this.textBoxFirstName.TabIndex = 7;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(67, 170);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(112, 20);
            this.textBoxLastName.TabIndex = 9;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.ForeColor = System.Drawing.Color.White;
            this.labelLastName.Location = new System.Drawing.Point(1, 173);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(61, 13);
            this.labelLastName.TabIndex = 8;
            this.labelLastName.Text = "Last Name:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(67, 196);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(109, 20);
            this.textBoxPhone.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Phone:";
            // 
            // labelSeparator
            // 
            this.labelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSeparator.Location = new System.Drawing.Point(4, 292);
            this.labelSeparator.Name = "labelSeparator";
            this.labelSeparator.Size = new System.Drawing.Size(694, 10);
            this.labelSeparator.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(321, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Monthly TimeSheet";
            // 
            // dataGridViewTimeSheet
            // 
            this.dataGridViewTimeSheet.AllowUserToAddRows = false;
            this.dataGridViewTimeSheet.AllowUserToDeleteRows = false;
            this.dataGridViewTimeSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTimeSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.HoursWorked,
            this.Day2,
            this.HoursWorked2});
            this.dataGridViewTimeSheet.Location = new System.Drawing.Point(192, 338);
            this.dataGridViewTimeSheet.Name = "dataGridViewTimeSheet";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTimeSheet.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTimeSheet.Size = new System.Drawing.Size(444, 253);
            this.dataGridViewTimeSheet.TabIndex = 16;
            // 
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            // 
            // HoursWorked
            // 
            this.HoursWorked.HeaderText = "Hours Worked";
            this.HoursWorked.Name = "HoursWorked";
            // 
            // Day2
            // 
            this.Day2.HeaderText = "Day";
            this.Day2.Name = "Day2";
            this.Day2.ReadOnly = true;
            // 
            // HoursWorked2
            // 
            this.HoursWorked2.HeaderText = "Hours Worked";
            this.HoursWorked2.Name = "HoursWorked2";
            // 
            // btSave
            // 
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.White;
            this.btSave.Location = new System.Drawing.Point(291, 611);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(73, 31);
            this.btSave.TabIndex = 17;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // labelInstructions
            // 
            this.labelInstructions.ForeColor = System.Drawing.Color.White;
            this.labelInstructions.Location = new System.Drawing.Point(12, 352);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(164, 155);
            this.labelInstructions.TabIndex = 19;
            this.labelInstructions.Text = resources.GetString("labelInstructions.Text");
            // 
            // btUpdate
            // 
            this.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdate.ForeColor = System.Drawing.Color.White;
            this.btUpdate.Location = new System.Drawing.Point(47, 236);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(94, 30);
            this.btUpdate.TabIndex = 20;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            // 
            // btnGoback
            // 
            this.btnGoback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoback.ForeColor = System.Drawing.Color.White;
            this.btnGoback.Location = new System.Drawing.Point(435, 611);
            this.btnGoback.Name = "btnGoback";
            this.btnGoback.Size = new System.Drawing.Size(102, 31);
            this.btnGoback.TabIndex = 21;
            this.btnGoback.Text = "Go Back";
            this.btnGoback.UseVisualStyleBackColor = true;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(111)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(698, 654);
            this.Controls.Add(this.btnGoback);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.labelInstructions);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.dataGridViewTimeSheet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelSeparator);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxPaymentYear);
            this.Controls.Add(this.comboBoxPaymentMonth);
            this.Controls.Add(this.labelSelectMonthYear);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaxes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotalPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimeSheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectMonthYear;
        private System.Windows.Forms.ComboBox comboBoxPaymentMonth;
        private System.Windows.Forms.ComboBox comboBoxPaymentYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewTaxes;
        private System.Windows.Forms.DataGridView dataGridViewTotalPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label labelTaxes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxNetPay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTaxes;
        private System.Windows.Forms.Label labelTax;
        private System.Windows.Forms.TextBox textBoxTotalPay;
        private System.Windows.Forms.Label labelTotalPay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSeparator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewTimeSheet;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoursWorked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day2;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoursWorked2;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Taxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Current;
        private System.Windows.Forms.Button btnGoback;
    }
}