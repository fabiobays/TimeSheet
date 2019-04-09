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
        private int employeeId = 1;

        public AdminForm()
        {
            context = new ProjectEntities();

            InitializeComponent();

            // test insert database 
            insertData();
            // load emnploee email for combo box
            loadComboBox();
            loadEmployeeGridView();
            loadTimesheetGridView();
            // register creating Emplyoee button 
            registerEmployeeBtn.Click += RegisterEmployeeBtn_Click;
            // register update houly rate
            setHourBtn.Click += SetHourBtn_Click;
            // register timesheet select employee combobox
            timeSheetSelectEmployeeCB.DropDownClosed += TimeSheetSelectEmployeeCB_DropDownClosed;
            // register accept button 
            acceptTimesheetBtn.Click += AcceptTimesheetBtn_Click;
            monthCB.DropDownClosed += MonthCB_DropDownClosed;
            yearCB.DropDownClosed += YearCB_DropDownClosed;
        }

        

        private void insertData()
        {

            // insert month list
            List<TimeSheetMonth> monthList = new List<TimeSheetMonth>()  {
                new TimeSheetMonth { employeeId = employeeId, month = 1, year = 2019, totalHours = 0 }
            };

            context.TimeSheetMonth.AddRange(monthList);
            context.SaveChanges();

            // insert timesheet
            var testMonth = (from myMonth in context.TimeSheetMonth
                             select myMonth).ToList();
            List<EF.TimeSheet> timeSheetList = new List<EF.TimeSheet>()  {
                new EF.TimeSheet { employeeId = employeeId, TimeSheetMonth = testMonth[0], day = 7, hoursWorked = 8 },
                new EF.TimeSheet { employeeId = employeeId, TimeSheetMonth = testMonth[0], day = 9, hoursWorked = 8 },
                new EF.TimeSheet { employeeId = employeeId, TimeSheetMonth = testMonth[0], day = 10, hoursWorked = 8 },
                new EF.TimeSheet { employeeId = employeeId, TimeSheetMonth = testMonth[0], day = 14, hoursWorked = 8 },
                new EF.TimeSheet { employeeId = employeeId, TimeSheetMonth = testMonth[0], day = 20, hoursWorked = 8 }
            };

            context.TimeSheet.AddRange(timeSheetList);
            context.SaveChanges();
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
            // get Emploee from selected value (email) in comboBox
            string selectedEmail = timeSheetSelectEmployeeCB.SelectedItem.ToString();
            int year, month;
            int.TryParse(yearCB.SelectedItem.ToString(), out year);
            int.TryParse(monthCB.SelectedItem.ToString(), out month);
            var selectedEmployee = context.Employee.First(se => se.email.Equals(selectedEmail));
            var selectedTimeSheetMonth = context.TimeSheetMonth.First(m => m.year.Equals(year) && m.month.Equals(month));
            int id = selectedTimeSheetMonth.Id;
            var paymentToUpdate = context.Payment.FirstOrDefault(p => p.employeeId.Equals(selectedEmployee.Id) 
                                                        && p.timesheetMonthId.Equals(selectedTimeSheetMonth.Id));
            if (paymentToUpdate != null)
            {
                // TODO: update payment 
                MessageBox.Show("should be updated!");
            }
            else
            {
                // create payment table 
                paymentToUpdate = new Payment
                {
                   // TODO: the logic for creating payment should be added
                    employeeId = selectedEmployee.Id,
                    timesheetMonthId = selectedTimeSheetMonth.Id,
                    hourlyRate = selectedEmployee.hourlyRate ?? 0, // check null value, hourly rate in payment is not null
                    gross = 0,
                    ei = 0,
                    net = 0,
                    tax = 0
                };
            }
            context.SaveChanges();
            paymentGridView.DataSource = context.Payment.Local.ToBindingList();
        }
        
        private void loadEmployeeGridView()
        {
            var employeList = from employee in context.Employee
                             select employee;
           foreach(Employee e in employeList)
           {
               Console.WriteLine(e.email + " " + e.firstName);
           }
            EmployeeGridView.DataSource = context.Employee.Local.ToBindingList();
        }
        // Display Employee Gridview
        private void loadTimesheetGridView(string email = null, int month = 0, int year = 0)
        {
            if (email == null || month == 0 || year ==0)
                return;

            // gets all timesheet list matching year, month and employee email
            var timeSheetList = from timesheet in context.TimeSheet
                                    where timesheet.Employee.email.Equals(email)
                                    && timesheet.TimeSheetMonth.month.Equals(month)
                                    && timesheet.TimeSheetMonth.year.Equals(year)
                                    select new
                                    {
                                        Month = timesheet.TimeSheetMonth.month,
                                        Day = timesheet.day,
                                        HoursWorked = timesheet.hoursWorked
                                    };
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
                if (employeeToUpdate != null)
                {
                    employeeToUpdate.hourlyRate = newRate;
                    context.SaveChanges();
                    MessageBox.Show("email :" + email + " new rate: " + newRate + " successfully saved!");
                } 
            }
            else
            {
                MessageBox.Show("Please enter valid input");
            }
            loadEmployeeGridView();
        }

        // if employee is selected, load month and year combobox
        private void TimeSheetSelectEmployeeCB_DropDownClosed(object sender, EventArgs e)
        {
            MessageBox.Show("selected item = " + timeSheetSelectEmployeeCB.SelectedItem);
            string selectedEmail = timeSheetSelectEmployeeCB.SelectedItem.ToString();
            // load month and year combobox 
            var selectedEmployee = context.Employee.First(se => se.email.Equals(selectedEmail));
            var timesheetList= from timesheet in context.TimeSheet
                                    where timesheet.employeeId == selectedEmployee.Id
                                    select timesheet;
            foreach(EF.TimeSheet t in timesheetList)
            {
                if(!monthCB.Items.Contains(t.TimeSheetMonth.month))
                    monthCB.Items.Add(t.TimeSheetMonth.month);
                if (!yearCB.Items.Contains(t.TimeSheetMonth.year))
                    yearCB.Items.Add(t.TimeSheetMonth.year);
            }
        }

        
        // load employee in comboBox
        private void loadComboBox()
        {
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
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void yearCB_SelectedIndexChanged(object sender, EventArgs e)
        {

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
