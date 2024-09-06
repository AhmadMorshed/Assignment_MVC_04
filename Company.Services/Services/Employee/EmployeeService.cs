using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Employee employee)
        {
            var mappedEmployee = new Employee()
            {
                Name = employee.Name,
                Age= employee.Age,
                Address= employee.Address,
                Email= employee.Email,
                PhoneNumber= employee.PhoneNumber,
                HiringDate= employee.HiringDate,
                ImageUrl= employee.ImageUrl,
                Department= employee.Department,
                DepartmentId= employee.DepartmentId,

            };
            _unitOfWork.EmployeeRepository.Add(mappedEmployee);
            _unitOfWork.Complete();
        }

        public void Delete(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<Employee> GetAll()
        {
            var employee=_unitOfWork.EmployeeRepository.GetAll();
            return employee;
        }

        public Employee GetById(int? id)
        {

            if (id is null)
                return null;

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employee is null)
                return null;

            return employee;
        }

        public void Update(Employee employee)
        {
           _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }
    }
}
