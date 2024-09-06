using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Services.Interfaces;

namespace Company.Services.Services
{
    public class DepartmentServices : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentServices(IUnitOfWork unitOfWork)

            => _unitOfWork=unitOfWork;

        public void Add(Department department)
        {
            var mappedDepartment = new Department
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = DateTime.Now

            };
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);
            _unitOfWork.Complete();
        }

        public void Delete(Department department)
        {

           _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Complete();
        }

        public IEnumerable<Department> GetAll()
        {
            var departments= _unitOfWork.DepartmentRepository.GetAll();
            return departments;
        }

        public Department GetById(int? id)
        {
            if (id is null)
                return null;

            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);

            if (department is null)
                return null;

            return department;

        }

        public void Update(Department department)
        {
            //var dept = GetById(department.Id);

            //if (dept.Name != department.Name)
            //{
            //    if (GetAll().Any(x => x.Name == department.Name)) ;
            //    throw new Exception("DuplicateDepartmentName");
            //}
            //dept.Name = department.Name;
            //dept.Code = department.Code;

            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();
        }
        
      


    }
}
