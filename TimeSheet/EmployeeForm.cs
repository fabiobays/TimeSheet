using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeSheet.EF;

namespace TimeSheet
{
    public partial class EmployeeForm : Form
    {
        private ProjectEntities context;
        int UserId { get; set; }
        private Form ParentForm;
        public EmployeeForm(int userId, ProjectEntities context, Form parentForm)
        {
            this.UserId = userId;
            this.context = context;
            this.ParentForm = parentForm;
            InitializeComponent();
            this.Load += EmployeeForm_Load;
            this.FormClosed += EmployeeForm_FormClosed;
            dataGridViewTimeSheet.CellLeave += DataGridViewTimeSheet_CellLeave;
            this.comboBoxPaymentMonth.SelectedIndexChanged += ComboBoxPaymentMonth_SelectedIndexChanged;
            this.comboBoxPaymentYear.SelectedIndexChanged += ComboBoxPaymentYear_SelectedIndexChanged;
            this.btUpdate.Click += BtUpdate_Click;
            this.btSave.Click += BtSave_Click;
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            SaveTimeSheet();            
        }

        private void SaveTimeSheet()
        {
            try
            {
                var month = comboBoxPaymentMonth.SelectedIndex + 1;
                var year = int.Parse(comboBoxPaymentYear.SelectedItem.ToString());

                //Check if there is a record for the Table TimeSheetMonth for the current year and month, if there is not it means it is the first time the employee is saving its timesheet this month
                var tsm = context.TimeSheetMonth.FirstOrDefault(p => p.employeeId == UserId && p.month == month && p.year == year);
                if (tsm == null)
                {
                    TimeSheetMonth timeSheetMonth = new TimeSheetMonth { employeeId = UserId, month = month, year = year, totalHours = 0 };
                    context.TimeSheetMonth.Add(timeSheetMonth);
                    context.SaveChanges();
                }

                var currentMonthTimeSheet = context.TimeSheetMonth.FirstOrDefault(p => p.employeeId == UserId && p.month == month && p.year == year);
                decimal totalHours = 0.0M;
                foreach (DataGridViewRow row in dataGridViewTimeSheet.Rows)
                {
                    var day = (int)row.Cells[0].Value;
                    var hoursWorked = decimal.Parse(row.Cells[1].Value.ToString());
                    //Look if the day is already in the database for that month, if it is, only updates its hoursworked value if it is not add it to the database
                    var currentTimeSheet = context.TimeSheet.FirstOrDefault(p => p.timesheetMonthId == currentMonthTimeSheet.Id && p.day == day);
                    if (currentTimeSheet != null)
                    {
                        currentTimeSheet.hoursWorked = hoursWorked;
                        context.SaveChanges();
                    }
                    else
                    {
                        EF.TimeSheet timeSheet = new EF.TimeSheet() { employeeId = UserId, timesheetMonthId = currentMonthTimeSheet.Id, day = day, hoursWorked = hoursWorked };
                        context.TimeSheet.Add(timeSheet);
                        context.SaveChanges();
                    }
                    totalHours += hoursWorked;
                    //Do the samething for the second and third columns (days 16-31)
                    day = (int)row.Cells[2].Value;
                    hoursWorked = decimal.Parse(row.Cells[3].Value.ToString());
                    currentTimeSheet = context.TimeSheet.FirstOrDefault(p => p.timesheetMonthId == currentMonthTimeSheet.Id && p.day == day);
                    if (currentTimeSheet != null)
                    {
                        currentTimeSheet.hoursWorked = hoursWorked;
                        context.SaveChanges();
                    }
                    else
                    {
                        EF.TimeSheet timeSheet = new EF.TimeSheet() { employeeId = UserId, timesheetMonthId = currentMonthTimeSheet.Id, day = day, hoursWorked = hoursWorked };
                        context.TimeSheet.Add(timeSheet);
                        context.SaveChanges();
                    }

                    totalHours += hoursWorked;
                    currentMonthTimeSheet.totalHours = totalHours;
                    context.SaveChanges();


                }

                MessageBox.Show("Timesheet Saved Successfully!");
            }
            catch(Exception e)
            {
                MessageBox.Show("Something went wrong, your timesheet was not saved!");
            }
            
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxFirstName.Text) &&
               !String.IsNullOrEmpty(textBoxLastName.Text) &&
               !String.IsNullOrEmpty(textBoxPhone.Text))
            {
                try
                {
                    var employee = context.Employee.FirstOrDefault(p => p.Id == UserId);
                    if (employee != null)
                    {
                        employee.firstName = textBoxFirstName.Text.Trim();
                        employee.lastName = textBoxLastName.Text.Trim();
                        employee.phone = textBoxPhone.Text.Trim();

                        context.SaveChanges();

                        MessageBox.Show("Personal Info updated successfully!");
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please enter valid information!");
            }
        }

        private void ComboBoxPaymentYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPaymentAndTimeSheet();
        }

