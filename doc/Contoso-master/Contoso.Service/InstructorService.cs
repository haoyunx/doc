using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Transactions;
using Contoso.Data.Repositories;
using Contoso.Model;
using Contoso.Model.Common;

namespace Contoso.Service
{
   public class InstructorService: IInstructorService
   {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IPersonRepository _personRepository;

        public InstructorService(IInstructorRepository instructorRepository, IPersonRepository personRepository)
        {
            _instructorRepository = instructorRepository;
            _personRepository = personRepository;
        }

        public IEnumerable<Instructor> GetAllInstructors(int? page, int pageSize, out int totalCount)
        {
            var instructors = _instructorRepository.GetPagedList(out totalCount, page, pageSize, null, null,
                new SortExpression<Instructor>(s => s.FirstName, ListSortDirection.Ascending));
            return instructors;
        }

        public Instructor GetInstructorById(int id)
        {
            return _instructorRepository.GetById(id);
        }

        public IEnumerable<Instructor> GetInstructorByName(string name)
        {
            return _instructorRepository.GetMany(i => i.LastName.Contains(name) || i.FirstName.Contains(name)).ToList();
        }

        public Instructor GetInstructorByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public void CreateInstructor(Instructor instructor)
        {
            _instructorRepository.Add(instructor);
            _instructorRepository.SaveChanges();
        }

        public void UpdateInstructor(Instructor instructor)
        {
            _personRepository.Update(instructor);
            _personRepository.SaveChanges();
        }

        public void DeleteInstructorById(int id)
        {
            _personRepository.Delete(i => i.Id == id);
            _personRepository.SaveChanges();
        }
    }

   public interface IInstructorService
    {
        IEnumerable<Instructor> GetAllInstructors(int? page, int pageSize, out int totalCount);
        Instructor GetInstructorById(int id);
        IEnumerable<Instructor> GetInstructorByName(string name);
        Instructor GetInstructorByCode(string employeeCode);
        void CreateInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
        void DeleteInstructorById(int id);
    }
}
