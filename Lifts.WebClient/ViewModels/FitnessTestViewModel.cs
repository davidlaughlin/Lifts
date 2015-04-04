using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class FitnessTestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public FitnessTestViewModel()
        {
            
        }

        public FitnessTestViewModel(int id, string name, bool completed)
        {
            Id = id;
            Name = name;
            Completed = completed;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Completed);
        }
    }
}