using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
        private readonly DBNameEntities dBNameEntities = new DBNameEntities();
        private readonly IDepartmentRepository departmentRepository;
        private readonly IEmployeeRepository employeeRepository;

        public BindingList<Employee> Employees => dBNameEntities.Employee.Local.ToBindingList();
        public BindingList<Department> Departments => dBNameEntities.Department.Local.ToBindingList();
        public MainWindow()
        {
            dBNameEntities.Employee.Load();
            dBNameEntities.Department.Load();
            departmentRepository = new DepartmentRepository(dBNameEntities, dBNameEntities);
            employeeRepository = new EmployeeRepository(dBNameEntities, dBNameEntities);
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
            Employee employee = EmployeeEdit.Create(Departments);
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
                EmployeeEdit.Edit(selectedItem, Departments);
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

        private void FillData()
        {
            if (Departments.Count > 0 || Employees.Count > 0) return;

            Department department1 = departmentRepository.Insert(new Department() { NAME = "Бухгалтерия" });
            Department department2 = departmentRepository.Insert(new Department() { NAME = "Склад" });
            Department department3 = departmentRepository.Insert(new Department() { NAME = "Гараж" });
            Department department4 = departmentRepository.Insert(new Department() { NAME = "Кадры" });

            employeeRepository.Insert(new Employee() {FIRSTNAME= "Иван",LASTNAME= "Иванов", Midllename="Иванович" ,Department=department1});
            employeeRepository.Insert(new Employee() { FIRSTNAME = "Иван", LASTNAME = "Петров", Midllename = "Петрович", Department = department2 });
            employeeRepository.Insert(new Employee() { FIRSTNAME = "Пётр", LASTNAME = "Иванов", Midllename = "Романовия", Department = department3 });
            employeeRepository.Insert(new Employee() { FIRSTNAME = "Сергей", LASTNAME = "Иванов", Midllename = "Сергеевич", Department = department4 });
            employeeRepository.Insert(new Employee() { FIRSTNAME = "Андрей", LASTNAME = "Андреев", Midllename = "Романович", Department = department1 });
            employeeRepository.Insert(new Employee() { FIRSTNAME = "Игорь", LASTNAME = "Комаров", Midllename = "Иванович", Department = department2 });
        }
    }
}
