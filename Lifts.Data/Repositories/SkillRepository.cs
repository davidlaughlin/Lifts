using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifts.Data.Repository.UnitsOfWork;
using Lifts.Data.Repository.Repositories;

namespace Lifts.Data.Repositories
{
    public class SkillRepository : Repository<Skill>
    {
        public SkillRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
