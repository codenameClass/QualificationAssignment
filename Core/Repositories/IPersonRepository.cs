using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonAsync(Guid id);
        Task<List<Person>> GetAllPeopleAsync();
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Guid id);
    }
}
