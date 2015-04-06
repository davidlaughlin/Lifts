using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifts.Data.DomainModel
{
    public class SkillProgress : DomainObject
    {
        public int SkillId { get; private set; }
        public string SkillName { get; private set; }
        public int TotalTests { get; set; }
        public int CompletedTests { get; set; }

        public SkillProgress(Skill skill, int totalTests, int completedTests)
        {
            SkillId = skill.Id;
            SkillName = skill.Name;
            TotalTests = totalTests;
            CompletedTests = completedTests;
        }
    }
}
