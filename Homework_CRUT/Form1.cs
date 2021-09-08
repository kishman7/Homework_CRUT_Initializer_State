using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_CRUT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Employee employee = new Employee();
                employee.Name = textBox1.Text;
                employee.Surname = textBox2.Text;
                employee.Age = int.Parse(textBox3.Text);
                employee.Salary = int.Parse(textBox4.Text);
                employee.Position = db.Positions.FirstOrDefault(x => x.Title == textBox5.Text) ?? new Position { Title = textBox5.Text }; //буде створюватись нова posotion, якщо її ще немає в списку
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var employee = db.Employees.ToList();
                foreach (var item in employee)
                {
                    MessageBox.Show(item.Id + ". " + item.Name + " " + item.Surname + ", " + item.Age + " years old, "
                        + item.Salary + "$, " + item.Position.Title + ", " + item.Tasks);
                    Console.WriteLine(item.Id + ". " + item.Name + " " + item.Surname + ", " + item.Age + " years old, "
                        + item.Salary + "$, " + item.Position.Title + ", " + item.Tasks.FirstOrDefault().Title);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int idDelete = int.Parse(textBox7.Text);
                Employee employee = db.Employees.FirstOrDefault(x => x.Id == idDelete);
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int idEdit = int.Parse(textBox8.Text);
                Employee employee = db.Employees.FirstOrDefault(x => x.Id == idEdit);
                employee.Salary = double.Parse(textBox9.Text);
                if (employee != null)
                {
                    db.SaveChanges();
                }
            }
        }
    }
}
