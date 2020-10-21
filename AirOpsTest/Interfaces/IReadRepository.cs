using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirOpsTest.Interfaces
{
    public interface IReadRepository<T> where T : class
    {
        Task<IList<string>> GetAll();
    }
}