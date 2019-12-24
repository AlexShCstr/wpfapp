using System;
using System.Windows;
using System.Windows.Input;
using WpfApp.domain;

namespace WpfApp.view
{
    /// <summary>
    /// Логика взаимодействия для DepartmentEdit.xaml
    /// </summary>
    public partial class DepartmentEdit : Window
    {

        private Department department;

        public Department Department { get => department; set => department = value; }

        public DepartmentEdit(): this(new Department(""))
        {
            
        }

        public DepartmentEdit(Department department)
        {
            this.Department = department;
            InitializeComponent();
            this.DataContext = department;
            buttonApply.Click += OnApplyClick;
        }

        private void OnApplyClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        public static bool Edit(Department department)
        {
            DepartmentEdit departmentEdit = new DepartmentEdit(department);
            if (departmentEdit.ShowDialog().GetValueOrDefault(false))
            {
                department.Name = departmentEdit.textName.Text;
                return true;
            }
            return false;
        }

        public static Department Create()
        {
            DepartmentEdit departmentEdit = new DepartmentEdit();
            if (departmentEdit.ShowDialog().GetValueOrDefault(false))
            {
                departmentEdit.Department.Name = departmentEdit.textName.Text;
                return departmentEdit.Department;
            }
            return null;
        }

    }
}
