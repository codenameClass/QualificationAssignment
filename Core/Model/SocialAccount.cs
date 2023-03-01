using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class SocialAccount
    {
        public SocialAccount(string type, string address)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Type cannot be null or whitespace.", nameof(type));
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address cannot be null or whitespace.", nameof(address));
            }

            Type = type;
            Address = address;
        }
        public SocialAccount() { }

        public string Type { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public static SocialAccount CreateNew(string type, string address)
        {
            return new SocialAccount(type, address);
        }
    }
}
