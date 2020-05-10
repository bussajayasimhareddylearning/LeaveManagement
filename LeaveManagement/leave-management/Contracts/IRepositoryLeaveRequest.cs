using leave_management.Data;
using System.Collections.Generic;

namespace leave_management.Contracts
{
    public interface IRepositoryLeaveRequest : IRepositoryBase<LeaveRequest>
    {
        ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string employeeid);
    }
}
