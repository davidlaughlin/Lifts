using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class SkillViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }

        public SkillViewModel()
        {
            
        }

        public SkillViewModel(string name, string description, int progress)
        {
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