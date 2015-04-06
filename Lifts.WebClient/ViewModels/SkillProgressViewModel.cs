using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lifts.Data.DomainModel;
using Microsoft.Ajax.Utilities;

namespace Lifts.WebClient.ViewModels
{
    public class SkillProgressViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Completed { get; set; }
        public int Total { get; set; }
        public double Progress { get; set; }
        public string SkillDetailLink { get; set; }

        public SkillProgressViewModel()
        {
            
        }

        public SkillProgressViewModel(int athleteId, SkillProgress skillProgress)
            :this(skillProgress.SkillId, athleteId, skillProgress.SkillName, string.Empty, skillProgress.CompletedTests, skillProgress.TotalTests)
        {
            
        }


        public SkillProgressViewModel(int id, int athleteId, string name, string description, int completed, int total)
        {
            Id = id;
            Name = name;
            Description = description;
            Total = total;
            Completed = completed;
            SkillDetailLink = "/Skills/Detail?athleteId=" + athleteId + "&name=" + name;
            if (total == 0)
            {
                Progress = 0.0;
            }
            else
            {
                Progress = Math.Floor((completed * 100.0) / total);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Description);
        }
    }
}