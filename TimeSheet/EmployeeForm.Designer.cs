﻿namespace TimeSheet
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSeparator = new System.Windows.Forms.Label();
            this.comboBoxTimeSheetYear = new System.Windows.Forms.ComboBox();
            this.comboBoxTimeSheetMonth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaxes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotalPay)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSelectMonthYear
            // 
            this.labelSelectMonthYear.AutoSize = true;
            this.labelSelectMonthYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectMonthYear.Location = new System.Drawing.Point(12, 10);
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
            this.comboBoxPaymentMonth.Location = new System.Drawing.Point(16, 34);
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
            this.comboBoxPaymentYear.Location = new System.Drawing.Point(99, 34);
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
            this.groupBox1.Location = new System.Drawing.Point(182, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 268);
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
            this.groupBox2.Location = new System.Drawing.Point(256, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 120);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary";
            // 
            // textBoxNetPay
            // 
            this.textBoxNetPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNetPay.Location = new System.Drawing.Point(68, 74);
            this.textBoxNetPay.Name = "textBoxNetPay";
            this.textBoxNetPay.ReadOnly = true;
            this.textBoxNetPay.Size = new System.Drawing.Size(100, 20);
            this.textBoxNetPay.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Net Pay:";
            // 
            // textBoxTaxes
            // 
            this.textBoxTaxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTaxes.Location = new System.Drawing.Point(68, 44);
            this.textBoxTaxes.Name = "textBoxTaxes";
            this.textBoxTaxes.ReadOnly = true;
            this.textBoxTaxes.Size = new System.Drawing.Size(100, 20);
            this.textBoxTaxes.TabIndex = 3;
            // 
            // labelTax
            // 
            this.labelTax.AutoSize = true;
            this.labelTax.Location = new System.Drawing.Point(7, 46);
            this.labelTax.Name = "labelTax";
            this.labelTax.Size = new System.Drawing.Size(39, 13);
            this.labelTax.TabIndex = 2;
            this.labelTax.Text = "Taxes:";
            // 
            // textBoxTotalPay
            // 
            this.textBoxTotalPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTotalPay.Location = new System.Drawing.Point(68, 18);
            this.textBoxTotalPay.Name = "textBoxTotalPay";
            this.textBoxTotalPay.ReadOnly = true;
            this.textBoxTotalPay.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalPay.TabIndex = 1;
            // 
            // labelTotalPay
            // 
            this.labelTotalPay.AutoSize = true;
            this.labelTotalPay.Location = new System.Drawing.Point(7, 20);
            this.labelTotalPay.Name = "labelTotalPay";
            this.labelTotalPay.Size = new System.Drawing.Size(55, 13);
            this.labelTotalPay.TabIndex = 0;
            this.labelTotalPay.Text = "Total Pay:";
            // 
            // labelTaxes
            // 
            this.labelTaxes.AutoSize = true;
            this.labelTaxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaxes.Location = new System.Drawing.Point(6, 133);
            this.labelTaxes.Name = "labelTaxes";
            this.labelTaxes.Size = new System.Drawing.Size(51, 20);
            this.labelTaxes.TabIndex = 3;
            this.labelTaxes.Text = "Taxes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Pay";
            // 
            // dataGridViewTaxes
            // 
            this.dataGridViewTaxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Taxes,
            this.Current});
            this.dataGridViewTaxes.Location = new System.Drawing.Point(6, 156);
            this.dataGridViewTaxes.Name = "dataGridViewTaxes";
            this.dataGridViewTaxes.Size = new System.Drawing.Size(244, 105);
            this.dataGridViewTaxes.TabIndex = 1;
            this.dataGridViewTaxes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Taxes
            // 
            this.Taxes.HeaderText = "Taxes";
            this.Taxes.Name = "Taxes";
            this.Taxes.ReadOnly = true;
            // 
            // Current
            // 
            this.Current.HeaderText = "Current";
            this.Current.Name = "Current";
            this.Current.ReadOnly = true;
            // 
            // dataGridViewTotalPay
            // 
            this.dataGridViewTotalPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTotalPay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pay,
            this.Hours,
            this.Rate,
            this.Total});
            this.dataGridViewTotalPay.Location = new System.Drawing.Point(6, 38);
            this.dataGridViewTotalPay.Name = "dataGridViewTotalPay";
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
            this.label3.Location = new System.Drawing.Point(31, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Personal Info";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(1, 124);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(60, 13);
            this.labelFirstName.TabIndex = 6;
            this.labelFirstName.Text = "First Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(67, 147);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 20);
            this.textBox2.TabIndex = 9;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(1, 150);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(61, 13);
            this.labelLastName.TabIndex = 8;
            this.labelLastName.Text = "Last Name:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(67, 173);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(109, 20);
            this.textBoxPhone.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Phone:";
            // 
            // labelSeparator
            // 
            this.labelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSeparator.Location = new System.Drawing.Point(4, 283);
            this.labelSeparator.Name = "labelSeparator";
            this.labelSeparator.Size = new System.Drawing.Size(640, 2);
            this.labelSeparator.TabIndex = 12;
            // 
            // comboBoxTimeSheetYear
            // 
            this.comboBoxTimeSheetYear.FormattingEnabled = true;
            this.comboBoxTimeSheetYear.Items.AddRange(new object[] {
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
            this.comboBoxTimeSheetYear.Location = new System.Drawing.Point(314, 319);
            this.comboBoxTimeSheetYear.Name = "comboBoxTimeSheetYear";
            this.comboBoxTimeSheetYear.Size = new System.Drawing.Size(77, 21);
            this.comboBoxTimeSheetYear.TabIndex = 15;
            // 
            // comboBoxTimeSheetMonth
            // 
            this.comboBoxTimeSheetMonth.FormattingEnabled = true;
            this.comboBoxTimeSheetMonth.Items.AddRange(new object[] {
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
            this.comboBoxTimeSheetMonth.Location = new System.Drawing.Point(231, 319);
            this.comboBoxTimeSheetMonth.Name = "comboBoxTimeSheetMonth";
            this.comboBoxTimeSheetMonth.Size = new System.Drawing.Size(77, 21);
            this.comboBoxTimeSheetMonth.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(241, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Select TimeSheet";
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 584);
            this.Controls.Add(this.comboBoxTimeSheetYear);
            this.Controls.Add(this.comboBoxTimeSheetMonth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelSeparator);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Taxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Current;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSeparator;
        private System.Windows.Forms.ComboBox comboBoxTimeSheetYear;
        private System.Windows.Forms.ComboBox comboBoxTimeSheetMonth;
        private System.Windows.Forms.Label label5;
    }
}