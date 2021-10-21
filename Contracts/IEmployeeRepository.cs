using DapperASPNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperASPNetCore.Contracts
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(int id);
    }
}
