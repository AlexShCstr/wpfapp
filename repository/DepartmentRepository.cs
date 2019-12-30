using System.Data.Entity;
using System.Net.Http;

namespace WpfApp.repository
{
    class DepartmentRepository : AbstractWebApiRepository<Department>, IDepartmentRepository
    {       
        public DepartmentRepository(HttpClient client) : base(client)
        {

        }

        internal override string GetCollectionUrlString()
        {
            return "api/departments";
        }
    }
}
