using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeSheet.EF;

namespace TimeSheet
{
    public partial class AdminForm : Form
    {
        // private data context field 
        private ProjectEntities context;
        private Form ParentForm;
        // get current datetime 
        DateTime dt = DateTime.Now;

        public AdminForm(Form parentForm)
        {
            context = new ProjectEntities();
            InitializeComponent();
            this.ParentForm = parentForm;
            this.FormClosed += AdminForm_FormClosed;

            // load emnploee email for combo box
            loadEmailComboBoxex();
            loadEmployeeGridView();
            loadTimesheetGridView();

            // register button events
            registerEmployeeBtn.Click += RegisterEmployeeBtn_Click;
            setHourBtn.Click += SetHourBtn_Click;
            acceptTimesheetBtn.Click += AcceptTimesheetBtn_Click;
            declineBtn.Click += DeclineBtn_Click;
            goBackBtn.Click += GoBackBtn_Click;

            // register timesheet select employee combobox
            timeSheetSelectEmployeeCB.DropDownClosed += TimeSheetSelectEmployeeCB_DropDownClosed;
            monthCB.DropDownClosed += MonthCB_DropDownClosed;
            yearCB.DropDownClosed += YearCB_DropDownClosed;
            
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            ParentForm.Show();
            this.Hide();
        }

        private void DeclineBtn_Click(object sender, EventArgs e)
        {
            string email = timeSheetSelectEmployeeCB.SelectedItem.ToString();
            // get timesheet table 
            //get timesheetmonth id
            int year, month;
            int.TryParse(yearCB.SelectedItem.ToString(), out year);
            int.TryParse(monthCB.SelectedItem.ToString(), out month);

            var timesheetMonth = context.TimeSheetMonth.FirstOrDefault(tm => tm.month.Equals(month) && tm.year.Equals(year));
            var timesheetList = context.TimeSheet.Where(ts => ts.timesheetMonthId.Equals(timesheetMonth.Id)).ToList();
            foreach(EF.TimeSheet ts in timesheetList)
            {
                context.TimeSheet.Remove(ts);
            }
            context.SaveChanges();
            MessageBox.Show("The timesheet approval is declined");
            loadTimesheetGridView(email, month, year);
        }
        
        private void YearCB_DropDownClosed(object sender, EventArgs e)
        {
            string email = timeSheetSelectEmployeeCB.SelectedItem.ToString();
            int month = 0;
            int year = 0;
            if (monthCB.SelectedItem == null)
                return;
            int.TryParse(monthCB.SelectedItem.ToString(), out month);
            int.TryParse(yearCB.SelectedItem.ToString(), out year);
            loadTimesheetGridView(email, month, year);
        }

        private void MonthCB_DropDownClosed(object sender, EventArgs e)
        {
            string email = timeSheetSelectEmployeeCB.SelectedItem.ToString();
            int month = 0;
            int year = 0;
            if (yearCB.SelectedItem == null)
                return;
            int.TryParse(monthCB.SelectedItem.ToString(), out month);
            int.TryParse(yearCB.SelectedItem.ToString(), out year);
            loadTimesheetGridView(email, month, year);
        }

