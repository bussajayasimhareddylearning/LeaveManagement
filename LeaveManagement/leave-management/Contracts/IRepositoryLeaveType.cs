using leave_management.Data;
using System.Collections.Generic;

namespace leave_management.Contracts
{
    public interface IRepositoryLeaveType : IRepositoryBase<LeaveType>
    {
        ICollection<LeaveType> GetEmployeesByLeaveType(int Id);
    }
}
