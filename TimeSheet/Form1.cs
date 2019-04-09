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

            // load users from database 
            loadEmployee();
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
    }
}
