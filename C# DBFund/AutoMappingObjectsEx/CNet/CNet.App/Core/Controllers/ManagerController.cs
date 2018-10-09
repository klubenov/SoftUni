using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CNet.App.Core.Controllers
{
    using System;
    using AutoMapper;
    using Contracts;
    using Dtos;
    using Data;

    public class ManagerController : IManagerController
    {
        private readonly CNetContext context;
        private readonly IMapper mapper;

        public ManagerController(CNetContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = context.Employees.Find(employeeId);

            var manager = context.Employees.Find(managerId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employeeId!");
            }

            if (manager == null)
            {
                throw new ArgumentException("Invalid managerId!");
            }

            employee.Manager = manager;

            context.SaveChanges();
        }

        public ManagerDto ManagerInfo(int managerId)
        {
            var manager = context.Employees.Include(x => x.ManagerEmployees).SingleOrDefault(x => x.Id == managerId);

            if (manager == null)
            {
                throw new ArgumentException("Invalid managerId!");
            }

            var managerDto = mapper.Map<ManagerDto>(manager);

            return managerDto;
        }
    }
}
