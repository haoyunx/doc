﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Model;

namespace Contoso.Data.Repositories
{
   public class DepartmentRepository: GenericRepository<Department>, IDepartmentRepository
   {
        public DepartmentRepository(ContosoDbContext context) : base(context)
        {
        }

        public IEnumerable<Department> GetAllDepartmentsIncludeCourses()
        {
            var departments = _context.Departments.Include(d => d.Courses).ToList();
            return departments;
        }

        public IEnumerable<Department> GetAllDepartmentsLazyCourses()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }

        public IEnumerable<Department> GetDepartmentsByName(string name)
        {
            var result = base.GetMany(d => d.Name == name).AsEnumerable<Department>();
            return result;
        }
    }

    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Department> GetAllDepartmentsIncludeCourses();
        IEnumerable<Department> GetAllDepartmentsLazyCourses();
        IEnumerable<Department> GetDepartmentsByName(string name);
    }
}
