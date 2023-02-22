using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Person
    {
        public Guid Id { get; init; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public List<string> SocialSkills { get; init; }
        public Dictionary<string, string> SocialAccounts { get; init; }
    }
}
