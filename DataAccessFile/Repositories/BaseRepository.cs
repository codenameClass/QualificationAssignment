using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFile.Repositories
{
    public class BaseRepository<T> where T : IEntity
    {
        protected List<T> data = new List<T>();

        public virtual void Add(T item)
        {
            data.Add(item);
        }

        public virtual void Delete(T item)
        {
            var removed = data.Remove(item);

            if(removed == false)
            {
                throw new Exception("Data not found");
            }
        }

        public virtual void Update(T item)
        {
            data[data.IndexOf(item)] = item;
        }

        public virtual T Get(Guid id)
        {
            return data.FirstOrDefault(entry => entry.Id == id);
        }

        public virtual List<T> GetAll()
        {
            return data;
        }
    }
}
