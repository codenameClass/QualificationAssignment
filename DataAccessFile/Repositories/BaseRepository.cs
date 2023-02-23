using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFile.Repositories
{
    public class BaseRepository<T>
    {
        protected Dictionary<string, T> data = new Dictionary<string, T>();

        public virtual void Add(string key, T item)
        {
            data.Add(key, item);
        }

        public virtual void Delete(string key)
        {
            var removed = data.Remove(key);

            if(removed == false)
            {
                Console.WriteLine(key);
                throw new Exception("Data not found");
                data.Count();
            }
        }

        public virtual void Update(string key, T item)
        {
            data[key] = item;
        }

        public virtual T Get(string index)
        {
            return data[index];
        }

        public virtual List<T> GetAll()
        {
            return data.Values.ToList();
        }
    }
}
