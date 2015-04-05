using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifts.Data.DomainModel;
using Lifts.Data.Repository;

namespace Lifts.Data
{
    public partial class Athlete : DomainObject, IAggregateRoot
    {
        public ICollection<SkillProgress> SkillProgresses(IEnumerable<Skill> skills)
        {
            // Needs refactoring.
            List<SkillProgress> skillProgresses = new List<SkillProgress>();
            foreach (Skill skill in skills)
            {
                
                int total = 0;
                int completed = 0;
                foreach (AthleteFitnessTest fitnessTest in this.AthleteFitnessTests)
                {
                    if (fitnessTest.FitnessTest.Skill == skill)
                    {
                        total++;

                        if (fitnessTest.Completed)
                            completed++;
                    }
                }

                skillProgresses.Add(new SkillProgress(skill, total, completed));
            }

            return skillProgresses;
        }
    }
}
