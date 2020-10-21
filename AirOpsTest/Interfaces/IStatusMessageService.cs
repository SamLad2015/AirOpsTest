using System.Collections.Generic;
using System.Threading.Tasks;
using AirOpsTest.DtoS;

namespace AirOpsTest.Interfaces
{
    public interface IStatusMessageService
    {
        Task<IList<string>> GetAll();
        void AddMessage(StatusMessageModel model);
    }
}