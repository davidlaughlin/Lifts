using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class SkillListViewModel
    {
        public string AthleteFirstName { get; private set; }
        public string AthleteLastName { get; private set; }
        public IEnumerable<SkillProgressViewModel> AllSkills { get; private set; }
        public SkillListViewModel(string athleteFirstName, string athleteLastName, IEnumerable<SkillProgressViewModel> skills)
        {
            AthleteLastName = athleteLastName;
            AthleteFirstName = athleteFirstName;
            AllSkills = skills;
        }
    }
}