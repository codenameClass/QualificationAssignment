using Core.Model;
using Core.Repositories;
using DataAccessFile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFile.Repositories
{
    public class PersonFileRepository : BaseFileRepository<Person>, IPersonRepository
    {
        DataContext _context;

        public PersonFileRepository(DataContext context) {
            _context = context;
            data = _context.People;
        }

        private void SynchronizeContext()
        {
            _context.People = data;
        } 

        public async Task<Person> GetPersonAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await Task.FromResult(base.Get(id.ToString()));
        }

        public async Task<List<Person>> GetAllPeopleAsync()
        {
            return await Task.FromResult(base.GetAll());
        }

        public void AddPerson(Person person)
        {
            if(person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            base.Add(person.Id.ToString(), person);
            SynchronizeContext();
            //await SaveFileDataAsync();
        }

        public void DeletePerson(Guid id)
        {
            Delete(id.ToString());
            SynchronizeContext();
            //await SaveFileDataAsync();
        }

        public void UpdatePerson(Person person)
        {
            base.Update(person.Id.ToString(), person);
            SynchronizeContext();
            //await SaveFileDataAsync();
        }

    }
}
