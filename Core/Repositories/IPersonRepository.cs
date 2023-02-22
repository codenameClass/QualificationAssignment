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
        Person GetPerson(Guid id);
        List<Person> GetAllPeople();
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Guid id);
    }
}