        private void ComboBoxPaymentMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPaymentAndTimeSheet();
        }

        private void LoadPaymentAndTimeSheet()
        {
            var month = comboBoxPaymentMonth.SelectedIndex + 1;
            var year = int.Parse(comboBoxPaymentYear.SelectedItem.ToString());
            var timeSheetMonth = context.TimeSheetMonth.FirstOrDefault(p => p.month == month && p.year == year && p.employeeId == UserId);
            if (timeSheetMonth != null)
            {
                var payment = context.Payment.FirstOrDefault(p => p.employeeId == UserId && p.timesheetMonthId == timeSheetMonth.Id);
                if (payment != null)
                {
                    object[] regularPay = {"Regular Pay", timeSheetMonth.totalHours, payment.hourlyRate, payment.gross };
                    dataGridViewTotalPay.Rows.Add(regularPay);
                    
                    object[] tax = {"Income Tax", payment.tax};
                    dataGridViewTaxes.Rows.Add(tax);

                    object[] ei = { "Employment Insurance", payment.ei };
                    dataGridViewTaxes.Rows.Add(ei);

                    object[] cpp = { "Canada Pension Plan", payment.cpp };
                    dataGridViewTaxes.Rows.Add(cpp);

                    dataGridViewTotalPay.Refresh();
                    dataGridViewTaxes.Refresh();

                    var taxes = payment.tax + payment.ei + payment.cpp;

                    textBoxTotalPay.Text = payment.gross.ToString("C2");
                    textBoxTaxes.Text = taxes.ToString("C2");
                    textBoxNetPay.Text = payment.net.ToString("C2");
                }

                LoadTimeSheet();
            }
            
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {       
            ParentForm.Show();
        }

        private void DataGridViewTimeSheet_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            decimal hours;
            if(!Decimal.TryParse(dataGridViewTimeSheet.CurrentCell.GetEditedFormattedValue(dataGridViewTimeSheet.CurrentRow.Index,DataGridViewDataErrorContexts.Display).ToString(),out hours))
            {
                MessageBox.Show("Please enter a numeric value for your hours");
                dataGridViewTimeSheet.CurrentCell.Value = 0;
                dataGridViewTimeSheet.RefreshEdit();

            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            MockData();
            LoadPersonalInfo();
            //Initialize the datagridview for the timesheet of the current month
            InitializeTimeSheet();
            LoadComboBox();
            LoadTimeSheet();



        }

        private void LoadPersonalInfo()
        {
            var user = context.Employee.FirstOrDefault(p => p.Id == UserId);
            if (user != null)
            {
                textBoxFirstName.Text = user.firstName;
                textBoxLastName.Text = user.lastName;
                textBoxPhone.Text = user.phone;
            }
            else {
                MessageBox.Show("User not found!");
                this.Close();
            }
        }

        private void MockData()
        {
            List<TimeSheetMonth> tsm = new List<TimeSheetMonth>()
            {
                new TimeSheetMonth { employeeId = 1, month = 3, totalHours = 84, year = 2019 },
                new TimeSheetMonth { employeeId = 2, month = 3, totalHours = 168, year = 2019 },
                new TimeSheetMonth { employeeId = 3, month = 3, totalHours = 84, year = 2019 },
                new TimeSheetMonth { employeeId = 1, month = 4, totalHours = 40, year = 2019 },

            };

            context.TimeSheetMonth.AddRange(tsm);
            context.SaveChanges();

            List<EF.TimeSheet> ts = new List<EF.TimeSheet>()
            {
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 1 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 0 , day = 2 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 0 , day = 3 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 4 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 5 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 6 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 7 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 8 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 0 , day = 9 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 0 , day = 10 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 11 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 12 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 13 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 14 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 15 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 0 , day = 16 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 0 , day = 17 },                
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 18 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 19 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 20 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 21 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 22 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 0 , day = 23 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 0 , day = 24},
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 25 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 26 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 27 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 28 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 4 , day = 29 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 0 , day = 30 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 1, hoursWorked = 0 , day = 31 },

                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 1 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 0 , day = 2 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 0 , day = 3 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 4 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 5 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 6 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 7 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 8 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 0 , day = 9 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 0 , day = 10 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 11 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 12 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 13 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 14 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 15 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 0 , day = 16 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 0 , day = 17 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 18 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 19 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 20 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 21 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 22 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 0 , day = 23 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 0 , day = 24 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 25 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 26 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 27 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 28 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 8 , day = 29 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 0 , day = 30 },
                new EF.TimeSheet { employeeId = 2, timesheetMonthId = 2, hoursWorked = 0 , day = 31 },

                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 1 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 0 , day = 2 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 0 , day = 3 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 4 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 5 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 6 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 7 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 8 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 0 , day = 9 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 0 , day = 10 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 11 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 12 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 13 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 14 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 15 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 0 , day = 16 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 0 , day = 17 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 18 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 19 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 20 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 21 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 22 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 0 , day = 23 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 0 , day = 24 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 25 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 26 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 27 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 28 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 4 , day = 29 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 0 , day = 30 },
                new EF.TimeSheet { employeeId = 3, timesheetMonthId = 3, hoursWorked = 0 , day = 31 },

                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 4 , day = 1 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 4 , day = 2 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 4 , day = 3 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 4 , day = 4 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 4 , day = 5 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 0 , day = 6 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 0 , day = 7 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 4 , day = 8 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 4 , day = 9 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 4 , day = 10 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 4 , day = 11 },
                new EF.TimeSheet { employeeId = 1, timesheetMonthId = 4, hoursWorked = 4 , day = 12 },
            };

            context.TimeSheet.AddRange(ts);
            context.SaveChanges();

            List<Payment> payments = new List<Payment>()
            {

                new Payment {employeeId = 1, timesheetMonthId = 1, gross = 2940, tax = 589.76M, ei = 47.92M, cpp = 131.09M, net = 2117.23M, hourlyRate = 35 }
            };

            context.Payment.AddRange(payments);
            //The other two finished timesheets must have been approved by the admin!!
            context.SaveChanges();
        }

        private void InitializeTimeSheet(int m = 0, int y = 0)
        {
            var month =  m == 0 ? DateTime.UtcNow.Month : m;
            var year = y == 0 ? DateTime.UtcNow.Year : y;
            var daysInMonth =  DateTime.DaysInMonth(year, month);
            dataGridViewTimeSheet.Rows.Clear();
            //Disabling the addition and deletion of rows
            dataGridViewTimeSheet.AllowUserToAddRows = false;
            dataGridViewTimeSheet.AllowUserToDeleteRows = false;
            for (int i = 1; i <= 16; i++)
            {

                //If the month has only 30, 29 or 28 days there is no need for an addtional row
                if ((daysInMonth == 30 || daysInMonth == 29 || daysInMonth == 28) && i == 16)
                    continue;

                dataGridViewTimeSheet.Rows.Add();
                
                //If the month has 31 days we need to disable the first two columns of the last row
                if (daysInMonth == 31 && i == 16)
                {
                    dataGridViewTimeSheet.Rows[i - 1].Cells[0].Style.BackColor = Color.DarkGray;
                    dataGridViewTimeSheet.Rows[i - 1].Cells[0].ReadOnly = true;
                    dataGridViewTimeSheet.Rows[i - 1].Cells[1].Style.BackColor = Color.DarkGray;
                    dataGridViewTimeSheet.Rows[i - 1].Cells[1].ReadOnly = true;
                    dataGridViewTimeSheet.Rows[i - 1].Cells[2].Value = 15 + i;
                    dataGridViewTimeSheet.Rows[i - 1].Cells[3].Value = 0;

                }
                else 
                {
                    dataGridViewTimeSheet.Rows[i - 1].Cells[0].Value = i;
                    dataGridViewTimeSheet.Rows[i - 1].Cells[1].Value = 0;
                    //Disabling necessary cells when the month has only 28 days (february)
                    if(daysInMonth == 28 && i >= 14)
                    {
                        dataGridViewTimeSheet.Rows[i - 1].Cells[2].Style.BackColor = Color.DarkGray;
                        dataGridViewTimeSheet.Rows[i - 1].Cells[2].ReadOnly = true;
                        dataGridViewTimeSheet.Rows[i - 1].Cells[3].Style.BackColor = Color.DarkGray;
                        dataGridViewTimeSheet.Rows[i - 1].Cells[3].ReadOnly = true;
                    }
                    //Disabling necewssary cells when the month has only 29 days (february every 4 years)
                    else if(daysInMonth == 29 && i >= 15)
                    {
                        dataGridViewTimeSheet.Rows[i - 1].Cells[2].Style.BackColor = Color.DarkGray;
                        dataGridViewTimeSheet.Rows[i - 1].Cells[2].ReadOnly = true;
                        dataGridViewTimeSheet.Rows[i - 1].Cells[3].Style.BackColor = Color.DarkGray;
                        dataGridViewTimeSheet.Rows[i - 1].Cells[3].ReadOnly = true;
                    }
                    else
                    { 
                        dataGridViewTimeSheet.Rows[i - 1].Cells[2].Value = 15 + i;
                        dataGridViewTimeSheet.Rows[i - 1].Cells[3].Value = 0;
                    }
                }
            }
        }

        private void LoadComboBox()
        {
            var date = DateTime.UtcNow;

            //Unsubscrive events to not trigger when loading the combobox
            comboBoxPaymentMonth.SelectedIndexChanged -= ComboBoxPaymentMonth_SelectedIndexChanged;
            comboBoxPaymentYear.SelectedIndexChanged -= ComboBoxPaymentYear_SelectedIndexChanged;
            comboBoxPaymentMonth.SelectedIndex = date.Month - 1;
            comboBoxPaymentYear.SelectedItem = date.Year.ToString();
            //Subscribe events after loading comboboxes
            comboBoxPaymentMonth.SelectedIndexChanged += ComboBoxPaymentMonth_SelectedIndexChanged;
            comboBoxPaymentYear.SelectedIndexChanged += ComboBoxPaymentYear_SelectedIndexChanged;

        }

        private void LoadTimeSheet()
        {
            var year = int.Parse(comboBoxPaymentYear.SelectedItem.ToString());
            var timeSheetMonth = context.TimeSheetMonth.FirstOrDefault(p => p.month == comboBoxPaymentMonth.SelectedIndex + 1 && p.year == year && p.employeeId == UserId);
            int timeSheetMonthId = 0;
            if (timeSheetMonth != null)
                timeSheetMonthId = timeSheetMonth.Id;
                
            var timeSheet = context.TimeSheet.Where(p => p.timesheetMonthId == timeSheetMonthId).OrderBy(p=>p.day).ToList();
            if(timeSheet != null)
            {
                InitializeTimeSheet(comboBoxPaymentMonth.SelectedIndex + 1, year);
                foreach(var t in timeSheet)
                {
                    var row = 0;
                    if (t.day <= 15)
                    { 
                        row = t.day -1;
                        dataGridViewTimeSheet.Rows[row].Cells[1].Value = t.hoursWorked;
                    }
                    else
                    {
                        row = ((t.day -1) % 15) ; //calculate the row on the datagridview that would represent the day
                        dataGridViewTimeSheet.Rows[row].Cells[3].Value = t.hoursWorked;
                    }
                        

                }

                dataGridViewTimeSheet.Refresh();
            }
            else
            {
                InitializeTimeSheet(); //Call the default initializer for the timesheet in case the employee havent submitted  the timesheet this month
            }

            
        }


    }
}
