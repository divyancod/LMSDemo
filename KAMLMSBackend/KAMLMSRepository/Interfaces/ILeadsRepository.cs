using KAMLMSContracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMLMSRepository.Interfaces
{
    public interface ILeadsRepository
    {
        LeadsEntity AddLead(LeadsEntity leads);
        LeadsEntity GetLead(Guid id);
    }
}
