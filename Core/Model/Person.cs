using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Person : IEntity
    {
        public Person(Guid id, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or whitespace.", nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be null or whitespace.", nameof(lastName));
            }

            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public Person() {}

        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<string> SocialSkills { get; set; } = new List<string>();
        public List<SocialAccount> SocialAccounts { get; set; } = new List<SocialAccount>();

        public static Person CreateNew(Guid id, string firstName, string lastName, List<string> socialSkills, List<SocialAccount> socialAccounts)
        {
            return new Person(id, firstName, lastName)
            {
                SocialSkills = socialSkills,
                SocialAccounts = socialAccounts,
            };
        }
    }
}
