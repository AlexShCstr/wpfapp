using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfApp.domain;

namespace WpfApp.view
{
    /// <summary>
    /// Логика взаимодействия для EmployeeEdit.xaml
    /// </summary>
    public partial class EmployeeEdit : Window
    {
        private readonly ICollection<Department> departments;
        private readonly Employee employee;
        public EmployeeEdit(ICollection<Department> departments) : this(new Employee(), departments)
        {

        }

        public EmployeeEdit(Employee employee, ICollection<Department> departments)
        {
            this.employee = employee;
            this.departments = departments;
            InitializeComponent();

            comboDepartment.ItemsSource = departments;
            textFirstName.Text = employee.Firstname;
            textLastName.Text = employee.Lastname;
            textMiddleName.Text = employee.Middlename;
            if (employee.department != null)
            {
                comboDepartment.SelectedItem = employee.department;
            }
            else
                comboDepartment.SelectedIndex = 0;

            textLastName.TextChanged += LastNameChanged;

            buttonApply.Click += OnApplyClick;
            UpdateApplyVisibility();
        }

        private void LastNameChanged(object sender, TextChangedEventArgs e)
        {
            UpdateApplyVisibility();
        }

        private void UpdateApplyVisibility()
        {
            buttonApply.Visibility = textLastName.Text.Trim().Length > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void OnApplyClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        public static bool Edit(Employee employee, ICollection<Department> departments)
        {
            EmployeeEdit employeeEdit = new EmployeeEdit(employee, departments);
            if (employeeEdit.ShowDialog().GetValueOrDefault(false))
            {
                FillEmployee(employeeEdit, employee);
                return true;
            }
            return false;
        }

        public static Employee Create(ICollection<Department> departments)
        {

            EmployeeEdit employeeEdit = new EmployeeEdit(departments);
            if (employeeEdit.ShowDialog().GetValueOrDefault(false))
            {
                Employee employee = employeeEdit.employee;
                FillEmployee(employeeEdit, employee);
                return employee;
            }
            return null;
        }

        private static void FillEmployee(EmployeeEdit employeeEdit, Employee employee)
        {
            employee.Firstname = employeeEdit.textFirstName.Text;
            employee.Lastname = employeeEdit.textLastName.Text;
            employee.Middlename = employeeEdit.textMiddleName.Text;
            employee.department = (Department)employeeEdit.comboDepartment.SelectedItem;
        }

    }
}
