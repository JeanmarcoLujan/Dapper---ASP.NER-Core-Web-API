using Dapper;
using DapperASPNetCore.Context;
using DapperASPNetCore.Contracts;
using DapperASPNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperASPNetCore.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM Employees";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Employee>(query);
                return companies.ToList();
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var query = "SELECT * FROM Employees WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QuerySingleOrDefaultAsync<Employee>(query, new { id });
                return employee;
            }
        }

    }
}
