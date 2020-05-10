using leave_management.Data;
using System.Collections.Generic;

namespace leave_management.Contracts
{
    public interface IRepositoryLeaveAllocation : IRepositoryBase<LeaveAllocation>
    {
        bool CheckLeaveAllocation(string EmployeeID, int LeaveTypeID);
        ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id);

        LeaveAllocation GetLeaveAllocationsByEmployeeAndType(string employeeid, int leavetypeid);
    }
}
