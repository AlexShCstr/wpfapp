using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp.domain;
using WpfApp.repository;
using WpfApp.view;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDepartmentRepository departmentRepository = new DepartmentRepository();
        private readonly IEmployeeRepository employeeRepository = new EmployeeRepository();

        public ReadOnlyObservableCollection<Employee> Employees => employeeRepository.All();
        public ReadOnlyObservableCollection<Department> Departments => departmentRepository.All();
        public MainWindow()
        {           
            InitializeComponent();
            DataContext = this;

            listDepartments.MouseDoubleClick += OnDepartmentDblClick;
            buttonAddDepartment.Click += OnAddDepartmentClick;
            buttonRemoveDepartment.Click += OnRemoveDepartmentClick;

            listEmployees.MouseDoubleClick += OnEmployeeDblClick;
            buttonAddEmployee.Click += OnAddEmployeeClick;
            buttonRemoveEmployee.Click += OnRemoveEmployeeClick;

            FillData();
        }

        private void OnRemoveEmployeeClick(object sender, RoutedEventArgs e)
        {
            Employee selectedItem = (Employee)listEmployees.SelectedItem;
            if (selectedItem != null)
            {
                employeeRepository.Delete(selectedItem);
            }
        }

        private void OnAddEmployeeClick(object sender, RoutedEventArgs e)
        {
            Employee employee = EmployeeEdit.Create(departmentRepository.All());
            if (employee != null)
            {
                employeeRepository.Insert(employee);
            }
        }

        private void OnEmployeeDblClick(object sender, MouseButtonEventArgs e)
        {
            Employee selectedItem = (Employee)listEmployees.SelectedItem;
            if (selectedItem != null)
            {
                EmployeeEdit.Edit(selectedItem, departmentRepository.All());
            }
        }

        private void OnRemoveDepartmentClick(object sender, RoutedEventArgs e)
        {
            Department selectedItem = (Department)listDepartments.SelectedItem;
            if (selectedItem != null)
            {
                if (employeeRepository.hasEmployeesInDepartment(selectedItem))
                {
                    MessageBox.Show("Нельзя удалить отдел с сотрудниками");
                }
                else
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

        private void FillData()
        {
            departmentRepository.Insert(new domain.Department("Бухгалтерия"));
            departmentRepository.Insert(new domain.Department("Склад"));
            departmentRepository.Insert(new domain.Department("Гараж"));
            departmentRepository.Insert(new domain.Department("Кадры"));

            employeeRepository.Insert(new domain.Employee("Иван", "Иванов", "Иванович")).department = departmentRepository.FindById(1);
            employeeRepository.Insert(new domain.Employee("Иван", "Петров", "Петрович")).department = departmentRepository.FindById(2);
            employeeRepository.Insert(new domain.Employee("Пётр", "Иванов", "Романовия")).department = departmentRepository.FindById(3);
            employeeRepository.Insert(new domain.Employee("Сергей", "Иванов", "Сергеевич")).department = departmentRepository.FindById(1);
            employeeRepository.Insert(new domain.Employee("Андрей", "Андреев", "Романович")).department = departmentRepository.FindById(4);
            employeeRepository.Insert(new domain.Employee("Игорь", "Комаров", "Иванович")).department = departmentRepository.FindById(1);
        }
    }
}
