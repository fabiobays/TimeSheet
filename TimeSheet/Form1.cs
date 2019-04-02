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

            // load users from database 
            loadEmployee();
            // register admin button 
            AdminBtn.Click += AdminBtn_Click;
            // register User button 
            userBtn.Click += UserBtn_Click;

        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("user clicekd!");
            this.Hide();
            // remove this comment
           // new EmployeeForm().Show();
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            //Application.Run(new AdminForm());
            this.Hide();
            new AdminForm().Show();
        }

        private void loadEmployeeComboBox()
        {
            var employeeNames = (from employee in context.Employee
                                 select employee).ToList();

            foreach (Employee e in employeeNames)
            {
                Console.WriteLine("firstName: " + e.firstName);
                usersCB.Items.Add(e.firstName);
            }
        }
        private void loadEmployee()
        {
           
            // mock employee data
            List<Employee> employees = new List<Employee>()  {
                new Employee { firstName = "firstName1", lastName = "lastName1", address ="address1",
                            email = "email", hourlyRate = 10, phone ="000-000-000"},
                new Employee { firstName = "firstName2", lastName = "lastName2", address ="address1",
                            email = "email", hourlyRate = 10, phone ="000-000-000"},
                new Employee { firstName = "firstName3", lastName = "lastName3", address ="address1",
                            email = "email", hourlyRate = 10, phone ="000-000-000"},
            };
         
            context.Employee.AddRange(employees);
            context.SaveChanges();

            loadEmployeeComboBox();
        }
    }
}
