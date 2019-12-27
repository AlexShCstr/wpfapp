using System.Data.Entity;

namespace WpfApp.repository
{
    class EmployeeRepository : AbstractDBRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IEmployeeCollectionAccessor collectionAccessor, DbContext dbContext) : base(collectionAccessor.GetEmployees(), dbContext)
        {

        }       
                

    }
}
