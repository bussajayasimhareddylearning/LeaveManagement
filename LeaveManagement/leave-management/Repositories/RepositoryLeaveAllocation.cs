using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repositories
{
    public class RepositoryLeaveAllocation : IRepositoryLeaveAllocation
    {
        private readonly ApplicationDbContext _db;
        public RepositoryLeaveAllocation(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }
        public bool IsExists(int id)
        {
            return _db.LeaveAllocations.Any(q => q.Id == id);
        }
        public ICollection<LeaveAllocation> FindAll()
        {
            return _db.LeaveAllocations.Include(x=>x.LeaveType).Include(y=>y.Employee)
                .ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.LeaveAllocations.Include(x => x.LeaveType).Include(y => y.Employee).FirstOrDefault(x=>x.Id==id);
        }

        public ICollection<LeaveAllocation> GetEmployeesByLeaveAllocation(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }

        public bool CheckLeaveAllocation(string EmployeeID, int LeaveTypeID)
        {
            return FindAll().Where(x => x.EmployeeID == EmployeeID && x.LeaveTypeID == LeaveTypeID && x.Period == DateTime.Now.Year).Any();
        }
        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                    .Where(q => q.EmployeeID == employeeid && q.Period == period)
                    .ToList();
        }

        public LeaveAllocation GetLeaveAllocationsByEmployeeAndType(string employeeid, int leavetypeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                    .FirstOrDefault(q => q.EmployeeID == employeeid && q.Period == period && q.LeaveTypeID == leavetypeid);
        }
    }
}
