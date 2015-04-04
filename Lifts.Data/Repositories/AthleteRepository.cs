using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifts.Data.Repository.Repositories;
using Lifts.Data.Repository.UnitsOfWork;

namespace Lifts.Data.Repositories
{
    public class AthleteRepository : Repository<Athlete>, IAthleteRepository
    {
        public AthleteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
