using CNet.App.Core.Dtos;

namespace CNet.App.Core.Contracts
{
    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);

        ManagerDto ManagerInfo(int managerId);
    }
}
