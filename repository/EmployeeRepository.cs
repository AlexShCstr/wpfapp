using System.Data.Entity;
using System.Net.Http;

namespace WpfApp.repository
{
    class EmployeeRepository : AbstractWebApiRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HttpClient client) : base(client)
        {

        }

        internal override string GetCollectionUrlString()
        {
            return "api/employees";
        }
    }
}
