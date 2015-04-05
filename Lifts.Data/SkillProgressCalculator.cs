using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifts.Data.DomainModel;

namespace Lifts.Data
{
    public class SkillProgressCalculator
    {
        private IEnumerable<Skill> _skills;

        public SkillProgressCalculator(IEnumerable<Skill> skills)
        {
            _skills = skills;
        }

        public IEnumerable<SkillProgress> Calculate(Athlete athlete)
        {
            List<SkillProgress> skillProgresses = new List<SkillProgress>();
            foreach (Skill skill in _skills)
            {
                int total = 0;
                int completed = 0;
                foreach (FitnessTest fitnessTest in skill.FitnessTests)
                {
                    total++;
                    AthleteFitnessTest fitnessTestProgress = athlete.AthleteFitnessTests.FirstOrDefault(each => each.FitnessTestId == fitnessTest.Id);
                    if (fitnessTestProgress != null && fitnessTestProgress.Completed)
                    {
                        completed++;
                    }  
                }

                skillProgresses.Add(new SkillProgress(skill, total, completed));
            }

            return skillProgresses;
        }

    }
}
