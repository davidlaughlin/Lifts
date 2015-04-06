using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifts.Data.Repository;

namespace Lifts.Data
{
    public partial class Roster : IAggregateRoot
    {
        public IEnumerable<Athlete> Athletes
        {
            get { return this.RosterAthletes.Select(each => each.Athlete); }

        }
    }
}
