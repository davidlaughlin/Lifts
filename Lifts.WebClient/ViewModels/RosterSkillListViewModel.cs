using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class RosterSkillListViewModel
    {
        public string RosterName { get; set; }
        public IEnumerable<SkillProgressViewModel> AllSkills { get; private set; }

        public RosterSkillListViewModel(string rosterName, IEnumerable<SkillProgressViewModel> allSkills)
        {
            RosterName = rosterName;
            AllSkills = allSkills;
        }
    }
}