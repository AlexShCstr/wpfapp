using System.Data.Entity;

namespace WpfApp.repository
{
    class DepartmentRepository : AbstractDBRepository<Department>, IDepartmentRepository
    {       
        public DepartmentRepository(IDepartmentCollectionAccessor collectionAccessor, DbContext dbContext) : base(collectionAccessor.GetDepartments(), dbContext)
        {

        }
    }
}
