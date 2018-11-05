using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class ClientDto
    {
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        

        public ClientDto(long id, string firstName, string lastName)
        {
            Id = Id;
            FirstName = firstName;
            LastName = lastName;           
        }
    }
}
