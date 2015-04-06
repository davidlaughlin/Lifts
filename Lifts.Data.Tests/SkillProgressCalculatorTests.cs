using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lifts.Data.Tests
{
    [TestClass]
    public class SkillProgressCalculatorTests
    {
        [TestMethod]
        public void CalculateAthlete()
        {

            SkillProgressCalculator calculator = new SkillProgressCalculator(Skill_Data());
            calculator.Calculate(Athlete_Data());
        }

        private Athlete Athlete_Data()
        {
            Athlete athlete = new Athlete();
            athlete.FirstName = "David";
            athlete.LastName = "Laughlin";

            return athlete;
        }

        private IEnumerable<Skill> Skill_Data()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill { Name = "Strength" });
            skills.Add(new Skill { Name = "Flexibility" });

            return skills;
        }

    }
}
