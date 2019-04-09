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

        public AdminForm()
        {
            context = new ProjectEntities();

            InitializeComponent();

            // load emnploee email for combo box
            loadComboBox();
            loadGridView();
            // register creating Emplyoee button 
            registerEmployeeBtn.Click += RegisterEmployeeBtn_Click;
            // register update houly rate
            setHourBtn.Click += SetHourBtn_Click;
        }

        // Display Employee Gridview
        private void loadGridView()
        {
            var employeList = from employee in context.Employee
                              select employee;
           foreach(Employee e in employeList)
            {
                Console.WriteLine(e.email + " " + e.firstName);
            }
            EmployeeGridView.DataSource = context.Employee.Local.ToBindingList();
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
            loadGridView();
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
