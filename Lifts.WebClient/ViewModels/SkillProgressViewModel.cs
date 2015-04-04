using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class SkillProgressViewModel
    {
        public string AthleteName { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }

        public SkillProgressViewModel()
        {
            
        }

        public SkillProgressViewModel(int id, string name, string description, int progress)
        {
            Id = id;
            Name = name;
            Description = description;
            Progress = progress;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Description);
        }
    }
}