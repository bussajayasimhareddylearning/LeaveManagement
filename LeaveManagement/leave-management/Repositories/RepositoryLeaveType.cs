﻿using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repositories
{
    public class RepositoryLeaveType : IRepositoryLeaveType
    {
        private readonly ApplicationDbContext _db;
        public RepositoryLeaveType(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveType entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(LeaveType entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<LeaveType> FindAll()
        {
            throw new NotImplementedException();
        }

        public LeaveType FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(LeaveType entity)
        {
            throw new NotImplementedException();
        }
    }
}
