using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data.Repositories;
using Contoso.Model;

namespace Contoso.Service
{
   public class DepartmentService: IDepartmentService
   {
       private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void CreateDepartment(Department department)
        {
            _departmentRepository.Add(department);
            _departmentRepository.SaveChanges();
        }

        public void DeleteDepartmentById(int id)
        {
            _departmentRepository.Delete(d => d.Id == id);
            _departmentRepository.SaveChanges();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
           return _departmentRepository.GetAll();
        }

       public IEnumerable<Department> GetAllDepartmentsIncludeCourses()
       {
           return _departmentRepository.GetAllDepartmentsIncludeCourses();
          // return _departmentRepository.GetAllDepartmentsLazyCourses();
       }

        public Department GetDepartmentById(int id)
        {
            var result = _departmentRepository.GetById(id);
            return result;
        }

        public IEnumerable<Department> GetDepartmentByName(string name)
        {
            var result = _departmentRepository.GetDepartmentsByName(name);
            return result;
        }

        public void UpdateDepartment(Department department)
        {
            _departmentRepository.Update(department);
            _departmentRepository.SaveChanges();
        }
    }

    public class DepartmentServiceTest : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentServiceTest(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void CreateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public IEnumerable<Department> GetAllDepartmentsIncludeCourses()
        {
            return _departmentRepository.GetAllDepartmentsIncludeCourses();
            // return _departmentRepository.GetAllDepartmentsLazyCourses();
        }

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetDepartmentByName(string name)
        {
            var result = _departmentRepository.GetDepartmentsByName(name);
            return result;
        }

        public void UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        IEnumerable<Department> GetAllDepartmentsIncludeCourses();
        IEnumerable<Department> GetDepartmentByName(string name);
        Department GetDepartmentById(int id);
        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartmentById(int id);
    }
}
