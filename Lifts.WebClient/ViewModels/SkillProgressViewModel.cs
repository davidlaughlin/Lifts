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
        public string AthleteName { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Completed { get; set; }
        public int Total { get; set; }
        public double Progress { get; set; }

        public SkillProgressViewModel()
        {
            
        }

        public SkillProgressViewModel(SkillProgress skillProgress)
            :this(skillProgress.SkillId, skillProgress.SkillName, string.Empty, skillProgress.CompletedTests, skillProgress.TotalTests)
        {
            
        }


        public SkillProgressViewModel(int id, string name, string description, int completed, int total)
        {
            Id = id;
            Name = name;
            Description = description;
            Total = total;
            Completed = completed;
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