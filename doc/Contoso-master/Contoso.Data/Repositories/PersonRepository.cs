﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Model;

namespace Contoso.Data.Repositories
{
   public class PersonRepository:GenericRepository<Person>,IPersonRepository
    {
        public PersonRepository(ContosoDbContext context) : base(context)
        {
            
        }

        public override void Add(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }
    }

    public interface IPersonRepository:IRepository<Person>
    {
        
    }
}
