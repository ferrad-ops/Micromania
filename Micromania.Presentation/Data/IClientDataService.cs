using Micromania.Domain;
using System.Collections.Generic;

namespace Micromania.Presentation.Data
{
    public interface IClientDataService
    {
        IEnumerable<Client> GetAll();
    }
}