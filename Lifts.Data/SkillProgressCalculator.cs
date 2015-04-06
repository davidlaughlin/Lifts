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
            Dictionary<Skill, SkillProgress> accumulatedProgress = new Dictionary<Skill, SkillProgress>();
            this.CalculateInternal(athlete, accumulatedProgress);
            return accumulatedProgress.Values;
        }

        public IEnumerable<SkillProgress> Calculate(Roster roster)
        {
            Dictionary<Skill, SkillProgress> accumulatedProgress = new Dictionary<Skill, SkillProgress>();
            foreach (Athlete athlete in roster.Athletes)
            {
                CalculateInternal(athlete, accumulatedProgress);
            }
            return accumulatedProgress.Values;
        }

        private void CalculateInternal(Athlete athlete, Dictionary<Skill, SkillProgress> accumulatedProgress)
        {
            foreach (Skill skill in _skills)
            {
                foreach (FitnessTest fitnessTest in skill.FitnessTests)
                {
                    AthleteFitnessTest fitnessTestProgress = athlete.AthleteFitnessTests.FirstOrDefault(each => each.FitnessTestId == fitnessTest.Id);
                    if (!accumulatedProgress.ContainsKey(skill))
                    {
                        accumulatedProgress.Add(skill, new SkillProgress(skill, 0, 0));
                    }

                    if (fitnessTestProgress != null && fitnessTestProgress.Completed)
                    {
                        accumulatedProgress[skill].CompletedTests++;
                    }

                    accumulatedProgress[skill].TotalTests++;
                }
            }
        }
    }
}
