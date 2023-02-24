using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Person : IEntity
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<string> SocialSkills { get; set; }
        public Dictionary<string, string> SocialAccounts { get; set; }
    }
}