        private void AcceptTimesheetBtn_Click(object sender, EventArgs e)
        {
            // get current month and year
            int currentMonth = dt.Month;
            int currentYear = dt.Year;
            
            // get an Employee from selected value (email) in comboBox
           
            int year, month;
            if (!int.TryParse(yearCB.SelectedItem.ToString(), out year) ||
                !int.TryParse(monthCB.SelectedItem.ToString(), out month) || 
                yearCB.SelectedItem == null || monthCB.SelectedItem == null ||
                timeSheetSelectEmployeeCB.SelectedItem == null)
            {
                MessageBox.Show("Please select valid month and year");
                return;
            }

            string selectedEmail = timeSheetSelectEmployeeCB.SelectedItem.ToString();
            // check if admin tries to submit current month (only previous month can be submitted)
            if (currentMonth == month && currentYear == year)
            {
                MessageBox.Show("Cannot accept current month's timesheet");
                return;
            }

            // Get Employee
            var selectedEmployee = context.Employee.First(se => se.email.Equals(selectedEmail));
            // get employee's timesheetMonth
            var selectedTimeSheetMonth = context.TimeSheetMonth
                            .First(m => m.year.Equals(year) 
                                    && m.month.Equals(month)
                                    && m.employeeId.Equals(selectedEmployee.Id));
            // get payment
            var paymentToUpdate = context.Payment
                            .FirstOrDefault(p => p.employeeId.Equals(selectedEmployee.Id) 
                                               && p.timesheetMonthId.Equals(selectedTimeSheetMonth.Id));

            // calculate grosspay (hourly rate * workedHours)
            decimal currentGrossPay = 0;
            var timesheetList = (from timesheet in context.TimeSheet
                                where timesheet.employeeId.Equals(selectedEmployee.Id)
                                    && timesheet.timesheetMonthId.Equals(selectedTimeSheetMonth.Id)
                                select timesheet).ToList();

            foreach(EF.TimeSheet t in timesheetList)
            {
                currentGrossPay += t.hoursWorked * selectedEmployee.hourlyRate ?? 1;
            }

            decimal gross = paymentToUpdate == null ? 0 : paymentToUpdate.gross;
            gross += currentGrossPay;
            decimal tax = CalculateIncomeProvinceTax(gross);
            decimal ei = CalculateEI(gross);
            decimal cpp = CalculateCPP(gross);
            decimal net = gross - (tax + ei + cpp);

            // update payment 
            if (paymentToUpdate != null)
            {
                paymentToUpdate.gross = gross;
                paymentToUpdate.ei = ei;
                paymentToUpdate.cpp = cpp;
                paymentToUpdate.net = net;
                paymentToUpdate.tax = tax;

                context.Payment.Attach(paymentToUpdate);
                context.Entry(paymentToUpdate).Property(p => p.gross).IsModified = true;
                context.SaveChanges();
            }
            else
            {
                // create payment table 
                paymentToUpdate = new Payment
                {
                    employeeId = selectedEmployee.Id,
                    timesheetMonthId = selectedTimeSheetMonth.Id,
                    hourlyRate = selectedEmployee.hourlyRate ?? 1, // check null value, hourly rate in payment is not null
                    gross = gross,
                    ei = ei,
                    net = net,
                    cpp = cpp,
                    tax = tax
                };

                context.Payment.Add(paymentToUpdate);
                context.SaveChanges();
            }
            
            // save data 
            context.SaveChanges();

            // display detail
            displayDetail(selectedEmployee.Id, selectedTimeSheetMonth.Id);

            // reset all selected button
            resetTimesheetOptions();
        }

        private void resetTimesheetOptions()
        {
            loadEmailComboBoxex();
            timeSheetGridView.DataSource = typeof(List<>);
            timeSheetGridView.DataSource = null;
            timeSheetGridView.Rows.Clear();
            timeSheetGridView.Refresh();

            monthCB.SelectedIndex = -1;
            yearCB.SelectedIndex = -1;
            timeSheetSelectEmployeeCB.SelectedIndex = -1;
        }

        private void resetDetailOptions()
        {
            dataGridViewTotalPay.Rows.Clear();
            dataGridViewTotalPay.Refresh();
            
            dataGridViewTaxes.Rows.Clear();
            dataGridViewTaxes.Refresh();
            totalPayTB.Text = "";
            taxexTB.Text = "";
            netPayTB.Text = "";
            paymentEmployeeNameTB.Text = "";
            paymentMonthYearTB.Text = "";
        }

