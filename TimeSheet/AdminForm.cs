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
    public partial class AdminForm : Form
    {
        // private data context field 
        private ProjectEntities context;

        public AdminForm()
        {
            context = new ProjectEntities();

            InitializeComponent();


            // register creating Emplyoee button 
            registerEmployeeBtn.Click += RegisterEmployeeBtn_Click;
        }

        private void RegisterEmployeeBtn_Click(object sender, EventArgs e)
        {
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
        }
    }
}
