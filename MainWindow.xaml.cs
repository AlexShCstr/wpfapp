using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.repository;
using WpfApp.view;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IEmployeeRepository employeeRepository;
        static HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:44362/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            departmentRepository = new DepartmentRepository(client);
            employeeRepository = new EmployeeRepository(client);

            FillData();

            listDepartments.MouseDoubleClick += OnDepartmentDblClick;
            buttonAddDepartment.Click += OnAddDepartmentClick;
            buttonRemoveDepartment.Click += OnRemoveDepartmentClick;
            
            listEmployees.MouseDoubleClick += OnEmployeeDblClick;
            buttonAddEmployee.Click += OnAddEmployeeClick;
            buttonRemoveEmployee.Click += OnRemoveEmployeeClick;

        }

        private async void FillData()
        {
            listDepartments.ItemsSource = await departmentRepository.All();
            listEmployees.ItemsSource = await employeeRepository.All();
        }

        private void OnRemoveEmployeeClick(object sender, RoutedEventArgs e)
        {
            Employee selectedItem = (Employee)listEmployees.SelectedItem;
            if (selectedItem != null)
            {
                employeeRepository.Delete(selectedItem);
            }
        }

        private async void OnAddEmployeeClick(object sender, RoutedEventArgs e)
        {
            ICollection<Department> Departments = (ICollection<Department>)await departmentRepository.All();
            Employee employee = EmployeeEdit.Create(Departments);
            if (employee != null)
            {
                employeeRepository.Insert(employee);
            }
        }


        private async void OnEmployeeDblClick(object sender, MouseButtonEventArgs e)
        {
            Employee selectedItem = (Employee)listEmployees.SelectedItem;
            if (selectedItem != null)
            {
                ICollection<Department> Departments = (ICollection<Department>)await departmentRepository.All();
                EmployeeEdit.Edit(selectedItem, (ICollection<Department>)Departments);
            }
        }

        private void OnRemoveDepartmentClick(object sender, RoutedEventArgs e)
        {
            Department selectedItem = (Department)listDepartments.SelectedItem;
            if (selectedItem != null)
            {
                departmentRepository.Delete(selectedItem);
            }
        }

        private void OnAddDepartmentClick(object sender, RoutedEventArgs e)
        {
            Department department = DepartmentEdit.Create();
            if (department != null)
            {
                departmentRepository.Insert(department);
            }
        }

        private void OnDepartmentDblClick(object sender, MouseButtonEventArgs e)
        {
            Department selectedItem = (Department)listDepartments.SelectedItem;
            if (selectedItem != null)
            {
                DepartmentEdit.Edit(selectedItem);
            }
        }

    }
}