        private void displayDetail(int employeeId, int monthId)
        {
            resetDetailOptions();
            var employee = context.Employee.FirstOrDefault(e => e.Id.Equals(employeeId));
            var timeSheetMonth = context.TimeSheetMonth.FirstOrDefault(p => p.Id == monthId);
            var payment = context.Payment.FirstOrDefault(p => p.employeeId.Equals(employeeId) && p.timesheetMonthId.Equals(monthId));
            if (payment != null)
            {
                object[] regularPay = { "Regular Pay", timeSheetMonth.totalHours, payment.hourlyRate, payment.gross };
                dataGridViewTotalPay.Rows.Add(regularPay);

                object[] tax = { "Income Tax", payment.tax };
                dataGridViewTaxes.Rows.Add(tax);

                object[] ei = { "Employment Insurance", payment.ei };
                dataGridViewTaxes.Rows.Add(ei);

                object[] cpp = { "Canada Pension Plan", payment.cpp };
                dataGridViewTaxes.Rows.Add(cpp);

                dataGridViewTotalPay.Refresh();
                dataGridViewTaxes.Refresh();

                var taxes = payment.tax + payment.ei + payment.cpp;

                totalPayTB.Text = payment.gross.ToString("C2");
                taxexTB.Text = taxes.ToString("C2");
                netPayTB.Text = payment.net.ToString("C2");
                paymentEmployeeNameTB.Text = employee.firstName + " " + employee.lastName;
                paymentMonthYearTB.Text = timeSheetMonth.month + " / " + timeSheetMonth.year;
            }

        }
        private void loadEmployeeGridView()
        {
            var employeList = (from employee in context.Employee
                             select employee).ToList();
            // update gridview 
            EmployeeGridView.DataSource = typeof(List<Employee>);
            EmployeeGridView.DataSource = context.Employee.Local.ToBindingList();
        }

        // Display Employee Timesheet Gridview
        private void loadTimesheetGridView(string email = null, int month = 0, int year = 0)
        {
            if (email == null || month == 0 || year ==0)
                return;
            timeSheetGridView.DataSource = typeof(List<>);
            // gets all timesheet list matching year, month and employee email
            var timeSheetList = (from timesheet in context.TimeSheet
                                    where timesheet.Employee.email.Equals(email)
                                    && timesheet.TimeSheetMonth.month.Equals(month)
                                    && timesheet.TimeSheetMonth.year.Equals(year)
                                    select new
                                    {
                                        Month = timesheet.TimeSheetMonth.month,
                                        Day = timesheet.day,
                                        HoursWorked = timesheet.hoursWorked
                                    }).ToList();
            timeSheetGridView.DataSource = timeSheetList.ToList();
        }

        // setting houly rate
        private void SetHourBtn_Click(object sender, EventArgs e)
        {
            decimal newRate;
            string email = setEmployeeHourCB.SelectedItem.ToString();

            // if admin enter valid input for new hourly rate, then update the entity 
            if(Decimal.TryParse(houlyRateUpdateTxt.Text, out newRate))
            {
                var employeeToUpdate = context.Employee.SingleOrDefault(ue => ue.email == email);
                Console.WriteLine(employeeToUpdate.email);
                if (employeeToUpdate != null)
                {
                    employeeToUpdate.hourlyRate = newRate;
                   
                    context.Employee.Attach(employeeToUpdate);
                    context.Entry(employeeToUpdate).Property(ue => ue.hourlyRate).IsModified = true;
                    context.SaveChanges();
                    MessageBox.Show("New hourly rate successfully saved!");
                } 
            }
            else
            {
                MessageBox.Show("Please enter valid input");
            }
            var updatedEmployee = context.Employee.SingleOrDefault(ue => ue.email == email);
            loadEmployeeGridView();
        }

