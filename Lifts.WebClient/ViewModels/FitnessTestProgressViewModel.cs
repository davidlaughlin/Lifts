using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class FitnessTestProgressViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public string SkillName { get; set; }

        public FitnessTestProgressViewModel()
        {
            
        }

        public FitnessTestProgressViewModel(int id, string skillName, string name, string description, bool completed)
        {
            Id = id;
            SkillName = skillName;
            Name = name;
            Description = description;
            Completed = completed;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Completed);
        }
    }
}