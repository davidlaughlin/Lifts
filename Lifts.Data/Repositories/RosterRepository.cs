using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifts.Data.Repository.Repositories;
using Lifts.Data.Repository.UnitsOfWork;

namespace Lifts.Data.Repositories
{
    public class RosterRepository : Repository<Roster>, IRosterRepository
    {
        public RosterRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