        // if employee is selected, load month and year comboboxes
        private void TimeSheetSelectEmployeeCB_DropDownClosed(object sender, EventArgs e)
        {
            if (timeSheetSelectEmployeeCB.SelectedItem == null)
                return;

            string selectedEmail = timeSheetSelectEmployeeCB.SelectedItem.ToString();
            // load month and year combobox 
            var selectedEmployee = context.Employee.FirstOrDefault(se => se.email.Equals(selectedEmail));

            var timesheetList= (from timesheet in context.TimeSheet
                                    where timesheet.employeeId == selectedEmployee.Id
                                    select timesheet).ToList();



            // clear combobox before adding items
            monthCB.Items.Clear();
            yearCB.Items.Clear();

            foreach (EF.TimeSheet t in timesheetList)
            {
                Console.WriteLine(t.Employee.email + ", month: " + t.TimeSheetMonth.month + ", year: " + t.TimeSheetMonth.year);
                if(!monthCB.Items.Contains(t.TimeSheetMonth.month))
                    monthCB.Items.Add(t.TimeSheetMonth.month);
                if (!yearCB.Items.Contains(t.TimeSheetMonth.year))
                    yearCB.Items.Add(t.TimeSheetMonth.year);
            }
        }
        
        // load employee in comboBox
        private void loadEmailComboBoxex()
        {
            // reset comboboxes first
            timeSheetSelectEmployeeCB.Items.Clear();
            setEmployeeHourCB.Items.Clear();

            // get employee email list then display in combo box
            var employeeEmailList = (from employee in context.Employee
                                     select new
                                     {
                                         employee.email,
                                         employee.hourlyRate
                                     }).ToList();

            foreach (var e in employeeEmailList)
            {
                setEmployeeHourCB.Items.Add(e.email);
                timeSheetSelectEmployeeCB.Items.Add(e.email);
            }
        }

        // register employee 
        private void RegisterEmployeeBtn_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("register clicked");
            string firstName, lastName, email, address, phone;
            decimal hourlyRate;

            firstName = firstNameTxt.Text;
            lastName = lastNameTxt.Text;
            email = emailTxt.Text;
            address = addressTxt.Text;
            phone = phoneTxt.Text;
            // validate form text fields
            if(firstName != "" && lastName != "" && email != ""  && address != "" 
                && phone != "" && Decimal.TryParse(hourlyRateTxt.Text, out hourlyRate))
            {
                // create employee class 
                Employee newEmployee = new Employee()
                {
                    firstName = firstName,
                    lastName = lastName,
                    email = email,
                    address = address,
                    phone = phone,
                    hourlyRate = hourlyRate
                };

                // insert employee data into Employee table
                context.Employee.Add(newEmployee);
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Please enter valid input");
            }
            loadEmployeeGridView();
            loadEmailComboBoxex();
        }
        
        
        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentForm.Show();
        }

        private decimal CalculateIncomeProvinceTax(decimal grossPay)
        {

            var anualIncome = grossPay * 12;
            if (anualIncome <= 10682)
                return 0;
            else if (anualIncome <= 40707)
                return anualIncome * 0.0506M;
            else if (anualIncome <= 81416)
                return anualIncome * 0.0770M;
            else if (anualIncome <= 93476)
                return grossPay * 0.105M;
            else if (anualIncome <= 113506)
                return grossPay * 0.1229M;
            else if (anualIncome <= 153900)
                return grossPay * 0.1470M;
            else
                return grossPay * 0.1680M;
        }

        private decimal CalculateIncomeFederalTax(decimal grossPay)
        {

            var anualIncome = grossPay * 12;
            if (anualIncome <= 12069)
                return 0;
            else if (anualIncome <= 47630)
                return anualIncome * 0.15M;
            else if (anualIncome <= 95259)
                return anualIncome * 0.205M;
            else if (anualIncome <= 147667)
                return grossPay * 0.26M;
            else if (anualIncome <= 210371)
                return grossPay * 0.29M;
            else
                return grossPay * 0.33M;
        }

        private decimal CalculateCPP(decimal grossPay)
        {
            return (grossPay - 291.66M) * 0.0495M;
        }

        private decimal CalculateEI(decimal grossPay)
        {
            return (grossPay * 0.0163M);
        }
    }
}
