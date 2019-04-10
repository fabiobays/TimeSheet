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
    public partial class Form1 : Form
    {
        private ProjectEntities context;
        public Form1()
        {
            context = new ProjectEntities();

            InitializeComponent();

            context.Database.Delete();
            context.Database.Create();

            // load users from database and mock the data
            MockData();
            // register admin button 
            AdminBtn.Click += AdminBtn_Click;
            // register User button 
            userBtn.Click += UserBtn_Click;

            this.FormClosed += Form1_FormClosed;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Database.Connection.Dispose();
            context.Dispose();
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            if(usersCB.SelectedItem == null)
            {
                MessageBox.Show("Please Select a User!");
                return;
            }
            this.Hide();
            var email = usersCB.SelectedItem.ToString();
            var userId = context.Employee.FirstOrDefault(p => p.email == email);
            new EmployeeForm(userId.Id,context,this).Show();
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            //Application.Run(new AdminForm());
            this.Hide();
            new AdminForm(this).Show();
        }

        private void loadEmployeeComboBox()
        {
            var employeeNames = (from employee in context.Employee
                                 select employee).ToList();

            foreach (Employee e in employeeNames)
            {                
                usersCB.Items.Add(e.email);
            }
        }
        private void loadEmployee()
        {
           
            // mock employee data
            List<Employee> employees = new List<Employee>()  {
                new Employee { firstName = "Fabio", lastName = "Bays", address ="221 7th St",
                            email = "fabiobays@gmail.com", hourlyRate = 35, phone ="604-338-6711"},
                new Employee { firstName = "Cleidi", lastName = "Prado", address ="7880 Mayfield St",
                            email = "cleidiprado@gmail.com", hourlyRate = 18, phone ="604-365-4512"},
                new Employee { firstName = "Matheus", lastName = "Prado", address ="7558 19 Ave",
                            email = "matheus2002@gmail.com", hourlyRate = 13, phone ="604-555-5689"},
            };
         
            context.Employee.AddRange(employees);
            context.SaveChanges();

            loadEmployeeComboBox();
        }

        private void MockData()
        {
            loadEmployee();
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
    }
}
