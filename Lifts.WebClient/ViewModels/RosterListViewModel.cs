using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class RosterListViewModel
    {
        public IEnumerable<RosterlViewModel> AllRosters { get; private set; }

        public RosterListViewModel(IEnumerable<RosterlViewModel> rosters)
        {
            AllRosters = rosters;
        }
    }
}