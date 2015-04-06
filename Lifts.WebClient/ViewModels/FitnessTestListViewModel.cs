using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class FitnessTestListViewModel
    {
        public string AthleteFirstName { get; private set; }
        public string AthleteLastName { get; private set; }
        public string SkillName { get; private set; }
        public IEnumerable<FitnessTestProgressViewModel> AllFitnessTests { get; private set; }

        public FitnessTestListViewModel(string skillName, string athleteFirstName, string athleteLastName, IEnumerable<FitnessTestProgressViewModel> fitnessTests)
        {
            SkillName = skillName;
            AthleteFirstName = athleteFirstName;
            AthleteLastName = athleteLastName;
            AllFitnessTests = fitnessTests;
        }
    }
}